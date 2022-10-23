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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
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
            gxLoad_14( A25TrActividades_IDTarea) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridtractividades_level1") == 0 )
         {
            nRC_GXsfl_74 = (int)(NumberUtil.Val( GetNextPar( ), "."));
            nGXsfl_74_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
            sGXsfl_74_idx = GetNextPar( );
            Gx_BScreen = (short)(NumberUtil.Val( GetNextPar( ), "."));
            Gx_mode = GetNextPar( );
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridtractividades_level1_newrow( ) ;
            return  ;
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
         cmbTrListaActividad_Estado = new GXCombobox();
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
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TRACTIVIDADES_ID"+"'), id:'"+"TRACTIVIDADES_ID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_TrActividades.htm");
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
         GxWebStd.gx_single_line_edit( context, edtTrActividades_FechaInicio_Internalname, context.localUtil.Format(A29TrActividades_FechaInicio, "99/99/9999"), context.localUtil.Format( A29TrActividades_FechaInicio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrActividades_FechaInicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrActividades_FechaInicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrActividades.htm");
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
         GxWebStd.gx_single_line_edit( context, edtTrActividades_FechaFin_Internalname, context.localUtil.Format(A30TrActividades_FechaFin, "99/99/9999"), context.localUtil.Format( A30TrActividades_FechaFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrActividades_FechaFin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrActividades_FechaFin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrActividades.htm");
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
         GxWebStd.gx_single_line_edit( context, edtTrActividades_FechaCreacion_Internalname, context.localUtil.Format(A31TrActividades_FechaCreacion, "99/99/9999"), context.localUtil.Format( A31TrActividades_FechaCreacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrActividades_FechaCreacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrActividades_FechaCreacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrActividades.htm");
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
         GxWebStd.gx_single_line_edit( context, edtTrActividades_FechaModificacion_Internalname, context.localUtil.Format(A32TrActividades_FechaModificacion, "99/99/9999"), context.localUtil.Format( A32TrActividades_FechaModificacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrActividades_FechaModificacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrActividades_FechaModificacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrActividades.htm");
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
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlelevel1_Internalname, "Level1", "", "", lblTitlelevel1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_TrActividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         gxdraw_Gridtractividades_level1( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrActividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrActividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrActividades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridtractividades_level1( )
      {
         /*  Grid Control  */
         Gridtractividades_level1Container.AddObjectProperty("GridName", "Gridtractividades_level1");
         Gridtractividades_level1Container.AddObjectProperty("Header", subGridtractividades_level1_Header);
         Gridtractividades_level1Container.AddObjectProperty("Class", "Grid");
         Gridtractividades_level1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridtractividades_level1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridtractividades_level1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtractividades_level1_Backcolorstyle), 1, 0, ".", "")));
         Gridtractividades_level1Container.AddObjectProperty("CmpContext", "");
         Gridtractividades_level1Container.AddObjectProperty("InMasterPage", "false");
         Gridtractividades_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtractividades_level1Column.AddObjectProperty("Value", A55TrListaActividad_ID.ToString());
         Gridtractividades_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_ID_Enabled), 5, 0, ".", "")));
         Gridtractividades_level1Container.AddColumnProperties(Gridtractividades_level1Column);
         Gridtractividades_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtractividades_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A56TrListaActividad_Nombre));
         Gridtractividades_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_Nombre_Enabled), 5, 0, ".", "")));
         Gridtractividades_level1Container.AddColumnProperties(Gridtractividades_level1Column);
         Gridtractividades_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtractividades_level1Column.AddObjectProperty("Value", A57TrListaActividad_Descripcion);
         Gridtractividades_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_Descripcion_Enabled), 5, 0, ".", "")));
         Gridtractividades_level1Container.AddColumnProperties(Gridtractividades_level1Column);
         Gridtractividades_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtractividades_level1Column.AddObjectProperty("Value", context.localUtil.Format(A58TrListaActividad_FechaInicio, "99/99/9999"));
         Gridtractividades_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_FechaInicio_Enabled), 5, 0, ".", "")));
         Gridtractividades_level1Container.AddColumnProperties(Gridtractividades_level1Column);
         Gridtractividades_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtractividades_level1Column.AddObjectProperty("Value", context.localUtil.Format(A59TrListaActividad_FechaFin, "99/99/9999"));
         Gridtractividades_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_FechaFin_Enabled), 5, 0, ".", "")));
         Gridtractividades_level1Container.AddColumnProperties(Gridtractividades_level1Column);
         Gridtractividades_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtractividades_level1Column.AddObjectProperty("Value", context.localUtil.Format(A60TrListaActividad_FechaCreacion, "99/99/9999"));
         Gridtractividades_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_FechaCreacion_Enabled), 5, 0, ".", "")));
         Gridtractividades_level1Container.AddColumnProperties(Gridtractividades_level1Column);
         Gridtractividades_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtractividades_level1Column.AddObjectProperty("Value", context.localUtil.Format(A61TrListaActividad_FechaModificacion, "99/99/9999"));
         Gridtractividades_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_FechaModificacion_Enabled), 5, 0, ".", "")));
         Gridtractividades_level1Container.AddColumnProperties(Gridtractividades_level1Column);
         Gridtractividades_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtractividades_level1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A62TrListaActividad_Estado), 4, 0, ".", "")));
         Gridtractividades_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbTrListaActividad_Estado.Enabled), 5, 0, ".", "")));
         Gridtractividades_level1Container.AddColumnProperties(Gridtractividades_level1Column);
         Gridtractividades_level1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtractividades_level1_Selectedindex), 4, 0, ".", "")));
         Gridtractividades_level1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtractividades_level1_Allowselection), 1, 0, ".", "")));
         Gridtractividades_level1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtractividades_level1_Selectioncolor), 9, 0, ".", "")));
         Gridtractividades_level1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtractividades_level1_Allowhovering), 1, 0, ".", "")));
         Gridtractividades_level1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtractividades_level1_Hoveringcolor), 9, 0, ".", "")));
         Gridtractividades_level1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtractividades_level1_Allowcollapsing), 1, 0, ".", "")));
         Gridtractividades_level1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtractividades_level1_Collapsed), 1, 0, ".", "")));
         nGXsfl_74_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount9 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_9 = 1;
               ScanStart049( ) ;
               while ( RcdFound9 != 0 )
               {
                  init_level_properties9( ) ;
                  getByPrimaryKey049( ) ;
                  AddRow049( ) ;
                  ScanNext049( ) ;
               }
               ScanEnd049( ) ;
               nBlankRcdCount9 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal049( ) ;
            standaloneModal049( ) ;
            sMode9 = Gx_mode;
            while ( nGXsfl_74_idx < nRC_GXsfl_74 )
            {
               bGXsfl_74_Refreshing = true;
               ReadRow049( ) ;
               edtTrListaActividad_ID_Enabled = (int)(context.localUtil.CToN( cgiGet( "TRLISTAACTIVIDAD_ID_"+sGXsfl_74_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtTrListaActividad_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrListaActividad_ID_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               edtTrListaActividad_Nombre_Enabled = (int)(context.localUtil.CToN( cgiGet( "TRLISTAACTIVIDAD_NOMBRE_"+sGXsfl_74_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtTrListaActividad_Nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrListaActividad_Nombre_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               edtTrListaActividad_Descripcion_Enabled = (int)(context.localUtil.CToN( cgiGet( "TRLISTAACTIVIDAD_DESCRIPCION_"+sGXsfl_74_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtTrListaActividad_Descripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrListaActividad_Descripcion_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               edtTrListaActividad_FechaInicio_Enabled = (int)(context.localUtil.CToN( cgiGet( "TRLISTAACTIVIDAD_FECHAINICIO_"+sGXsfl_74_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtTrListaActividad_FechaInicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrListaActividad_FechaInicio_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               edtTrListaActividad_FechaFin_Enabled = (int)(context.localUtil.CToN( cgiGet( "TRLISTAACTIVIDAD_FECHAFIN_"+sGXsfl_74_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtTrListaActividad_FechaFin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrListaActividad_FechaFin_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               edtTrListaActividad_FechaCreacion_Enabled = (int)(context.localUtil.CToN( cgiGet( "TRLISTAACTIVIDAD_FECHACREACION_"+sGXsfl_74_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtTrListaActividad_FechaCreacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrListaActividad_FechaCreacion_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               edtTrListaActividad_FechaModificacion_Enabled = (int)(context.localUtil.CToN( cgiGet( "TRLISTAACTIVIDAD_FECHAMODIFICACION_"+sGXsfl_74_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtTrListaActividad_FechaModificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrListaActividad_FechaModificacion_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               cmbTrListaActividad_Estado.Enabled = (int)(context.localUtil.CToN( cgiGet( "TRLISTAACTIVIDAD_ESTADO_"+sGXsfl_74_idx+"Enabled"), ".", ","));
               AssignProp("", false, cmbTrListaActividad_Estado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTrListaActividad_Estado.Enabled), 5, 0), !bGXsfl_74_Refreshing);
               if ( ( nRcdExists_9 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal049( ) ;
               }
               SendRow049( ) ;
               bGXsfl_74_Refreshing = false;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount9 = 5;
            nRcdExists_9 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart049( ) ;
               while ( RcdFound9 != 0 )
               {
                  sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_749( ) ;
                  init_level_properties9( ) ;
                  standaloneNotModal049( ) ;
                  getByPrimaryKey049( ) ;
                  standaloneModal049( ) ;
                  AddRow049( ) ;
                  ScanNext049( ) ;
               }
               ScanEnd049( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode9 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx+1), 4, 0), 4, "0");
         SubsflControlProps_749( ) ;
         InitAll049( ) ;
         init_level_properties9( ) ;
         nRcdExists_9 = 0;
         nIsMod_9 = 0;
         nRcdDeleted_9 = 0;
         nBlankRcdCount9 = (short)(nBlankRcdUsr9+nBlankRcdCount9);
         fRowAdded = 0;
         while ( nBlankRcdCount9 > 0 )
         {
            A55TrListaActividad_ID = (Guid)(Guid.Empty);
            standaloneNotModal049( ) ;
            standaloneModal049( ) ;
            AddRow049( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtTrListaActividad_ID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount9 = (short)(nBlankRcdCount9-1);
         }
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridtractividades_level1Container"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridtractividades_level1", Gridtractividades_level1Container);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridtractividades_level1ContainerData", Gridtractividades_level1Container.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridtractividades_level1ContainerData"+"V", Gridtractividades_level1Container.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridtractividades_level1ContainerData"+"V"+"\" value='"+Gridtractividades_level1Container.GridValuesHidden()+"'/>") ;
         }
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
            nRC_GXsfl_74 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_74"), ".", ","));
            Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
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
            if ( context.localUtil.VCDate( cgiGet( edtTrActividades_FechaInicio_Internalname), 2) == 0 )
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
               A29TrActividades_FechaInicio = context.localUtil.CToD( cgiGet( edtTrActividades_FechaInicio_Internalname), 2);
               n29TrActividades_FechaInicio = false;
               AssignAttri("", false, "A29TrActividades_FechaInicio", context.localUtil.Format(A29TrActividades_FechaInicio, "99/99/9999"));
            }
            n29TrActividades_FechaInicio = ((DateTime.MinValue==A29TrActividades_FechaInicio) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrActividades_FechaFin_Internalname), 2) == 0 )
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
               A30TrActividades_FechaFin = context.localUtil.CToD( cgiGet( edtTrActividades_FechaFin_Internalname), 2);
               n30TrActividades_FechaFin = false;
               AssignAttri("", false, "A30TrActividades_FechaFin", context.localUtil.Format(A30TrActividades_FechaFin, "99/99/9999"));
            }
            n30TrActividades_FechaFin = ((DateTime.MinValue==A30TrActividades_FechaFin) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrActividades_FechaCreacion_Internalname), 2) == 0 )
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
               A31TrActividades_FechaCreacion = context.localUtil.CToD( cgiGet( edtTrActividades_FechaCreacion_Internalname), 2);
               n31TrActividades_FechaCreacion = false;
               AssignAttri("", false, "A31TrActividades_FechaCreacion", context.localUtil.Format(A31TrActividades_FechaCreacion, "99/99/9999"));
            }
            n31TrActividades_FechaCreacion = ((DateTime.MinValue==A31TrActividades_FechaCreacion) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrActividades_FechaModificacion_Internalname), 2) == 0 )
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
               A32TrActividades_FechaModificacion = context.localUtil.CToD( cgiGet( edtTrActividades_FechaModificacion_Internalname), 2);
               n32TrActividades_FechaModificacion = false;
               AssignAttri("", false, "A32TrActividades_FechaModificacion", context.localUtil.Format(A32TrActividades_FechaModificacion, "99/99/9999"));
            }
            n32TrActividades_FechaModificacion = ((DateTime.MinValue==A32TrActividades_FechaModificacion) ? true : false);
            cmbTrActividades_Estado.Name = cmbTrActividades_Estado_Internalname;
            cmbTrActividades_Estado.CurrentValue = cgiGet( cmbTrActividades_Estado_Internalname);
            A33TrActividades_Estado = (short)(NumberUtil.Val( cgiGet( cmbTrActividades_Estado_Internalname), "."));
            n33TrActividades_Estado = false;
            AssignAttri("", false, "A33TrActividades_Estado", StringUtil.LTrimStr( (decimal)(A33TrActividades_Estado), 4, 0));
            n33TrActividades_Estado = ((0==A33TrActividades_Estado) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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

      protected void CONFIRM_049( )
      {
         nGXsfl_74_idx = 0;
         while ( nGXsfl_74_idx < nRC_GXsfl_74 )
         {
            ReadRow049( ) ;
            if ( ( nRcdExists_9 != 0 ) || ( nIsMod_9 != 0 ) )
            {
               GetKey049( ) ;
               if ( ( nRcdExists_9 == 0 ) && ( nRcdDeleted_9 == 0 ) )
               {
                  if ( RcdFound9 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate049( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable049( ) ;
                        CloseExtendedTableCursors049( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "TRLISTAACTIVIDAD_ID_" + sGXsfl_74_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtTrListaActividad_ID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound9 != 0 )
                  {
                     if ( nRcdDeleted_9 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey049( ) ;
                        Load049( ) ;
                        BeforeValidate049( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls049( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_9 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate049( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable049( ) ;
                              CloseExtendedTableCursors049( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_9 == 0 )
                     {
                        GXCCtl = "TRLISTAACTIVIDAD_ID_" + sGXsfl_74_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtTrListaActividad_ID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtTrListaActividad_ID_Internalname, A55TrListaActividad_ID.ToString()) ;
            ChangePostValue( edtTrListaActividad_Nombre_Internalname, StringUtil.RTrim( A56TrListaActividad_Nombre)) ;
            ChangePostValue( edtTrListaActividad_Descripcion_Internalname, A57TrListaActividad_Descripcion) ;
            ChangePostValue( edtTrListaActividad_FechaInicio_Internalname, context.localUtil.Format(A58TrListaActividad_FechaInicio, "99/99/9999")) ;
            ChangePostValue( edtTrListaActividad_FechaFin_Internalname, context.localUtil.Format(A59TrListaActividad_FechaFin, "99/99/9999")) ;
            ChangePostValue( edtTrListaActividad_FechaCreacion_Internalname, context.localUtil.Format(A60TrListaActividad_FechaCreacion, "99/99/9999")) ;
            ChangePostValue( edtTrListaActividad_FechaModificacion_Internalname, context.localUtil.Format(A61TrListaActividad_FechaModificacion, "99/99/9999")) ;
            ChangePostValue( cmbTrListaActividad_Estado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A62TrListaActividad_Estado), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z55TrListaActividad_ID_"+sGXsfl_74_idx, Z55TrListaActividad_ID.ToString()) ;
            ChangePostValue( "ZT_"+"Z56TrListaActividad_Nombre_"+sGXsfl_74_idx, StringUtil.RTrim( Z56TrListaActividad_Nombre)) ;
            ChangePostValue( "ZT_"+"Z58TrListaActividad_FechaInicio_"+sGXsfl_74_idx, context.localUtil.DToC( Z58TrListaActividad_FechaInicio, 0, "/")) ;
            ChangePostValue( "ZT_"+"Z59TrListaActividad_FechaFin_"+sGXsfl_74_idx, context.localUtil.DToC( Z59TrListaActividad_FechaFin, 0, "/")) ;
            ChangePostValue( "ZT_"+"Z60TrListaActividad_FechaCreacion_"+sGXsfl_74_idx, context.localUtil.DToC( Z60TrListaActividad_FechaCreacion, 0, "/")) ;
            ChangePostValue( "ZT_"+"Z61TrListaActividad_FechaModificacion_"+sGXsfl_74_idx, context.localUtil.DToC( Z61TrListaActividad_FechaModificacion, 0, "/")) ;
            ChangePostValue( "ZT_"+"Z62TrListaActividad_Estado_"+sGXsfl_74_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z62TrListaActividad_Estado), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_9_"+sGXsfl_74_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_9), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_9_"+sGXsfl_74_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_9), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_9_"+sGXsfl_74_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_9), 4, 0, ".", ""))) ;
            if ( nIsMod_9 != 0 )
            {
               ChangePostValue( "TRLISTAACTIVIDAD_ID_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_ID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TRLISTAACTIVIDAD_NOMBRE_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_Nombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TRLISTAACTIVIDAD_DESCRIPCION_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_Descripcion_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TRLISTAACTIVIDAD_FECHAINICIO_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_FechaInicio_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TRLISTAACTIVIDAD_FECHAFIN_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_FechaFin_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TRLISTAACTIVIDAD_FECHACREACION_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_FechaCreacion_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TRLISTAACTIVIDAD_FECHAMODIFICACION_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_FechaModificacion_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TRLISTAACTIVIDAD_ESTADO_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbTrListaActividad_Estado.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption040( )
      {
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z27TrActividades_Nombre = T00045_A27TrActividades_Nombre[0];
               Z29TrActividades_FechaInicio = T00045_A29TrActividades_FechaInicio[0];
               Z30TrActividades_FechaFin = T00045_A30TrActividades_FechaFin[0];
               Z31TrActividades_FechaCreacion = T00045_A31TrActividades_FechaCreacion[0];
               Z32TrActividades_FechaModificacion = T00045_A32TrActividades_FechaModificacion[0];
               Z33TrActividades_Estado = T00045_A33TrActividades_Estado[0];
               Z25TrActividades_IDTarea = T00045_A25TrActividades_IDTarea[0];
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
         if ( GX_JID == -13 )
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
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
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
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {A26TrActividades_ID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound4 = 1;
            A27TrActividades_Nombre = T00047_A27TrActividades_Nombre[0];
            n27TrActividades_Nombre = T00047_n27TrActividades_Nombre[0];
            AssignAttri("", false, "A27TrActividades_Nombre", A27TrActividades_Nombre);
            A28TrActividades_Descripcion = T00047_A28TrActividades_Descripcion[0];
            n28TrActividades_Descripcion = T00047_n28TrActividades_Descripcion[0];
            AssignAttri("", false, "A28TrActividades_Descripcion", A28TrActividades_Descripcion);
            A29TrActividades_FechaInicio = T00047_A29TrActividades_FechaInicio[0];
            n29TrActividades_FechaInicio = T00047_n29TrActividades_FechaInicio[0];
            AssignAttri("", false, "A29TrActividades_FechaInicio", context.localUtil.Format(A29TrActividades_FechaInicio, "99/99/9999"));
            A30TrActividades_FechaFin = T00047_A30TrActividades_FechaFin[0];
            n30TrActividades_FechaFin = T00047_n30TrActividades_FechaFin[0];
            AssignAttri("", false, "A30TrActividades_FechaFin", context.localUtil.Format(A30TrActividades_FechaFin, "99/99/9999"));
            A31TrActividades_FechaCreacion = T00047_A31TrActividades_FechaCreacion[0];
            n31TrActividades_FechaCreacion = T00047_n31TrActividades_FechaCreacion[0];
            AssignAttri("", false, "A31TrActividades_FechaCreacion", context.localUtil.Format(A31TrActividades_FechaCreacion, "99/99/9999"));
            A32TrActividades_FechaModificacion = T00047_A32TrActividades_FechaModificacion[0];
            n32TrActividades_FechaModificacion = T00047_n32TrActividades_FechaModificacion[0];
            AssignAttri("", false, "A32TrActividades_FechaModificacion", context.localUtil.Format(A32TrActividades_FechaModificacion, "99/99/9999"));
            A33TrActividades_Estado = T00047_A33TrActividades_Estado[0];
            n33TrActividades_Estado = T00047_n33TrActividades_Estado[0];
            AssignAttri("", false, "A33TrActividades_Estado", StringUtil.LTrimStr( (decimal)(A33TrActividades_Estado), 4, 0));
            A25TrActividades_IDTarea = T00047_A25TrActividades_IDTarea[0];
            n25TrActividades_IDTarea = T00047_n25TrActividades_IDTarea[0];
            AssignAttri("", false, "A25TrActividades_IDTarea", StringUtil.LTrimStr( (decimal)(A25TrActividades_IDTarea), 13, 0));
            ZM044( -13) ;
         }
         pr_default.close(5);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
      }

      protected void CheckExtendedTable044( )
      {
         nIsDirty_4 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {n25TrActividades_IDTarea, A25TrActividades_IDTarea});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A25TrActividades_IDTarea) ) )
            {
               GX_msglist.addItem("No existe 'Tr Gestion Tareas_STG'.", "ForeignKeyNotFound", 1, "TRACTIVIDADES_IDTAREA");
               AnyError = 1;
               GX_FocusControl = edtTrActividades_IDTarea_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
         if ( ! ( (DateTime.MinValue==A29TrActividades_FechaInicio) || ( A29TrActividades_FechaInicio >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Tr Actividades_Fecha Inicio fuera de rango", "OutOfRange", 1, "TRACTIVIDADES_FECHAINICIO");
            AnyError = 1;
            GX_FocusControl = edtTrActividades_FechaInicio_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A30TrActividades_FechaFin) || ( A30TrActividades_FechaFin >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Tr Actividades_Fecha Fin fuera de rango", "OutOfRange", 1, "TRACTIVIDADES_FECHAFIN");
            AnyError = 1;
            GX_FocusControl = edtTrActividades_FechaFin_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A31TrActividades_FechaCreacion) || ( A31TrActividades_FechaCreacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Tr Actividades_Fecha Creacion fuera de rango", "OutOfRange", 1, "TRACTIVIDADES_FECHACREACION");
            AnyError = 1;
            GX_FocusControl = edtTrActividades_FechaCreacion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A32TrActividades_FechaModificacion) || ( A32TrActividades_FechaModificacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Tr Actividades_Fecha Modificacion fuera de rango", "OutOfRange", 1, "TRACTIVIDADES_FECHAMODIFICACION");
            AnyError = 1;
            GX_FocusControl = edtTrActividades_FechaModificacion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( A33TrActividades_Estado == 1 ) || ( A33TrActividades_Estado == 2 ) || ( A33TrActividades_Estado == 3 ) || ( A33TrActividades_Estado == 4 ) || ( A33TrActividades_Estado == 5 ) || (0==A33TrActividades_Estado) ) )
         {
            GX_msglist.addItem("Campo Tr Actividades_Estado fuera de rango", "OutOfRange", 1, "TRACTIVIDADES_ESTADO");
            AnyError = 1;
            GX_FocusControl = cmbTrActividades_Estado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors044( )
      {
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_14( long A25TrActividades_IDTarea )
      {
         /* Using cursor T00048 */
         pr_default.execute(6, new Object[] {n25TrActividades_IDTarea, A25TrActividades_IDTarea});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A25TrActividades_IDTarea) ) )
            {
               GX_msglist.addItem("No existe 'Tr Gestion Tareas_STG'.", "ForeignKeyNotFound", 1, "TRACTIVIDADES_IDTAREA");
               AnyError = 1;
               GX_FocusControl = edtTrActividades_IDTarea_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey044( )
      {
         /* Using cursor T00049 */
         pr_default.execute(7, new Object[] {A26TrActividades_ID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00045 */
         pr_default.execute(3, new Object[] {A26TrActividades_ID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM044( 13) ;
            RcdFound4 = 1;
            A26TrActividades_ID = T00045_A26TrActividades_ID[0];
            AssignAttri("", false, "A26TrActividades_ID", StringUtil.LTrimStr( (decimal)(A26TrActividades_ID), 13, 0));
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
         pr_default.close(3);
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
         /* Using cursor T000410 */
         pr_default.execute(8, new Object[] {A26TrActividades_ID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000410_A26TrActividades_ID[0] < A26TrActividades_ID ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000410_A26TrActividades_ID[0] > A26TrActividades_ID ) ) )
            {
               A26TrActividades_ID = T000410_A26TrActividades_ID[0];
               AssignAttri("", false, "A26TrActividades_ID", StringUtil.LTrimStr( (decimal)(A26TrActividades_ID), 13, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound4 = 0;
         /* Using cursor T000411 */
         pr_default.execute(9, new Object[] {A26TrActividades_ID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000411_A26TrActividades_ID[0] > A26TrActividades_ID ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000411_A26TrActividades_ID[0] < A26TrActividades_ID ) ) )
            {
               A26TrActividades_ID = T000411_A26TrActividades_ID[0];
               AssignAttri("", false, "A26TrActividades_ID", StringUtil.LTrimStr( (decimal)(A26TrActividades_ID), 13, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(9);
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
            /* Using cursor T00044 */
            pr_default.execute(2, new Object[] {A26TrActividades_ID});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrActividades"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z27TrActividades_Nombre, T00044_A27TrActividades_Nombre[0]) != 0 ) || ( Z29TrActividades_FechaInicio != T00044_A29TrActividades_FechaInicio[0] ) || ( Z30TrActividades_FechaFin != T00044_A30TrActividades_FechaFin[0] ) || ( Z31TrActividades_FechaCreacion != T00044_A31TrActividades_FechaCreacion[0] ) || ( Z32TrActividades_FechaModificacion != T00044_A32TrActividades_FechaModificacion[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z33TrActividades_Estado != T00044_A33TrActividades_Estado[0] ) || ( Z25TrActividades_IDTarea != T00044_A25TrActividades_IDTarea[0] ) )
            {
               if ( StringUtil.StrCmp(Z27TrActividades_Nombre, T00044_A27TrActividades_Nombre[0]) != 0 )
               {
                  GXUtil.WriteLog("tractividades:[seudo value changed for attri]"+"TrActividades_Nombre");
                  GXUtil.WriteLogRaw("Old: ",Z27TrActividades_Nombre);
                  GXUtil.WriteLogRaw("Current: ",T00044_A27TrActividades_Nombre[0]);
               }
               if ( Z29TrActividades_FechaInicio != T00044_A29TrActividades_FechaInicio[0] )
               {
                  GXUtil.WriteLog("tractividades:[seudo value changed for attri]"+"TrActividades_FechaInicio");
                  GXUtil.WriteLogRaw("Old: ",Z29TrActividades_FechaInicio);
                  GXUtil.WriteLogRaw("Current: ",T00044_A29TrActividades_FechaInicio[0]);
               }
               if ( Z30TrActividades_FechaFin != T00044_A30TrActividades_FechaFin[0] )
               {
                  GXUtil.WriteLog("tractividades:[seudo value changed for attri]"+"TrActividades_FechaFin");
                  GXUtil.WriteLogRaw("Old: ",Z30TrActividades_FechaFin);
                  GXUtil.WriteLogRaw("Current: ",T00044_A30TrActividades_FechaFin[0]);
               }
               if ( Z31TrActividades_FechaCreacion != T00044_A31TrActividades_FechaCreacion[0] )
               {
                  GXUtil.WriteLog("tractividades:[seudo value changed for attri]"+"TrActividades_FechaCreacion");
                  GXUtil.WriteLogRaw("Old: ",Z31TrActividades_FechaCreacion);
                  GXUtil.WriteLogRaw("Current: ",T00044_A31TrActividades_FechaCreacion[0]);
               }
               if ( Z32TrActividades_FechaModificacion != T00044_A32TrActividades_FechaModificacion[0] )
               {
                  GXUtil.WriteLog("tractividades:[seudo value changed for attri]"+"TrActividades_FechaModificacion");
                  GXUtil.WriteLogRaw("Old: ",Z32TrActividades_FechaModificacion);
                  GXUtil.WriteLogRaw("Current: ",T00044_A32TrActividades_FechaModificacion[0]);
               }
               if ( Z33TrActividades_Estado != T00044_A33TrActividades_Estado[0] )
               {
                  GXUtil.WriteLog("tractividades:[seudo value changed for attri]"+"TrActividades_Estado");
                  GXUtil.WriteLogRaw("Old: ",Z33TrActividades_Estado);
                  GXUtil.WriteLogRaw("Current: ",T00044_A33TrActividades_Estado[0]);
               }
               if ( Z25TrActividades_IDTarea != T00044_A25TrActividades_IDTarea[0] )
               {
                  GXUtil.WriteLog("tractividades:[seudo value changed for attri]"+"TrActividades_IDTarea");
                  GXUtil.WriteLogRaw("Old: ",Z25TrActividades_IDTarea);
                  GXUtil.WriteLogRaw("Current: ",T00044_A25TrActividades_IDTarea[0]);
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
                     /* Using cursor T000412 */
                     pr_default.execute(10, new Object[] {n27TrActividades_Nombre, A27TrActividades_Nombre, n28TrActividades_Descripcion, A28TrActividades_Descripcion, n29TrActividades_FechaInicio, A29TrActividades_FechaInicio, n30TrActividades_FechaFin, A30TrActividades_FechaFin, n31TrActividades_FechaCreacion, A31TrActividades_FechaCreacion, n32TrActividades_FechaModificacion, A32TrActividades_FechaModificacion, n33TrActividades_Estado, A33TrActividades_Estado, n25TrActividades_IDTarea, A25TrActividades_IDTarea});
                     A26TrActividades_ID = T000412_A26TrActividades_ID[0];
                     AssignAttri("", false, "A26TrActividades_ID", StringUtil.LTrimStr( (decimal)(A26TrActividades_ID), 13, 0));
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("TrActividades") ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel044( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              GX_msglist.addItem(context.GetMessage( "GXM_sucadded", ""), "SuccessfullyAdded", 0, "", true);
                              ResetCaption040( ) ;
                           }
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
                     /* Using cursor T000413 */
                     pr_default.execute(11, new Object[] {n27TrActividades_Nombre, A27TrActividades_Nombre, n28TrActividades_Descripcion, A28TrActividades_Descripcion, n29TrActividades_FechaInicio, A29TrActividades_FechaInicio, n30TrActividades_FechaFin, A30TrActividades_FechaFin, n31TrActividades_FechaCreacion, A31TrActividades_FechaCreacion, n32TrActividades_FechaModificacion, A32TrActividades_FechaModificacion, n33TrActividades_Estado, A33TrActividades_Estado, n25TrActividades_IDTarea, A25TrActividades_IDTarea, A26TrActividades_ID});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("TrActividades") ;
                     if ( (pr_default.getStatus(11) == 103) )
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
                           ProcessLevel044( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              GX_msglist.addItem(context.GetMessage( "GXM_sucupdated", ""), "SuccessfullyUpdated", 0, "", true);
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
                  ScanStart049( ) ;
                  while ( RcdFound9 != 0 )
                  {
                     getByPrimaryKey049( ) ;
                     Delete049( ) ;
                     ScanNext049( ) ;
                  }
                  ScanEnd049( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000414 */
                     pr_default.execute(12, new Object[] {A26TrActividades_ID});
                     pr_default.close(12);
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

      protected void ProcessNestedLevel049( )
      {
         nGXsfl_74_idx = 0;
         while ( nGXsfl_74_idx < nRC_GXsfl_74 )
         {
            ReadRow049( ) ;
            if ( ( nRcdExists_9 != 0 ) || ( nIsMod_9 != 0 ) )
            {
               standaloneNotModal049( ) ;
               GetKey049( ) ;
               if ( ( nRcdExists_9 == 0 ) && ( nRcdDeleted_9 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert049( ) ;
               }
               else
               {
                  if ( RcdFound9 != 0 )
                  {
                     if ( ( nRcdDeleted_9 != 0 ) && ( nRcdExists_9 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete049( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_9 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update049( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_9 == 0 )
                     {
                        GXCCtl = "TRLISTAACTIVIDAD_ID_" + sGXsfl_74_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtTrListaActividad_ID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtTrListaActividad_ID_Internalname, A55TrListaActividad_ID.ToString()) ;
            ChangePostValue( edtTrListaActividad_Nombre_Internalname, StringUtil.RTrim( A56TrListaActividad_Nombre)) ;
            ChangePostValue( edtTrListaActividad_Descripcion_Internalname, A57TrListaActividad_Descripcion) ;
            ChangePostValue( edtTrListaActividad_FechaInicio_Internalname, context.localUtil.Format(A58TrListaActividad_FechaInicio, "99/99/9999")) ;
            ChangePostValue( edtTrListaActividad_FechaFin_Internalname, context.localUtil.Format(A59TrListaActividad_FechaFin, "99/99/9999")) ;
            ChangePostValue( edtTrListaActividad_FechaCreacion_Internalname, context.localUtil.Format(A60TrListaActividad_FechaCreacion, "99/99/9999")) ;
            ChangePostValue( edtTrListaActividad_FechaModificacion_Internalname, context.localUtil.Format(A61TrListaActividad_FechaModificacion, "99/99/9999")) ;
            ChangePostValue( cmbTrListaActividad_Estado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A62TrListaActividad_Estado), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z55TrListaActividad_ID_"+sGXsfl_74_idx, Z55TrListaActividad_ID.ToString()) ;
            ChangePostValue( "ZT_"+"Z56TrListaActividad_Nombre_"+sGXsfl_74_idx, StringUtil.RTrim( Z56TrListaActividad_Nombre)) ;
            ChangePostValue( "ZT_"+"Z58TrListaActividad_FechaInicio_"+sGXsfl_74_idx, context.localUtil.DToC( Z58TrListaActividad_FechaInicio, 0, "/")) ;
            ChangePostValue( "ZT_"+"Z59TrListaActividad_FechaFin_"+sGXsfl_74_idx, context.localUtil.DToC( Z59TrListaActividad_FechaFin, 0, "/")) ;
            ChangePostValue( "ZT_"+"Z60TrListaActividad_FechaCreacion_"+sGXsfl_74_idx, context.localUtil.DToC( Z60TrListaActividad_FechaCreacion, 0, "/")) ;
            ChangePostValue( "ZT_"+"Z61TrListaActividad_FechaModificacion_"+sGXsfl_74_idx, context.localUtil.DToC( Z61TrListaActividad_FechaModificacion, 0, "/")) ;
            ChangePostValue( "ZT_"+"Z62TrListaActividad_Estado_"+sGXsfl_74_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z62TrListaActividad_Estado), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_9_"+sGXsfl_74_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_9), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_9_"+sGXsfl_74_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_9), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_9_"+sGXsfl_74_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_9), 4, 0, ".", ""))) ;
            if ( nIsMod_9 != 0 )
            {
               ChangePostValue( "TRLISTAACTIVIDAD_ID_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_ID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TRLISTAACTIVIDAD_NOMBRE_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_Nombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TRLISTAACTIVIDAD_DESCRIPCION_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_Descripcion_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TRLISTAACTIVIDAD_FECHAINICIO_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_FechaInicio_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TRLISTAACTIVIDAD_FECHAFIN_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_FechaFin_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TRLISTAACTIVIDAD_FECHACREACION_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_FechaCreacion_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TRLISTAACTIVIDAD_FECHAMODIFICACION_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_FechaModificacion_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TRLISTAACTIVIDAD_ESTADO_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbTrListaActividad_Estado.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll049( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_9 = 0;
         nIsMod_9 = 0;
         nRcdDeleted_9 = 0;
      }

      protected void ProcessLevel044( )
      {
         /* Save parent mode. */
         sMode4 = Gx_mode;
         ProcessNestedLevel049( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode4;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel044( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
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
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
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
         /* Using cursor T000415 */
         pr_default.execute(13);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound4 = 1;
            A26TrActividades_ID = T000415_A26TrActividades_ID[0];
            AssignAttri("", false, "A26TrActividades_ID", StringUtil.LTrimStr( (decimal)(A26TrActividades_ID), 13, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound4 = 1;
            A26TrActividades_ID = T000415_A26TrActividades_ID[0];
            AssignAttri("", false, "A26TrActividades_ID", StringUtil.LTrimStr( (decimal)(A26TrActividades_ID), 13, 0));
         }
      }

      protected void ScanEnd044( )
      {
         pr_default.close(13);
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

      protected void ZM049( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z56TrListaActividad_Nombre = T00043_A56TrListaActividad_Nombre[0];
               Z58TrListaActividad_FechaInicio = T00043_A58TrListaActividad_FechaInicio[0];
               Z59TrListaActividad_FechaFin = T00043_A59TrListaActividad_FechaFin[0];
               Z60TrListaActividad_FechaCreacion = T00043_A60TrListaActividad_FechaCreacion[0];
               Z61TrListaActividad_FechaModificacion = T00043_A61TrListaActividad_FechaModificacion[0];
               Z62TrListaActividad_Estado = T00043_A62TrListaActividad_Estado[0];
            }
            else
            {
               Z56TrListaActividad_Nombre = A56TrListaActividad_Nombre;
               Z58TrListaActividad_FechaInicio = A58TrListaActividad_FechaInicio;
               Z59TrListaActividad_FechaFin = A59TrListaActividad_FechaFin;
               Z60TrListaActividad_FechaCreacion = A60TrListaActividad_FechaCreacion;
               Z61TrListaActividad_FechaModificacion = A61TrListaActividad_FechaModificacion;
               Z62TrListaActividad_Estado = A62TrListaActividad_Estado;
            }
         }
         if ( GX_JID == -15 )
         {
            Z26TrActividades_ID = A26TrActividades_ID;
            Z55TrListaActividad_ID = (Guid)(A55TrListaActividad_ID);
            Z56TrListaActividad_Nombre = A56TrListaActividad_Nombre;
            Z57TrListaActividad_Descripcion = A57TrListaActividad_Descripcion;
            Z58TrListaActividad_FechaInicio = A58TrListaActividad_FechaInicio;
            Z59TrListaActividad_FechaFin = A59TrListaActividad_FechaFin;
            Z60TrListaActividad_FechaCreacion = A60TrListaActividad_FechaCreacion;
            Z61TrListaActividad_FechaModificacion = A61TrListaActividad_FechaModificacion;
            Z62TrListaActividad_Estado = A62TrListaActividad_Estado;
         }
      }

      protected void standaloneNotModal049( )
      {
      }

      protected void standaloneModal049( )
      {
         if ( IsIns( )  && (Guid.Empty==A55TrListaActividad_ID) && ( Gx_BScreen == 0 ) )
         {
            A55TrListaActividad_ID = (Guid)(Guid.NewGuid( ));
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtTrListaActividad_ID_Enabled = 0;
            AssignProp("", false, edtTrListaActividad_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrListaActividad_ID_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         }
         else
         {
            edtTrListaActividad_ID_Enabled = 1;
            AssignProp("", false, edtTrListaActividad_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrListaActividad_ID_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load049( )
      {
         /* Using cursor T000416 */
         pr_default.execute(14, new Object[] {A26TrActividades_ID, A55TrListaActividad_ID});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound9 = 1;
            A56TrListaActividad_Nombre = T000416_A56TrListaActividad_Nombre[0];
            n56TrListaActividad_Nombre = T000416_n56TrListaActividad_Nombre[0];
            A57TrListaActividad_Descripcion = T000416_A57TrListaActividad_Descripcion[0];
            n57TrListaActividad_Descripcion = T000416_n57TrListaActividad_Descripcion[0];
            A58TrListaActividad_FechaInicio = T000416_A58TrListaActividad_FechaInicio[0];
            n58TrListaActividad_FechaInicio = T000416_n58TrListaActividad_FechaInicio[0];
            A59TrListaActividad_FechaFin = T000416_A59TrListaActividad_FechaFin[0];
            n59TrListaActividad_FechaFin = T000416_n59TrListaActividad_FechaFin[0];
            A60TrListaActividad_FechaCreacion = T000416_A60TrListaActividad_FechaCreacion[0];
            n60TrListaActividad_FechaCreacion = T000416_n60TrListaActividad_FechaCreacion[0];
            A61TrListaActividad_FechaModificacion = T000416_A61TrListaActividad_FechaModificacion[0];
            n61TrListaActividad_FechaModificacion = T000416_n61TrListaActividad_FechaModificacion[0];
            A62TrListaActividad_Estado = T000416_A62TrListaActividad_Estado[0];
            n62TrListaActividad_Estado = T000416_n62TrListaActividad_Estado[0];
            ZM049( -15) ;
         }
         pr_default.close(14);
         OnLoadActions049( ) ;
      }

      protected void OnLoadActions049( )
      {
      }

      protected void CheckExtendedTable049( )
      {
         nIsDirty_9 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal049( ) ;
         if ( ! ( (DateTime.MinValue==A58TrListaActividad_FechaInicio) || ( A58TrListaActividad_FechaInicio >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GXCCtl = "TRLISTAACTIVIDAD_FECHAINICIO_" + sGXsfl_74_idx;
            GX_msglist.addItem("Campo Tr Lista Actividad_Fecha Inicio fuera de rango", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTrListaActividad_FechaInicio_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A59TrListaActividad_FechaFin) || ( A59TrListaActividad_FechaFin >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GXCCtl = "TRLISTAACTIVIDAD_FECHAFIN_" + sGXsfl_74_idx;
            GX_msglist.addItem("Campo Tr Lista Actividad_Fecha Fin fuera de rango", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTrListaActividad_FechaFin_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A60TrListaActividad_FechaCreacion) || ( A60TrListaActividad_FechaCreacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GXCCtl = "TRLISTAACTIVIDAD_FECHACREACION_" + sGXsfl_74_idx;
            GX_msglist.addItem("Campo Tr Lista Actividad_Fecha Creacion fuera de rango", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTrListaActividad_FechaCreacion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A61TrListaActividad_FechaModificacion) || ( A61TrListaActividad_FechaModificacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GXCCtl = "TRLISTAACTIVIDAD_FECHAMODIFICACION_" + sGXsfl_74_idx;
            GX_msglist.addItem("Campo Tr Lista Actividad_Fecha Modificacion fuera de rango", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTrListaActividad_FechaModificacion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( A62TrListaActividad_Estado == 1 ) || ( A62TrListaActividad_Estado == 2 ) || ( A62TrListaActividad_Estado == 3 ) || ( A62TrListaActividad_Estado == 4 ) || ( A62TrListaActividad_Estado == 5 ) || (0==A62TrListaActividad_Estado) ) )
         {
            GXCCtl = "TRLISTAACTIVIDAD_ESTADO_" + sGXsfl_74_idx;
            GX_msglist.addItem("Campo Tr Lista Actividad_Estado fuera de rango", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbTrListaActividad_Estado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors049( )
      {
      }

      protected void enableDisable049( )
      {
      }

      protected void GetKey049( )
      {
         /* Using cursor T000417 */
         pr_default.execute(15, new Object[] {A26TrActividades_ID, A55TrListaActividad_ID});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey049( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {A26TrActividades_ID, A55TrListaActividad_ID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM049( 15) ;
            RcdFound9 = 1;
            InitializeNonKey049( ) ;
            A55TrListaActividad_ID = (Guid)((Guid)(T00043_A55TrListaActividad_ID[0]));
            A56TrListaActividad_Nombre = T00043_A56TrListaActividad_Nombre[0];
            n56TrListaActividad_Nombre = T00043_n56TrListaActividad_Nombre[0];
            A57TrListaActividad_Descripcion = T00043_A57TrListaActividad_Descripcion[0];
            n57TrListaActividad_Descripcion = T00043_n57TrListaActividad_Descripcion[0];
            A58TrListaActividad_FechaInicio = T00043_A58TrListaActividad_FechaInicio[0];
            n58TrListaActividad_FechaInicio = T00043_n58TrListaActividad_FechaInicio[0];
            A59TrListaActividad_FechaFin = T00043_A59TrListaActividad_FechaFin[0];
            n59TrListaActividad_FechaFin = T00043_n59TrListaActividad_FechaFin[0];
            A60TrListaActividad_FechaCreacion = T00043_A60TrListaActividad_FechaCreacion[0];
            n60TrListaActividad_FechaCreacion = T00043_n60TrListaActividad_FechaCreacion[0];
            A61TrListaActividad_FechaModificacion = T00043_A61TrListaActividad_FechaModificacion[0];
            n61TrListaActividad_FechaModificacion = T00043_n61TrListaActividad_FechaModificacion[0];
            A62TrListaActividad_Estado = T00043_A62TrListaActividad_Estado[0];
            n62TrListaActividad_Estado = T00043_n62TrListaActividad_Estado[0];
            Z26TrActividades_ID = A26TrActividades_ID;
            Z55TrListaActividad_ID = (Guid)(A55TrListaActividad_ID);
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal049( ) ;
            Load049( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey049( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal049( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes049( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency049( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {A26TrActividades_ID, A55TrListaActividad_ID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrActividadesLevel1"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z56TrListaActividad_Nombre, T00042_A56TrListaActividad_Nombre[0]) != 0 ) || ( Z58TrListaActividad_FechaInicio != T00042_A58TrListaActividad_FechaInicio[0] ) || ( Z59TrListaActividad_FechaFin != T00042_A59TrListaActividad_FechaFin[0] ) || ( Z60TrListaActividad_FechaCreacion != T00042_A60TrListaActividad_FechaCreacion[0] ) || ( Z61TrListaActividad_FechaModificacion != T00042_A61TrListaActividad_FechaModificacion[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z62TrListaActividad_Estado != T00042_A62TrListaActividad_Estado[0] ) )
            {
               if ( StringUtil.StrCmp(Z56TrListaActividad_Nombre, T00042_A56TrListaActividad_Nombre[0]) != 0 )
               {
                  GXUtil.WriteLog("tractividades:[seudo value changed for attri]"+"TrListaActividad_Nombre");
                  GXUtil.WriteLogRaw("Old: ",Z56TrListaActividad_Nombre);
                  GXUtil.WriteLogRaw("Current: ",T00042_A56TrListaActividad_Nombre[0]);
               }
               if ( Z58TrListaActividad_FechaInicio != T00042_A58TrListaActividad_FechaInicio[0] )
               {
                  GXUtil.WriteLog("tractividades:[seudo value changed for attri]"+"TrListaActividad_FechaInicio");
                  GXUtil.WriteLogRaw("Old: ",Z58TrListaActividad_FechaInicio);
                  GXUtil.WriteLogRaw("Current: ",T00042_A58TrListaActividad_FechaInicio[0]);
               }
               if ( Z59TrListaActividad_FechaFin != T00042_A59TrListaActividad_FechaFin[0] )
               {
                  GXUtil.WriteLog("tractividades:[seudo value changed for attri]"+"TrListaActividad_FechaFin");
                  GXUtil.WriteLogRaw("Old: ",Z59TrListaActividad_FechaFin);
                  GXUtil.WriteLogRaw("Current: ",T00042_A59TrListaActividad_FechaFin[0]);
               }
               if ( Z60TrListaActividad_FechaCreacion != T00042_A60TrListaActividad_FechaCreacion[0] )
               {
                  GXUtil.WriteLog("tractividades:[seudo value changed for attri]"+"TrListaActividad_FechaCreacion");
                  GXUtil.WriteLogRaw("Old: ",Z60TrListaActividad_FechaCreacion);
                  GXUtil.WriteLogRaw("Current: ",T00042_A60TrListaActividad_FechaCreacion[0]);
               }
               if ( Z61TrListaActividad_FechaModificacion != T00042_A61TrListaActividad_FechaModificacion[0] )
               {
                  GXUtil.WriteLog("tractividades:[seudo value changed for attri]"+"TrListaActividad_FechaModificacion");
                  GXUtil.WriteLogRaw("Old: ",Z61TrListaActividad_FechaModificacion);
                  GXUtil.WriteLogRaw("Current: ",T00042_A61TrListaActividad_FechaModificacion[0]);
               }
               if ( Z62TrListaActividad_Estado != T00042_A62TrListaActividad_Estado[0] )
               {
                  GXUtil.WriteLog("tractividades:[seudo value changed for attri]"+"TrListaActividad_Estado");
                  GXUtil.WriteLogRaw("Old: ",Z62TrListaActividad_Estado);
                  GXUtil.WriteLogRaw("Current: ",T00042_A62TrListaActividad_Estado[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TrActividadesLevel1"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert049( )
      {
         BeforeValidate049( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable049( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM049( 0) ;
            CheckOptimisticConcurrency049( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm049( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert049( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000418 */
                     pr_default.execute(16, new Object[] {A26TrActividades_ID, n56TrListaActividad_Nombre, A56TrListaActividad_Nombre, n57TrListaActividad_Descripcion, A57TrListaActividad_Descripcion, n58TrListaActividad_FechaInicio, A58TrListaActividad_FechaInicio, n59TrListaActividad_FechaFin, A59TrListaActividad_FechaFin, n60TrListaActividad_FechaCreacion, A60TrListaActividad_FechaCreacion, n61TrListaActividad_FechaModificacion, A61TrListaActividad_FechaModificacion, n62TrListaActividad_Estado, A62TrListaActividad_Estado, A55TrListaActividad_ID});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("TrActividadesLevel1") ;
                     if ( (pr_default.getStatus(16) == 1) )
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
               Load049( ) ;
            }
            EndLevel049( ) ;
         }
         CloseExtendedTableCursors049( ) ;
      }

      protected void Update049( )
      {
         BeforeValidate049( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable049( ) ;
         }
         if ( ( nIsMod_9 != 0 ) || ( nIsDirty_9 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency049( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm049( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate049( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000419 */
                        pr_default.execute(17, new Object[] {n56TrListaActividad_Nombre, A56TrListaActividad_Nombre, n57TrListaActividad_Descripcion, A57TrListaActividad_Descripcion, n58TrListaActividad_FechaInicio, A58TrListaActividad_FechaInicio, n59TrListaActividad_FechaFin, A59TrListaActividad_FechaFin, n60TrListaActividad_FechaCreacion, A60TrListaActividad_FechaCreacion, n61TrListaActividad_FechaModificacion, A61TrListaActividad_FechaModificacion, n62TrListaActividad_Estado, A62TrListaActividad_Estado, A26TrActividades_ID, A55TrListaActividad_ID});
                        pr_default.close(17);
                        dsDefault.SmartCacheProvider.SetUpdated("TrActividadesLevel1") ;
                        if ( (pr_default.getStatus(17) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrActividadesLevel1"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate049( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey049( ) ;
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
               EndLevel049( ) ;
            }
         }
         CloseExtendedTableCursors049( ) ;
      }

      protected void DeferredUpdate049( )
      {
      }

      protected void Delete049( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate049( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency049( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls049( ) ;
            AfterConfirm049( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete049( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000420 */
                  pr_default.execute(18, new Object[] {A26TrActividades_ID, A55TrListaActividad_ID});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("TrActividadesLevel1") ;
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel049( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls049( )
      {
         standaloneModal049( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel049( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart049( )
      {
         /* Scan By routine */
         /* Using cursor T000421 */
         pr_default.execute(19, new Object[] {A26TrActividades_ID});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound9 = 1;
            A55TrListaActividad_ID = (Guid)((Guid)(T000421_A55TrListaActividad_ID[0]));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext049( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound9 = 1;
            A55TrListaActividad_ID = (Guid)((Guid)(T000421_A55TrListaActividad_ID[0]));
         }
      }

      protected void ScanEnd049( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm049( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert049( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate049( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete049( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete049( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate049( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes049( )
      {
         edtTrListaActividad_ID_Enabled = 0;
         AssignProp("", false, edtTrListaActividad_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrListaActividad_ID_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         edtTrListaActividad_Nombre_Enabled = 0;
         AssignProp("", false, edtTrListaActividad_Nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrListaActividad_Nombre_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         edtTrListaActividad_Descripcion_Enabled = 0;
         AssignProp("", false, edtTrListaActividad_Descripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrListaActividad_Descripcion_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         edtTrListaActividad_FechaInicio_Enabled = 0;
         AssignProp("", false, edtTrListaActividad_FechaInicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrListaActividad_FechaInicio_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         edtTrListaActividad_FechaFin_Enabled = 0;
         AssignProp("", false, edtTrListaActividad_FechaFin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrListaActividad_FechaFin_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         edtTrListaActividad_FechaCreacion_Enabled = 0;
         AssignProp("", false, edtTrListaActividad_FechaCreacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrListaActividad_FechaCreacion_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         edtTrListaActividad_FechaModificacion_Enabled = 0;
         AssignProp("", false, edtTrListaActividad_FechaModificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrListaActividad_FechaModificacion_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         cmbTrListaActividad_Estado.Enabled = 0;
         AssignProp("", false, cmbTrListaActividad_Estado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTrListaActividad_Estado.Enabled), 5, 0), !bGXsfl_74_Refreshing);
      }

      protected void send_integrity_lvl_hashes049( )
      {
      }

      protected void send_integrity_lvl_hashes044( )
      {
      }

      protected void SubsflControlProps_749( )
      {
         edtTrListaActividad_ID_Internalname = "TRLISTAACTIVIDAD_ID_"+sGXsfl_74_idx;
         edtTrListaActividad_Nombre_Internalname = "TRLISTAACTIVIDAD_NOMBRE_"+sGXsfl_74_idx;
         edtTrListaActividad_Descripcion_Internalname = "TRLISTAACTIVIDAD_DESCRIPCION_"+sGXsfl_74_idx;
         edtTrListaActividad_FechaInicio_Internalname = "TRLISTAACTIVIDAD_FECHAINICIO_"+sGXsfl_74_idx;
         edtTrListaActividad_FechaFin_Internalname = "TRLISTAACTIVIDAD_FECHAFIN_"+sGXsfl_74_idx;
         edtTrListaActividad_FechaCreacion_Internalname = "TRLISTAACTIVIDAD_FECHACREACION_"+sGXsfl_74_idx;
         edtTrListaActividad_FechaModificacion_Internalname = "TRLISTAACTIVIDAD_FECHAMODIFICACION_"+sGXsfl_74_idx;
         cmbTrListaActividad_Estado_Internalname = "TRLISTAACTIVIDAD_ESTADO_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_749( )
      {
         edtTrListaActividad_ID_Internalname = "TRLISTAACTIVIDAD_ID_"+sGXsfl_74_fel_idx;
         edtTrListaActividad_Nombre_Internalname = "TRLISTAACTIVIDAD_NOMBRE_"+sGXsfl_74_fel_idx;
         edtTrListaActividad_Descripcion_Internalname = "TRLISTAACTIVIDAD_DESCRIPCION_"+sGXsfl_74_fel_idx;
         edtTrListaActividad_FechaInicio_Internalname = "TRLISTAACTIVIDAD_FECHAINICIO_"+sGXsfl_74_fel_idx;
         edtTrListaActividad_FechaFin_Internalname = "TRLISTAACTIVIDAD_FECHAFIN_"+sGXsfl_74_fel_idx;
         edtTrListaActividad_FechaCreacion_Internalname = "TRLISTAACTIVIDAD_FECHACREACION_"+sGXsfl_74_fel_idx;
         edtTrListaActividad_FechaModificacion_Internalname = "TRLISTAACTIVIDAD_FECHAMODIFICACION_"+sGXsfl_74_fel_idx;
         cmbTrListaActividad_Estado_Internalname = "TRLISTAACTIVIDAD_ESTADO_"+sGXsfl_74_fel_idx;
      }

      protected void AddRow049( )
      {
         nGXsfl_74_idx = (int)(nGXsfl_74_idx+1);
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_749( ) ;
         SendRow049( ) ;
      }

      protected void SendRow049( )
      {
         Gridtractividades_level1Row = GXWebRow.GetNew(context);
         if ( subGridtractividades_level1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridtractividades_level1_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridtractividades_level1_Class, "") != 0 )
            {
               subGridtractividades_level1_Linesclass = subGridtractividades_level1_Class+"Odd";
            }
         }
         else if ( subGridtractividades_level1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridtractividades_level1_Backstyle = 0;
            subGridtractividades_level1_Backcolor = subGridtractividades_level1_Allbackcolor;
            if ( StringUtil.StrCmp(subGridtractividades_level1_Class, "") != 0 )
            {
               subGridtractividades_level1_Linesclass = subGridtractividades_level1_Class+"Uniform";
            }
         }
         else if ( subGridtractividades_level1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridtractividades_level1_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridtractividades_level1_Class, "") != 0 )
            {
               subGridtractividades_level1_Linesclass = subGridtractividades_level1_Class+"Odd";
            }
            subGridtractividades_level1_Backcolor = (int)(0x0);
         }
         else if ( subGridtractividades_level1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridtractividades_level1_Backstyle = 1;
            if ( ((int)((nGXsfl_74_idx) % (2))) == 0 )
            {
               subGridtractividades_level1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridtractividades_level1_Class, "") != 0 )
               {
                  subGridtractividades_level1_Linesclass = subGridtractividades_level1_Class+"Even";
               }
            }
            else
            {
               subGridtractividades_level1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridtractividades_level1_Class, "") != 0 )
               {
                  subGridtractividades_level1_Linesclass = subGridtractividades_level1_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_9_" + sGXsfl_74_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_74_idx + "',74)\"";
         ROClassString = "Attribute";
         Gridtractividades_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrListaActividad_ID_Internalname,A55TrListaActividad_ID.ToString(),A55TrListaActividad_ID.ToString(),TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrListaActividad_ID_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(int)edtTrListaActividad_ID_Enabled,(short)1,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)36,(short)0,(short)0,(short)74,(short)1,(short)0,(short)0,(bool)true,(String)"",(String)"",(bool)false,(String)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_9_" + sGXsfl_74_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_74_idx + "',74)\"";
         ROClassString = "Attribute";
         Gridtractividades_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrListaActividad_Nombre_Internalname,StringUtil.RTrim( A56TrListaActividad_Nombre),(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrListaActividad_Nombre_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(int)edtTrListaActividad_Nombre_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)100,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_9_" + sGXsfl_74_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_74_idx + "',74)\"";
         ROClassString = "Attribute";
         Gridtractividades_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrListaActividad_Descripcion_Internalname,(String)A57TrListaActividad_Descripcion,(String)A57TrListaActividad_Descripcion,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrListaActividad_Descripcion_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(int)edtTrListaActividad_Descripcion_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(int)2097152,(short)0,(short)0,(short)74,(short)1,(short)0,(short)-1,(bool)true,(String)"",(String)"left",(bool)false,(String)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_9_" + sGXsfl_74_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_74_idx + "',74)\"";
         ROClassString = "Attribute";
         Gridtractividades_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrListaActividad_FechaInicio_Internalname,context.localUtil.Format(A58TrListaActividad_FechaInicio, "99/99/9999"),context.localUtil.Format( A58TrListaActividad_FechaInicio, "99/99/9999"),TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,78);\"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrListaActividad_FechaInicio_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(int)edtTrListaActividad_FechaInicio_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_9_" + sGXsfl_74_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_74_idx + "',74)\"";
         ROClassString = "Attribute";
         Gridtractividades_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrListaActividad_FechaFin_Internalname,context.localUtil.Format(A59TrListaActividad_FechaFin, "99/99/9999"),context.localUtil.Format( A59TrListaActividad_FechaFin, "99/99/9999"),TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,79);\"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrListaActividad_FechaFin_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(int)edtTrListaActividad_FechaFin_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_9_" + sGXsfl_74_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_74_idx + "',74)\"";
         ROClassString = "Attribute";
         Gridtractividades_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrListaActividad_FechaCreacion_Internalname,context.localUtil.Format(A60TrListaActividad_FechaCreacion, "99/99/9999"),context.localUtil.Format( A60TrListaActividad_FechaCreacion, "99/99/9999"),TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,80);\"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrListaActividad_FechaCreacion_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(int)edtTrListaActividad_FechaCreacion_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_9_" + sGXsfl_74_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_74_idx + "',74)\"";
         ROClassString = "Attribute";
         Gridtractividades_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrListaActividad_FechaModificacion_Internalname,context.localUtil.Format(A61TrListaActividad_FechaModificacion, "99/99/9999"),context.localUtil.Format( A61TrListaActividad_FechaModificacion, "99/99/9999"),TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,81);\"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrListaActividad_FechaModificacion_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(int)edtTrListaActividad_FechaModificacion_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_9_" + sGXsfl_74_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 82,'',false,'" + sGXsfl_74_idx + "',74)\"";
         if ( ( cmbTrListaActividad_Estado.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "TRLISTAACTIVIDAD_ESTADO_" + sGXsfl_74_idx;
            cmbTrListaActividad_Estado.Name = GXCCtl;
            cmbTrListaActividad_Estado.WebTags = "";
            cmbTrListaActividad_Estado.addItem("1", "Nuevo", 0);
            cmbTrListaActividad_Estado.addItem("2", "En Progreso", 0);
            cmbTrListaActividad_Estado.addItem("3", "Completado", 0);
            cmbTrListaActividad_Estado.addItem("4", "Detenido", 0);
            cmbTrListaActividad_Estado.addItem("5", "Pendiente", 0);
            if ( cmbTrListaActividad_Estado.ItemCount > 0 )
            {
               A62TrListaActividad_Estado = (short)(NumberUtil.Val( cmbTrListaActividad_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A62TrListaActividad_Estado), 4, 0))), "."));
               n62TrListaActividad_Estado = false;
            }
         }
         /* ComboBox */
         Gridtractividades_level1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTrListaActividad_Estado,(String)cmbTrListaActividad_Estado_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A62TrListaActividad_Estado), 4, 0)),(short)1,(String)cmbTrListaActividad_Estado_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,cmbTrListaActividad_Estado.Enabled,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"",(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"",(String)"",(bool)true});
         cmbTrListaActividad_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A62TrListaActividad_Estado), 4, 0));
         AssignProp("", false, cmbTrListaActividad_Estado_Internalname, "Values", (String)(cmbTrListaActividad_Estado.ToJavascriptSource()), !bGXsfl_74_Refreshing);
         context.httpAjaxContext.ajax_sending_grid_row(Gridtractividades_level1Row);
         send_integrity_lvl_hashes049( ) ;
         GXCCtl = "Z55TrListaActividad_ID_" + sGXsfl_74_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z55TrListaActividad_ID.ToString());
         GXCCtl = "Z56TrListaActividad_Nombre_" + sGXsfl_74_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z56TrListaActividad_Nombre));
         GXCCtl = "Z58TrListaActividad_FechaInicio_" + sGXsfl_74_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.DToC( Z58TrListaActividad_FechaInicio, 0, "/"));
         GXCCtl = "Z59TrListaActividad_FechaFin_" + sGXsfl_74_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.DToC( Z59TrListaActividad_FechaFin, 0, "/"));
         GXCCtl = "Z60TrListaActividad_FechaCreacion_" + sGXsfl_74_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.DToC( Z60TrListaActividad_FechaCreacion, 0, "/"));
         GXCCtl = "Z61TrListaActividad_FechaModificacion_" + sGXsfl_74_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.DToC( Z61TrListaActividad_FechaModificacion, 0, "/"));
         GXCCtl = "Z62TrListaActividad_Estado_" + sGXsfl_74_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z62TrListaActividad_Estado), 4, 0, ".", "")));
         GXCCtl = "nRcdDeleted_9_" + sGXsfl_74_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_9), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_9_" + sGXsfl_74_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_9), 4, 0, ".", "")));
         GXCCtl = "nIsMod_9_" + sGXsfl_74_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_9), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_ID_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_ID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_NOMBRE_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_Nombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_DESCRIPCION_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_Descripcion_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_FECHAINICIO_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_FechaInicio_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_FECHAFIN_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_FechaFin_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_FECHACREACION_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_FechaCreacion_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_FECHAMODIFICACION_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrListaActividad_FechaModificacion_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_ESTADO_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbTrListaActividad_Estado.Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridtractividades_level1Container.AddRow(Gridtractividades_level1Row);
      }

      protected void ReadRow049( )
      {
         nGXsfl_74_idx = (int)(nGXsfl_74_idx+1);
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_749( ) ;
         edtTrListaActividad_ID_Enabled = (int)(context.localUtil.CToN( cgiGet( "TRLISTAACTIVIDAD_ID_"+sGXsfl_74_idx+"Enabled"), ".", ","));
         edtTrListaActividad_Nombre_Enabled = (int)(context.localUtil.CToN( cgiGet( "TRLISTAACTIVIDAD_NOMBRE_"+sGXsfl_74_idx+"Enabled"), ".", ","));
         edtTrListaActividad_Descripcion_Enabled = (int)(context.localUtil.CToN( cgiGet( "TRLISTAACTIVIDAD_DESCRIPCION_"+sGXsfl_74_idx+"Enabled"), ".", ","));
         edtTrListaActividad_FechaInicio_Enabled = (int)(context.localUtil.CToN( cgiGet( "TRLISTAACTIVIDAD_FECHAINICIO_"+sGXsfl_74_idx+"Enabled"), ".", ","));
         edtTrListaActividad_FechaFin_Enabled = (int)(context.localUtil.CToN( cgiGet( "TRLISTAACTIVIDAD_FECHAFIN_"+sGXsfl_74_idx+"Enabled"), ".", ","));
         edtTrListaActividad_FechaCreacion_Enabled = (int)(context.localUtil.CToN( cgiGet( "TRLISTAACTIVIDAD_FECHACREACION_"+sGXsfl_74_idx+"Enabled"), ".", ","));
         edtTrListaActividad_FechaModificacion_Enabled = (int)(context.localUtil.CToN( cgiGet( "TRLISTAACTIVIDAD_FECHAMODIFICACION_"+sGXsfl_74_idx+"Enabled"), ".", ","));
         cmbTrListaActividad_Estado.Enabled = (int)(context.localUtil.CToN( cgiGet( "TRLISTAACTIVIDAD_ESTADO_"+sGXsfl_74_idx+"Enabled"), ".", ","));
         if ( StringUtil.StrCmp(cgiGet( edtTrListaActividad_ID_Internalname), "") == 0 )
         {
            A55TrListaActividad_ID = (Guid)(Guid.Empty);
         }
         else
         {
            try
            {
               A55TrListaActividad_ID = (Guid)(StringUtil.StrToGuid( cgiGet( edtTrListaActividad_ID_Internalname)));
            }
            catch ( Exception e )
            {
               GXCCtl = "TRLISTAACTIVIDAD_ID_" + sGXsfl_74_idx;
               GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtTrListaActividad_ID_Internalname;
               wbErr = true;
            }
         }
         A56TrListaActividad_Nombre = cgiGet( edtTrListaActividad_Nombre_Internalname);
         n56TrListaActividad_Nombre = false;
         n56TrListaActividad_Nombre = (String.IsNullOrEmpty(StringUtil.RTrim( A56TrListaActividad_Nombre)) ? true : false);
         A57TrListaActividad_Descripcion = cgiGet( edtTrListaActividad_Descripcion_Internalname);
         n57TrListaActividad_Descripcion = false;
         n57TrListaActividad_Descripcion = (String.IsNullOrEmpty(StringUtil.RTrim( A57TrListaActividad_Descripcion)) ? true : false);
         if ( context.localUtil.VCDate( cgiGet( edtTrListaActividad_FechaInicio_Internalname), 2) == 0 )
         {
            GXCCtl = "TRLISTAACTIVIDAD_FECHAINICIO_" + sGXsfl_74_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Lista Actividad_Fecha Inicio"}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTrListaActividad_FechaInicio_Internalname;
            wbErr = true;
            A58TrListaActividad_FechaInicio = DateTime.MinValue;
            n58TrListaActividad_FechaInicio = false;
         }
         else
         {
            A58TrListaActividad_FechaInicio = context.localUtil.CToD( cgiGet( edtTrListaActividad_FechaInicio_Internalname), 2);
            n58TrListaActividad_FechaInicio = false;
         }
         n58TrListaActividad_FechaInicio = ((DateTime.MinValue==A58TrListaActividad_FechaInicio) ? true : false);
         if ( context.localUtil.VCDate( cgiGet( edtTrListaActividad_FechaFin_Internalname), 2) == 0 )
         {
            GXCCtl = "TRLISTAACTIVIDAD_FECHAFIN_" + sGXsfl_74_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Lista Actividad_Fecha Fin"}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTrListaActividad_FechaFin_Internalname;
            wbErr = true;
            A59TrListaActividad_FechaFin = DateTime.MinValue;
            n59TrListaActividad_FechaFin = false;
         }
         else
         {
            A59TrListaActividad_FechaFin = context.localUtil.CToD( cgiGet( edtTrListaActividad_FechaFin_Internalname), 2);
            n59TrListaActividad_FechaFin = false;
         }
         n59TrListaActividad_FechaFin = ((DateTime.MinValue==A59TrListaActividad_FechaFin) ? true : false);
         if ( context.localUtil.VCDate( cgiGet( edtTrListaActividad_FechaCreacion_Internalname), 2) == 0 )
         {
            GXCCtl = "TRLISTAACTIVIDAD_FECHACREACION_" + sGXsfl_74_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Lista Actividad_Fecha Creacion"}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTrListaActividad_FechaCreacion_Internalname;
            wbErr = true;
            A60TrListaActividad_FechaCreacion = DateTime.MinValue;
            n60TrListaActividad_FechaCreacion = false;
         }
         else
         {
            A60TrListaActividad_FechaCreacion = context.localUtil.CToD( cgiGet( edtTrListaActividad_FechaCreacion_Internalname), 2);
            n60TrListaActividad_FechaCreacion = false;
         }
         n60TrListaActividad_FechaCreacion = ((DateTime.MinValue==A60TrListaActividad_FechaCreacion) ? true : false);
         if ( context.localUtil.VCDate( cgiGet( edtTrListaActividad_FechaModificacion_Internalname), 2) == 0 )
         {
            GXCCtl = "TRLISTAACTIVIDAD_FECHAMODIFICACION_" + sGXsfl_74_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Lista Actividad_Fecha Modificacion"}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTrListaActividad_FechaModificacion_Internalname;
            wbErr = true;
            A61TrListaActividad_FechaModificacion = DateTime.MinValue;
            n61TrListaActividad_FechaModificacion = false;
         }
         else
         {
            A61TrListaActividad_FechaModificacion = context.localUtil.CToD( cgiGet( edtTrListaActividad_FechaModificacion_Internalname), 2);
            n61TrListaActividad_FechaModificacion = false;
         }
         n61TrListaActividad_FechaModificacion = ((DateTime.MinValue==A61TrListaActividad_FechaModificacion) ? true : false);
         cmbTrListaActividad_Estado.Name = cmbTrListaActividad_Estado_Internalname;
         cmbTrListaActividad_Estado.CurrentValue = cgiGet( cmbTrListaActividad_Estado_Internalname);
         A62TrListaActividad_Estado = (short)(NumberUtil.Val( cgiGet( cmbTrListaActividad_Estado_Internalname), "."));
         n62TrListaActividad_Estado = false;
         n62TrListaActividad_Estado = ((0==A62TrListaActividad_Estado) ? true : false);
         GXCCtl = "Z55TrListaActividad_ID_" + sGXsfl_74_idx;
         Z55TrListaActividad_ID = (Guid)(StringUtil.StrToGuid( cgiGet( GXCCtl)));
         GXCCtl = "Z56TrListaActividad_Nombre_" + sGXsfl_74_idx;
         Z56TrListaActividad_Nombre = cgiGet( GXCCtl);
         n56TrListaActividad_Nombre = (String.IsNullOrEmpty(StringUtil.RTrim( A56TrListaActividad_Nombre)) ? true : false);
         GXCCtl = "Z58TrListaActividad_FechaInicio_" + sGXsfl_74_idx;
         Z58TrListaActividad_FechaInicio = context.localUtil.CToD( cgiGet( GXCCtl), 0);
         n58TrListaActividad_FechaInicio = ((DateTime.MinValue==A58TrListaActividad_FechaInicio) ? true : false);
         GXCCtl = "Z59TrListaActividad_FechaFin_" + sGXsfl_74_idx;
         Z59TrListaActividad_FechaFin = context.localUtil.CToD( cgiGet( GXCCtl), 0);
         n59TrListaActividad_FechaFin = ((DateTime.MinValue==A59TrListaActividad_FechaFin) ? true : false);
         GXCCtl = "Z60TrListaActividad_FechaCreacion_" + sGXsfl_74_idx;
         Z60TrListaActividad_FechaCreacion = context.localUtil.CToD( cgiGet( GXCCtl), 0);
         n60TrListaActividad_FechaCreacion = ((DateTime.MinValue==A60TrListaActividad_FechaCreacion) ? true : false);
         GXCCtl = "Z61TrListaActividad_FechaModificacion_" + sGXsfl_74_idx;
         Z61TrListaActividad_FechaModificacion = context.localUtil.CToD( cgiGet( GXCCtl), 0);
         n61TrListaActividad_FechaModificacion = ((DateTime.MinValue==A61TrListaActividad_FechaModificacion) ? true : false);
         GXCCtl = "Z62TrListaActividad_Estado_" + sGXsfl_74_idx;
         Z62TrListaActividad_Estado = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         n62TrListaActividad_Estado = ((0==A62TrListaActividad_Estado) ? true : false);
         GXCCtl = "nRcdDeleted_9_" + sGXsfl_74_idx;
         nRcdDeleted_9 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_9_" + sGXsfl_74_idx;
         nRcdExists_9 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_9_" + sGXsfl_74_idx;
         nIsMod_9 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtTrListaActividad_ID_Enabled = edtTrListaActividad_ID_Enabled;
      }

      protected void ConfirmValues040( )
      {
         nGXsfl_74_idx = 0;
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_749( ) ;
         while ( nGXsfl_74_idx < nRC_GXsfl_74 )
         {
            nGXsfl_74_idx = (int)(nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_749( ) ;
            ChangePostValue( "Z55TrListaActividad_ID_"+sGXsfl_74_idx, cgiGet( "ZT_"+"Z55TrListaActividad_ID_"+sGXsfl_74_idx)) ;
            DeletePostValue( "ZT_"+"Z55TrListaActividad_ID_"+sGXsfl_74_idx) ;
            ChangePostValue( "Z56TrListaActividad_Nombre_"+sGXsfl_74_idx, cgiGet( "ZT_"+"Z56TrListaActividad_Nombre_"+sGXsfl_74_idx)) ;
            DeletePostValue( "ZT_"+"Z56TrListaActividad_Nombre_"+sGXsfl_74_idx) ;
            ChangePostValue( "Z58TrListaActividad_FechaInicio_"+sGXsfl_74_idx, cgiGet( "ZT_"+"Z58TrListaActividad_FechaInicio_"+sGXsfl_74_idx)) ;
            DeletePostValue( "ZT_"+"Z58TrListaActividad_FechaInicio_"+sGXsfl_74_idx) ;
            ChangePostValue( "Z59TrListaActividad_FechaFin_"+sGXsfl_74_idx, cgiGet( "ZT_"+"Z59TrListaActividad_FechaFin_"+sGXsfl_74_idx)) ;
            DeletePostValue( "ZT_"+"Z59TrListaActividad_FechaFin_"+sGXsfl_74_idx) ;
            ChangePostValue( "Z60TrListaActividad_FechaCreacion_"+sGXsfl_74_idx, cgiGet( "ZT_"+"Z60TrListaActividad_FechaCreacion_"+sGXsfl_74_idx)) ;
            DeletePostValue( "ZT_"+"Z60TrListaActividad_FechaCreacion_"+sGXsfl_74_idx) ;
            ChangePostValue( "Z61TrListaActividad_FechaModificacion_"+sGXsfl_74_idx, cgiGet( "ZT_"+"Z61TrListaActividad_FechaModificacion_"+sGXsfl_74_idx)) ;
            DeletePostValue( "ZT_"+"Z61TrListaActividad_FechaModificacion_"+sGXsfl_74_idx) ;
            ChangePostValue( "Z62TrListaActividad_Estado_"+sGXsfl_74_idx, cgiGet( "ZT_"+"Z62TrListaActividad_Estado_"+sGXsfl_74_idx)) ;
            DeletePostValue( "ZT_"+"Z62TrListaActividad_Estado_"+sGXsfl_74_idx) ;
         }
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
         context.AddJavascriptSource("gxcfg.js", "?202210211744493", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 947160), false, true);
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
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_74_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
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

      protected void InitializeNonKey049( )
      {
         A56TrListaActividad_Nombre = "";
         n56TrListaActividad_Nombre = false;
         A57TrListaActividad_Descripcion = "";
         n57TrListaActividad_Descripcion = false;
         A58TrListaActividad_FechaInicio = DateTime.MinValue;
         n58TrListaActividad_FechaInicio = false;
         A59TrListaActividad_FechaFin = DateTime.MinValue;
         n59TrListaActividad_FechaFin = false;
         A60TrListaActividad_FechaCreacion = DateTime.MinValue;
         n60TrListaActividad_FechaCreacion = false;
         A61TrListaActividad_FechaModificacion = DateTime.MinValue;
         n61TrListaActividad_FechaModificacion = false;
         A62TrListaActividad_Estado = 0;
         n62TrListaActividad_Estado = false;
         Z56TrListaActividad_Nombre = "";
         Z58TrListaActividad_FechaInicio = DateTime.MinValue;
         Z59TrListaActividad_FechaFin = DateTime.MinValue;
         Z60TrListaActividad_FechaCreacion = DateTime.MinValue;
         Z61TrListaActividad_FechaModificacion = DateTime.MinValue;
         Z62TrListaActividad_Estado = 0;
      }

      protected void InitAll049( )
      {
         A55TrListaActividad_ID = (Guid)(Guid.NewGuid( ));
         InitializeNonKey049( ) ;
      }

      protected void StandaloneModalInsert049( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?20221021174458", true, true);
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
         context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("tractividades.js", "?20221021174459", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties9( )
      {
         edtTrListaActividad_ID_Enabled = defedtTrListaActividad_ID_Enabled;
         AssignProp("", false, edtTrListaActividad_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrListaActividad_ID_Enabled), 5, 0), !bGXsfl_74_Refreshing);
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
         lblTitlelevel1_Internalname = "TITLELEVEL1";
         edtTrListaActividad_ID_Internalname = "TRLISTAACTIVIDAD_ID";
         edtTrListaActividad_Nombre_Internalname = "TRLISTAACTIVIDAD_NOMBRE";
         edtTrListaActividad_Descripcion_Internalname = "TRLISTAACTIVIDAD_DESCRIPCION";
         edtTrListaActividad_FechaInicio_Internalname = "TRLISTAACTIVIDAD_FECHAINICIO";
         edtTrListaActividad_FechaFin_Internalname = "TRLISTAACTIVIDAD_FECHAFIN";
         edtTrListaActividad_FechaCreacion_Internalname = "TRLISTAACTIVIDAD_FECHACREACION";
         edtTrListaActividad_FechaModificacion_Internalname = "TRLISTAACTIVIDAD_FECHAMODIFICACION";
         cmbTrListaActividad_Estado_Internalname = "TRLISTAACTIVIDAD_ESTADO";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Form.Internalname = "FORM";
         imgprompt_25_Internalname = "PROMPT_25";
         subGridtractividades_level1_Internalname = "GRIDTRACTIVIDADES_LEVEL1";
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
         cmbTrListaActividad_Estado_Jsonclick = "";
         edtTrListaActividad_FechaModificacion_Jsonclick = "";
         edtTrListaActividad_FechaCreacion_Jsonclick = "";
         edtTrListaActividad_FechaFin_Jsonclick = "";
         edtTrListaActividad_FechaInicio_Jsonclick = "";
         edtTrListaActividad_Descripcion_Jsonclick = "";
         edtTrListaActividad_Nombre_Jsonclick = "";
         edtTrListaActividad_ID_Jsonclick = "";
         subGridtractividades_level1_Class = "Grid";
         subGridtractividades_level1_Backcolorstyle = 0;
         subGridtractividades_level1_Allowcollapsing = 0;
         subGridtractividades_level1_Allowselection = 0;
         cmbTrListaActividad_Estado.Enabled = 1;
         edtTrListaActividad_FechaModificacion_Enabled = 1;
         edtTrListaActividad_FechaCreacion_Enabled = 1;
         edtTrListaActividad_FechaFin_Enabled = 1;
         edtTrListaActividad_FechaInicio_Enabled = 1;
         edtTrListaActividad_Descripcion_Enabled = 1;
         edtTrListaActividad_Nombre_Enabled = 1;
         edtTrListaActividad_ID_Enabled = 1;
         subGridtractividades_level1_Header = "";
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

      protected void gxnrGridtractividades_level1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_749( ) ;
         while ( nGXsfl_74_idx <= nRC_GXsfl_74 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal049( ) ;
            standaloneModal049( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow049( ) ;
            nGXsfl_74_idx = (int)(nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_749( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridtractividades_level1Container)) ;
         /* End function gxnrGridtractividades_level1_newrow */
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
         GXCCtl = "TRLISTAACTIVIDAD_ESTADO_" + sGXsfl_74_idx;
         cmbTrListaActividad_Estado.Name = GXCCtl;
         cmbTrListaActividad_Estado.WebTags = "";
         cmbTrListaActividad_Estado.addItem("1", "Nuevo", 0);
         cmbTrListaActividad_Estado.addItem("2", "En Progreso", 0);
         cmbTrListaActividad_Estado.addItem("3", "Completado", 0);
         cmbTrListaActividad_Estado.addItem("4", "Detenido", 0);
         cmbTrListaActividad_Estado.addItem("5", "Pendiente", 0);
         if ( cmbTrListaActividad_Estado.ItemCount > 0 )
         {
            A62TrListaActividad_Estado = (short)(NumberUtil.Val( cmbTrListaActividad_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A62TrListaActividad_Estado), 4, 0))), "."));
            n62TrListaActividad_Estado = false;
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
         /* Using cursor T000422 */
         pr_default.execute(20, new Object[] {n25TrActividades_IDTarea, A25TrActividades_IDTarea});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A25TrActividades_IDTarea) ) )
            {
               GX_msglist.addItem("No existe 'Tr Gestion Tareas_STG'.", "ForeignKeyNotFound", 1, "TRACTIVIDADES_IDTAREA");
               AnyError = 1;
               GX_FocusControl = edtTrActividades_IDTarea_Internalname;
            }
         }
         pr_default.close(20);
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
         setEventMetadata("VALID_TRACTIVIDADES_ID","{handler:'Valid_Tractividades_id',iparms:[{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'cmbTrActividades_Estado'},{av:'A33TrActividades_Estado',fld:'TRACTIVIDADES_ESTADO',pic:'ZZZ9'},{av:'A26TrActividades_ID',fld:'TRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
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
         setEventMetadata("VALID_TRLISTAACTIVIDAD_ID","{handler:'Valid_Trlistaactividad_id',iparms:[]");
         setEventMetadata("VALID_TRLISTAACTIVIDAD_ID",",oparms:[]}");
         setEventMetadata("VALID_TRLISTAACTIVIDAD_FECHAINICIO","{handler:'Valid_Trlistaactividad_fechainicio',iparms:[]");
         setEventMetadata("VALID_TRLISTAACTIVIDAD_FECHAINICIO",",oparms:[]}");
         setEventMetadata("VALID_TRLISTAACTIVIDAD_FECHAFIN","{handler:'Valid_Trlistaactividad_fechafin',iparms:[]");
         setEventMetadata("VALID_TRLISTAACTIVIDAD_FECHAFIN",",oparms:[]}");
         setEventMetadata("VALID_TRLISTAACTIVIDAD_FECHACREACION","{handler:'Valid_Trlistaactividad_fechacreacion',iparms:[]");
         setEventMetadata("VALID_TRLISTAACTIVIDAD_FECHACREACION",",oparms:[]}");
         setEventMetadata("VALID_TRLISTAACTIVIDAD_FECHAMODIFICACION","{handler:'Valid_Trlistaactividad_fechamodificacion',iparms:[]");
         setEventMetadata("VALID_TRLISTAACTIVIDAD_FECHAMODIFICACION",",oparms:[]}");
         setEventMetadata("VALID_TRLISTAACTIVIDAD_ESTADO","{handler:'Valid_Trlistaactividad_estado',iparms:[]");
         setEventMetadata("VALID_TRLISTAACTIVIDAD_ESTADO",",oparms:[]}");
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
         pr_default.close(3);
         pr_default.close(20);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z27TrActividades_Nombre = "";
         Z29TrActividades_FechaInicio = DateTime.MinValue;
         Z30TrActividades_FechaFin = DateTime.MinValue;
         Z31TrActividades_FechaCreacion = DateTime.MinValue;
         Z32TrActividades_FechaModificacion = DateTime.MinValue;
         Z55TrListaActividad_ID = (Guid)(Guid.Empty);
         Z56TrListaActividad_Nombre = "";
         Z58TrListaActividad_FechaInicio = DateTime.MinValue;
         Z59TrListaActividad_FechaFin = DateTime.MinValue;
         Z60TrListaActividad_FechaCreacion = DateTime.MinValue;
         Z61TrListaActividad_FechaModificacion = DateTime.MinValue;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         Gx_mode = "";
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
         lblTitlelevel1_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridtractividades_level1Container = new GXWebGrid( context);
         Gridtractividades_level1Column = new GXWebColumn();
         A55TrListaActividad_ID = (Guid)(Guid.Empty);
         A56TrListaActividad_Nombre = "";
         A57TrListaActividad_Descripcion = "";
         A58TrListaActividad_FechaInicio = DateTime.MinValue;
         A59TrListaActividad_FechaFin = DateTime.MinValue;
         A60TrListaActividad_FechaCreacion = DateTime.MinValue;
         A61TrListaActividad_FechaModificacion = DateTime.MinValue;
         sMode9 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXCCtl = "";
         Z28TrActividades_Descripcion = "";
         T00047_A26TrActividades_ID = new long[1] ;
         T00047_A27TrActividades_Nombre = new String[] {""} ;
         T00047_n27TrActividades_Nombre = new bool[] {false} ;
         T00047_A28TrActividades_Descripcion = new String[] {""} ;
         T00047_n28TrActividades_Descripcion = new bool[] {false} ;
         T00047_A29TrActividades_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         T00047_n29TrActividades_FechaInicio = new bool[] {false} ;
         T00047_A30TrActividades_FechaFin = new DateTime[] {DateTime.MinValue} ;
         T00047_n30TrActividades_FechaFin = new bool[] {false} ;
         T00047_A31TrActividades_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00047_n31TrActividades_FechaCreacion = new bool[] {false} ;
         T00047_A32TrActividades_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00047_n32TrActividades_FechaModificacion = new bool[] {false} ;
         T00047_A33TrActividades_Estado = new short[1] ;
         T00047_n33TrActividades_Estado = new bool[] {false} ;
         T00047_A25TrActividades_IDTarea = new long[1] ;
         T00047_n25TrActividades_IDTarea = new bool[] {false} ;
         T00046_A25TrActividades_IDTarea = new long[1] ;
         T00046_n25TrActividades_IDTarea = new bool[] {false} ;
         T00048_A25TrActividades_IDTarea = new long[1] ;
         T00048_n25TrActividades_IDTarea = new bool[] {false} ;
         T00049_A26TrActividades_ID = new long[1] ;
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
         sMode4 = "";
         T000410_A26TrActividades_ID = new long[1] ;
         T000411_A26TrActividades_ID = new long[1] ;
         T00044_A26TrActividades_ID = new long[1] ;
         T00044_A27TrActividades_Nombre = new String[] {""} ;
         T00044_n27TrActividades_Nombre = new bool[] {false} ;
         T00044_A28TrActividades_Descripcion = new String[] {""} ;
         T00044_n28TrActividades_Descripcion = new bool[] {false} ;
         T00044_A29TrActividades_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         T00044_n29TrActividades_FechaInicio = new bool[] {false} ;
         T00044_A30TrActividades_FechaFin = new DateTime[] {DateTime.MinValue} ;
         T00044_n30TrActividades_FechaFin = new bool[] {false} ;
         T00044_A31TrActividades_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00044_n31TrActividades_FechaCreacion = new bool[] {false} ;
         T00044_A32TrActividades_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00044_n32TrActividades_FechaModificacion = new bool[] {false} ;
         T00044_A33TrActividades_Estado = new short[1] ;
         T00044_n33TrActividades_Estado = new bool[] {false} ;
         T00044_A25TrActividades_IDTarea = new long[1] ;
         T00044_n25TrActividades_IDTarea = new bool[] {false} ;
         T000412_A26TrActividades_ID = new long[1] ;
         T000415_A26TrActividades_ID = new long[1] ;
         Z57TrListaActividad_Descripcion = "";
         T000416_A26TrActividades_ID = new long[1] ;
         T000416_A55TrListaActividad_ID = new Guid[] {Guid.Empty} ;
         T000416_A56TrListaActividad_Nombre = new String[] {""} ;
         T000416_n56TrListaActividad_Nombre = new bool[] {false} ;
         T000416_A57TrListaActividad_Descripcion = new String[] {""} ;
         T000416_n57TrListaActividad_Descripcion = new bool[] {false} ;
         T000416_A58TrListaActividad_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         T000416_n58TrListaActividad_FechaInicio = new bool[] {false} ;
         T000416_A59TrListaActividad_FechaFin = new DateTime[] {DateTime.MinValue} ;
         T000416_n59TrListaActividad_FechaFin = new bool[] {false} ;
         T000416_A60TrListaActividad_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T000416_n60TrListaActividad_FechaCreacion = new bool[] {false} ;
         T000416_A61TrListaActividad_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T000416_n61TrListaActividad_FechaModificacion = new bool[] {false} ;
         T000416_A62TrListaActividad_Estado = new short[1] ;
         T000416_n62TrListaActividad_Estado = new bool[] {false} ;
         T000417_A26TrActividades_ID = new long[1] ;
         T000417_A55TrListaActividad_ID = new Guid[] {Guid.Empty} ;
         T00043_A26TrActividades_ID = new long[1] ;
         T00043_A55TrListaActividad_ID = new Guid[] {Guid.Empty} ;
         T00043_A56TrListaActividad_Nombre = new String[] {""} ;
         T00043_n56TrListaActividad_Nombre = new bool[] {false} ;
         T00043_A57TrListaActividad_Descripcion = new String[] {""} ;
         T00043_n57TrListaActividad_Descripcion = new bool[] {false} ;
         T00043_A58TrListaActividad_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         T00043_n58TrListaActividad_FechaInicio = new bool[] {false} ;
         T00043_A59TrListaActividad_FechaFin = new DateTime[] {DateTime.MinValue} ;
         T00043_n59TrListaActividad_FechaFin = new bool[] {false} ;
         T00043_A60TrListaActividad_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00043_n60TrListaActividad_FechaCreacion = new bool[] {false} ;
         T00043_A61TrListaActividad_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00043_n61TrListaActividad_FechaModificacion = new bool[] {false} ;
         T00043_A62TrListaActividad_Estado = new short[1] ;
         T00043_n62TrListaActividad_Estado = new bool[] {false} ;
         T00042_A26TrActividades_ID = new long[1] ;
         T00042_A55TrListaActividad_ID = new Guid[] {Guid.Empty} ;
         T00042_A56TrListaActividad_Nombre = new String[] {""} ;
         T00042_n56TrListaActividad_Nombre = new bool[] {false} ;
         T00042_A57TrListaActividad_Descripcion = new String[] {""} ;
         T00042_n57TrListaActividad_Descripcion = new bool[] {false} ;
         T00042_A58TrListaActividad_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         T00042_n58TrListaActividad_FechaInicio = new bool[] {false} ;
         T00042_A59TrListaActividad_FechaFin = new DateTime[] {DateTime.MinValue} ;
         T00042_n59TrListaActividad_FechaFin = new bool[] {false} ;
         T00042_A60TrListaActividad_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00042_n60TrListaActividad_FechaCreacion = new bool[] {false} ;
         T00042_A61TrListaActividad_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00042_n61TrListaActividad_FechaModificacion = new bool[] {false} ;
         T00042_A62TrListaActividad_Estado = new short[1] ;
         T00042_n62TrListaActividad_Estado = new bool[] {false} ;
         T000421_A26TrActividades_ID = new long[1] ;
         T000421_A55TrListaActividad_ID = new Guid[] {Guid.Empty} ;
         Gridtractividades_level1Row = new GXWebRow();
         subGridtractividades_level1_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ27TrActividades_Nombre = "";
         ZZ28TrActividades_Descripcion = "";
         ZZ29TrActividades_FechaInicio = DateTime.MinValue;
         ZZ30TrActividades_FechaFin = DateTime.MinValue;
         ZZ31TrActividades_FechaCreacion = DateTime.MinValue;
         ZZ32TrActividades_FechaModificacion = DateTime.MinValue;
         T000422_A25TrActividades_IDTarea = new long[1] ;
         T000422_n25TrActividades_IDTarea = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tractividades__default(),
            new Object[][] {
                new Object[] {
               T00042_A26TrActividades_ID, T00042_A55TrListaActividad_ID, T00042_A56TrListaActividad_Nombre, T00042_n56TrListaActividad_Nombre, T00042_A57TrListaActividad_Descripcion, T00042_n57TrListaActividad_Descripcion, T00042_A58TrListaActividad_FechaInicio, T00042_n58TrListaActividad_FechaInicio, T00042_A59TrListaActividad_FechaFin, T00042_n59TrListaActividad_FechaFin,
               T00042_A60TrListaActividad_FechaCreacion, T00042_n60TrListaActividad_FechaCreacion, T00042_A61TrListaActividad_FechaModificacion, T00042_n61TrListaActividad_FechaModificacion, T00042_A62TrListaActividad_Estado, T00042_n62TrListaActividad_Estado
               }
               , new Object[] {
               T00043_A26TrActividades_ID, T00043_A55TrListaActividad_ID, T00043_A56TrListaActividad_Nombre, T00043_n56TrListaActividad_Nombre, T00043_A57TrListaActividad_Descripcion, T00043_n57TrListaActividad_Descripcion, T00043_A58TrListaActividad_FechaInicio, T00043_n58TrListaActividad_FechaInicio, T00043_A59TrListaActividad_FechaFin, T00043_n59TrListaActividad_FechaFin,
               T00043_A60TrListaActividad_FechaCreacion, T00043_n60TrListaActividad_FechaCreacion, T00043_A61TrListaActividad_FechaModificacion, T00043_n61TrListaActividad_FechaModificacion, T00043_A62TrListaActividad_Estado, T00043_n62TrListaActividad_Estado
               }
               , new Object[] {
               T00044_A26TrActividades_ID, T00044_A27TrActividades_Nombre, T00044_n27TrActividades_Nombre, T00044_A28TrActividades_Descripcion, T00044_n28TrActividades_Descripcion, T00044_A29TrActividades_FechaInicio, T00044_n29TrActividades_FechaInicio, T00044_A30TrActividades_FechaFin, T00044_n30TrActividades_FechaFin, T00044_A31TrActividades_FechaCreacion,
               T00044_n31TrActividades_FechaCreacion, T00044_A32TrActividades_FechaModificacion, T00044_n32TrActividades_FechaModificacion, T00044_A33TrActividades_Estado, T00044_n33TrActividades_Estado, T00044_A25TrActividades_IDTarea, T00044_n25TrActividades_IDTarea
               }
               , new Object[] {
               T00045_A26TrActividades_ID, T00045_A27TrActividades_Nombre, T00045_n27TrActividades_Nombre, T00045_A28TrActividades_Descripcion, T00045_n28TrActividades_Descripcion, T00045_A29TrActividades_FechaInicio, T00045_n29TrActividades_FechaInicio, T00045_A30TrActividades_FechaFin, T00045_n30TrActividades_FechaFin, T00045_A31TrActividades_FechaCreacion,
               T00045_n31TrActividades_FechaCreacion, T00045_A32TrActividades_FechaModificacion, T00045_n32TrActividades_FechaModificacion, T00045_A33TrActividades_Estado, T00045_n33TrActividades_Estado, T00045_A25TrActividades_IDTarea, T00045_n25TrActividades_IDTarea
               }
               , new Object[] {
               T00046_A25TrActividades_IDTarea
               }
               , new Object[] {
               T00047_A26TrActividades_ID, T00047_A27TrActividades_Nombre, T00047_n27TrActividades_Nombre, T00047_A28TrActividades_Descripcion, T00047_n28TrActividades_Descripcion, T00047_A29TrActividades_FechaInicio, T00047_n29TrActividades_FechaInicio, T00047_A30TrActividades_FechaFin, T00047_n30TrActividades_FechaFin, T00047_A31TrActividades_FechaCreacion,
               T00047_n31TrActividades_FechaCreacion, T00047_A32TrActividades_FechaModificacion, T00047_n32TrActividades_FechaModificacion, T00047_A33TrActividades_Estado, T00047_n33TrActividades_Estado, T00047_A25TrActividades_IDTarea, T00047_n25TrActividades_IDTarea
               }
               , new Object[] {
               T00048_A25TrActividades_IDTarea
               }
               , new Object[] {
               T00049_A26TrActividades_ID
               }
               , new Object[] {
               T000410_A26TrActividades_ID
               }
               , new Object[] {
               T000411_A26TrActividades_ID
               }
               , new Object[] {
               T000412_A26TrActividades_ID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000415_A26TrActividades_ID
               }
               , new Object[] {
               T000416_A26TrActividades_ID, T000416_A55TrListaActividad_ID, T000416_A56TrListaActividad_Nombre, T000416_n56TrListaActividad_Nombre, T000416_A57TrListaActividad_Descripcion, T000416_n57TrListaActividad_Descripcion, T000416_A58TrListaActividad_FechaInicio, T000416_n58TrListaActividad_FechaInicio, T000416_A59TrListaActividad_FechaFin, T000416_n59TrListaActividad_FechaFin,
               T000416_A60TrListaActividad_FechaCreacion, T000416_n60TrListaActividad_FechaCreacion, T000416_A61TrListaActividad_FechaModificacion, T000416_n61TrListaActividad_FechaModificacion, T000416_A62TrListaActividad_Estado, T000416_n62TrListaActividad_Estado
               }
               , new Object[] {
               T000417_A26TrActividades_ID, T000417_A55TrListaActividad_ID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000421_A26TrActividades_ID, T000421_A55TrListaActividad_ID
               }
               , new Object[] {
               T000422_A25TrActividades_IDTarea
               }
            }
         );
         Z55TrListaActividad_ID = (Guid)(Guid.NewGuid( ));
         A55TrListaActividad_ID = (Guid)(Guid.NewGuid( ));
      }

      private short Z33TrActividades_Estado ;
      private short Z62TrListaActividad_Estado ;
      private short nRcdDeleted_9 ;
      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short GxWebError ;
      private short Gx_BScreen ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A33TrActividades_Estado ;
      private short subGridtractividades_level1_Backcolorstyle ;
      private short A62TrListaActividad_Estado ;
      private short subGridtractividades_level1_Allowselection ;
      private short subGridtractividades_level1_Allowhovering ;
      private short subGridtractividades_level1_Allowcollapsing ;
      private short subGridtractividades_level1_Collapsed ;
      private short nBlankRcdCount9 ;
      private short RcdFound9 ;
      private short nBlankRcdUsr9 ;
      private short GX_JID ;
      private short RcdFound4 ;
      private short nIsDirty_4 ;
      private short nIsDirty_9 ;
      private short subGridtractividades_level1_Backstyle ;
      private short gxajaxcallmode ;
      private short ZZ33TrActividades_Estado ;
      private int nRC_GXsfl_74 ;
      private int nGXsfl_74_idx=1 ;
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
      private int edtTrListaActividad_ID_Enabled ;
      private int edtTrListaActividad_Nombre_Enabled ;
      private int edtTrListaActividad_Descripcion_Enabled ;
      private int edtTrListaActividad_FechaInicio_Enabled ;
      private int edtTrListaActividad_FechaFin_Enabled ;
      private int edtTrListaActividad_FechaCreacion_Enabled ;
      private int edtTrListaActividad_FechaModificacion_Enabled ;
      private int subGridtractividades_level1_Selectedindex ;
      private int subGridtractividades_level1_Selectioncolor ;
      private int subGridtractividades_level1_Hoveringcolor ;
      private int fRowAdded ;
      private int subGridtractividades_level1_Backcolor ;
      private int subGridtractividades_level1_Allbackcolor ;
      private int defedtTrListaActividad_ID_Enabled ;
      private int idxLst ;
      private long Z26TrActividades_ID ;
      private long Z25TrActividades_IDTarea ;
      private long A25TrActividades_IDTarea ;
      private long A26TrActividades_ID ;
      private long GRIDTRACTIVIDADES_LEVEL1_nFirstRecordOnPage ;
      private long ZZ26TrActividades_ID ;
      private long ZZ25TrActividades_IDTarea ;
      private String sPrefix ;
      private String Z27TrActividades_Nombre ;
      private String Z56TrListaActividad_Nombre ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_74_idx="0001" ;
      private String Gx_mode ;
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
      private String lblTitlelevel1_Internalname ;
      private String lblTitlelevel1_Jsonclick ;
      private String bttBtn_enter_Internalname ;
      private String bttBtn_enter_Jsonclick ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String bttBtn_delete_Internalname ;
      private String bttBtn_delete_Jsonclick ;
      private String subGridtractividades_level1_Header ;
      private String A56TrListaActividad_Nombre ;
      private String sMode9 ;
      private String edtTrListaActividad_ID_Internalname ;
      private String edtTrListaActividad_Nombre_Internalname ;
      private String edtTrListaActividad_Descripcion_Internalname ;
      private String edtTrListaActividad_FechaInicio_Internalname ;
      private String edtTrListaActividad_FechaFin_Internalname ;
      private String edtTrListaActividad_FechaCreacion_Internalname ;
      private String edtTrListaActividad_FechaModificacion_Internalname ;
      private String cmbTrListaActividad_Estado_Internalname ;
      private String sStyleString ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String GXCCtl ;
      private String sMode4 ;
      private String sGXsfl_74_fel_idx="0001" ;
      private String subGridtractividades_level1_Class ;
      private String subGridtractividades_level1_Linesclass ;
      private String ROClassString ;
      private String edtTrListaActividad_ID_Jsonclick ;
      private String edtTrListaActividad_Nombre_Jsonclick ;
      private String edtTrListaActividad_Descripcion_Jsonclick ;
      private String edtTrListaActividad_FechaInicio_Jsonclick ;
      private String edtTrListaActividad_FechaFin_Jsonclick ;
      private String edtTrListaActividad_FechaCreacion_Jsonclick ;
      private String edtTrListaActividad_FechaModificacion_Jsonclick ;
      private String cmbTrListaActividad_Estado_Jsonclick ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String subGridtractividades_level1_Internalname ;
      private String ZZ27TrActividades_Nombre ;
      private DateTime Z29TrActividades_FechaInicio ;
      private DateTime Z30TrActividades_FechaFin ;
      private DateTime Z31TrActividades_FechaCreacion ;
      private DateTime Z32TrActividades_FechaModificacion ;
      private DateTime Z58TrListaActividad_FechaInicio ;
      private DateTime Z59TrListaActividad_FechaFin ;
      private DateTime Z60TrListaActividad_FechaCreacion ;
      private DateTime Z61TrListaActividad_FechaModificacion ;
      private DateTime A29TrActividades_FechaInicio ;
      private DateTime A30TrActividades_FechaFin ;
      private DateTime A31TrActividades_FechaCreacion ;
      private DateTime A32TrActividades_FechaModificacion ;
      private DateTime A58TrListaActividad_FechaInicio ;
      private DateTime A59TrListaActividad_FechaFin ;
      private DateTime A60TrListaActividad_FechaCreacion ;
      private DateTime A61TrListaActividad_FechaModificacion ;
      private DateTime ZZ29TrActividades_FechaInicio ;
      private DateTime ZZ30TrActividades_FechaFin ;
      private DateTime ZZ31TrActividades_FechaCreacion ;
      private DateTime ZZ32TrActividades_FechaModificacion ;
      private bool entryPointCalled ;
      private bool n25TrActividades_IDTarea ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n33TrActividades_Estado ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool n27TrActividades_Nombre ;
      private bool n29TrActividades_FechaInicio ;
      private bool n30TrActividades_FechaFin ;
      private bool n31TrActividades_FechaCreacion ;
      private bool n32TrActividades_FechaModificacion ;
      private bool n28TrActividades_Descripcion ;
      private bool Gx_longc ;
      private bool n56TrListaActividad_Nombre ;
      private bool n57TrListaActividad_Descripcion ;
      private bool n58TrListaActividad_FechaInicio ;
      private bool n59TrListaActividad_FechaFin ;
      private bool n60TrListaActividad_FechaCreacion ;
      private bool n61TrListaActividad_FechaModificacion ;
      private bool n62TrListaActividad_Estado ;
      private String A28TrActividades_Descripcion ;
      private String A57TrListaActividad_Descripcion ;
      private String Z28TrActividades_Descripcion ;
      private String Z57TrListaActividad_Descripcion ;
      private String ZZ28TrActividades_Descripcion ;
      private Guid Z55TrListaActividad_ID ;
      private Guid A55TrListaActividad_ID ;
      private GXWebGrid Gridtractividades_level1Container ;
      private GXWebRow Gridtractividades_level1Row ;
      private GXWebColumn Gridtractividades_level1Column ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTrActividades_Estado ;
      private GXCombobox cmbTrListaActividad_Estado ;
      private IDataStoreProvider pr_default ;
      private long[] T00047_A26TrActividades_ID ;
      private String[] T00047_A27TrActividades_Nombre ;
      private bool[] T00047_n27TrActividades_Nombre ;
      private String[] T00047_A28TrActividades_Descripcion ;
      private bool[] T00047_n28TrActividades_Descripcion ;
      private DateTime[] T00047_A29TrActividades_FechaInicio ;
      private bool[] T00047_n29TrActividades_FechaInicio ;
      private DateTime[] T00047_A30TrActividades_FechaFin ;
      private bool[] T00047_n30TrActividades_FechaFin ;
      private DateTime[] T00047_A31TrActividades_FechaCreacion ;
      private bool[] T00047_n31TrActividades_FechaCreacion ;
      private DateTime[] T00047_A32TrActividades_FechaModificacion ;
      private bool[] T00047_n32TrActividades_FechaModificacion ;
      private short[] T00047_A33TrActividades_Estado ;
      private bool[] T00047_n33TrActividades_Estado ;
      private long[] T00047_A25TrActividades_IDTarea ;
      private bool[] T00047_n25TrActividades_IDTarea ;
      private long[] T00046_A25TrActividades_IDTarea ;
      private bool[] T00046_n25TrActividades_IDTarea ;
      private long[] T00048_A25TrActividades_IDTarea ;
      private bool[] T00048_n25TrActividades_IDTarea ;
      private long[] T00049_A26TrActividades_ID ;
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
      private long[] T000410_A26TrActividades_ID ;
      private long[] T000411_A26TrActividades_ID ;
      private long[] T00044_A26TrActividades_ID ;
      private String[] T00044_A27TrActividades_Nombre ;
      private bool[] T00044_n27TrActividades_Nombre ;
      private String[] T00044_A28TrActividades_Descripcion ;
      private bool[] T00044_n28TrActividades_Descripcion ;
      private DateTime[] T00044_A29TrActividades_FechaInicio ;
      private bool[] T00044_n29TrActividades_FechaInicio ;
      private DateTime[] T00044_A30TrActividades_FechaFin ;
      private bool[] T00044_n30TrActividades_FechaFin ;
      private DateTime[] T00044_A31TrActividades_FechaCreacion ;
      private bool[] T00044_n31TrActividades_FechaCreacion ;
      private DateTime[] T00044_A32TrActividades_FechaModificacion ;
      private bool[] T00044_n32TrActividades_FechaModificacion ;
      private short[] T00044_A33TrActividades_Estado ;
      private bool[] T00044_n33TrActividades_Estado ;
      private long[] T00044_A25TrActividades_IDTarea ;
      private bool[] T00044_n25TrActividades_IDTarea ;
      private long[] T000412_A26TrActividades_ID ;
      private long[] T000415_A26TrActividades_ID ;
      private long[] T000416_A26TrActividades_ID ;
      private Guid[] T000416_A55TrListaActividad_ID ;
      private String[] T000416_A56TrListaActividad_Nombre ;
      private bool[] T000416_n56TrListaActividad_Nombre ;
      private String[] T000416_A57TrListaActividad_Descripcion ;
      private bool[] T000416_n57TrListaActividad_Descripcion ;
      private DateTime[] T000416_A58TrListaActividad_FechaInicio ;
      private bool[] T000416_n58TrListaActividad_FechaInicio ;
      private DateTime[] T000416_A59TrListaActividad_FechaFin ;
      private bool[] T000416_n59TrListaActividad_FechaFin ;
      private DateTime[] T000416_A60TrListaActividad_FechaCreacion ;
      private bool[] T000416_n60TrListaActividad_FechaCreacion ;
      private DateTime[] T000416_A61TrListaActividad_FechaModificacion ;
      private bool[] T000416_n61TrListaActividad_FechaModificacion ;
      private short[] T000416_A62TrListaActividad_Estado ;
      private bool[] T000416_n62TrListaActividad_Estado ;
      private long[] T000417_A26TrActividades_ID ;
      private Guid[] T000417_A55TrListaActividad_ID ;
      private long[] T00043_A26TrActividades_ID ;
      private Guid[] T00043_A55TrListaActividad_ID ;
      private String[] T00043_A56TrListaActividad_Nombre ;
      private bool[] T00043_n56TrListaActividad_Nombre ;
      private String[] T00043_A57TrListaActividad_Descripcion ;
      private bool[] T00043_n57TrListaActividad_Descripcion ;
      private DateTime[] T00043_A58TrListaActividad_FechaInicio ;
      private bool[] T00043_n58TrListaActividad_FechaInicio ;
      private DateTime[] T00043_A59TrListaActividad_FechaFin ;
      private bool[] T00043_n59TrListaActividad_FechaFin ;
      private DateTime[] T00043_A60TrListaActividad_FechaCreacion ;
      private bool[] T00043_n60TrListaActividad_FechaCreacion ;
      private DateTime[] T00043_A61TrListaActividad_FechaModificacion ;
      private bool[] T00043_n61TrListaActividad_FechaModificacion ;
      private short[] T00043_A62TrListaActividad_Estado ;
      private bool[] T00043_n62TrListaActividad_Estado ;
      private long[] T00042_A26TrActividades_ID ;
      private Guid[] T00042_A55TrListaActividad_ID ;
      private String[] T00042_A56TrListaActividad_Nombre ;
      private bool[] T00042_n56TrListaActividad_Nombre ;
      private String[] T00042_A57TrListaActividad_Descripcion ;
      private bool[] T00042_n57TrListaActividad_Descripcion ;
      private DateTime[] T00042_A58TrListaActividad_FechaInicio ;
      private bool[] T00042_n58TrListaActividad_FechaInicio ;
      private DateTime[] T00042_A59TrListaActividad_FechaFin ;
      private bool[] T00042_n59TrListaActividad_FechaFin ;
      private DateTime[] T00042_A60TrListaActividad_FechaCreacion ;
      private bool[] T00042_n60TrListaActividad_FechaCreacion ;
      private DateTime[] T00042_A61TrListaActividad_FechaModificacion ;
      private bool[] T00042_n61TrListaActividad_FechaModificacion ;
      private short[] T00042_A62TrListaActividad_Estado ;
      private bool[] T00042_n62TrListaActividad_Estado ;
      private long[] T000421_A26TrActividades_ID ;
      private Guid[] T000421_A55TrListaActividad_ID ;
      private long[] T000422_A25TrActividades_IDTarea ;
      private bool[] T000422_n25TrActividades_IDTarea ;
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
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00047 ;
          prmT00047 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00046 ;
          prmT00046 = new Object[] {
          new Object[] {"@TrActividades_IDTarea",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00048 ;
          prmT00048 = new Object[] {
          new Object[] {"@TrActividades_IDTarea",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00049 ;
          prmT00049 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00045 ;
          prmT00045 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000410 ;
          prmT000410 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000411 ;
          prmT000411 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00044 ;
          prmT00044 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000412 ;
          prmT000412 = new Object[] {
          new Object[] {"@TrActividades_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@TrActividades_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrActividades_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrActividades_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrActividades_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrActividades_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrActividades_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrActividades_IDTarea",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000413 ;
          prmT000413 = new Object[] {
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
          Object[] prmT000414 ;
          prmT000414 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000415 ;
          prmT000415 = new Object[] {
          } ;
          Object[] prmT000416 ;
          prmT000416 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@TrListaActividad_ID",SqlDbType.UniqueIdentifier,13,0}
          } ;
          Object[] prmT000417 ;
          prmT000417 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@TrListaActividad_ID",SqlDbType.UniqueIdentifier,13,0}
          } ;
          Object[] prmT00043 ;
          prmT00043 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@TrListaActividad_ID",SqlDbType.UniqueIdentifier,13,0}
          } ;
          Object[] prmT00042 ;
          prmT00042 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@TrListaActividad_ID",SqlDbType.UniqueIdentifier,13,0}
          } ;
          Object[] prmT000418 ;
          prmT000418 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@TrListaActividad_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@TrListaActividad_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrListaActividad_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrListaActividad_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrListaActividad_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrListaActividad_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrListaActividad_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrListaActividad_ID",SqlDbType.UniqueIdentifier,13,0}
          } ;
          Object[] prmT000419 ;
          prmT000419 = new Object[] {
          new Object[] {"@TrListaActividad_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@TrListaActividad_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrListaActividad_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrListaActividad_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrListaActividad_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrListaActividad_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrListaActividad_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@TrListaActividad_ID",SqlDbType.UniqueIdentifier,13,0}
          } ;
          Object[] prmT000420 ;
          prmT000420 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@TrListaActividad_ID",SqlDbType.UniqueIdentifier,13,0}
          } ;
          Object[] prmT000421 ;
          prmT000421 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000422 ;
          prmT000422 = new Object[] {
          new Object[] {"@TrActividades_IDTarea",SqlDbType.Decimal,13,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T00042", "SELECT [TrActividades_ID], [TrListaActividad_ID], [TrListaActividad_Nombre], [TrListaActividad_Descripcion], [TrListaActividad_FechaInicio], [TrListaActividad_FechaFin], [TrListaActividad_FechaCreacion], [TrListaActividad_FechaModificacion], [TrListaActividad_Estado] FROM TABLERO.[TrActividadesLevel1] WITH (UPDLOCK) WHERE [TrActividades_ID] = @TrActividades_ID AND [TrListaActividad_ID] = @TrListaActividad_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00043", "SELECT [TrActividades_ID], [TrListaActividad_ID], [TrListaActividad_Nombre], [TrListaActividad_Descripcion], [TrListaActividad_FechaInicio], [TrListaActividad_FechaFin], [TrListaActividad_FechaCreacion], [TrListaActividad_FechaModificacion], [TrListaActividad_Estado] FROM TABLERO.[TrActividadesLevel1] WHERE [TrActividades_ID] = @TrActividades_ID AND [TrListaActividad_ID] = @TrListaActividad_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00044", "SELECT [TrActividades_ID], [TrActividades_Nombre], [TrActividades_Descripcion], [TrActividades_FechaInicio], [TrActividades_FechaFin], [TrActividades_FechaCreacion], [TrActividades_FechaModificacion], [TrActividades_Estado], [TrActividades_IDTarea] AS TrActividades_IDTarea FROM TABLERO.[TrActividades] WITH (UPDLOCK) WHERE [TrActividades_ID] = @TrActividades_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00045", "SELECT [TrActividades_ID], [TrActividades_Nombre], [TrActividades_Descripcion], [TrActividades_FechaInicio], [TrActividades_FechaFin], [TrActividades_FechaCreacion], [TrActividades_FechaModificacion], [TrActividades_Estado], [TrActividades_IDTarea] AS TrActividades_IDTarea FROM TABLERO.[TrActividades] WHERE [TrActividades_ID] = @TrActividades_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00046", "SELECT [TrGestionTareas_ID] AS TrActividades_IDTarea FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_ID] = @TrActividades_IDTarea ",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00047", "SELECT TM1.[TrActividades_ID], TM1.[TrActividades_Nombre], TM1.[TrActividades_Descripcion], TM1.[TrActividades_FechaInicio], TM1.[TrActividades_FechaFin], TM1.[TrActividades_FechaCreacion], TM1.[TrActividades_FechaModificacion], TM1.[TrActividades_Estado], TM1.[TrActividades_IDTarea] AS TrActividades_IDTarea FROM TABLERO.[TrActividades] TM1 WHERE TM1.[TrActividades_ID] = @TrActividades_ID ORDER BY TM1.[TrActividades_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00047,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00048", "SELECT [TrGestionTareas_ID] AS TrActividades_IDTarea FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_ID] = @TrActividades_IDTarea ",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00049", "SELECT [TrActividades_ID] FROM TABLERO.[TrActividades] WHERE [TrActividades_ID] = @TrActividades_ID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000410", "SELECT TOP 1 [TrActividades_ID] FROM TABLERO.[TrActividades] WHERE ( [TrActividades_ID] > @TrActividades_ID) ORDER BY [TrActividades_ID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000410,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000411", "SELECT TOP 1 [TrActividades_ID] FROM TABLERO.[TrActividades] WHERE ( [TrActividades_ID] < @TrActividades_ID) ORDER BY [TrActividades_ID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000411,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000412", "INSERT INTO TABLERO.[TrActividades]([TrActividades_Nombre], [TrActividades_Descripcion], [TrActividades_FechaInicio], [TrActividades_FechaFin], [TrActividades_FechaCreacion], [TrActividades_FechaModificacion], [TrActividades_Estado], [TrActividades_IDTarea]) VALUES(@TrActividades_Nombre, @TrActividades_Descripcion, @TrActividades_FechaInicio, @TrActividades_FechaFin, @TrActividades_FechaCreacion, @TrActividades_FechaModificacion, @TrActividades_Estado, @TrActividades_IDTarea); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000412)
             ,new CursorDef("T000413", "UPDATE TABLERO.[TrActividades] SET [TrActividades_Nombre]=@TrActividades_Nombre, [TrActividades_Descripcion]=@TrActividades_Descripcion, [TrActividades_FechaInicio]=@TrActividades_FechaInicio, [TrActividades_FechaFin]=@TrActividades_FechaFin, [TrActividades_FechaCreacion]=@TrActividades_FechaCreacion, [TrActividades_FechaModificacion]=@TrActividades_FechaModificacion, [TrActividades_Estado]=@TrActividades_Estado, [TrActividades_IDTarea]=@TrActividades_IDTarea  WHERE [TrActividades_ID] = @TrActividades_ID", GxErrorMask.GX_NOMASK,prmT000413)
             ,new CursorDef("T000414", "DELETE FROM TABLERO.[TrActividades]  WHERE [TrActividades_ID] = @TrActividades_ID", GxErrorMask.GX_NOMASK,prmT000414)
             ,new CursorDef("T000415", "SELECT [TrActividades_ID] FROM TABLERO.[TrActividades] ORDER BY [TrActividades_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000415,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000416", "SELECT [TrActividades_ID], [TrListaActividad_ID], [TrListaActividad_Nombre], [TrListaActividad_Descripcion], [TrListaActividad_FechaInicio], [TrListaActividad_FechaFin], [TrListaActividad_FechaCreacion], [TrListaActividad_FechaModificacion], [TrListaActividad_Estado] FROM TABLERO.[TrActividadesLevel1] WHERE [TrActividades_ID] = @TrActividades_ID and [TrListaActividad_ID] = @TrListaActividad_ID ORDER BY [TrActividades_ID], [TrListaActividad_ID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000416,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000417", "SELECT [TrActividades_ID], [TrListaActividad_ID] FROM TABLERO.[TrActividadesLevel1] WHERE [TrActividades_ID] = @TrActividades_ID AND [TrListaActividad_ID] = @TrListaActividad_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000417,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000418", "INSERT INTO TABLERO.[TrActividadesLevel1]([TrActividades_ID], [TrListaActividad_Nombre], [TrListaActividad_Descripcion], [TrListaActividad_FechaInicio], [TrListaActividad_FechaFin], [TrListaActividad_FechaCreacion], [TrListaActividad_FechaModificacion], [TrListaActividad_Estado], [TrListaActividad_ID]) VALUES(@TrActividades_ID, @TrListaActividad_Nombre, @TrListaActividad_Descripcion, @TrListaActividad_FechaInicio, @TrListaActividad_FechaFin, @TrListaActividad_FechaCreacion, @TrListaActividad_FechaModificacion, @TrListaActividad_Estado, @TrListaActividad_ID)", GxErrorMask.GX_NOMASK,prmT000418)
             ,new CursorDef("T000419", "UPDATE TABLERO.[TrActividadesLevel1] SET [TrListaActividad_Nombre]=@TrListaActividad_Nombre, [TrListaActividad_Descripcion]=@TrListaActividad_Descripcion, [TrListaActividad_FechaInicio]=@TrListaActividad_FechaInicio, [TrListaActividad_FechaFin]=@TrListaActividad_FechaFin, [TrListaActividad_FechaCreacion]=@TrListaActividad_FechaCreacion, [TrListaActividad_FechaModificacion]=@TrListaActividad_FechaModificacion, [TrListaActividad_Estado]=@TrListaActividad_Estado  WHERE [TrActividades_ID] = @TrActividades_ID AND [TrListaActividad_ID] = @TrListaActividad_ID", GxErrorMask.GX_NOMASK,prmT000419)
             ,new CursorDef("T000420", "DELETE FROM TABLERO.[TrActividadesLevel1]  WHERE [TrActividades_ID] = @TrActividades_ID AND [TrListaActividad_ID] = @TrListaActividad_ID", GxErrorMask.GX_NOMASK,prmT000420)
             ,new CursorDef("T000421", "SELECT [TrActividades_ID], [TrListaActividad_ID] FROM TABLERO.[TrActividadesLevel1] WHERE [TrActividades_ID] = @TrActividades_ID ORDER BY [TrActividades_ID], [TrListaActividad_ID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000421,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000422", "SELECT [TrGestionTareas_ID] AS TrActividades_IDTarea FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_ID] = @TrActividades_IDTarea ",true, GxErrorMask.GX_NOMASK, false, this,prmT000422,1, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 100) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((String[]) buf[4])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(8) ;
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((short[]) buf[14])[0] = rslt.getShort(9) ;
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((Guid[]) buf[1])[0] = rslt.getGuid(2) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 100) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((String[]) buf[4])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(8) ;
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((short[]) buf[14])[0] = rslt.getShort(9) ;
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                return;
             case 2 :
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
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 8 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 10 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 13 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 14 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((Guid[]) buf[1])[0] = rslt.getGuid(2) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 100) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((String[]) buf[4])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(8) ;
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((short[]) buf[14])[0] = rslt.getShort(9) ;
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                return;
             case 15 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((Guid[]) buf[1])[0] = rslt.getGuid(2) ;
                return;
             case 19 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((Guid[]) buf[1])[0] = rslt.getGuid(2) ;
                return;
             case 20 :
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
                stmt.SetParameter(2, (Guid)parms[1]);
                return;
             case 1 :
                stmt.SetParameter(1, (long)parms[0]);
                stmt.SetParameter(2, (Guid)parms[1]);
                return;
             case 2 :
                stmt.SetParameter(1, (long)parms[0]);
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
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Decimal );
                }
                else
                {
                   stmt.SetParameter(1, (long)parms[1]);
                }
                return;
             case 7 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 8 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 9 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 10 :
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
                return;
             case 11 :
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
             case 12 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 14 :
                stmt.SetParameter(1, (long)parms[0]);
                stmt.SetParameter(2, (Guid)parms[1]);
                return;
             case 15 :
                stmt.SetParameter(1, (long)parms[0]);
                stmt.SetParameter(2, (Guid)parms[1]);
                return;
             case 16 :
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
                stmt.SetParameter(9, (Guid)parms[15]);
                return;
             case 17 :
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
                stmt.SetParameter(8, (long)parms[14]);
                stmt.SetParameter(9, (Guid)parms[15]);
                return;
             case 18 :
                stmt.SetParameter(1, (long)parms[0]);
                stmt.SetParameter(2, (Guid)parms[1]);
                return;
             case 19 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 20 :
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
