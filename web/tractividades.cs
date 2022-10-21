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
   public class tractividades : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A25TrActividades_IDTarea = (long)(NumberUtil.Val( GetNextPar( ), "."));
            n25TrActividades_IDTarea = false;
            AssignAttri("", false, "A25TrActividades_IDTarea", StringUtil.LTrimStr( (decimal)(A25TrActividades_IDTarea), 13, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A25TrActividades_IDTarea) ;
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
            Form.Meta.addItem("description", "Tr Actividades", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         GX_FocusControl = edtTrActividades_ID_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         wbErr = false;
         context.SetDefaultTheme("K2BOrion");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tractividades( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public tractividades( IGxContext context )
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
         cmbTrActividades_Estado = new GXCombobox();
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
         if ( cmbTrActividades_Estado.ItemCount > 0 )
         {
            A33TrActividades_Estado = (short)(NumberUtil.Val( cmbTrActividades_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A33TrActividades_Estado), 4, 0))), "."));
            n33TrActividades_Estado = false;
            AssignAttri("", false, "A33TrActividades_Estado", StringUtil.LTrimStr( (decimal)(A33TrActividades_Estado), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTrActividades_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A33TrActividades_Estado), 4, 0));
            AssignProp("", false, cmbTrActividades_Estado_Internalname, "Values", cmbTrActividades_Estado.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Tr Actividades", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_TrActividades.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrActividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrActividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrActividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrActividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TRACTIVIDADES_ID"+"'), id:'"+"TRACTIVIDADES_ID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_TrActividades.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrActividades_ID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrActividades_ID_Internalname, "Actividades_ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrActividades_ID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A26TrActividades_ID), 13, 0, ".", "")), ((edtTrActividades_ID_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A26TrActividades_ID), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A26TrActividades_ID), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrActividades_ID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrActividades_ID_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TrActividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrActividades_IDTarea_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrActividades_IDTarea_Internalname, "Actividades_IDTarea", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrActividades_IDTarea_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A25TrActividades_IDTarea), 13, 0, ".", "")), ((edtTrActividades_IDTarea_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A25TrActividades_IDTarea), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A25TrActividades_IDTarea), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrActividades_IDTarea_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrActividades_IDTarea_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TrActividades.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (String)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_25_Internalname, sImgUrl, imgprompt_25_Link, "", "", context.GetTheme( ), imgprompt_25_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TrActividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrActividades_Nombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrActividades_Nombre_Internalname, "Actividades_Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrActividades_Nombre_Internalname, StringUtil.RTrim( A27TrActividades_Nombre), StringUtil.RTrim( context.localUtil.Format( A27TrActividades_Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrActividades_Nombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrActividades_Nombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TrActividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrActividades_Descripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrActividades_Descripcion_Internalname, "Actividades_Descripcion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTrActividades_Descripcion_Internalname, A28TrActividades_Descripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", 0, 1, edtTrActividades_Descripcion_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_TrActividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrActividades_FechaInicio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrActividades_FechaInicio_Internalname, "Actividades_Fecha Inicio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrActividades_FechaInicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrActividades_FechaInicio_Internalname, context.localUtil.Format(A29TrActividades_FechaInicio, "99/99/9999"), context.localUtil.Format( A29TrActividades_FechaInicio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrActividades_FechaInicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrActividades_FechaInicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrActividades.htm");
         GxWebStd.gx_bitmap( context, edtTrActividades_FechaInicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrActividades_FechaInicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrActividades.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrActividades_FechaFin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrActividades_FechaFin_Internalname, "Actividades_Fecha Fin", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrActividades_FechaFin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrActividades_FechaFin_Internalname, context.localUtil.Format(A30TrActividades_FechaFin, "99/99/9999"), context.localUtil.Format( A30TrActividades_FechaFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrActividades_FechaFin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrActividades_FechaFin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrActividades.htm");
         GxWebStd.gx_bitmap( context, edtTrActividades_FechaFin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrActividades_FechaFin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrActividades.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrActividades_FechaCreacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrActividades_FechaCreacion_Internalname, "Actividades_Fecha Creacion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrActividades_FechaCreacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrActividades_FechaCreacion_Internalname, context.localUtil.Format(A31TrActividades_FechaCreacion, "99/99/9999"), context.localUtil.Format( A31TrActividades_FechaCreacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrActividades_FechaCreacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrActividades_FechaCreacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrActividades.htm");
         GxWebStd.gx_bitmap( context, edtTrActividades_FechaCreacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrActividades_FechaCreacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrActividades.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrActividades_FechaModificacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrActividades_FechaModificacion_Internalname, "Actividades_Fecha Modificacion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrActividades_FechaModificacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrActividades_FechaModificacion_Internalname, context.localUtil.Format(A32TrActividades_FechaModificacion, "99/99/9999"), context.localUtil.Format( A32TrActividades_FechaModificacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrActividades_FechaModificacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrActividades_FechaModificacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrActividades.htm");
         GxWebStd.gx_bitmap( context, edtTrActividades_FechaModificacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrActividades_FechaModificacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrActividades.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbTrActividades_Estado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTrActividades_Estado_Internalname, "Actividades_Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTrActividades_Estado, cmbTrActividades_Estado_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A33TrActividades_Estado), 4, 0)), 1, cmbTrActividades_Estado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbTrActividades_Estado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, "HLP_TrActividades.htm");
         cmbTrActividades_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A33TrActividades_Estado), 4, 0));
         AssignProp("", false, cmbTrActividades_Estado_Internalname, "Values", (String)(cmbTrActividades_Estado.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrActividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrActividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrActividades.htm");
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
            Z26TrActividades_ID = (long)(context.localUtil.CToN( cgiGet( "Z26TrActividades_ID"), ".", ","));
            Z27TrActividades_Nombre = cgiGet( "Z27TrActividades_Nombre");
            n27TrActividades_Nombre = (String.IsNullOrEmpty(StringUtil.RTrim( A27TrActividades_Nombre)) ? true : false);
            Z29TrActividades_FechaInicio = context.localUtil.CToD( cgiGet( "Z29TrActividades_FechaInicio"), 0);
            n29TrActividades_FechaInicio = ((DateTime.MinValue==A29TrActividades_FechaInicio) ? true : false);
            Z30TrActividades_FechaFin = context.localUtil.CToD( cgiGet( "Z30TrActividades_FechaFin"), 0);
            n30TrActividades_FechaFin = ((DateTime.MinValue==A30TrActividades_FechaFin) ? true : false);
            Z31TrActividades_FechaCreacion = context.localUtil.CToD( cgiGet( "Z31TrActividades_FechaCreacion"), 0);
            n31TrActividades_FechaCreacion = ((DateTime.MinValue==A31TrActividades_FechaCreacion) ? true : false);
            Z32TrActividades_FechaModificacion = context.localUtil.CToD( cgiGet( "Z32TrActividades_FechaModificacion"), 0);
            n32TrActividades_FechaModificacion = ((DateTime.MinValue==A32TrActividades_FechaModificacion) ? true : false);
            Z33TrActividades_Estado = (short)(context.localUtil.CToN( cgiGet( "Z33TrActividades_Estado"), ".", ","));
            n33TrActividades_Estado = ((0==A33TrActividades_Estado) ? true : false);
            Z25TrActividades_IDTarea = (long)(context.localUtil.CToN( cgiGet( "Z25TrActividades_IDTarea"), ".", ","));
            n25TrActividades_IDTarea = ((0==A25TrActividades_IDTarea) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtTrActividades_ID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTrActividades_ID_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRACTIVIDADES_ID");
               AnyError = 1;
               GX_FocusControl = edtTrActividades_ID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A26TrActividades_ID = 0;
               AssignAttri("", false, "A26TrActividades_ID", StringUtil.LTrimStr( (decimal)(A26TrActividades_ID), 13, 0));
            }
            else
            {
               A26TrActividades_ID = (long)(context.localUtil.CToN( cgiGet( edtTrActividades_ID_Internalname), ".", ","));
               AssignAttri("", false, "A26TrActividades_ID", StringUtil.LTrimStr( (decimal)(A26TrActividades_ID), 13, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTrActividades_IDTarea_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTrActividades_IDTarea_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRACTIVIDADES_IDTAREA");
               AnyError = 1;
               GX_FocusControl = edtTrActividades_IDTarea_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A25TrActividades_IDTarea = 0;
               n25TrActividades_IDTarea = false;
               AssignAttri("", false, "A25TrActividades_IDTarea", StringUtil.LTrimStr( (decimal)(A25TrActividades_IDTarea), 13, 0));
            }
            else
            {
               A25TrActividades_IDTarea = (long)(context.localUtil.CToN( cgiGet( edtTrActividades_IDTarea_Internalname), ".", ","));
               n25TrActividades_IDTarea = false;
               AssignAttri("", false, "A25TrActividades_IDTarea", StringUtil.LTrimStr( (decimal)(A25TrActividades_IDTarea), 13, 0));
            }
            n25TrActividades_IDTarea = ((0==A25TrActividades_IDTarea) ? true : false);
            A27TrActividades_Nombre = cgiGet( edtTrActividades_Nombre_Internalname);
            n27TrActividades_Nombre = false;
            AssignAttri("", false, "A27TrActividades_Nombre", A27TrActividades_Nombre);
            n27TrActividades_Nombre = (String.IsNullOrEmpty(StringUtil.RTrim( A27TrActividades_Nombre)) ? true : false);
            A28TrActividades_Descripcion = cgiGet( edtTrActividades_Descripcion_Internalname);
            n28TrActividades_Descripcion = false;
            AssignAttri("", false, "A28TrActividades_Descripcion", A28TrActividades_Descripcion);
            n28TrActividades_Descripcion = (String.IsNullOrEmpty(StringUtil.RTrim( A28TrActividades_Descripcion)) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrActividades_FechaInicio_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Actividades_Fecha Inicio"}), 1, "TRACTIVIDADES_FECHAINICIO");
               AnyError = 1;
               GX_FocusControl = edtTrActividades_FechaInicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A29TrActividades_FechaInicio = DateTime.MinValue;
               n29TrActividades_FechaInicio = false;
               AssignAttri("", false, "A29TrActividades_FechaInicio", context.localUtil.Format(A29TrActividades_FechaInicio, "99/99/9999"));
            }
            else
            {
               A29TrActividades_FechaInicio = context.localUtil.CToD( cgiGet( edtTrActividades_FechaInicio_Internalname), 1);
               n29TrActividades_FechaInicio = false;
               AssignAttri("", false, "A29TrActividades_FechaInicio", context.localUtil.Format(A29TrActividades_FechaInicio, "99/99/9999"));
            }
            n29TrActividades_FechaInicio = ((DateTime.MinValue==A29TrActividades_FechaInicio) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrActividades_FechaFin_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Actividades_Fecha Fin"}), 1, "TRACTIVIDADES_FECHAFIN");
               AnyError = 1;
               GX_FocusControl = edtTrActividades_FechaFin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A30TrActividades_FechaFin = DateTime.MinValue;
               n30TrActividades_FechaFin = false;
               AssignAttri("", false, "A30TrActividades_FechaFin", context.localUtil.Format(A30TrActividades_FechaFin, "99/99/9999"));
            }
            else
            {
               A30TrActividades_FechaFin = context.localUtil.CToD( cgiGet( edtTrActividades_FechaFin_Internalname), 1);
               n30TrActividades_FechaFin = false;
               AssignAttri("", false, "A30TrActividades_FechaFin", context.localUtil.Format(A30TrActividades_FechaFin, "99/99/9999"));
            }
            n30TrActividades_FechaFin = ((DateTime.MinValue==A30TrActividades_FechaFin) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrActividades_FechaCreacion_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Actividades_Fecha Creacion"}), 1, "TRACTIVIDADES_FECHACREACION");
               AnyError = 1;
               GX_FocusControl = edtTrActividades_FechaCreacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A31TrActividades_FechaCreacion = DateTime.MinValue;
               n31TrActividades_FechaCreacion = false;
               AssignAttri("", false, "A31TrActividades_FechaCreacion", context.localUtil.Format(A31TrActividades_FechaCreacion, "99/99/9999"));
            }
            else
            {
               A31TrActividades_FechaCreacion = context.localUtil.CToD( cgiGet( edtTrActividades_FechaCreacion_Internalname), 1);
               n31TrActividades_FechaCreacion = false;
               AssignAttri("", false, "A31TrActividades_FechaCreacion", context.localUtil.Format(A31TrActividades_FechaCreacion, "99/99/9999"));
            }
            n31TrActividades_FechaCreacion = ((DateTime.MinValue==A31TrActividades_FechaCreacion) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrActividades_FechaModificacion_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Actividades_Fecha Modificacion"}), 1, "TRACTIVIDADES_FECHAMODIFICACION");
               AnyError = 1;
               GX_FocusControl = edtTrActividades_FechaModificacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A32TrActividades_FechaModificacion = DateTime.MinValue;
               n32TrActividades_FechaModificacion = false;
               AssignAttri("", false, "A32TrActividades_FechaModificacion", context.localUtil.Format(A32TrActividades_FechaModificacion, "99/99/9999"));
            }
            else
            {
               A32TrActividades_FechaModificacion = context.localUtil.CToD( cgiGet( edtTrActividades_FechaModificacion_Internalname), 1);
               n32TrActividades_FechaModificacion = false;
               AssignAttri("", false, "A32TrActividades_FechaModificacion", context.localUtil.Format(A32TrActividades_FechaModificacion, "99/99/9999"));
            }
            n32TrActividades_FechaModificacion = ((DateTime.MinValue==A32TrActividades_FechaModificacion) ? true : false);
            cmbTrActividades_Estado.CurrentValue = cgiGet( cmbTrActividades_Estado_Internalname);
            A33TrActividades_Estado = (short)(NumberUtil.Val( cgiGet( cmbTrActividades_Estado_Internalname), "."));
            n33TrActividades_Estado = false;
            AssignAttri("", false, "A33TrActividades_Estado", StringUtil.LTrimStr( (decimal)(A33TrActividades_Estado), 4, 0));
            n33TrActividades_Estado = ((0==A33TrActividades_Estado) ? true : false);
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
               A26TrActividades_ID = (long)(NumberUtil.Val( GetNextPar( ), "."));
               AssignAttri("", false, "A26TrActividades_ID", StringUtil.LTrimStr( (decimal)(A26TrActividades_ID), 13, 0));
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
               InitAll044( ) ;
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
         DisableAttributes044( ) ;
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

      protected void ResetCaption040( )
      {
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z27TrActividades_Nombre = T00043_A27TrActividades_Nombre[0];
               Z29TrActividades_FechaInicio = T00043_A29TrActividades_FechaInicio[0];
               Z30TrActividades_FechaFin = T00043_A30TrActividades_FechaFin[0];
               Z31TrActividades_FechaCreacion = T00043_A31TrActividades_FechaCreacion[0];
               Z32TrActividades_FechaModificacion = T00043_A32TrActividades_FechaModificacion[0];
               Z33TrActividades_Estado = T00043_A33TrActividades_Estado[0];
               Z25TrActividades_IDTarea = T00043_A25TrActividades_IDTarea[0];
            }
            else
            {
               Z27TrActividades_Nombre = A27TrActividades_Nombre;
               Z29TrActividades_FechaInicio = A29TrActividades_FechaInicio;
               Z30TrActividades_FechaFin = A30TrActividades_FechaFin;
               Z31TrActividades_FechaCreacion = A31TrActividades_FechaCreacion;
               Z32TrActividades_FechaModificacion = A32TrActividades_FechaModificacion;
               Z33TrActividades_Estado = A33TrActividades_Estado;
               Z25TrActividades_IDTarea = A25TrActividades_IDTarea;
            }
         }
         if ( GX_JID == -6 )
         {
            Z26TrActividades_ID = A26TrActividades_ID;
            Z27TrActividades_Nombre = A27TrActividades_Nombre;
            Z28TrActividades_Descripcion = A28TrActividades_Descripcion;
            Z29TrActividades_FechaInicio = A29TrActividades_FechaInicio;
            Z30TrActividades_FechaFin = A30TrActividades_FechaFin;
            Z31TrActividades_FechaCreacion = A31TrActividades_FechaCreacion;
            Z32TrActividades_FechaModificacion = A32TrActividades_FechaModificacion;
            Z33TrActividades_Estado = A33TrActividades_Estado;
            Z25TrActividades_IDTarea = A25TrActividades_IDTarea;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_25_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TRACTIVIDADES_IDTAREA"+"'), id:'"+"TRACTIVIDADES_IDTAREA"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load044( )
      {
         /* Using cursor T00045 */
         pr_default.execute(3, new Object[] {A26TrActividades_ID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound4 = 1;
            A27TrActividades_Nombre = T00045_A27TrActividades_Nombre[0];
            n27TrActividades_Nombre = T00045_n27TrActividades_Nombre[0];
            AssignAttri("", false, "A27TrActividades_Nombre", A27TrActividades_Nombre);
            A28TrActividades_Descripcion = T00045_A28TrActividades_Descripcion[0];
            n28TrActividades_Descripcion = T00045_n28TrActividades_Descripcion[0];
            AssignAttri("", false, "A28TrActividades_Descripcion", A28TrActividades_Descripcion);
            A29TrActividades_FechaInicio = T00045_A29TrActividades_FechaInicio[0];
            n29TrActividades_FechaInicio = T00045_n29TrActividades_FechaInicio[0];
            AssignAttri("", false, "A29TrActividades_FechaInicio", context.localUtil.Format(A29TrActividades_FechaInicio, "99/99/9999"));
            A30TrActividades_FechaFin = T00045_A30TrActividades_FechaFin[0];
            n30TrActividades_FechaFin = T00045_n30TrActividades_FechaFin[0];
            AssignAttri("", false, "A30TrActividades_FechaFin", context.localUtil.Format(A30TrActividades_FechaFin, "99/99/9999"));
            A31TrActividades_FechaCreacion = T00045_A31TrActividades_FechaCreacion[0];
            n31TrActividades_FechaCreacion = T00045_n31TrActividades_FechaCreacion[0];
            AssignAttri("", false, "A31TrActividades_FechaCreacion", context.localUtil.Format(A31TrActividades_FechaCreacion, "99/99/9999"));
            A32TrActividades_FechaModificacion = T00045_A32TrActividades_FechaModificacion[0];
            n32TrActividades_FechaModificacion = T00045_n32TrActividades_FechaModificacion[0];
            AssignAttri("", false, "A32TrActividades_FechaModificacion", context.localUtil.Format(A32TrActividades_FechaModificacion, "99/99/9999"));
            A33TrActividades_Estado = T00045_A33TrActividades_Estado[0];
            n33TrActividades_Estado = T00045_n33TrActividades_Estado[0];
            AssignAttri("", false, "A33TrActividades_Estado", StringUtil.LTrimStr( (decimal)(A33TrActividades_Estado), 4, 0));
            A25TrActividades_IDTarea = T00045_A25TrActividades_IDTarea[0];
            n25TrActividades_IDTarea = T00045_n25TrActividades_IDTarea[0];
            AssignAttri("", false, "A25TrActividades_IDTarea", StringUtil.LTrimStr( (decimal)(A25TrActividades_IDTarea), 13, 0));
            ZM044( -6) ;
         }
         pr_default.close(3);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
      }

      protected void CheckExtendedTable044( )
      {
         nIsDirty_4 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00044 */
         pr_default.execute(2, new Object[] {n25TrActividades_IDTarea, A25TrActividades_IDTarea});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A25TrActividades_IDTarea) ) )
            {
               GX_msglist.addItem("No matching 'Tr Gestion Tareas_STG'.", "ForeignKeyNotFound", 1, "TRACTIVIDADES_IDTAREA");
               AnyError = 1;
               GX_FocusControl = edtTrActividades_IDTarea_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A29TrActividades_FechaInicio) || ( A29TrActividades_FechaInicio >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Tr Actividades_Fecha Inicio is out of range", "OutOfRange", 1, "TRACTIVIDADES_FECHAINICIO");
            AnyError = 1;
            GX_FocusControl = edtTrActividades_FechaInicio_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A30TrActividades_FechaFin) || ( A30TrActividades_FechaFin >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Tr Actividades_Fecha Fin is out of range", "OutOfRange", 1, "TRACTIVIDADES_FECHAFIN");
            AnyError = 1;
            GX_FocusControl = edtTrActividades_FechaFin_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A31TrActividades_FechaCreacion) || ( A31TrActividades_FechaCreacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Tr Actividades_Fecha Creacion is out of range", "OutOfRange", 1, "TRACTIVIDADES_FECHACREACION");
            AnyError = 1;
            GX_FocusControl = edtTrActividades_FechaCreacion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A32TrActividades_FechaModificacion) || ( A32TrActividades_FechaModificacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Tr Actividades_Fecha Modificacion is out of range", "OutOfRange", 1, "TRACTIVIDADES_FECHAMODIFICACION");
            AnyError = 1;
            GX_FocusControl = edtTrActividades_FechaModificacion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( A33TrActividades_Estado == 1 ) || ( A33TrActividades_Estado == 2 ) || ( A33TrActividades_Estado == 3 ) || ( A33TrActividades_Estado == 4 ) || ( A33TrActividades_Estado == 5 ) || (0==A33TrActividades_Estado) ) )
         {
            GX_msglist.addItem("Field Tr Actividades_Estado is out of range", "OutOfRange", 1, "TRACTIVIDADES_ESTADO");
            AnyError = 1;
            GX_FocusControl = cmbTrActividades_Estado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors044( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_7( long A25TrActividades_IDTarea )
      {
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {n25TrActividades_IDTarea, A25TrActividades_IDTarea});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A25TrActividades_IDTarea) ) )
            {
               GX_msglist.addItem("No matching 'Tr Gestion Tareas_STG'.", "ForeignKeyNotFound", 1, "TRACTIVIDADES_IDTAREA");
               AnyError = 1;
               GX_FocusControl = edtTrActividades_IDTarea_Internalname;
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

      protected void GetKey044( )
      {
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {A26TrActividades_ID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {A26TrActividades_ID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM044( 6) ;
            RcdFound4 = 1;
            A26TrActividades_ID = T00043_A26TrActividades_ID[0];
            AssignAttri("", false, "A26TrActividades_ID", StringUtil.LTrimStr( (decimal)(A26TrActividades_ID), 13, 0));
            A27TrActividades_Nombre = T00043_A27TrActividades_Nombre[0];
            n27TrActividades_Nombre = T00043_n27TrActividades_Nombre[0];
            AssignAttri("", false, "A27TrActividades_Nombre", A27TrActividades_Nombre);
            A28TrActividades_Descripcion = T00043_A28TrActividades_Descripcion[0];
            n28TrActividades_Descripcion = T00043_n28TrActividades_Descripcion[0];
            AssignAttri("", false, "A28TrActividades_Descripcion", A28TrActividades_Descripcion);
            A29TrActividades_FechaInicio = T00043_A29TrActividades_FechaInicio[0];
            n29TrActividades_FechaInicio = T00043_n29TrActividades_FechaInicio[0];
            AssignAttri("", false, "A29TrActividades_FechaInicio", context.localUtil.Format(A29TrActividades_FechaInicio, "99/99/9999"));
            A30TrActividades_FechaFin = T00043_A30TrActividades_FechaFin[0];
            n30TrActividades_FechaFin = T00043_n30TrActividades_FechaFin[0];
            AssignAttri("", false, "A30TrActividades_FechaFin", context.localUtil.Format(A30TrActividades_FechaFin, "99/99/9999"));
            A31TrActividades_FechaCreacion = T00043_A31TrActividades_FechaCreacion[0];
            n31TrActividades_FechaCreacion = T00043_n31TrActividades_FechaCreacion[0];
            AssignAttri("", false, "A31TrActividades_FechaCreacion", context.localUtil.Format(A31TrActividades_FechaCreacion, "99/99/9999"));
            A32TrActividades_FechaModificacion = T00043_A32TrActividades_FechaModificacion[0];
            n32TrActividades_FechaModificacion = T00043_n32TrActividades_FechaModificacion[0];
            AssignAttri("", false, "A32TrActividades_FechaModificacion", context.localUtil.Format(A32TrActividades_FechaModificacion, "99/99/9999"));
            A33TrActividades_Estado = T00043_A33TrActividades_Estado[0];
            n33TrActividades_Estado = T00043_n33TrActividades_Estado[0];
            AssignAttri("", false, "A33TrActividades_Estado", StringUtil.LTrimStr( (decimal)(A33TrActividades_Estado), 4, 0));
            A25TrActividades_IDTarea = T00043_A25TrActividades_IDTarea[0];
            n25TrActividades_IDTarea = T00043_n25TrActividades_IDTarea[0];
            AssignAttri("", false, "A25TrActividades_IDTarea", StringUtil.LTrimStr( (decimal)(A25TrActividades_IDTarea), 13, 0));
            Z26TrActividades_ID = A26TrActividades_ID;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load044( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey044( ) ;
            }
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
         if ( RcdFound4 == 0 )
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
         RcdFound4 = 0;
         /* Using cursor T00048 */
         pr_default.execute(6, new Object[] {A26TrActividades_ID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00048_A26TrActividades_ID[0] < A26TrActividades_ID ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00048_A26TrActividades_ID[0] > A26TrActividades_ID ) ) )
            {
               A26TrActividades_ID = T00048_A26TrActividades_ID[0];
               AssignAttri("", false, "A26TrActividades_ID", StringUtil.LTrimStr( (decimal)(A26TrActividades_ID), 13, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound4 = 0;
         /* Using cursor T00049 */
         pr_default.execute(7, new Object[] {A26TrActividades_ID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00049_A26TrActividades_ID[0] > A26TrActividades_ID ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00049_A26TrActividades_ID[0] < A26TrActividades_ID ) ) )
            {
               A26TrActividades_ID = T00049_A26TrActividades_ID[0];
               AssignAttri("", false, "A26TrActividades_ID", StringUtil.LTrimStr( (decimal)(A26TrActividades_ID), 13, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey044( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTrActividades_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert044( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( A26TrActividades_ID != Z26TrActividades_ID )
               {
                  A26TrActividades_ID = Z26TrActividades_ID;
                  AssignAttri("", false, "A26TrActividades_ID", StringUtil.LTrimStr( (decimal)(A26TrActividades_ID), 13, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRACTIVIDADES_ID");
                  AnyError = 1;
                  GX_FocusControl = edtTrActividades_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTrActividades_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update044( ) ;
                  GX_FocusControl = edtTrActividades_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A26TrActividades_ID != Z26TrActividades_ID )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTrActividades_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert044( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRACTIVIDADES_ID");
                     AnyError = 1;
                     GX_FocusControl = edtTrActividades_ID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTrActividades_ID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert044( ) ;
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
         if ( A26TrActividades_ID != Z26TrActividades_ID )
         {
            A26TrActividades_ID = Z26TrActividades_ID;
            AssignAttri("", false, "A26TrActividades_ID", StringUtil.LTrimStr( (decimal)(A26TrActividades_ID), 13, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRACTIVIDADES_ID");
            AnyError = 1;
            GX_FocusControl = edtTrActividades_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTrActividades_ID_Internalname;
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
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TRACTIVIDADES_ID");
            AnyError = 1;
            GX_FocusControl = edtTrActividades_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTrActividades_IDTarea_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrActividades_IDTarea_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd044( ) ;
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
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrActividades_IDTarea_Internalname;
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
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrActividades_IDTarea_Internalname;
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
         ScanStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound4 != 0 )
            {
               ScanNext044( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrActividades_IDTarea_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd044( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency044( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {A26TrActividades_ID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrActividades"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z27TrActividades_Nombre, T00042_A27TrActividades_Nombre[0]) != 0 ) || ( Z29TrActividades_FechaInicio != T00042_A29TrActividades_FechaInicio[0] ) || ( Z30TrActividades_FechaFin != T00042_A30TrActividades_FechaFin[0] ) || ( Z31TrActividades_FechaCreacion != T00042_A31TrActividades_FechaCreacion[0] ) || ( Z32TrActividades_FechaModificacion != T00042_A32TrActividades_FechaModificacion[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z33TrActividades_Estado != T00042_A33TrActividades_Estado[0] ) || ( Z25TrActividades_IDTarea != T00042_A25TrActividades_IDTarea[0] ) )
            {
               if ( StringUtil.StrCmp(Z27TrActividades_Nombre, T00042_A27TrActividades_Nombre[0]) != 0 )
               {
                  GXUtil.WriteLog("tractividades:[seudo value changed for attri]"+"TrActividades_Nombre");
                  GXUtil.WriteLogRaw("Old: ",Z27TrActividades_Nombre);
                  GXUtil.WriteLogRaw("Current: ",T00042_A27TrActividades_Nombre[0]);
               }
               if ( Z29TrActividades_FechaInicio != T00042_A29TrActividades_FechaInicio[0] )
               {
                  GXUtil.WriteLog("tractividades:[seudo value changed for attri]"+"TrActividades_FechaInicio");
                  GXUtil.WriteLogRaw("Old: ",Z29TrActividades_FechaInicio);
                  GXUtil.WriteLogRaw("Current: ",T00042_A29TrActividades_FechaInicio[0]);
               }
               if ( Z30TrActividades_FechaFin != T00042_A30TrActividades_FechaFin[0] )
               {
                  GXUtil.WriteLog("tractividades:[seudo value changed for attri]"+"TrActividades_FechaFin");
                  GXUtil.WriteLogRaw("Old: ",Z30TrActividades_FechaFin);
                  GXUtil.WriteLogRaw("Current: ",T00042_A30TrActividades_FechaFin[0]);
               }
               if ( Z31TrActividades_FechaCreacion != T00042_A31TrActividades_FechaCreacion[0] )
               {
                  GXUtil.WriteLog("tractividades:[seudo value changed for attri]"+"TrActividades_FechaCreacion");
                  GXUtil.WriteLogRaw("Old: ",Z31TrActividades_FechaCreacion);
                  GXUtil.WriteLogRaw("Current: ",T00042_A31TrActividades_FechaCreacion[0]);
               }
               if ( Z32TrActividades_FechaModificacion != T00042_A32TrActividades_FechaModificacion[0] )
               {
                  GXUtil.WriteLog("tractividades:[seudo value changed for attri]"+"TrActividades_FechaModificacion");
                  GXUtil.WriteLogRaw("Old: ",Z32TrActividades_FechaModificacion);
                  GXUtil.WriteLogRaw("Current: ",T00042_A32TrActividades_FechaModificacion[0]);
               }
               if ( Z33TrActividades_Estado != T00042_A33TrActividades_Estado[0] )
               {
                  GXUtil.WriteLog("tractividades:[seudo value changed for attri]"+"TrActividades_Estado");
                  GXUtil.WriteLogRaw("Old: ",Z33TrActividades_Estado);
                  GXUtil.WriteLogRaw("Current: ",T00042_A33TrActividades_Estado[0]);
               }
               if ( Z25TrActividades_IDTarea != T00042_A25TrActividades_IDTarea[0] )
               {
                  GXUtil.WriteLog("tractividades:[seudo value changed for attri]"+"TrActividades_IDTarea");
                  GXUtil.WriteLogRaw("Old: ",Z25TrActividades_IDTarea);
                  GXUtil.WriteLogRaw("Current: ",T00042_A25TrActividades_IDTarea[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TrActividades"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM044( 0) ;
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000410 */
                     pr_default.execute(8, new Object[] {A26TrActividades_ID, n27TrActividades_Nombre, A27TrActividades_Nombre, n28TrActividades_Descripcion, A28TrActividades_Descripcion, n29TrActividades_FechaInicio, A29TrActividades_FechaInicio, n30TrActividades_FechaFin, A30TrActividades_FechaFin, n31TrActividades_FechaCreacion, A31TrActividades_FechaCreacion, n32TrActividades_FechaModificacion, A32TrActividades_FechaModificacion, n33TrActividades_Estado, A33TrActividades_Estado, n25TrActividades_IDTarea, A25TrActividades_IDTarea});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("TrActividades") ;
                     if ( (pr_default.getStatus(8) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           GX_msglist.addItem(context.GetMessage( "GXM_sucadded", ""), "SuccessfullyAdded", 0, "", true);
                           ResetCaption040( ) ;
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
               Load044( ) ;
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void Update044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000411 */
                     pr_default.execute(9, new Object[] {n27TrActividades_Nombre, A27TrActividades_Nombre, n28TrActividades_Descripcion, A28TrActividades_Descripcion, n29TrActividades_FechaInicio, A29TrActividades_FechaInicio, n30TrActividades_FechaFin, A30TrActividades_FechaFin, n31TrActividades_FechaCreacion, A31TrActividades_FechaCreacion, n32TrActividades_FechaModificacion, A32TrActividades_FechaModificacion, n33TrActividades_Estado, A33TrActividades_Estado, n25TrActividades_IDTarea, A25TrActividades_IDTarea, A26TrActividades_ID});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("TrActividades") ;
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrActividades"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate044( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           GX_msglist.addItem(context.GetMessage( "GXM_sucupdated", ""), "SuccessfullyUpdated", 0, "", true);
                           ResetCaption040( ) ;
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
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls044( ) ;
            AfterConfirm044( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete044( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000412 */
                  pr_default.execute(10, new Object[] {A26TrActividades_ID});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("TrActividades") ;
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound4 == 0 )
                        {
                           InitAll044( ) ;
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
                        ResetCaption040( ) ;
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel044( ) ;
         Gx_mode = sMode4;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel044( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("tractividades",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("tractividades",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart044( )
      {
         /* Using cursor T000413 */
         pr_default.execute(11);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound4 = 1;
            A26TrActividades_ID = T000413_A26TrActividades_ID[0];
            AssignAttri("", false, "A26TrActividades_ID", StringUtil.LTrimStr( (decimal)(A26TrActividades_ID), 13, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound4 = 1;
            A26TrActividades_ID = T000413_A26TrActividades_ID[0];
            AssignAttri("", false, "A26TrActividades_ID", StringUtil.LTrimStr( (decimal)(A26TrActividades_ID), 13, 0));
         }
      }

      protected void ScanEnd044( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm044( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert044( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate044( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete044( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete044( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate044( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes044( )
      {
         edtTrActividades_ID_Enabled = 0;
         AssignProp("", false, edtTrActividades_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrActividades_ID_Enabled), 5, 0), true);
         edtTrActividades_IDTarea_Enabled = 0;
         AssignProp("", false, edtTrActividades_IDTarea_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrActividades_IDTarea_Enabled), 5, 0), true);
         edtTrActividades_Nombre_Enabled = 0;
         AssignProp("", false, edtTrActividades_Nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrActividades_Nombre_Enabled), 5, 0), true);
         edtTrActividades_Descripcion_Enabled = 0;
         AssignProp("", false, edtTrActividades_Descripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrActividades_Descripcion_Enabled), 5, 0), true);
         edtTrActividades_FechaInicio_Enabled = 0;
         AssignProp("", false, edtTrActividades_FechaInicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrActividades_FechaInicio_Enabled), 5, 0), true);
         edtTrActividades_FechaFin_Enabled = 0;
         AssignProp("", false, edtTrActividades_FechaFin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrActividades_FechaFin_Enabled), 5, 0), true);
         edtTrActividades_FechaCreacion_Enabled = 0;
         AssignProp("", false, edtTrActividades_FechaCreacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrActividades_FechaCreacion_Enabled), 5, 0), true);
         edtTrActividades_FechaModificacion_Enabled = 0;
         AssignProp("", false, edtTrActividades_FechaModificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrActividades_FechaModificacion_Enabled), 5, 0), true);
         cmbTrActividades_Estado.Enabled = 0;
         AssignProp("", false, cmbTrActividades_Estado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTrActividades_Estado.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes044( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues040( )
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
         context.AddJavascriptSource("gxcfg.js", "?202210202185459", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tractividades.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z26TrActividades_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26TrActividades_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z27TrActividades_Nombre", StringUtil.RTrim( Z27TrActividades_Nombre));
         GxWebStd.gx_hidden_field( context, "Z29TrActividades_FechaInicio", context.localUtil.DToC( Z29TrActividades_FechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z30TrActividades_FechaFin", context.localUtil.DToC( Z30TrActividades_FechaFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z31TrActividades_FechaCreacion", context.localUtil.DToC( Z31TrActividades_FechaCreacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z32TrActividades_FechaModificacion", context.localUtil.DToC( Z32TrActividades_FechaModificacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z33TrActividades_Estado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z33TrActividades_Estado), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z25TrActividades_IDTarea", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z25TrActividades_IDTarea), 13, 0, ".", "")));
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
         return formatLink("tractividades.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "TrActividades" ;
      }

      public override String GetPgmdesc( )
      {
         return "Tr Actividades" ;
      }

      protected void InitializeNonKey044( )
      {
         A25TrActividades_IDTarea = 0;
         n25TrActividades_IDTarea = false;
         AssignAttri("", false, "A25TrActividades_IDTarea", StringUtil.LTrimStr( (decimal)(A25TrActividades_IDTarea), 13, 0));
         n25TrActividades_IDTarea = ((0==A25TrActividades_IDTarea) ? true : false);
         A27TrActividades_Nombre = "";
         n27TrActividades_Nombre = false;
         AssignAttri("", false, "A27TrActividades_Nombre", A27TrActividades_Nombre);
         n27TrActividades_Nombre = (String.IsNullOrEmpty(StringUtil.RTrim( A27TrActividades_Nombre)) ? true : false);
         A28TrActividades_Descripcion = "";
         n28TrActividades_Descripcion = false;
         AssignAttri("", false, "A28TrActividades_Descripcion", A28TrActividades_Descripcion);
         n28TrActividades_Descripcion = (String.IsNullOrEmpty(StringUtil.RTrim( A28TrActividades_Descripcion)) ? true : false);
         A29TrActividades_FechaInicio = DateTime.MinValue;
         n29TrActividades_FechaInicio = false;
         AssignAttri("", false, "A29TrActividades_FechaInicio", context.localUtil.Format(A29TrActividades_FechaInicio, "99/99/9999"));
         n29TrActividades_FechaInicio = ((DateTime.MinValue==A29TrActividades_FechaInicio) ? true : false);
         A30TrActividades_FechaFin = DateTime.MinValue;
         n30TrActividades_FechaFin = false;
         AssignAttri("", false, "A30TrActividades_FechaFin", context.localUtil.Format(A30TrActividades_FechaFin, "99/99/9999"));
         n30TrActividades_FechaFin = ((DateTime.MinValue==A30TrActividades_FechaFin) ? true : false);
         A31TrActividades_FechaCreacion = DateTime.MinValue;
         n31TrActividades_FechaCreacion = false;
         AssignAttri("", false, "A31TrActividades_FechaCreacion", context.localUtil.Format(A31TrActividades_FechaCreacion, "99/99/9999"));
         n31TrActividades_FechaCreacion = ((DateTime.MinValue==A31TrActividades_FechaCreacion) ? true : false);
         A32TrActividades_FechaModificacion = DateTime.MinValue;
         n32TrActividades_FechaModificacion = false;
         AssignAttri("", false, "A32TrActividades_FechaModificacion", context.localUtil.Format(A32TrActividades_FechaModificacion, "99/99/9999"));
         n32TrActividades_FechaModificacion = ((DateTime.MinValue==A32TrActividades_FechaModificacion) ? true : false);
         A33TrActividades_Estado = 0;
         n33TrActividades_Estado = false;
         AssignAttri("", false, "A33TrActividades_Estado", StringUtil.LTrimStr( (decimal)(A33TrActividades_Estado), 4, 0));
         n33TrActividades_Estado = ((0==A33TrActividades_Estado) ? true : false);
         Z27TrActividades_Nombre = "";
         Z29TrActividades_FechaInicio = DateTime.MinValue;
         Z30TrActividades_FechaFin = DateTime.MinValue;
         Z31TrActividades_FechaCreacion = DateTime.MinValue;
         Z32TrActividades_FechaModificacion = DateTime.MinValue;
         Z33TrActividades_Estado = 0;
         Z25TrActividades_IDTarea = 0;
      }

      protected void InitAll044( )
      {
         A26TrActividades_ID = 0;
         AssignAttri("", false, "A26TrActividades_ID", StringUtil.LTrimStr( (decimal)(A26TrActividades_ID), 13, 0));
         InitializeNonKey044( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210202185467", true, true);
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
         context.AddJavascriptSource("tractividades.js", "?202210202185467", false, true);
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
         edtTrActividades_ID_Internalname = "TRACTIVIDADES_ID";
         edtTrActividades_IDTarea_Internalname = "TRACTIVIDADES_IDTAREA";
         edtTrActividades_Nombre_Internalname = "TRACTIVIDADES_NOMBRE";
         edtTrActividades_Descripcion_Internalname = "TRACTIVIDADES_DESCRIPCION";
         edtTrActividades_FechaInicio_Internalname = "TRACTIVIDADES_FECHAINICIO";
         edtTrActividades_FechaFin_Internalname = "TRACTIVIDADES_FECHAFIN";
         edtTrActividades_FechaCreacion_Internalname = "TRACTIVIDADES_FECHACREACION";
         edtTrActividades_FechaModificacion_Internalname = "TRACTIVIDADES_FECHAMODIFICACION";
         cmbTrActividades_Estado_Internalname = "TRACTIVIDADES_ESTADO";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Form.Internalname = "FORM";
         imgprompt_25_Internalname = "PROMPT_25";
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
         Form.Caption = "Tr Actividades";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbTrActividades_Estado_Jsonclick = "";
         cmbTrActividades_Estado.Enabled = 1;
         edtTrActividades_FechaModificacion_Jsonclick = "";
         edtTrActividades_FechaModificacion_Enabled = 1;
         edtTrActividades_FechaCreacion_Jsonclick = "";
         edtTrActividades_FechaCreacion_Enabled = 1;
         edtTrActividades_FechaFin_Jsonclick = "";
         edtTrActividades_FechaFin_Enabled = 1;
         edtTrActividades_FechaInicio_Jsonclick = "";
         edtTrActividades_FechaInicio_Enabled = 1;
         edtTrActividades_Descripcion_Enabled = 1;
         edtTrActividades_Nombre_Jsonclick = "";
         edtTrActividades_Nombre_Enabled = 1;
         imgprompt_25_Visible = 1;
         imgprompt_25_Link = "";
         edtTrActividades_IDTarea_Jsonclick = "";
         edtTrActividades_IDTarea_Enabled = 1;
         edtTrActividades_ID_Jsonclick = "";
         edtTrActividades_ID_Enabled = 1;
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
         cmbTrActividades_Estado.Name = "TRACTIVIDADES_ESTADO";
         cmbTrActividades_Estado.WebTags = "";
         cmbTrActividades_Estado.addItem("1", "Nuevo", 0);
         cmbTrActividades_Estado.addItem("2", "En Progreso", 0);
         cmbTrActividades_Estado.addItem("3", "Completado", 0);
         cmbTrActividades_Estado.addItem("4", "Detenido", 0);
         cmbTrActividades_Estado.addItem("5", "Pendiente", 0);
         if ( cmbTrActividades_Estado.ItemCount > 0 )
         {
            A33TrActividades_Estado = (short)(NumberUtil.Val( cmbTrActividades_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A33TrActividades_Estado), 4, 0))), "."));
            n33TrActividades_Estado = false;
            AssignAttri("", false, "A33TrActividades_Estado", StringUtil.LTrimStr( (decimal)(A33TrActividades_Estado), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtTrActividades_IDTarea_Internalname;
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

      public void Valid_Tractividades_id( )
      {
         n33TrActividades_Estado = false;
         A33TrActividades_Estado = (short)(NumberUtil.Val( cmbTrActividades_Estado.CurrentValue, "."));
         n33TrActividades_Estado = false;
         cmbTrActividades_Estado.CurrentValue = StringUtil.LTrimStr( (decimal)(A33TrActividades_Estado), 4, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbTrActividades_Estado.ItemCount > 0 )
         {
            A33TrActividades_Estado = (short)(NumberUtil.Val( cmbTrActividades_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A33TrActividades_Estado), 4, 0))), "."));
            n33TrActividades_Estado = false;
            cmbTrActividades_Estado.CurrentValue = StringUtil.LTrimStr( (decimal)(A33TrActividades_Estado), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTrActividades_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A33TrActividades_Estado), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A25TrActividades_IDTarea", StringUtil.LTrim( StringUtil.NToC( (decimal)(A25TrActividades_IDTarea), 13, 0, ".", "")));
         AssignAttri("", false, "A27TrActividades_Nombre", StringUtil.RTrim( A27TrActividades_Nombre));
         AssignAttri("", false, "A28TrActividades_Descripcion", A28TrActividades_Descripcion);
         AssignAttri("", false, "A29TrActividades_FechaInicio", context.localUtil.Format(A29TrActividades_FechaInicio, "99/99/9999"));
         AssignAttri("", false, "A30TrActividades_FechaFin", context.localUtil.Format(A30TrActividades_FechaFin, "99/99/9999"));
         AssignAttri("", false, "A31TrActividades_FechaCreacion", context.localUtil.Format(A31TrActividades_FechaCreacion, "99/99/9999"));
         AssignAttri("", false, "A32TrActividades_FechaModificacion", context.localUtil.Format(A32TrActividades_FechaModificacion, "99/99/9999"));
         AssignAttri("", false, "A33TrActividades_Estado", StringUtil.LTrim( StringUtil.NToC( (decimal)(A33TrActividades_Estado), 4, 0, ".", "")));
         cmbTrActividades_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A33TrActividades_Estado), 4, 0));
         AssignProp("", false, cmbTrActividades_Estado_Internalname, "Values", cmbTrActividades_Estado.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z26TrActividades_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26TrActividades_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z25TrActividades_IDTarea", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z25TrActividades_IDTarea), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z27TrActividades_Nombre", StringUtil.RTrim( Z27TrActividades_Nombre));
         GxWebStd.gx_hidden_field( context, "Z28TrActividades_Descripcion", Z28TrActividades_Descripcion);
         GxWebStd.gx_hidden_field( context, "Z29TrActividades_FechaInicio", context.localUtil.Format(Z29TrActividades_FechaInicio, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z30TrActividades_FechaFin", context.localUtil.Format(Z30TrActividades_FechaFin, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z31TrActividades_FechaCreacion", context.localUtil.Format(Z31TrActividades_FechaCreacion, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z32TrActividades_FechaModificacion", context.localUtil.Format(Z32TrActividades_FechaModificacion, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z33TrActividades_Estado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z33TrActividades_Estado), 4, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Tractividades_idtarea( )
      {
         n25TrActividades_IDTarea = false;
         /* Using cursor T000414 */
         pr_default.execute(12, new Object[] {n25TrActividades_IDTarea, A25TrActividades_IDTarea});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A25TrActividades_IDTarea) ) )
            {
               GX_msglist.addItem("No matching 'Tr Gestion Tareas_STG'.", "ForeignKeyNotFound", 1, "TRACTIVIDADES_IDTAREA");
               AnyError = 1;
               GX_FocusControl = edtTrActividades_IDTarea_Internalname;
            }
         }
         pr_default.close(12);
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
         setEventMetadata("VALID_TRACTIVIDADES_ID","{handler:'Valid_Tractividades_id',iparms:[{av:'cmbTrActividades_Estado'},{av:'A33TrActividades_Estado',fld:'TRACTIVIDADES_ESTADO',pic:'ZZZ9'},{av:'A26TrActividades_ID',fld:'TRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TRACTIVIDADES_ID",",oparms:[{av:'A25TrActividades_IDTarea',fld:'TRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'A27TrActividades_Nombre',fld:'TRACTIVIDADES_NOMBRE',pic:''},{av:'A28TrActividades_Descripcion',fld:'TRACTIVIDADES_DESCRIPCION',pic:''},{av:'A29TrActividades_FechaInicio',fld:'TRACTIVIDADES_FECHAINICIO',pic:''},{av:'A30TrActividades_FechaFin',fld:'TRACTIVIDADES_FECHAFIN',pic:''},{av:'A31TrActividades_FechaCreacion',fld:'TRACTIVIDADES_FECHACREACION',pic:''},{av:'A32TrActividades_FechaModificacion',fld:'TRACTIVIDADES_FECHAMODIFICACION',pic:''},{av:'cmbTrActividades_Estado'},{av:'A33TrActividades_Estado',fld:'TRACTIVIDADES_ESTADO',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z26TrActividades_ID'},{av:'Z25TrActividades_IDTarea'},{av:'Z27TrActividades_Nombre'},{av:'Z28TrActividades_Descripcion'},{av:'Z29TrActividades_FechaInicio'},{av:'Z30TrActividades_FechaFin'},{av:'Z31TrActividades_FechaCreacion'},{av:'Z32TrActividades_FechaModificacion'},{av:'Z33TrActividades_Estado'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_TRACTIVIDADES_IDTAREA","{handler:'Valid_Tractividades_idtarea',iparms:[{av:'A25TrActividades_IDTarea',fld:'TRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("VALID_TRACTIVIDADES_IDTAREA",",oparms:[]}");
         setEventMetadata("VALID_TRACTIVIDADES_FECHAINICIO","{handler:'Valid_Tractividades_fechainicio',iparms:[]");
         setEventMetadata("VALID_TRACTIVIDADES_FECHAINICIO",",oparms:[]}");
         setEventMetadata("VALID_TRACTIVIDADES_FECHAFIN","{handler:'Valid_Tractividades_fechafin',iparms:[]");
         setEventMetadata("VALID_TRACTIVIDADES_FECHAFIN",",oparms:[]}");
         setEventMetadata("VALID_TRACTIVIDADES_FECHACREACION","{handler:'Valid_Tractividades_fechacreacion',iparms:[]");
         setEventMetadata("VALID_TRACTIVIDADES_FECHACREACION",",oparms:[]}");
         setEventMetadata("VALID_TRACTIVIDADES_FECHAMODIFICACION","{handler:'Valid_Tractividades_fechamodificacion',iparms:[]");
         setEventMetadata("VALID_TRACTIVIDADES_FECHAMODIFICACION",",oparms:[]}");
         setEventMetadata("VALID_TRACTIVIDADES_ESTADO","{handler:'Valid_Tractividades_estado',iparms:[]");
         setEventMetadata("VALID_TRACTIVIDADES_ESTADO",",oparms:[]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z27TrActividades_Nombre = "";
         Z29TrActividades_FechaInicio = DateTime.MinValue;
         Z30TrActividades_FechaFin = DateTime.MinValue;
         Z31TrActividades_FechaCreacion = DateTime.MinValue;
         Z32TrActividades_FechaModificacion = DateTime.MinValue;
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
         A27TrActividades_Nombre = "";
         A28TrActividades_Descripcion = "";
         A29TrActividades_FechaInicio = DateTime.MinValue;
         A30TrActividades_FechaFin = DateTime.MinValue;
         A31TrActividades_FechaCreacion = DateTime.MinValue;
         A32TrActividades_FechaModificacion = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         Z28TrActividades_Descripcion = "";
         T00045_A26TrActividades_ID = new long[1] ;
         T00045_A27TrActividades_Nombre = new String[] {""} ;
         T00045_n27TrActividades_Nombre = new bool[] {false} ;
         T00045_A28TrActividades_Descripcion = new String[] {""} ;
         T00045_n28TrActividades_Descripcion = new bool[] {false} ;
         T00045_A29TrActividades_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         T00045_n29TrActividades_FechaInicio = new bool[] {false} ;
         T00045_A30TrActividades_FechaFin = new DateTime[] {DateTime.MinValue} ;
         T00045_n30TrActividades_FechaFin = new bool[] {false} ;
         T00045_A31TrActividades_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00045_n31TrActividades_FechaCreacion = new bool[] {false} ;
         T00045_A32TrActividades_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00045_n32TrActividades_FechaModificacion = new bool[] {false} ;
         T00045_A33TrActividades_Estado = new short[1] ;
         T00045_n33TrActividades_Estado = new bool[] {false} ;
         T00045_A25TrActividades_IDTarea = new long[1] ;
         T00045_n25TrActividades_IDTarea = new bool[] {false} ;
         T00044_A25TrActividades_IDTarea = new long[1] ;
         T00044_n25TrActividades_IDTarea = new bool[] {false} ;
         T00046_A25TrActividades_IDTarea = new long[1] ;
         T00046_n25TrActividades_IDTarea = new bool[] {false} ;
         T00047_A26TrActividades_ID = new long[1] ;
         T00043_A26TrActividades_ID = new long[1] ;
         T00043_A27TrActividades_Nombre = new String[] {""} ;
         T00043_n27TrActividades_Nombre = new bool[] {false} ;
         T00043_A28TrActividades_Descripcion = new String[] {""} ;
         T00043_n28TrActividades_Descripcion = new bool[] {false} ;
         T00043_A29TrActividades_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         T00043_n29TrActividades_FechaInicio = new bool[] {false} ;
         T00043_A30TrActividades_FechaFin = new DateTime[] {DateTime.MinValue} ;
         T00043_n30TrActividades_FechaFin = new bool[] {false} ;
         T00043_A31TrActividades_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00043_n31TrActividades_FechaCreacion = new bool[] {false} ;
         T00043_A32TrActividades_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00043_n32TrActividades_FechaModificacion = new bool[] {false} ;
         T00043_A33TrActividades_Estado = new short[1] ;
         T00043_n33TrActividades_Estado = new bool[] {false} ;
         T00043_A25TrActividades_IDTarea = new long[1] ;
         T00043_n25TrActividades_IDTarea = new bool[] {false} ;
         sMode4 = "";
         T00048_A26TrActividades_ID = new long[1] ;
         T00049_A26TrActividades_ID = new long[1] ;
         T00042_A26TrActividades_ID = new long[1] ;
         T00042_A27TrActividades_Nombre = new String[] {""} ;
         T00042_n27TrActividades_Nombre = new bool[] {false} ;
         T00042_A28TrActividades_Descripcion = new String[] {""} ;
         T00042_n28TrActividades_Descripcion = new bool[] {false} ;
         T00042_A29TrActividades_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         T00042_n29TrActividades_FechaInicio = new bool[] {false} ;
         T00042_A30TrActividades_FechaFin = new DateTime[] {DateTime.MinValue} ;
         T00042_n30TrActividades_FechaFin = new bool[] {false} ;
         T00042_A31TrActividades_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00042_n31TrActividades_FechaCreacion = new bool[] {false} ;
         T00042_A32TrActividades_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00042_n32TrActividades_FechaModificacion = new bool[] {false} ;
         T00042_A33TrActividades_Estado = new short[1] ;
         T00042_n33TrActividades_Estado = new bool[] {false} ;
         T00042_A25TrActividades_IDTarea = new long[1] ;
         T00042_n25TrActividades_IDTarea = new bool[] {false} ;
         T000413_A26TrActividades_ID = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ27TrActividades_Nombre = "";
         ZZ28TrActividades_Descripcion = "";
         ZZ29TrActividades_FechaInicio = DateTime.MinValue;
         ZZ30TrActividades_FechaFin = DateTime.MinValue;
         ZZ31TrActividades_FechaCreacion = DateTime.MinValue;
         ZZ32TrActividades_FechaModificacion = DateTime.MinValue;
         T000414_A25TrActividades_IDTarea = new long[1] ;
         T000414_n25TrActividades_IDTarea = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tractividades__default(),
            new Object[][] {
                new Object[] {
               T00042_A26TrActividades_ID, T00042_A27TrActividades_Nombre, T00042_n27TrActividades_Nombre, T00042_A28TrActividades_Descripcion, T00042_n28TrActividades_Descripcion, T00042_A29TrActividades_FechaInicio, T00042_n29TrActividades_FechaInicio, T00042_A30TrActividades_FechaFin, T00042_n30TrActividades_FechaFin, T00042_A31TrActividades_FechaCreacion,
               T00042_n31TrActividades_FechaCreacion, T00042_A32TrActividades_FechaModificacion, T00042_n32TrActividades_FechaModificacion, T00042_A33TrActividades_Estado, T00042_n33TrActividades_Estado, T00042_A25TrActividades_IDTarea, T00042_n25TrActividades_IDTarea
               }
               , new Object[] {
               T00043_A26TrActividades_ID, T00043_A27TrActividades_Nombre, T00043_n27TrActividades_Nombre, T00043_A28TrActividades_Descripcion, T00043_n28TrActividades_Descripcion, T00043_A29TrActividades_FechaInicio, T00043_n29TrActividades_FechaInicio, T00043_A30TrActividades_FechaFin, T00043_n30TrActividades_FechaFin, T00043_A31TrActividades_FechaCreacion,
               T00043_n31TrActividades_FechaCreacion, T00043_A32TrActividades_FechaModificacion, T00043_n32TrActividades_FechaModificacion, T00043_A33TrActividades_Estado, T00043_n33TrActividades_Estado, T00043_A25TrActividades_IDTarea, T00043_n25TrActividades_IDTarea
               }
               , new Object[] {
               T00044_A25TrActividades_IDTarea
               }
               , new Object[] {
               T00045_A26TrActividades_ID, T00045_A27TrActividades_Nombre, T00045_n27TrActividades_Nombre, T00045_A28TrActividades_Descripcion, T00045_n28TrActividades_Descripcion, T00045_A29TrActividades_FechaInicio, T00045_n29TrActividades_FechaInicio, T00045_A30TrActividades_FechaFin, T00045_n30TrActividades_FechaFin, T00045_A31TrActividades_FechaCreacion,
               T00045_n31TrActividades_FechaCreacion, T00045_A32TrActividades_FechaModificacion, T00045_n32TrActividades_FechaModificacion, T00045_A33TrActividades_Estado, T00045_n33TrActividades_Estado, T00045_A25TrActividades_IDTarea, T00045_n25TrActividades_IDTarea
               }
               , new Object[] {
               T00046_A25TrActividades_IDTarea
               }
               , new Object[] {
               T00047_A26TrActividades_ID
               }
               , new Object[] {
               T00048_A26TrActividades_ID
               }
               , new Object[] {
               T00049_A26TrActividades_ID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000413_A26TrActividades_ID
               }
               , new Object[] {
               T000414_A25TrActividades_IDTarea
               }
            }
         );
      }

      private short Z33TrActividades_Estado ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A33TrActividades_Estado ;
      private short GX_JID ;
      private short RcdFound4 ;
      private short nIsDirty_4 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ33TrActividades_Estado ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTrActividades_ID_Enabled ;
      private int edtTrActividades_IDTarea_Enabled ;
      private int imgprompt_25_Visible ;
      private int edtTrActividades_Nombre_Enabled ;
      private int edtTrActividades_Descripcion_Enabled ;
      private int edtTrActividades_FechaInicio_Enabled ;
      private int edtTrActividades_FechaFin_Enabled ;
      private int edtTrActividades_FechaCreacion_Enabled ;
      private int edtTrActividades_FechaModificacion_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z26TrActividades_ID ;
      private long Z25TrActividades_IDTarea ;
      private long A25TrActividades_IDTarea ;
      private long A26TrActividades_ID ;
      private long ZZ26TrActividades_ID ;
      private long ZZ25TrActividades_IDTarea ;
      private String sPrefix ;
      private String Z27TrActividades_Nombre ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String GXKey ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtTrActividades_ID_Internalname ;
      private String cmbTrActividades_Estado_Internalname ;
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
      private String edtTrActividades_ID_Jsonclick ;
      private String edtTrActividades_IDTarea_Internalname ;
      private String edtTrActividades_IDTarea_Jsonclick ;
      private String sImgUrl ;
      private String imgprompt_25_Internalname ;
      private String imgprompt_25_Link ;
      private String edtTrActividades_Nombre_Internalname ;
      private String A27TrActividades_Nombre ;
      private String edtTrActividades_Nombre_Jsonclick ;
      private String edtTrActividades_Descripcion_Internalname ;
      private String edtTrActividades_FechaInicio_Internalname ;
      private String edtTrActividades_FechaInicio_Jsonclick ;
      private String edtTrActividades_FechaFin_Internalname ;
      private String edtTrActividades_FechaFin_Jsonclick ;
      private String edtTrActividades_FechaCreacion_Internalname ;
      private String edtTrActividades_FechaCreacion_Jsonclick ;
      private String edtTrActividades_FechaModificacion_Internalname ;
      private String edtTrActividades_FechaModificacion_Jsonclick ;
      private String cmbTrActividades_Estado_Jsonclick ;
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
      private String sMode4 ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String ZZ27TrActividades_Nombre ;
      private DateTime Z29TrActividades_FechaInicio ;
      private DateTime Z30TrActividades_FechaFin ;
      private DateTime Z31TrActividades_FechaCreacion ;
      private DateTime Z32TrActividades_FechaModificacion ;
      private DateTime A29TrActividades_FechaInicio ;
      private DateTime A30TrActividades_FechaFin ;
      private DateTime A31TrActividades_FechaCreacion ;
      private DateTime A32TrActividades_FechaModificacion ;
      private DateTime ZZ29TrActividades_FechaInicio ;
      private DateTime ZZ30TrActividades_FechaFin ;
      private DateTime ZZ31TrActividades_FechaCreacion ;
      private DateTime ZZ32TrActividades_FechaModificacion ;
      private bool entryPointCalled ;
      private bool n25TrActividades_IDTarea ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n33TrActividades_Estado ;
      private bool n27TrActividades_Nombre ;
      private bool n29TrActividades_FechaInicio ;
      private bool n30TrActividades_FechaFin ;
      private bool n31TrActividades_FechaCreacion ;
      private bool n32TrActividades_FechaModificacion ;
      private bool n28TrActividades_Descripcion ;
      private bool Gx_longc ;
      private String A28TrActividades_Descripcion ;
      private String Z28TrActividades_Descripcion ;
      private String ZZ28TrActividades_Descripcion ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTrActividades_Estado ;
      private IDataStoreProvider pr_default ;
      private long[] T00045_A26TrActividades_ID ;
      private String[] T00045_A27TrActividades_Nombre ;
      private bool[] T00045_n27TrActividades_Nombre ;
      private String[] T00045_A28TrActividades_Descripcion ;
      private bool[] T00045_n28TrActividades_Descripcion ;
      private DateTime[] T00045_A29TrActividades_FechaInicio ;
      private bool[] T00045_n29TrActividades_FechaInicio ;
      private DateTime[] T00045_A30TrActividades_FechaFin ;
      private bool[] T00045_n30TrActividades_FechaFin ;
      private DateTime[] T00045_A31TrActividades_FechaCreacion ;
      private bool[] T00045_n31TrActividades_FechaCreacion ;
      private DateTime[] T00045_A32TrActividades_FechaModificacion ;
      private bool[] T00045_n32TrActividades_FechaModificacion ;
      private short[] T00045_A33TrActividades_Estado ;
      private bool[] T00045_n33TrActividades_Estado ;
      private long[] T00045_A25TrActividades_IDTarea ;
      private bool[] T00045_n25TrActividades_IDTarea ;
      private long[] T00044_A25TrActividades_IDTarea ;
      private bool[] T00044_n25TrActividades_IDTarea ;
      private long[] T00046_A25TrActividades_IDTarea ;
      private bool[] T00046_n25TrActividades_IDTarea ;
      private long[] T00047_A26TrActividades_ID ;
      private long[] T00043_A26TrActividades_ID ;
      private String[] T00043_A27TrActividades_Nombre ;
      private bool[] T00043_n27TrActividades_Nombre ;
      private String[] T00043_A28TrActividades_Descripcion ;
      private bool[] T00043_n28TrActividades_Descripcion ;
      private DateTime[] T00043_A29TrActividades_FechaInicio ;
      private bool[] T00043_n29TrActividades_FechaInicio ;
      private DateTime[] T00043_A30TrActividades_FechaFin ;
      private bool[] T00043_n30TrActividades_FechaFin ;
      private DateTime[] T00043_A31TrActividades_FechaCreacion ;
      private bool[] T00043_n31TrActividades_FechaCreacion ;
      private DateTime[] T00043_A32TrActividades_FechaModificacion ;
      private bool[] T00043_n32TrActividades_FechaModificacion ;
      private short[] T00043_A33TrActividades_Estado ;
      private bool[] T00043_n33TrActividades_Estado ;
      private long[] T00043_A25TrActividades_IDTarea ;
      private bool[] T00043_n25TrActividades_IDTarea ;
      private long[] T00048_A26TrActividades_ID ;
      private long[] T00049_A26TrActividades_ID ;
      private long[] T00042_A26TrActividades_ID ;
      private String[] T00042_A27TrActividades_Nombre ;
      private bool[] T00042_n27TrActividades_Nombre ;
      private String[] T00042_A28TrActividades_Descripcion ;
      private bool[] T00042_n28TrActividades_Descripcion ;
      private DateTime[] T00042_A29TrActividades_FechaInicio ;
      private bool[] T00042_n29TrActividades_FechaInicio ;
      private DateTime[] T00042_A30TrActividades_FechaFin ;
      private bool[] T00042_n30TrActividades_FechaFin ;
      private DateTime[] T00042_A31TrActividades_FechaCreacion ;
      private bool[] T00042_n31TrActividades_FechaCreacion ;
      private DateTime[] T00042_A32TrActividades_FechaModificacion ;
      private bool[] T00042_n32TrActividades_FechaModificacion ;
      private short[] T00042_A33TrActividades_Estado ;
      private bool[] T00042_n33TrActividades_Estado ;
      private long[] T00042_A25TrActividades_IDTarea ;
      private bool[] T00042_n25TrActividades_IDTarea ;
      private long[] T000413_A26TrActividades_ID ;
      private long[] T000414_A25TrActividades_IDTarea ;
      private bool[] T000414_n25TrActividades_IDTarea ;
      private GXWebForm Form ;
   }

   public class tractividades__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00045 ;
          prmT00045 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00044 ;
          prmT00044 = new Object[] {
          new Object[] {"@TrActividades_IDTarea",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00046 ;
          prmT00046 = new Object[] {
          new Object[] {"@TrActividades_IDTarea",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00047 ;
          prmT00047 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00043 ;
          prmT00043 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00048 ;
          prmT00048 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00049 ;
          prmT00049 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00042 ;
          prmT00042 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000410 ;
          prmT000410 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@TrActividades_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@TrActividades_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrActividades_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrActividades_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrActividades_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrActividades_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrActividades_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrActividades_IDTarea",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000411 ;
          prmT000411 = new Object[] {
          new Object[] {"@TrActividades_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@TrActividades_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrActividades_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrActividades_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrActividades_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrActividades_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrActividades_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrActividades_IDTarea",SqlDbType.Decimal,13,0} ,
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000412 ;
          prmT000412 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000413 ;
          prmT000413 = new Object[] {
          } ;
          Object[] prmT000414 ;
          prmT000414 = new Object[] {
          new Object[] {"@TrActividades_IDTarea",SqlDbType.Decimal,13,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T00042", "SELECT [TrActividades_ID], [TrActividades_Nombre], [TrActividades_Descripcion], [TrActividades_FechaInicio], [TrActividades_FechaFin], [TrActividades_FechaCreacion], [TrActividades_FechaModificacion], [TrActividades_Estado], [TrActividades_IDTarea] AS TrActividades_IDTarea FROM TABLERO.[TrActividades] WITH (UPDLOCK) WHERE [TrActividades_ID] = @TrActividades_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00043", "SELECT [TrActividades_ID], [TrActividades_Nombre], [TrActividades_Descripcion], [TrActividades_FechaInicio], [TrActividades_FechaFin], [TrActividades_FechaCreacion], [TrActividades_FechaModificacion], [TrActividades_Estado], [TrActividades_IDTarea] AS TrActividades_IDTarea FROM TABLERO.[TrActividades] WHERE [TrActividades_ID] = @TrActividades_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00044", "SELECT [TrGestionTareas_ID] AS TrActividades_IDTarea FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_ID] = @TrActividades_IDTarea ",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00045", "SELECT TM1.[TrActividades_ID], TM1.[TrActividades_Nombre], TM1.[TrActividades_Descripcion], TM1.[TrActividades_FechaInicio], TM1.[TrActividades_FechaFin], TM1.[TrActividades_FechaCreacion], TM1.[TrActividades_FechaModificacion], TM1.[TrActividades_Estado], TM1.[TrActividades_IDTarea] AS TrActividades_IDTarea FROM TABLERO.[TrActividades] TM1 WHERE TM1.[TrActividades_ID] = @TrActividades_ID ORDER BY TM1.[TrActividades_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00046", "SELECT [TrGestionTareas_ID] AS TrActividades_IDTarea FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_ID] = @TrActividades_IDTarea ",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00047", "SELECT [TrActividades_ID] FROM TABLERO.[TrActividades] WHERE [TrActividades_ID] = @TrActividades_ID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00047,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00048", "SELECT TOP 1 [TrActividades_ID] FROM TABLERO.[TrActividades] WHERE ( [TrActividades_ID] > @TrActividades_ID) ORDER BY [TrActividades_ID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00049", "SELECT TOP 1 [TrActividades_ID] FROM TABLERO.[TrActividades] WHERE ( [TrActividades_ID] < @TrActividades_ID) ORDER BY [TrActividades_ID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000410", "INSERT INTO TABLERO.[TrActividades]([TrActividades_ID], [TrActividades_Nombre], [TrActividades_Descripcion], [TrActividades_FechaInicio], [TrActividades_FechaFin], [TrActividades_FechaCreacion], [TrActividades_FechaModificacion], [TrActividades_Estado], [TrActividades_IDTarea]) VALUES(@TrActividades_ID, @TrActividades_Nombre, @TrActividades_Descripcion, @TrActividades_FechaInicio, @TrActividades_FechaFin, @TrActividades_FechaCreacion, @TrActividades_FechaModificacion, @TrActividades_Estado, @TrActividades_IDTarea)", GxErrorMask.GX_NOMASK,prmT000410)
             ,new CursorDef("T000411", "UPDATE TABLERO.[TrActividades] SET [TrActividades_Nombre]=@TrActividades_Nombre, [TrActividades_Descripcion]=@TrActividades_Descripcion, [TrActividades_FechaInicio]=@TrActividades_FechaInicio, [TrActividades_FechaFin]=@TrActividades_FechaFin, [TrActividades_FechaCreacion]=@TrActividades_FechaCreacion, [TrActividades_FechaModificacion]=@TrActividades_FechaModificacion, [TrActividades_Estado]=@TrActividades_Estado, [TrActividades_IDTarea]=@TrActividades_IDTarea  WHERE [TrActividades_ID] = @TrActividades_ID", GxErrorMask.GX_NOMASK,prmT000411)
             ,new CursorDef("T000412", "DELETE FROM TABLERO.[TrActividades]  WHERE [TrActividades_ID] = @TrActividades_ID", GxErrorMask.GX_NOMASK,prmT000412)
             ,new CursorDef("T000413", "SELECT [TrActividades_ID] FROM TABLERO.[TrActividades] ORDER BY [TrActividades_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000413,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000414", "SELECT [TrGestionTareas_ID] AS TrActividades_IDTarea FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_ID] = @TrActividades_IDTarea ",true, GxErrorMask.GX_NOMASK, false, this,prmT000414,1, GxCacheFrequency.OFF ,true,false )
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
                ((String[]) buf[1])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((long[]) buf[15])[0] = rslt.getLong(9) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((long[]) buf[15])[0] = rslt.getLong(9) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((long[]) buf[15])[0] = rslt.getLong(9) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
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
             case 11 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 12 :
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
                stmt.SetParameter(1, (long)parms[0]);
                if ( (bool)parms[1] )
                {
                   stmt.setNull( 2 , SqlDbType.NChar );
                }
                else
                {
                   stmt.SetParameter(2, (String)parms[2]);
                }
                if ( (bool)parms[3] )
                {
                   stmt.setNull( 3 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(3, (String)parms[4]);
                }
                if ( (bool)parms[5] )
                {
                   stmt.setNull( 4 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(4, (DateTime)parms[6]);
                }
                if ( (bool)parms[7] )
                {
                   stmt.setNull( 5 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(5, (DateTime)parms[8]);
                }
                if ( (bool)parms[9] )
                {
                   stmt.setNull( 6 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(6, (DateTime)parms[10]);
                }
                if ( (bool)parms[11] )
                {
                   stmt.setNull( 7 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(7, (DateTime)parms[12]);
                }
                if ( (bool)parms[13] )
                {
                   stmt.setNull( 8 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(8, (short)parms[14]);
                }
                if ( (bool)parms[15] )
                {
                   stmt.setNull( 9 , SqlDbType.Decimal );
                }
                else
                {
                   stmt.SetParameter(9, (long)parms[16]);
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
                   stmt.setNull( 2 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(2, (String)parms[3]);
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
                   stmt.setNull( 4 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(4, (DateTime)parms[7]);
                }
                if ( (bool)parms[8] )
                {
                   stmt.setNull( 5 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(5, (DateTime)parms[9]);
                }
                if ( (bool)parms[10] )
                {
                   stmt.setNull( 6 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(6, (DateTime)parms[11]);
                }
                if ( (bool)parms[12] )
                {
                   stmt.setNull( 7 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(7, (short)parms[13]);
                }
                if ( (bool)parms[14] )
                {
                   stmt.setNull( 8 , SqlDbType.Decimal );
                }
                else
                {
                   stmt.SetParameter(8, (long)parms[15]);
                }
                stmt.SetParameter(9, (long)parms[16]);
                return;
             case 10 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 12 :
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
