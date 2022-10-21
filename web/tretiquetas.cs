using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class tretiquetas : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetNextPar( );
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A40TrEtiquetas_IDTarea = (long)(NumberUtil.Val( GetNextPar( ), "."));
            n40TrEtiquetas_IDTarea = false;
            AssignAttri("", false, "A40TrEtiquetas_IDTarea", StringUtil.LTrimStr( (decimal)(A40TrEtiquetas_IDTarea), 13, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A40TrEtiquetas_IDTarea) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 16_0_10-142546", 0) ;
            }
            Form.Meta.addItem("description", "Tr Etiquetas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         GX_FocusControl = edtTrEtiquetas_ID_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         wbErr = false;
         context.SetDefaultTheme("K2BOrion");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tretiquetas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public tretiquetas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbTrEtiquetas_Estado = new GXCombobox();
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("k2bwwmasterpageorion", "GeneXus.Programs.k2bwwmasterpageorion", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbTrEtiquetas_Estado.ItemCount > 0 )
         {
            A45TrEtiquetas_Estado = (short)(NumberUtil.Val( cmbTrEtiquetas_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A45TrEtiquetas_Estado), 4, 0))), "."));
            n45TrEtiquetas_Estado = false;
            AssignAttri("", false, "A45TrEtiquetas_Estado", StringUtil.LTrimStr( (decimal)(A45TrEtiquetas_Estado), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTrEtiquetas_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A45TrEtiquetas_Estado), 4, 0));
            AssignProp("", false, cmbTrEtiquetas_Estado_Internalname, "Values", cmbTrEtiquetas_Estado.ToJavascriptSource(), true);
         }
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Container FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Tr Etiquetas", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_TrEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0060.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TRETIQUETAS_ID"+"'), id:'"+"TRETIQUETAS_ID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_TrEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrEtiquetas_ID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrEtiquetas_ID_Internalname, "Etiquetas_ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrEtiquetas_ID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41TrEtiquetas_ID), 13, 0, ".", "")), ((edtTrEtiquetas_ID_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A41TrEtiquetas_ID), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A41TrEtiquetas_ID), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrEtiquetas_ID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrEtiquetas_ID_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TrEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrEtiquetas_IDTarea_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrEtiquetas_IDTarea_Internalname, "Etiquetas_IDTarea", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrEtiquetas_IDTarea_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A40TrEtiquetas_IDTarea), 13, 0, ".", "")), ((edtTrEtiquetas_IDTarea_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A40TrEtiquetas_IDTarea), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A40TrEtiquetas_IDTarea), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrEtiquetas_IDTarea_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrEtiquetas_IDTarea_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TrEtiquetas.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (String)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_40_Internalname, sImgUrl, imgprompt_40_Link, "", "", context.GetTheme( ), imgprompt_40_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TrEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrEtiquetas_Nombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrEtiquetas_Nombre_Internalname, "Etiquetas_Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTrEtiquetas_Nombre_Internalname, StringUtil.RTrim( A42TrEtiquetas_Nombre), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", 0, 1, edtTrEtiquetas_Nombre_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "256", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_TrEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrEtiquetas_FechaCreacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrEtiquetas_FechaCreacion_Internalname, "Etiquetas_Fecha Creacion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrEtiquetas_FechaCreacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrEtiquetas_FechaCreacion_Internalname, context.localUtil.Format(A43TrEtiquetas_FechaCreacion, "99/99/9999"), context.localUtil.Format( A43TrEtiquetas_FechaCreacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrEtiquetas_FechaCreacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrEtiquetas_FechaCreacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrEtiquetas.htm");
         GxWebStd.gx_bitmap( context, edtTrEtiquetas_FechaCreacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrEtiquetas_FechaCreacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrEtiquetas.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrEtiquetas_FechaModificacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrEtiquetas_FechaModificacion_Internalname, "Etiquetas_Fecha Modificacion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrEtiquetas_FechaModificacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrEtiquetas_FechaModificacion_Internalname, context.localUtil.Format(A44TrEtiquetas_FechaModificacion, "99/99/9999"), context.localUtil.Format( A44TrEtiquetas_FechaModificacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrEtiquetas_FechaModificacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrEtiquetas_FechaModificacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrEtiquetas.htm");
         GxWebStd.gx_bitmap( context, edtTrEtiquetas_FechaModificacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrEtiquetas_FechaModificacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrEtiquetas.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbTrEtiquetas_Estado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTrEtiquetas_Estado_Internalname, "Etiquetas_Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTrEtiquetas_Estado, cmbTrEtiquetas_Estado_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A45TrEtiquetas_Estado), 4, 0)), 1, cmbTrEtiquetas_Estado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbTrEtiquetas_Estado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, "HLP_TrEtiquetas.htm");
         cmbTrEtiquetas_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A45TrEtiquetas_Estado), 4, 0));
         AssignProp("", false, cmbTrEtiquetas_Estado_Internalname, "Values", (String)(cmbTrEtiquetas_Estado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z41TrEtiquetas_ID = (long)(context.localUtil.CToN( cgiGet( "Z41TrEtiquetas_ID"), ".", ","));
            Z42TrEtiquetas_Nombre = cgiGet( "Z42TrEtiquetas_Nombre");
            n42TrEtiquetas_Nombre = (String.IsNullOrEmpty(StringUtil.RTrim( A42TrEtiquetas_Nombre)) ? true : false);
            Z43TrEtiquetas_FechaCreacion = context.localUtil.CToD( cgiGet( "Z43TrEtiquetas_FechaCreacion"), 0);
            n43TrEtiquetas_FechaCreacion = ((DateTime.MinValue==A43TrEtiquetas_FechaCreacion) ? true : false);
            Z44TrEtiquetas_FechaModificacion = context.localUtil.CToD( cgiGet( "Z44TrEtiquetas_FechaModificacion"), 0);
            n44TrEtiquetas_FechaModificacion = ((DateTime.MinValue==A44TrEtiquetas_FechaModificacion) ? true : false);
            Z45TrEtiquetas_Estado = (short)(context.localUtil.CToN( cgiGet( "Z45TrEtiquetas_Estado"), ".", ","));
            n45TrEtiquetas_Estado = ((0==A45TrEtiquetas_Estado) ? true : false);
            Z40TrEtiquetas_IDTarea = (long)(context.localUtil.CToN( cgiGet( "Z40TrEtiquetas_IDTarea"), ".", ","));
            n40TrEtiquetas_IDTarea = ((0==A40TrEtiquetas_IDTarea) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtTrEtiquetas_ID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTrEtiquetas_ID_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRETIQUETAS_ID");
               AnyError = 1;
               GX_FocusControl = edtTrEtiquetas_ID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A41TrEtiquetas_ID = 0;
               AssignAttri("", false, "A41TrEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A41TrEtiquetas_ID), 13, 0));
            }
            else
            {
               A41TrEtiquetas_ID = (long)(context.localUtil.CToN( cgiGet( edtTrEtiquetas_ID_Internalname), ".", ","));
               AssignAttri("", false, "A41TrEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A41TrEtiquetas_ID), 13, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTrEtiquetas_IDTarea_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTrEtiquetas_IDTarea_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRETIQUETAS_IDTAREA");
               AnyError = 1;
               GX_FocusControl = edtTrEtiquetas_IDTarea_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A40TrEtiquetas_IDTarea = 0;
               n40TrEtiquetas_IDTarea = false;
               AssignAttri("", false, "A40TrEtiquetas_IDTarea", StringUtil.LTrimStr( (decimal)(A40TrEtiquetas_IDTarea), 13, 0));
            }
            else
            {
               A40TrEtiquetas_IDTarea = (long)(context.localUtil.CToN( cgiGet( edtTrEtiquetas_IDTarea_Internalname), ".", ","));
               n40TrEtiquetas_IDTarea = false;
               AssignAttri("", false, "A40TrEtiquetas_IDTarea", StringUtil.LTrimStr( (decimal)(A40TrEtiquetas_IDTarea), 13, 0));
            }
            n40TrEtiquetas_IDTarea = ((0==A40TrEtiquetas_IDTarea) ? true : false);
            A42TrEtiquetas_Nombre = cgiGet( edtTrEtiquetas_Nombre_Internalname);
            n42TrEtiquetas_Nombre = false;
            AssignAttri("", false, "A42TrEtiquetas_Nombre", A42TrEtiquetas_Nombre);
            n42TrEtiquetas_Nombre = (String.IsNullOrEmpty(StringUtil.RTrim( A42TrEtiquetas_Nombre)) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrEtiquetas_FechaCreacion_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Etiquetas_Fecha Creacion"}), 1, "TRETIQUETAS_FECHACREACION");
               AnyError = 1;
               GX_FocusControl = edtTrEtiquetas_FechaCreacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A43TrEtiquetas_FechaCreacion = DateTime.MinValue;
               n43TrEtiquetas_FechaCreacion = false;
               AssignAttri("", false, "A43TrEtiquetas_FechaCreacion", context.localUtil.Format(A43TrEtiquetas_FechaCreacion, "99/99/9999"));
            }
            else
            {
               A43TrEtiquetas_FechaCreacion = context.localUtil.CToD( cgiGet( edtTrEtiquetas_FechaCreacion_Internalname), 1);
               n43TrEtiquetas_FechaCreacion = false;
               AssignAttri("", false, "A43TrEtiquetas_FechaCreacion", context.localUtil.Format(A43TrEtiquetas_FechaCreacion, "99/99/9999"));
            }
            n43TrEtiquetas_FechaCreacion = ((DateTime.MinValue==A43TrEtiquetas_FechaCreacion) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrEtiquetas_FechaModificacion_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Etiquetas_Fecha Modificacion"}), 1, "TRETIQUETAS_FECHAMODIFICACION");
               AnyError = 1;
               GX_FocusControl = edtTrEtiquetas_FechaModificacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A44TrEtiquetas_FechaModificacion = DateTime.MinValue;
               n44TrEtiquetas_FechaModificacion = false;
               AssignAttri("", false, "A44TrEtiquetas_FechaModificacion", context.localUtil.Format(A44TrEtiquetas_FechaModificacion, "99/99/9999"));
            }
            else
            {
               A44TrEtiquetas_FechaModificacion = context.localUtil.CToD( cgiGet( edtTrEtiquetas_FechaModificacion_Internalname), 1);
               n44TrEtiquetas_FechaModificacion = false;
               AssignAttri("", false, "A44TrEtiquetas_FechaModificacion", context.localUtil.Format(A44TrEtiquetas_FechaModificacion, "99/99/9999"));
            }
            n44TrEtiquetas_FechaModificacion = ((DateTime.MinValue==A44TrEtiquetas_FechaModificacion) ? true : false);
            cmbTrEtiquetas_Estado.CurrentValue = cgiGet( cmbTrEtiquetas_Estado_Internalname);
            A45TrEtiquetas_Estado = (short)(NumberUtil.Val( cgiGet( cmbTrEtiquetas_Estado_Internalname), "."));
            n45TrEtiquetas_Estado = false;
            AssignAttri("", false, "A45TrEtiquetas_Estado", StringUtil.LTrimStr( (decimal)(A45TrEtiquetas_Estado), 4, 0));
            n45TrEtiquetas_Estado = ((0==A45TrEtiquetas_Estado) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A41TrEtiquetas_ID = (long)(NumberUtil.Val( GetNextPar( ), "."));
               AssignAttri("", false, "A41TrEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A41TrEtiquetas_ID), 13, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll066( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
      }

      public override String ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes066( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption060( )
      {
      }

      protected void ZM066( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z42TrEtiquetas_Nombre = T00063_A42TrEtiquetas_Nombre[0];
               Z43TrEtiquetas_FechaCreacion = T00063_A43TrEtiquetas_FechaCreacion[0];
               Z44TrEtiquetas_FechaModificacion = T00063_A44TrEtiquetas_FechaModificacion[0];
               Z45TrEtiquetas_Estado = T00063_A45TrEtiquetas_Estado[0];
               Z40TrEtiquetas_IDTarea = T00063_A40TrEtiquetas_IDTarea[0];
            }
            else
            {
               Z42TrEtiquetas_Nombre = A42TrEtiquetas_Nombre;
               Z43TrEtiquetas_FechaCreacion = A43TrEtiquetas_FechaCreacion;
               Z44TrEtiquetas_FechaModificacion = A44TrEtiquetas_FechaModificacion;
               Z45TrEtiquetas_Estado = A45TrEtiquetas_Estado;
               Z40TrEtiquetas_IDTarea = A40TrEtiquetas_IDTarea;
            }
         }
         if ( GX_JID == -4 )
         {
            Z41TrEtiquetas_ID = A41TrEtiquetas_ID;
            Z42TrEtiquetas_Nombre = A42TrEtiquetas_Nombre;
            Z43TrEtiquetas_FechaCreacion = A43TrEtiquetas_FechaCreacion;
            Z44TrEtiquetas_FechaModificacion = A44TrEtiquetas_FechaModificacion;
            Z45TrEtiquetas_Estado = A45TrEtiquetas_Estado;
            Z40TrEtiquetas_IDTarea = A40TrEtiquetas_IDTarea;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_40_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TRETIQUETAS_IDTAREA"+"'), id:'"+"TRETIQUETAS_IDTAREA"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load066( )
      {
         /* Using cursor T00065 */
         pr_default.execute(3, new Object[] {A41TrEtiquetas_ID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound6 = 1;
            A42TrEtiquetas_Nombre = T00065_A42TrEtiquetas_Nombre[0];
            n42TrEtiquetas_Nombre = T00065_n42TrEtiquetas_Nombre[0];
            AssignAttri("", false, "A42TrEtiquetas_Nombre", A42TrEtiquetas_Nombre);
            A43TrEtiquetas_FechaCreacion = T00065_A43TrEtiquetas_FechaCreacion[0];
            n43TrEtiquetas_FechaCreacion = T00065_n43TrEtiquetas_FechaCreacion[0];
            AssignAttri("", false, "A43TrEtiquetas_FechaCreacion", context.localUtil.Format(A43TrEtiquetas_FechaCreacion, "99/99/9999"));
            A44TrEtiquetas_FechaModificacion = T00065_A44TrEtiquetas_FechaModificacion[0];
            n44TrEtiquetas_FechaModificacion = T00065_n44TrEtiquetas_FechaModificacion[0];
            AssignAttri("", false, "A44TrEtiquetas_FechaModificacion", context.localUtil.Format(A44TrEtiquetas_FechaModificacion, "99/99/9999"));
            A45TrEtiquetas_Estado = T00065_A45TrEtiquetas_Estado[0];
            n45TrEtiquetas_Estado = T00065_n45TrEtiquetas_Estado[0];
            AssignAttri("", false, "A45TrEtiquetas_Estado", StringUtil.LTrimStr( (decimal)(A45TrEtiquetas_Estado), 4, 0));
            A40TrEtiquetas_IDTarea = T00065_A40TrEtiquetas_IDTarea[0];
            n40TrEtiquetas_IDTarea = T00065_n40TrEtiquetas_IDTarea[0];
            AssignAttri("", false, "A40TrEtiquetas_IDTarea", StringUtil.LTrimStr( (decimal)(A40TrEtiquetas_IDTarea), 13, 0));
            ZM066( -4) ;
         }
         pr_default.close(3);
         OnLoadActions066( ) ;
      }

      protected void OnLoadActions066( )
      {
      }

      protected void CheckExtendedTable066( )
      {
         nIsDirty_6 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00064 */
         pr_default.execute(2, new Object[] {n40TrEtiquetas_IDTarea, A40TrEtiquetas_IDTarea});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A40TrEtiquetas_IDTarea) ) )
            {
               GX_msglist.addItem("No matching 'Tr Gestion Tareas3_STG'.", "ForeignKeyNotFound", 1, "TRETIQUETAS_IDTAREA");
               AnyError = 1;
               GX_FocusControl = edtTrEtiquetas_IDTarea_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A43TrEtiquetas_FechaCreacion) || ( A43TrEtiquetas_FechaCreacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Tr Etiquetas_Fecha Creacion is out of range", "OutOfRange", 1, "TRETIQUETAS_FECHACREACION");
            AnyError = 1;
            GX_FocusControl = edtTrEtiquetas_FechaCreacion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A44TrEtiquetas_FechaModificacion) || ( A44TrEtiquetas_FechaModificacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Tr Etiquetas_Fecha Modificacion is out of range", "OutOfRange", 1, "TRETIQUETAS_FECHAMODIFICACION");
            AnyError = 1;
            GX_FocusControl = edtTrEtiquetas_FechaModificacion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( A45TrEtiquetas_Estado == 1 ) || ( A45TrEtiquetas_Estado == 2 ) || ( A45TrEtiquetas_Estado == 3 ) || ( A45TrEtiquetas_Estado == 4 ) || ( A45TrEtiquetas_Estado == 5 ) || (0==A45TrEtiquetas_Estado) ) )
         {
            GX_msglist.addItem("Field Tr Etiquetas_Estado is out of range", "OutOfRange", 1, "TRETIQUETAS_ESTADO");
            AnyError = 1;
            GX_FocusControl = cmbTrEtiquetas_Estado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors066( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( long A40TrEtiquetas_IDTarea )
      {
         /* Using cursor T00066 */
         pr_default.execute(4, new Object[] {n40TrEtiquetas_IDTarea, A40TrEtiquetas_IDTarea});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A40TrEtiquetas_IDTarea) ) )
            {
               GX_msglist.addItem("No matching 'Tr Gestion Tareas3_STG'.", "ForeignKeyNotFound", 1, "TRETIQUETAS_IDTAREA");
               AnyError = 1;
               GX_FocusControl = edtTrEtiquetas_IDTarea_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey066( )
      {
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {A41TrEtiquetas_ID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {A41TrEtiquetas_ID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM066( 4) ;
            RcdFound6 = 1;
            A41TrEtiquetas_ID = T00063_A41TrEtiquetas_ID[0];
            AssignAttri("", false, "A41TrEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A41TrEtiquetas_ID), 13, 0));
            A42TrEtiquetas_Nombre = T00063_A42TrEtiquetas_Nombre[0];
            n42TrEtiquetas_Nombre = T00063_n42TrEtiquetas_Nombre[0];
            AssignAttri("", false, "A42TrEtiquetas_Nombre", A42TrEtiquetas_Nombre);
            A43TrEtiquetas_FechaCreacion = T00063_A43TrEtiquetas_FechaCreacion[0];
            n43TrEtiquetas_FechaCreacion = T00063_n43TrEtiquetas_FechaCreacion[0];
            AssignAttri("", false, "A43TrEtiquetas_FechaCreacion", context.localUtil.Format(A43TrEtiquetas_FechaCreacion, "99/99/9999"));
            A44TrEtiquetas_FechaModificacion = T00063_A44TrEtiquetas_FechaModificacion[0];
            n44TrEtiquetas_FechaModificacion = T00063_n44TrEtiquetas_FechaModificacion[0];
            AssignAttri("", false, "A44TrEtiquetas_FechaModificacion", context.localUtil.Format(A44TrEtiquetas_FechaModificacion, "99/99/9999"));
            A45TrEtiquetas_Estado = T00063_A45TrEtiquetas_Estado[0];
            n45TrEtiquetas_Estado = T00063_n45TrEtiquetas_Estado[0];
            AssignAttri("", false, "A45TrEtiquetas_Estado", StringUtil.LTrimStr( (decimal)(A45TrEtiquetas_Estado), 4, 0));
            A40TrEtiquetas_IDTarea = T00063_A40TrEtiquetas_IDTarea[0];
            n40TrEtiquetas_IDTarea = T00063_n40TrEtiquetas_IDTarea[0];
            AssignAttri("", false, "A40TrEtiquetas_IDTarea", StringUtil.LTrimStr( (decimal)(A40TrEtiquetas_IDTarea), 13, 0));
            Z41TrEtiquetas_ID = A41TrEtiquetas_ID;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load066( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey066( ) ;
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey066( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey066( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound6 = 0;
         /* Using cursor T00068 */
         pr_default.execute(6, new Object[] {A41TrEtiquetas_ID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00068_A41TrEtiquetas_ID[0] < A41TrEtiquetas_ID ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00068_A41TrEtiquetas_ID[0] > A41TrEtiquetas_ID ) ) )
            {
               A41TrEtiquetas_ID = T00068_A41TrEtiquetas_ID[0];
               AssignAttri("", false, "A41TrEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A41TrEtiquetas_ID), 13, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound6 = 0;
         /* Using cursor T00069 */
         pr_default.execute(7, new Object[] {A41TrEtiquetas_ID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00069_A41TrEtiquetas_ID[0] > A41TrEtiquetas_ID ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00069_A41TrEtiquetas_ID[0] < A41TrEtiquetas_ID ) ) )
            {
               A41TrEtiquetas_ID = T00069_A41TrEtiquetas_ID[0];
               AssignAttri("", false, "A41TrEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A41TrEtiquetas_ID), 13, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey066( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTrEtiquetas_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert066( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A41TrEtiquetas_ID != Z41TrEtiquetas_ID )
               {
                  A41TrEtiquetas_ID = Z41TrEtiquetas_ID;
                  AssignAttri("", false, "A41TrEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A41TrEtiquetas_ID), 13, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRETIQUETAS_ID");
                  AnyError = 1;
                  GX_FocusControl = edtTrEtiquetas_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTrEtiquetas_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update066( ) ;
                  GX_FocusControl = edtTrEtiquetas_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A41TrEtiquetas_ID != Z41TrEtiquetas_ID )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTrEtiquetas_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert066( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRETIQUETAS_ID");
                     AnyError = 1;
                     GX_FocusControl = edtTrEtiquetas_ID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTrEtiquetas_ID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert066( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A41TrEtiquetas_ID != Z41TrEtiquetas_ID )
         {
            A41TrEtiquetas_ID = Z41TrEtiquetas_ID;
            AssignAttri("", false, "A41TrEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A41TrEtiquetas_ID), 13, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRETIQUETAS_ID");
            AnyError = 1;
            GX_FocusControl = edtTrEtiquetas_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTrEtiquetas_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TRETIQUETAS_ID");
            AnyError = 1;
            GX_FocusControl = edtTrEtiquetas_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTrEtiquetas_IDTarea_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrEtiquetas_IDTarea_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd066( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrEtiquetas_IDTarea_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrEtiquetas_IDTarea_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound6 != 0 )
            {
               ScanNext066( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrEtiquetas_IDTarea_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd066( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency066( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {A41TrEtiquetas_ID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrEtiquetas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z42TrEtiquetas_Nombre, T00062_A42TrEtiquetas_Nombre[0]) != 0 ) || ( Z43TrEtiquetas_FechaCreacion != T00062_A43TrEtiquetas_FechaCreacion[0] ) || ( Z44TrEtiquetas_FechaModificacion != T00062_A44TrEtiquetas_FechaModificacion[0] ) || ( Z45TrEtiquetas_Estado != T00062_A45TrEtiquetas_Estado[0] ) || ( Z40TrEtiquetas_IDTarea != T00062_A40TrEtiquetas_IDTarea[0] ) )
            {
               if ( StringUtil.StrCmp(Z42TrEtiquetas_Nombre, T00062_A42TrEtiquetas_Nombre[0]) != 0 )
               {
                  GXUtil.WriteLog("tretiquetas:[seudo value changed for attri]"+"TrEtiquetas_Nombre");
                  GXUtil.WriteLogRaw("Old: ",Z42TrEtiquetas_Nombre);
                  GXUtil.WriteLogRaw("Current: ",T00062_A42TrEtiquetas_Nombre[0]);
               }
               if ( Z43TrEtiquetas_FechaCreacion != T00062_A43TrEtiquetas_FechaCreacion[0] )
               {
                  GXUtil.WriteLog("tretiquetas:[seudo value changed for attri]"+"TrEtiquetas_FechaCreacion");
                  GXUtil.WriteLogRaw("Old: ",Z43TrEtiquetas_FechaCreacion);
                  GXUtil.WriteLogRaw("Current: ",T00062_A43TrEtiquetas_FechaCreacion[0]);
               }
               if ( Z44TrEtiquetas_FechaModificacion != T00062_A44TrEtiquetas_FechaModificacion[0] )
               {
                  GXUtil.WriteLog("tretiquetas:[seudo value changed for attri]"+"TrEtiquetas_FechaModificacion");
                  GXUtil.WriteLogRaw("Old: ",Z44TrEtiquetas_FechaModificacion);
                  GXUtil.WriteLogRaw("Current: ",T00062_A44TrEtiquetas_FechaModificacion[0]);
               }
               if ( Z45TrEtiquetas_Estado != T00062_A45TrEtiquetas_Estado[0] )
               {
                  GXUtil.WriteLog("tretiquetas:[seudo value changed for attri]"+"TrEtiquetas_Estado");
                  GXUtil.WriteLogRaw("Old: ",Z45TrEtiquetas_Estado);
                  GXUtil.WriteLogRaw("Current: ",T00062_A45TrEtiquetas_Estado[0]);
               }
               if ( Z40TrEtiquetas_IDTarea != T00062_A40TrEtiquetas_IDTarea[0] )
               {
                  GXUtil.WriteLog("tretiquetas:[seudo value changed for attri]"+"TrEtiquetas_IDTarea");
                  GXUtil.WriteLogRaw("Old: ",Z40TrEtiquetas_IDTarea);
                  GXUtil.WriteLogRaw("Current: ",T00062_A40TrEtiquetas_IDTarea[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TrEtiquetas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM066( 0) ;
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000610 */
                     pr_default.execute(8, new Object[] {n42TrEtiquetas_Nombre, A42TrEtiquetas_Nombre, n43TrEtiquetas_FechaCreacion, A43TrEtiquetas_FechaCreacion, n44TrEtiquetas_FechaModificacion, A44TrEtiquetas_FechaModificacion, n45TrEtiquetas_Estado, A45TrEtiquetas_Estado, n40TrEtiquetas_IDTarea, A40TrEtiquetas_IDTarea});
                     A41TrEtiquetas_ID = T000610_A41TrEtiquetas_ID[0];
                     AssignAttri("", false, "A41TrEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A41TrEtiquetas_ID), 13, 0));
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("TrEtiquetas") ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           GX_msglist.addItem(context.GetMessage( "GXM_sucadded", ""), "SuccessfullyAdded", 0, "", true);
                           ResetCaption060( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load066( ) ;
            }
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void Update066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000611 */
                     pr_default.execute(9, new Object[] {n42TrEtiquetas_Nombre, A42TrEtiquetas_Nombre, n43TrEtiquetas_FechaCreacion, A43TrEtiquetas_FechaCreacion, n44TrEtiquetas_FechaModificacion, A44TrEtiquetas_FechaModificacion, n45TrEtiquetas_Estado, A45TrEtiquetas_Estado, n40TrEtiquetas_IDTarea, A40TrEtiquetas_IDTarea, A41TrEtiquetas_ID});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("TrEtiquetas") ;
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrEtiquetas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate066( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           GX_msglist.addItem(context.GetMessage( "GXM_sucupdated", ""), "SuccessfullyUpdated", 0, "", true);
                           ResetCaption060( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void DeferredUpdate066( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls066( ) ;
            AfterConfirm066( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete066( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000612 */
                  pr_default.execute(10, new Object[] {A41TrEtiquetas_ID});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("TrEtiquetas") ;
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound6 == 0 )
                        {
                           InitAll066( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        GX_msglist.addItem(context.GetMessage( "GXM_sucdeleted", ""), "SuccessfullyDeleted", 0, "", true);
                        ResetCaption060( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel066( ) ;
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls066( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000613 */
            pr_default.execute(11, new Object[] {A41TrEtiquetas_ID});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tr Tareas Etiquetas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel066( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete066( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("tretiquetas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("tretiquetas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart066( )
      {
         /* Using cursor T000614 */
         pr_default.execute(12);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound6 = 1;
            A41TrEtiquetas_ID = T000614_A41TrEtiquetas_ID[0];
            AssignAttri("", false, "A41TrEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A41TrEtiquetas_ID), 13, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext066( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound6 = 1;
            A41TrEtiquetas_ID = T000614_A41TrEtiquetas_ID[0];
            AssignAttri("", false, "A41TrEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A41TrEtiquetas_ID), 13, 0));
         }
      }

      protected void ScanEnd066( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm066( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert066( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate066( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete066( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete066( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate066( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes066( )
      {
         edtTrEtiquetas_ID_Enabled = 0;
         AssignProp("", false, edtTrEtiquetas_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrEtiquetas_ID_Enabled), 5, 0), true);
         edtTrEtiquetas_IDTarea_Enabled = 0;
         AssignProp("", false, edtTrEtiquetas_IDTarea_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrEtiquetas_IDTarea_Enabled), 5, 0), true);
         edtTrEtiquetas_Nombre_Enabled = 0;
         AssignProp("", false, edtTrEtiquetas_Nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrEtiquetas_Nombre_Enabled), 5, 0), true);
         edtTrEtiquetas_FechaCreacion_Enabled = 0;
         AssignProp("", false, edtTrEtiquetas_FechaCreacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrEtiquetas_FechaCreacion_Enabled), 5, 0), true);
         edtTrEtiquetas_FechaModificacion_Enabled = 0;
         AssignProp("", false, edtTrEtiquetas_FechaModificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrEtiquetas_FechaModificacion_Enabled), 5, 0), true);
         cmbTrEtiquetas_Estado.Enabled = 0;
         AssignProp("", false, cmbTrEtiquetas_Estado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTrEtiquetas_Estado.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes066( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues060( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 947160), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202210202185589", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle = bodyStyle + " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tretiquetas.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z41TrEtiquetas_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41TrEtiquetas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z42TrEtiquetas_Nombre", StringUtil.RTrim( Z42TrEtiquetas_Nombre));
         GxWebStd.gx_hidden_field( context, "Z43TrEtiquetas_FechaCreacion", context.localUtil.DToC( Z43TrEtiquetas_FechaCreacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z44TrEtiquetas_FechaModificacion", context.localUtil.DToC( Z44TrEtiquetas_FechaModificacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z45TrEtiquetas_Estado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z45TrEtiquetas_Estado), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z40TrEtiquetas_IDTarea", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z40TrEtiquetas_IDTarea), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("tretiquetas.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "TrEtiquetas" ;
      }

      public override String GetPgmdesc( )
      {
         return "Tr Etiquetas" ;
      }

      protected void InitializeNonKey066( )
      {
         A40TrEtiquetas_IDTarea = 0;
         n40TrEtiquetas_IDTarea = false;
         AssignAttri("", false, "A40TrEtiquetas_IDTarea", StringUtil.LTrimStr( (decimal)(A40TrEtiquetas_IDTarea), 13, 0));
         n40TrEtiquetas_IDTarea = ((0==A40TrEtiquetas_IDTarea) ? true : false);
         A42TrEtiquetas_Nombre = "";
         n42TrEtiquetas_Nombre = false;
         AssignAttri("", false, "A42TrEtiquetas_Nombre", A42TrEtiquetas_Nombre);
         n42TrEtiquetas_Nombre = (String.IsNullOrEmpty(StringUtil.RTrim( A42TrEtiquetas_Nombre)) ? true : false);
         A43TrEtiquetas_FechaCreacion = DateTime.MinValue;
         n43TrEtiquetas_FechaCreacion = false;
         AssignAttri("", false, "A43TrEtiquetas_FechaCreacion", context.localUtil.Format(A43TrEtiquetas_FechaCreacion, "99/99/9999"));
         n43TrEtiquetas_FechaCreacion = ((DateTime.MinValue==A43TrEtiquetas_FechaCreacion) ? true : false);
         A44TrEtiquetas_FechaModificacion = DateTime.MinValue;
         n44TrEtiquetas_FechaModificacion = false;
         AssignAttri("", false, "A44TrEtiquetas_FechaModificacion", context.localUtil.Format(A44TrEtiquetas_FechaModificacion, "99/99/9999"));
         n44TrEtiquetas_FechaModificacion = ((DateTime.MinValue==A44TrEtiquetas_FechaModificacion) ? true : false);
         A45TrEtiquetas_Estado = 0;
         n45TrEtiquetas_Estado = false;
         AssignAttri("", false, "A45TrEtiquetas_Estado", StringUtil.LTrimStr( (decimal)(A45TrEtiquetas_Estado), 4, 0));
         n45TrEtiquetas_Estado = ((0==A45TrEtiquetas_Estado) ? true : false);
         Z42TrEtiquetas_Nombre = "";
         Z43TrEtiquetas_FechaCreacion = DateTime.MinValue;
         Z44TrEtiquetas_FechaModificacion = DateTime.MinValue;
         Z45TrEtiquetas_Estado = 0;
         Z40TrEtiquetas_IDTarea = 0;
      }

      protected void InitAll066( )
      {
         A41TrEtiquetas_ID = 0;
         AssignAttri("", false, "A41TrEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A41TrEtiquetas_ID), 13, 0));
         InitializeNonKey066( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210202185594", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("tretiquetas.js", "?202210202185594", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         edtTrEtiquetas_ID_Internalname = "TRETIQUETAS_ID";
         edtTrEtiquetas_IDTarea_Internalname = "TRETIQUETAS_IDTAREA";
         edtTrEtiquetas_Nombre_Internalname = "TRETIQUETAS_NOMBRE";
         edtTrEtiquetas_FechaCreacion_Internalname = "TRETIQUETAS_FECHACREACION";
         edtTrEtiquetas_FechaModificacion_Internalname = "TRETIQUETAS_FECHAMODIFICACION";
         cmbTrEtiquetas_Estado_Internalname = "TRETIQUETAS_ESTADO";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Form.Internalname = "FORM";
         imgprompt_40_Internalname = "PROMPT_40";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Tr Etiquetas";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbTrEtiquetas_Estado_Jsonclick = "";
         cmbTrEtiquetas_Estado.Enabled = 1;
         edtTrEtiquetas_FechaModificacion_Jsonclick = "";
         edtTrEtiquetas_FechaModificacion_Enabled = 1;
         edtTrEtiquetas_FechaCreacion_Jsonclick = "";
         edtTrEtiquetas_FechaCreacion_Enabled = 1;
         edtTrEtiquetas_Nombre_Enabled = 1;
         imgprompt_40_Visible = 1;
         imgprompt_40_Link = "";
         edtTrEtiquetas_IDTarea_Jsonclick = "";
         edtTrEtiquetas_IDTarea_Enabled = 1;
         edtTrEtiquetas_ID_Jsonclick = "";
         edtTrEtiquetas_ID_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         cmbTrEtiquetas_Estado.Name = "TRETIQUETAS_ESTADO";
         cmbTrEtiquetas_Estado.WebTags = "";
         cmbTrEtiquetas_Estado.addItem("1", "Nuevo", 0);
         cmbTrEtiquetas_Estado.addItem("2", "En Progreso", 0);
         cmbTrEtiquetas_Estado.addItem("3", "Completado", 0);
         cmbTrEtiquetas_Estado.addItem("4", "Detenido", 0);
         cmbTrEtiquetas_Estado.addItem("5", "Pendiente", 0);
         if ( cmbTrEtiquetas_Estado.ItemCount > 0 )
         {
            A45TrEtiquetas_Estado = (short)(NumberUtil.Val( cmbTrEtiquetas_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A45TrEtiquetas_Estado), 4, 0))), "."));
            n45TrEtiquetas_Estado = false;
            AssignAttri("", false, "A45TrEtiquetas_Estado", StringUtil.LTrimStr( (decimal)(A45TrEtiquetas_Estado), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtTrEtiquetas_IDTarea_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Tretiquetas_id( )
      {
         n45TrEtiquetas_Estado = false;
         A45TrEtiquetas_Estado = (short)(NumberUtil.Val( cmbTrEtiquetas_Estado.CurrentValue, "."));
         n45TrEtiquetas_Estado = false;
         cmbTrEtiquetas_Estado.CurrentValue = StringUtil.LTrimStr( (decimal)(A45TrEtiquetas_Estado), 4, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbTrEtiquetas_Estado.ItemCount > 0 )
         {
            A45TrEtiquetas_Estado = (short)(NumberUtil.Val( cmbTrEtiquetas_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A45TrEtiquetas_Estado), 4, 0))), "."));
            n45TrEtiquetas_Estado = false;
            cmbTrEtiquetas_Estado.CurrentValue = StringUtil.LTrimStr( (decimal)(A45TrEtiquetas_Estado), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTrEtiquetas_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A45TrEtiquetas_Estado), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A40TrEtiquetas_IDTarea", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40TrEtiquetas_IDTarea), 13, 0, ".", "")));
         AssignAttri("", false, "A42TrEtiquetas_Nombre", StringUtil.RTrim( A42TrEtiquetas_Nombre));
         AssignAttri("", false, "A43TrEtiquetas_FechaCreacion", context.localUtil.Format(A43TrEtiquetas_FechaCreacion, "99/99/9999"));
         AssignAttri("", false, "A44TrEtiquetas_FechaModificacion", context.localUtil.Format(A44TrEtiquetas_FechaModificacion, "99/99/9999"));
         AssignAttri("", false, "A45TrEtiquetas_Estado", StringUtil.LTrim( StringUtil.NToC( (decimal)(A45TrEtiquetas_Estado), 4, 0, ".", "")));
         cmbTrEtiquetas_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A45TrEtiquetas_Estado), 4, 0));
         AssignProp("", false, cmbTrEtiquetas_Estado_Internalname, "Values", cmbTrEtiquetas_Estado.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z41TrEtiquetas_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41TrEtiquetas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z40TrEtiquetas_IDTarea", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z40TrEtiquetas_IDTarea), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z42TrEtiquetas_Nombre", StringUtil.RTrim( Z42TrEtiquetas_Nombre));
         GxWebStd.gx_hidden_field( context, "Z43TrEtiquetas_FechaCreacion", context.localUtil.Format(Z43TrEtiquetas_FechaCreacion, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z44TrEtiquetas_FechaModificacion", context.localUtil.Format(Z44TrEtiquetas_FechaModificacion, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z45TrEtiquetas_Estado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z45TrEtiquetas_Estado), 4, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Tretiquetas_idtarea( )
      {
         n40TrEtiquetas_IDTarea = false;
         /* Using cursor T000615 */
         pr_default.execute(13, new Object[] {n40TrEtiquetas_IDTarea, A40TrEtiquetas_IDTarea});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A40TrEtiquetas_IDTarea) ) )
            {
               GX_msglist.addItem("No matching 'Tr Gestion Tareas3_STG'.", "ForeignKeyNotFound", 1, "TRETIQUETAS_IDTAREA");
               AnyError = 1;
               GX_FocusControl = edtTrEtiquetas_IDTarea_Internalname;
            }
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_TRETIQUETAS_ID","{handler:'Valid_Tretiquetas_id',iparms:[{av:'cmbTrEtiquetas_Estado'},{av:'A45TrEtiquetas_Estado',fld:'TRETIQUETAS_ESTADO',pic:'ZZZ9'},{av:'A41TrEtiquetas_ID',fld:'TRETIQUETAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TRETIQUETAS_ID",",oparms:[{av:'A40TrEtiquetas_IDTarea',fld:'TRETIQUETAS_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'A42TrEtiquetas_Nombre',fld:'TRETIQUETAS_NOMBRE',pic:''},{av:'A43TrEtiquetas_FechaCreacion',fld:'TRETIQUETAS_FECHACREACION',pic:''},{av:'A44TrEtiquetas_FechaModificacion',fld:'TRETIQUETAS_FECHAMODIFICACION',pic:''},{av:'cmbTrEtiquetas_Estado'},{av:'A45TrEtiquetas_Estado',fld:'TRETIQUETAS_ESTADO',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z41TrEtiquetas_ID'},{av:'Z40TrEtiquetas_IDTarea'},{av:'Z42TrEtiquetas_Nombre'},{av:'Z43TrEtiquetas_FechaCreacion'},{av:'Z44TrEtiquetas_FechaModificacion'},{av:'Z45TrEtiquetas_Estado'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_TRETIQUETAS_IDTAREA","{handler:'Valid_Tretiquetas_idtarea',iparms:[{av:'A40TrEtiquetas_IDTarea',fld:'TRETIQUETAS_IDTAREA',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("VALID_TRETIQUETAS_IDTAREA",",oparms:[]}");
         setEventMetadata("VALID_TRETIQUETAS_FECHACREACION","{handler:'Valid_Tretiquetas_fechacreacion',iparms:[]");
         setEventMetadata("VALID_TRETIQUETAS_FECHACREACION",",oparms:[]}");
         setEventMetadata("VALID_TRETIQUETAS_FECHAMODIFICACION","{handler:'Valid_Tretiquetas_fechamodificacion',iparms:[]");
         setEventMetadata("VALID_TRETIQUETAS_FECHAMODIFICACION",",oparms:[]}");
         setEventMetadata("VALID_TRETIQUETAS_ESTADO","{handler:'Valid_Tretiquetas_estado',iparms:[]");
         setEventMetadata("VALID_TRETIQUETAS_ESTADO",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections() ;
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z42TrEtiquetas_Nombre = "";
         Z43TrEtiquetas_FechaCreacion = DateTime.MinValue;
         Z44TrEtiquetas_FechaModificacion = DateTime.MinValue;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         sImgUrl = "";
         A42TrEtiquetas_Nombre = "";
         A43TrEtiquetas_FechaCreacion = DateTime.MinValue;
         A44TrEtiquetas_FechaModificacion = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         T00065_A41TrEtiquetas_ID = new long[1] ;
         T00065_A42TrEtiquetas_Nombre = new String[] {""} ;
         T00065_n42TrEtiquetas_Nombre = new bool[] {false} ;
         T00065_A43TrEtiquetas_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00065_n43TrEtiquetas_FechaCreacion = new bool[] {false} ;
         T00065_A44TrEtiquetas_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00065_n44TrEtiquetas_FechaModificacion = new bool[] {false} ;
         T00065_A45TrEtiquetas_Estado = new short[1] ;
         T00065_n45TrEtiquetas_Estado = new bool[] {false} ;
         T00065_A40TrEtiquetas_IDTarea = new long[1] ;
         T00065_n40TrEtiquetas_IDTarea = new bool[] {false} ;
         T00064_A40TrEtiquetas_IDTarea = new long[1] ;
         T00064_n40TrEtiquetas_IDTarea = new bool[] {false} ;
         T00066_A40TrEtiquetas_IDTarea = new long[1] ;
         T00066_n40TrEtiquetas_IDTarea = new bool[] {false} ;
         T00067_A41TrEtiquetas_ID = new long[1] ;
         T00063_A41TrEtiquetas_ID = new long[1] ;
         T00063_A42TrEtiquetas_Nombre = new String[] {""} ;
         T00063_n42TrEtiquetas_Nombre = new bool[] {false} ;
         T00063_A43TrEtiquetas_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00063_n43TrEtiquetas_FechaCreacion = new bool[] {false} ;
         T00063_A44TrEtiquetas_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00063_n44TrEtiquetas_FechaModificacion = new bool[] {false} ;
         T00063_A45TrEtiquetas_Estado = new short[1] ;
         T00063_n45TrEtiquetas_Estado = new bool[] {false} ;
         T00063_A40TrEtiquetas_IDTarea = new long[1] ;
         T00063_n40TrEtiquetas_IDTarea = new bool[] {false} ;
         sMode6 = "";
         T00068_A41TrEtiquetas_ID = new long[1] ;
         T00069_A41TrEtiquetas_ID = new long[1] ;
         T00062_A41TrEtiquetas_ID = new long[1] ;
         T00062_A42TrEtiquetas_Nombre = new String[] {""} ;
         T00062_n42TrEtiquetas_Nombre = new bool[] {false} ;
         T00062_A43TrEtiquetas_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00062_n43TrEtiquetas_FechaCreacion = new bool[] {false} ;
         T00062_A44TrEtiquetas_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00062_n44TrEtiquetas_FechaModificacion = new bool[] {false} ;
         T00062_A45TrEtiquetas_Estado = new short[1] ;
         T00062_n45TrEtiquetas_Estado = new bool[] {false} ;
         T00062_A40TrEtiquetas_IDTarea = new long[1] ;
         T00062_n40TrEtiquetas_IDTarea = new bool[] {false} ;
         T000610_A41TrEtiquetas_ID = new long[1] ;
         T000613_A51TrTareasEtiquetas_ID = new long[1] ;
         T000614_A41TrEtiquetas_ID = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ42TrEtiquetas_Nombre = "";
         ZZ43TrEtiquetas_FechaCreacion = DateTime.MinValue;
         ZZ44TrEtiquetas_FechaModificacion = DateTime.MinValue;
         T000615_A40TrEtiquetas_IDTarea = new long[1] ;
         T000615_n40TrEtiquetas_IDTarea = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tretiquetas__default(),
            new Object[][] {
                new Object[] {
               T00062_A41TrEtiquetas_ID, T00062_A42TrEtiquetas_Nombre, T00062_n42TrEtiquetas_Nombre, T00062_A43TrEtiquetas_FechaCreacion, T00062_n43TrEtiquetas_FechaCreacion, T00062_A44TrEtiquetas_FechaModificacion, T00062_n44TrEtiquetas_FechaModificacion, T00062_A45TrEtiquetas_Estado, T00062_n45TrEtiquetas_Estado, T00062_A40TrEtiquetas_IDTarea,
               T00062_n40TrEtiquetas_IDTarea
               }
               , new Object[] {
               T00063_A41TrEtiquetas_ID, T00063_A42TrEtiquetas_Nombre, T00063_n42TrEtiquetas_Nombre, T00063_A43TrEtiquetas_FechaCreacion, T00063_n43TrEtiquetas_FechaCreacion, T00063_A44TrEtiquetas_FechaModificacion, T00063_n44TrEtiquetas_FechaModificacion, T00063_A45TrEtiquetas_Estado, T00063_n45TrEtiquetas_Estado, T00063_A40TrEtiquetas_IDTarea,
               T00063_n40TrEtiquetas_IDTarea
               }
               , new Object[] {
               T00064_A40TrEtiquetas_IDTarea
               }
               , new Object[] {
               T00065_A41TrEtiquetas_ID, T00065_A42TrEtiquetas_Nombre, T00065_n42TrEtiquetas_Nombre, T00065_A43TrEtiquetas_FechaCreacion, T00065_n43TrEtiquetas_FechaCreacion, T00065_A44TrEtiquetas_FechaModificacion, T00065_n44TrEtiquetas_FechaModificacion, T00065_A45TrEtiquetas_Estado, T00065_n45TrEtiquetas_Estado, T00065_A40TrEtiquetas_IDTarea,
               T00065_n40TrEtiquetas_IDTarea
               }
               , new Object[] {
               T00066_A40TrEtiquetas_IDTarea
               }
               , new Object[] {
               T00067_A41TrEtiquetas_ID
               }
               , new Object[] {
               T00068_A41TrEtiquetas_ID
               }
               , new Object[] {
               T00069_A41TrEtiquetas_ID
               }
               , new Object[] {
               T000610_A41TrEtiquetas_ID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000613_A51TrTareasEtiquetas_ID
               }
               , new Object[] {
               T000614_A41TrEtiquetas_ID
               }
               , new Object[] {
               T000615_A40TrEtiquetas_IDTarea
               }
            }
         );
      }

      private short Z45TrEtiquetas_Estado ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A45TrEtiquetas_Estado ;
      private short GX_JID ;
      private short RcdFound6 ;
      private short nIsDirty_6 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ45TrEtiquetas_Estado ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTrEtiquetas_ID_Enabled ;
      private int edtTrEtiquetas_IDTarea_Enabled ;
      private int imgprompt_40_Visible ;
      private int edtTrEtiquetas_Nombre_Enabled ;
      private int edtTrEtiquetas_FechaCreacion_Enabled ;
      private int edtTrEtiquetas_FechaModificacion_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z41TrEtiquetas_ID ;
      private long Z40TrEtiquetas_IDTarea ;
      private long A40TrEtiquetas_IDTarea ;
      private long A41TrEtiquetas_ID ;
      private long ZZ41TrEtiquetas_ID ;
      private long ZZ40TrEtiquetas_IDTarea ;
      private String sPrefix ;
      private String Z42TrEtiquetas_Nombre ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String GXKey ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtTrEtiquetas_ID_Internalname ;
      private String cmbTrEtiquetas_Estado_Internalname ;
      private String divTablemain_Internalname ;
      private String lblTitle_Internalname ;
      private String lblTitle_Jsonclick ;
      private String TempTags ;
      private String ClassString ;
      private String StyleString ;
      private String bttBtn_first_Internalname ;
      private String bttBtn_first_Jsonclick ;
      private String bttBtn_previous_Internalname ;
      private String bttBtn_previous_Jsonclick ;
      private String bttBtn_next_Internalname ;
      private String bttBtn_next_Jsonclick ;
      private String bttBtn_last_Internalname ;
      private String bttBtn_last_Jsonclick ;
      private String bttBtn_select_Internalname ;
      private String bttBtn_select_Jsonclick ;
      private String edtTrEtiquetas_ID_Jsonclick ;
      private String edtTrEtiquetas_IDTarea_Internalname ;
      private String edtTrEtiquetas_IDTarea_Jsonclick ;
      private String sImgUrl ;
      private String imgprompt_40_Internalname ;
      private String imgprompt_40_Link ;
      private String edtTrEtiquetas_Nombre_Internalname ;
      private String A42TrEtiquetas_Nombre ;
      private String edtTrEtiquetas_FechaCreacion_Internalname ;
      private String edtTrEtiquetas_FechaCreacion_Jsonclick ;
      private String edtTrEtiquetas_FechaModificacion_Internalname ;
      private String edtTrEtiquetas_FechaModificacion_Jsonclick ;
      private String cmbTrEtiquetas_Estado_Jsonclick ;
      private String bttBtn_enter_Internalname ;
      private String bttBtn_enter_Jsonclick ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String bttBtn_delete_Internalname ;
      private String bttBtn_delete_Jsonclick ;
      private String Gx_mode ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String sMode6 ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String ZZ42TrEtiquetas_Nombre ;
      private DateTime Z43TrEtiquetas_FechaCreacion ;
      private DateTime Z44TrEtiquetas_FechaModificacion ;
      private DateTime A43TrEtiquetas_FechaCreacion ;
      private DateTime A44TrEtiquetas_FechaModificacion ;
      private DateTime ZZ43TrEtiquetas_FechaCreacion ;
      private DateTime ZZ44TrEtiquetas_FechaModificacion ;
      private bool entryPointCalled ;
      private bool n40TrEtiquetas_IDTarea ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n45TrEtiquetas_Estado ;
      private bool n42TrEtiquetas_Nombre ;
      private bool n43TrEtiquetas_FechaCreacion ;
      private bool n44TrEtiquetas_FechaModificacion ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTrEtiquetas_Estado ;
      private IDataStoreProvider pr_default ;
      private long[] T00065_A41TrEtiquetas_ID ;
      private String[] T00065_A42TrEtiquetas_Nombre ;
      private bool[] T00065_n42TrEtiquetas_Nombre ;
      private DateTime[] T00065_A43TrEtiquetas_FechaCreacion ;
      private bool[] T00065_n43TrEtiquetas_FechaCreacion ;
      private DateTime[] T00065_A44TrEtiquetas_FechaModificacion ;
      private bool[] T00065_n44TrEtiquetas_FechaModificacion ;
      private short[] T00065_A45TrEtiquetas_Estado ;
      private bool[] T00065_n45TrEtiquetas_Estado ;
      private long[] T00065_A40TrEtiquetas_IDTarea ;
      private bool[] T00065_n40TrEtiquetas_IDTarea ;
      private long[] T00064_A40TrEtiquetas_IDTarea ;
      private bool[] T00064_n40TrEtiquetas_IDTarea ;
      private long[] T00066_A40TrEtiquetas_IDTarea ;
      private bool[] T00066_n40TrEtiquetas_IDTarea ;
      private long[] T00067_A41TrEtiquetas_ID ;
      private long[] T00063_A41TrEtiquetas_ID ;
      private String[] T00063_A42TrEtiquetas_Nombre ;
      private bool[] T00063_n42TrEtiquetas_Nombre ;
      private DateTime[] T00063_A43TrEtiquetas_FechaCreacion ;
      private bool[] T00063_n43TrEtiquetas_FechaCreacion ;
      private DateTime[] T00063_A44TrEtiquetas_FechaModificacion ;
      private bool[] T00063_n44TrEtiquetas_FechaModificacion ;
      private short[] T00063_A45TrEtiquetas_Estado ;
      private bool[] T00063_n45TrEtiquetas_Estado ;
      private long[] T00063_A40TrEtiquetas_IDTarea ;
      private bool[] T00063_n40TrEtiquetas_IDTarea ;
      private long[] T00068_A41TrEtiquetas_ID ;
      private long[] T00069_A41TrEtiquetas_ID ;
      private long[] T00062_A41TrEtiquetas_ID ;
      private String[] T00062_A42TrEtiquetas_Nombre ;
      private bool[] T00062_n42TrEtiquetas_Nombre ;
      private DateTime[] T00062_A43TrEtiquetas_FechaCreacion ;
      private bool[] T00062_n43TrEtiquetas_FechaCreacion ;
      private DateTime[] T00062_A44TrEtiquetas_FechaModificacion ;
      private bool[] T00062_n44TrEtiquetas_FechaModificacion ;
      private short[] T00062_A45TrEtiquetas_Estado ;
      private bool[] T00062_n45TrEtiquetas_Estado ;
      private long[] T00062_A40TrEtiquetas_IDTarea ;
      private bool[] T00062_n40TrEtiquetas_IDTarea ;
      private long[] T000610_A41TrEtiquetas_ID ;
      private long[] T000613_A51TrTareasEtiquetas_ID ;
      private long[] T000614_A41TrEtiquetas_ID ;
      private long[] T000615_A40TrEtiquetas_IDTarea ;
      private bool[] T000615_n40TrEtiquetas_IDTarea ;
      private GXWebForm Form ;
   }

   public class tretiquetas__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00065 ;
          prmT00065 = new Object[] {
          new Object[] {"@TrEtiquetas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00064 ;
          prmT00064 = new Object[] {
          new Object[] {"@TrEtiquetas_IDTarea",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00066 ;
          prmT00066 = new Object[] {
          new Object[] {"@TrEtiquetas_IDTarea",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00067 ;
          prmT00067 = new Object[] {
          new Object[] {"@TrEtiquetas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00063 ;
          prmT00063 = new Object[] {
          new Object[] {"@TrEtiquetas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00068 ;
          prmT00068 = new Object[] {
          new Object[] {"@TrEtiquetas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00069 ;
          prmT00069 = new Object[] {
          new Object[] {"@TrEtiquetas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00062 ;
          prmT00062 = new Object[] {
          new Object[] {"@TrEtiquetas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000610 ;
          prmT000610 = new Object[] {
          new Object[] {"@TrEtiquetas_Nombre",SqlDbType.NChar,256,0} ,
          new Object[] {"@TrEtiquetas_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrEtiquetas_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrEtiquetas_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrEtiquetas_IDTarea",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000611 ;
          prmT000611 = new Object[] {
          new Object[] {"@TrEtiquetas_Nombre",SqlDbType.NChar,256,0} ,
          new Object[] {"@TrEtiquetas_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrEtiquetas_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrEtiquetas_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrEtiquetas_IDTarea",SqlDbType.Decimal,13,0} ,
          new Object[] {"@TrEtiquetas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000612 ;
          prmT000612 = new Object[] {
          new Object[] {"@TrEtiquetas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000613 ;
          prmT000613 = new Object[] {
          new Object[] {"@TrEtiquetas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000614 ;
          prmT000614 = new Object[] {
          } ;
          Object[] prmT000615 ;
          prmT000615 = new Object[] {
          new Object[] {"@TrEtiquetas_IDTarea",SqlDbType.Decimal,13,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T00062", "SELECT [TrEtiquetas_ID], [TrEtiquetas_Nombre], [TrEtiquetas_FechaCreacion], [TrEtiquetas_FechaModificacion], [TrEtiquetas_Estado], [TrEtiquetas_IDTarea] AS TrEtiquetas_IDTarea FROM TABLERO.[TrEtiquetas] WITH (UPDLOCK) WHERE [TrEtiquetas_ID] = @TrEtiquetas_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00063", "SELECT [TrEtiquetas_ID], [TrEtiquetas_Nombre], [TrEtiquetas_FechaCreacion], [TrEtiquetas_FechaModificacion], [TrEtiquetas_Estado], [TrEtiquetas_IDTarea] AS TrEtiquetas_IDTarea FROM TABLERO.[TrEtiquetas] WHERE [TrEtiquetas_ID] = @TrEtiquetas_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00064", "SELECT [TrGestionTareas_ID] AS TrEtiquetas_IDTarea FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_ID] = @TrEtiquetas_IDTarea ",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00065", "SELECT TM1.[TrEtiquetas_ID], TM1.[TrEtiquetas_Nombre], TM1.[TrEtiquetas_FechaCreacion], TM1.[TrEtiquetas_FechaModificacion], TM1.[TrEtiquetas_Estado], TM1.[TrEtiquetas_IDTarea] AS TrEtiquetas_IDTarea FROM TABLERO.[TrEtiquetas] TM1 WHERE TM1.[TrEtiquetas_ID] = @TrEtiquetas_ID ORDER BY TM1.[TrEtiquetas_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00066", "SELECT [TrGestionTareas_ID] AS TrEtiquetas_IDTarea FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_ID] = @TrEtiquetas_IDTarea ",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00067", "SELECT [TrEtiquetas_ID] FROM TABLERO.[TrEtiquetas] WHERE [TrEtiquetas_ID] = @TrEtiquetas_ID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00068", "SELECT TOP 1 [TrEtiquetas_ID] FROM TABLERO.[TrEtiquetas] WHERE ( [TrEtiquetas_ID] > @TrEtiquetas_ID) ORDER BY [TrEtiquetas_ID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00068,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00069", "SELECT TOP 1 [TrEtiquetas_ID] FROM TABLERO.[TrEtiquetas] WHERE ( [TrEtiquetas_ID] < @TrEtiquetas_ID) ORDER BY [TrEtiquetas_ID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00069,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000610", "INSERT INTO TABLERO.[TrEtiquetas]([TrEtiquetas_Nombre], [TrEtiquetas_FechaCreacion], [TrEtiquetas_FechaModificacion], [TrEtiquetas_Estado], [TrEtiquetas_IDTarea]) VALUES(@TrEtiquetas_Nombre, @TrEtiquetas_FechaCreacion, @TrEtiquetas_FechaModificacion, @TrEtiquetas_Estado, @TrEtiquetas_IDTarea); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000610)
             ,new CursorDef("T000611", "UPDATE TABLERO.[TrEtiquetas] SET [TrEtiquetas_Nombre]=@TrEtiquetas_Nombre, [TrEtiquetas_FechaCreacion]=@TrEtiquetas_FechaCreacion, [TrEtiquetas_FechaModificacion]=@TrEtiquetas_FechaModificacion, [TrEtiquetas_Estado]=@TrEtiquetas_Estado, [TrEtiquetas_IDTarea]=@TrEtiquetas_IDTarea  WHERE [TrEtiquetas_ID] = @TrEtiquetas_ID", GxErrorMask.GX_NOMASK,prmT000611)
             ,new CursorDef("T000612", "DELETE FROM TABLERO.[TrEtiquetas]  WHERE [TrEtiquetas_ID] = @TrEtiquetas_ID", GxErrorMask.GX_NOMASK,prmT000612)
             ,new CursorDef("T000613", "SELECT TOP 1 [TrTareasEtiquetas_ID] FROM TABLERO.[TrTareasEtiquetas] WHERE [TrTareasEtiquetas_IDEtiqueta] = @TrEtiquetas_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000613,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000614", "SELECT [TrEtiquetas_ID] FROM TABLERO.[TrEtiquetas] ORDER BY [TrEtiquetas_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000614,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000615", "SELECT [TrGestionTareas_ID] AS TrEtiquetas_IDTarea FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_ID] = @TrEtiquetas_IDTarea ",true, GxErrorMask.GX_NOMASK, false, this,prmT000615,1, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 256) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((long[]) buf[9])[0] = rslt.getLong(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 256) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((long[]) buf[9])[0] = rslt.getLong(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 256) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((long[]) buf[9])[0] = rslt.getLong(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 8 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 11 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 12 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 13 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
             case 0 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 1 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 2 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Decimal );
                }
                else
                {
                   stmt.SetParameter(1, (long)parms[1]);
                }
                return;
             case 3 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 4 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Decimal );
                }
                else
                {
                   stmt.SetParameter(1, (long)parms[1]);
                }
                return;
             case 5 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 6 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 7 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 8 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.NChar );
                }
                else
                {
                   stmt.SetParameter(1, (String)parms[1]);
                }
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 2 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(2, (DateTime)parms[3]);
                }
                if ( (bool)parms[4] )
                {
                   stmt.setNull( 3 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(3, (DateTime)parms[5]);
                }
                if ( (bool)parms[6] )
                {
                   stmt.setNull( 4 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(4, (short)parms[7]);
                }
                if ( (bool)parms[8] )
                {
                   stmt.setNull( 5 , SqlDbType.Decimal );
                }
                else
                {
                   stmt.SetParameter(5, (long)parms[9]);
                }
                return;
             case 9 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.NChar );
                }
                else
                {
                   stmt.SetParameter(1, (String)parms[1]);
                }
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 2 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(2, (DateTime)parms[3]);
                }
                if ( (bool)parms[4] )
                {
                   stmt.setNull( 3 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(3, (DateTime)parms[5]);
                }
                if ( (bool)parms[6] )
                {
                   stmt.setNull( 4 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(4, (short)parms[7]);
                }
                if ( (bool)parms[8] )
                {
                   stmt.setNull( 5 , SqlDbType.Decimal );
                }
                else
                {
                   stmt.SetParameter(5, (long)parms[9]);
                }
                stmt.SetParameter(6, (long)parms[10]);
                return;
             case 10 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 11 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 13 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Decimal );
                }
                else
                {
                   stmt.SetParameter(1, (long)parms[1]);
                }
                return;
       }
    }

 }

}
