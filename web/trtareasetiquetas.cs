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
   public class trtareasetiquetas : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A53TrTareasEtiquetas_IDEtiqueta = (long)(NumberUtil.Val( GetNextPar( ), "."));
            AssignAttri("", false, "A53TrTareasEtiquetas_IDEtiqueta", StringUtil.LTrimStr( (decimal)(A53TrTareasEtiquetas_IDEtiqueta), 13, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A53TrTareasEtiquetas_IDEtiqueta) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A52TrTareasEtiquetas_TareaID = (long)(NumberUtil.Val( GetNextPar( ), "."));
            AssignAttri("", false, "A52TrTareasEtiquetas_TareaID", StringUtil.LTrimStr( (decimal)(A52TrTareasEtiquetas_TareaID), 13, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A52TrTareasEtiquetas_TareaID) ;
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
            Form.Meta.addItem("description", "Tr Tareas Etiquetas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         GX_FocusControl = edtTrTareasEtiquetas_ID_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         wbErr = false;
         context.SetDefaultTheme("K2BOrion");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trtareasetiquetas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public trtareasetiquetas( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Tr Tareas Etiquetas", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_TrTareasEtiquetas.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrTareasEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrTareasEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrTareasEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrTareasEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0080.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TRTAREASETIQUETAS_ID"+"'), id:'"+"TRTAREASETIQUETAS_ID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_TrTareasEtiquetas.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrTareasEtiquetas_ID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrTareasEtiquetas_ID_Internalname, "Tareas Etiquetas_ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrTareasEtiquetas_ID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A51TrTareasEtiquetas_ID), 13, 0, ".", "")), ((edtTrTareasEtiquetas_ID_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A51TrTareasEtiquetas_ID), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A51TrTareasEtiquetas_ID), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrTareasEtiquetas_ID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrTareasEtiquetas_ID_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TrTareasEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrTareasEtiquetas_IDEtiqueta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrTareasEtiquetas_IDEtiqueta_Internalname, "Tareas Etiquetas_IDEtiqueta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrTareasEtiquetas_IDEtiqueta_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A53TrTareasEtiquetas_IDEtiqueta), 13, 0, ".", "")), ((edtTrTareasEtiquetas_IDEtiqueta_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A53TrTareasEtiquetas_IDEtiqueta), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A53TrTareasEtiquetas_IDEtiqueta), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrTareasEtiquetas_IDEtiqueta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrTareasEtiquetas_IDEtiqueta_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TrTareasEtiquetas.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (String)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_53_Internalname, sImgUrl, imgprompt_53_Link, "", "", context.GetTheme( ), imgprompt_53_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TrTareasEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrTareasEtiquetas_NombreEtiqueta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrTareasEtiquetas_NombreEtiqueta_Internalname, "Etiquetas_Nombre Etiqueta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTrTareasEtiquetas_NombreEtiqueta_Internalname, StringUtil.RTrim( A54TrTareasEtiquetas_NombreEtiqueta), "", "", 0, 1, edtTrTareasEtiquetas_NombreEtiqueta_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "256", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_TrTareasEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrTareasEtiquetas_TareaID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrTareasEtiquetas_TareaID_Internalname, "Tareas_ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrTareasEtiquetas_TareaID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A52TrTareasEtiquetas_TareaID), 13, 0, ".", "")), ((edtTrTareasEtiquetas_TareaID_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A52TrTareasEtiquetas_TareaID), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A52TrTareasEtiquetas_TareaID), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrTareasEtiquetas_TareaID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrTareasEtiquetas_TareaID_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TrTareasEtiquetas.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (String)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_52_Internalname, sImgUrl, imgprompt_52_Link, "", "", context.GetTheme( ), imgprompt_52_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TrTareasEtiquetas.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrTareasEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrTareasEtiquetas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrTareasEtiquetas.htm");
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
            Z51TrTareasEtiquetas_ID = (long)(context.localUtil.CToN( cgiGet( "Z51TrTareasEtiquetas_ID"), ".", ","));
            Z52TrTareasEtiquetas_TareaID = (long)(context.localUtil.CToN( cgiGet( "Z52TrTareasEtiquetas_TareaID"), ".", ","));
            Z53TrTareasEtiquetas_IDEtiqueta = (long)(context.localUtil.CToN( cgiGet( "Z53TrTareasEtiquetas_IDEtiqueta"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtTrTareasEtiquetas_ID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTrTareasEtiquetas_ID_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRTAREASETIQUETAS_ID");
               AnyError = 1;
               GX_FocusControl = edtTrTareasEtiquetas_ID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A51TrTareasEtiquetas_ID = 0;
               AssignAttri("", false, "A51TrTareasEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A51TrTareasEtiquetas_ID), 13, 0));
            }
            else
            {
               A51TrTareasEtiquetas_ID = (long)(context.localUtil.CToN( cgiGet( edtTrTareasEtiquetas_ID_Internalname), ".", ","));
               AssignAttri("", false, "A51TrTareasEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A51TrTareasEtiquetas_ID), 13, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTrTareasEtiquetas_IDEtiqueta_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTrTareasEtiquetas_IDEtiqueta_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRTAREASETIQUETAS_IDETIQUETA");
               AnyError = 1;
               GX_FocusControl = edtTrTareasEtiquetas_IDEtiqueta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A53TrTareasEtiquetas_IDEtiqueta = 0;
               AssignAttri("", false, "A53TrTareasEtiquetas_IDEtiqueta", StringUtil.LTrimStr( (decimal)(A53TrTareasEtiquetas_IDEtiqueta), 13, 0));
            }
            else
            {
               A53TrTareasEtiquetas_IDEtiqueta = (long)(context.localUtil.CToN( cgiGet( edtTrTareasEtiquetas_IDEtiqueta_Internalname), ".", ","));
               AssignAttri("", false, "A53TrTareasEtiquetas_IDEtiqueta", StringUtil.LTrimStr( (decimal)(A53TrTareasEtiquetas_IDEtiqueta), 13, 0));
            }
            A54TrTareasEtiquetas_NombreEtiqueta = cgiGet( edtTrTareasEtiquetas_NombreEtiqueta_Internalname);
            n54TrTareasEtiquetas_NombreEtiqueta = false;
            AssignAttri("", false, "A54TrTareasEtiquetas_NombreEtiqueta", A54TrTareasEtiquetas_NombreEtiqueta);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTrTareasEtiquetas_TareaID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTrTareasEtiquetas_TareaID_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRTAREASETIQUETAS_TAREAID");
               AnyError = 1;
               GX_FocusControl = edtTrTareasEtiquetas_TareaID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A52TrTareasEtiquetas_TareaID = 0;
               AssignAttri("", false, "A52TrTareasEtiquetas_TareaID", StringUtil.LTrimStr( (decimal)(A52TrTareasEtiquetas_TareaID), 13, 0));
            }
            else
            {
               A52TrTareasEtiquetas_TareaID = (long)(context.localUtil.CToN( cgiGet( edtTrTareasEtiquetas_TareaID_Internalname), ".", ","));
               AssignAttri("", false, "A52TrTareasEtiquetas_TareaID", StringUtil.LTrimStr( (decimal)(A52TrTareasEtiquetas_TareaID), 13, 0));
            }
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
               A51TrTareasEtiquetas_ID = (long)(NumberUtil.Val( GetNextPar( ), "."));
               AssignAttri("", false, "A51TrTareasEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A51TrTareasEtiquetas_ID), 13, 0));
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
               InitAll078( ) ;
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
         DisableAttributes078( ) ;
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

      protected void ResetCaption070( )
      {
      }

      protected void ZM078( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z52TrTareasEtiquetas_TareaID = T00073_A52TrTareasEtiquetas_TareaID[0];
               Z53TrTareasEtiquetas_IDEtiqueta = T00073_A53TrTareasEtiquetas_IDEtiqueta[0];
            }
            else
            {
               Z52TrTareasEtiquetas_TareaID = A52TrTareasEtiquetas_TareaID;
               Z53TrTareasEtiquetas_IDEtiqueta = A53TrTareasEtiquetas_IDEtiqueta;
            }
         }
         if ( GX_JID == -1 )
         {
            Z51TrTareasEtiquetas_ID = A51TrTareasEtiquetas_ID;
            Z52TrTareasEtiquetas_TareaID = A52TrTareasEtiquetas_TareaID;
            Z53TrTareasEtiquetas_IDEtiqueta = A53TrTareasEtiquetas_IDEtiqueta;
            Z54TrTareasEtiquetas_NombreEtiqueta = A54TrTareasEtiquetas_NombreEtiqueta;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_53_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0060.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TRTAREASETIQUETAS_IDETIQUETA"+"'), id:'"+"TRTAREASETIQUETAS_IDETIQUETA"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_52_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TRTAREASETIQUETAS_TAREAID"+"'), id:'"+"TRTAREASETIQUETAS_TAREAID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load078( )
      {
         /* Using cursor T00076 */
         pr_default.execute(4, new Object[] {A51TrTareasEtiquetas_ID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound8 = 1;
            A54TrTareasEtiquetas_NombreEtiqueta = T00076_A54TrTareasEtiquetas_NombreEtiqueta[0];
            n54TrTareasEtiquetas_NombreEtiqueta = T00076_n54TrTareasEtiquetas_NombreEtiqueta[0];
            AssignAttri("", false, "A54TrTareasEtiquetas_NombreEtiqueta", A54TrTareasEtiquetas_NombreEtiqueta);
            A52TrTareasEtiquetas_TareaID = T00076_A52TrTareasEtiquetas_TareaID[0];
            AssignAttri("", false, "A52TrTareasEtiquetas_TareaID", StringUtil.LTrimStr( (decimal)(A52TrTareasEtiquetas_TareaID), 13, 0));
            A53TrTareasEtiquetas_IDEtiqueta = T00076_A53TrTareasEtiquetas_IDEtiqueta[0];
            AssignAttri("", false, "A53TrTareasEtiquetas_IDEtiqueta", StringUtil.LTrimStr( (decimal)(A53TrTareasEtiquetas_IDEtiqueta), 13, 0));
            ZM078( -1) ;
         }
         pr_default.close(4);
         OnLoadActions078( ) ;
      }

      protected void OnLoadActions078( )
      {
      }

      protected void CheckExtendedTable078( )
      {
         nIsDirty_8 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00075 */
         pr_default.execute(3, new Object[] {A53TrTareasEtiquetas_IDEtiqueta});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Tr Etiquetas_STG'.", "ForeignKeyNotFound", 1, "TRTAREASETIQUETAS_IDETIQUETA");
            AnyError = 1;
            GX_FocusControl = edtTrTareasEtiquetas_IDEtiqueta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A54TrTareasEtiquetas_NombreEtiqueta = T00075_A54TrTareasEtiquetas_NombreEtiqueta[0];
         n54TrTareasEtiquetas_NombreEtiqueta = T00075_n54TrTareasEtiquetas_NombreEtiqueta[0];
         AssignAttri("", false, "A54TrTareasEtiquetas_NombreEtiqueta", A54TrTareasEtiquetas_NombreEtiqueta);
         pr_default.close(3);
         /* Using cursor T00074 */
         pr_default.execute(2, new Object[] {A52TrTareasEtiquetas_TareaID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tr Gestion Tareas4_STG'.", "ForeignKeyNotFound", 1, "TRTAREASETIQUETAS_TAREAID");
            AnyError = 1;
            GX_FocusControl = edtTrTareasEtiquetas_TareaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors078( )
      {
         pr_default.close(3);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( long A53TrTareasEtiquetas_IDEtiqueta )
      {
         /* Using cursor T00077 */
         pr_default.execute(5, new Object[] {A53TrTareasEtiquetas_IDEtiqueta});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Tr Etiquetas_STG'.", "ForeignKeyNotFound", 1, "TRTAREASETIQUETAS_IDETIQUETA");
            AnyError = 1;
            GX_FocusControl = edtTrTareasEtiquetas_IDEtiqueta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A54TrTareasEtiquetas_NombreEtiqueta = T00077_A54TrTareasEtiquetas_NombreEtiqueta[0];
         n54TrTareasEtiquetas_NombreEtiqueta = T00077_n54TrTareasEtiquetas_NombreEtiqueta[0];
         AssignAttri("", false, "A54TrTareasEtiquetas_NombreEtiqueta", A54TrTareasEtiquetas_NombreEtiqueta);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A54TrTareasEtiquetas_NombreEtiqueta))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_2( long A52TrTareasEtiquetas_TareaID )
      {
         /* Using cursor T00078 */
         pr_default.execute(6, new Object[] {A52TrTareasEtiquetas_TareaID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Tr Gestion Tareas4_STG'.", "ForeignKeyNotFound", 1, "TRTAREASETIQUETAS_TAREAID");
            AnyError = 1;
            GX_FocusControl = edtTrTareasEtiquetas_TareaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void GetKey078( )
      {
         /* Using cursor T00079 */
         pr_default.execute(7, new Object[] {A51TrTareasEtiquetas_ID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {A51TrTareasEtiquetas_ID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM078( 1) ;
            RcdFound8 = 1;
            A51TrTareasEtiquetas_ID = T00073_A51TrTareasEtiquetas_ID[0];
            AssignAttri("", false, "A51TrTareasEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A51TrTareasEtiquetas_ID), 13, 0));
            A52TrTareasEtiquetas_TareaID = T00073_A52TrTareasEtiquetas_TareaID[0];
            AssignAttri("", false, "A52TrTareasEtiquetas_TareaID", StringUtil.LTrimStr( (decimal)(A52TrTareasEtiquetas_TareaID), 13, 0));
            A53TrTareasEtiquetas_IDEtiqueta = T00073_A53TrTareasEtiquetas_IDEtiqueta[0];
            AssignAttri("", false, "A53TrTareasEtiquetas_IDEtiqueta", StringUtil.LTrimStr( (decimal)(A53TrTareasEtiquetas_IDEtiqueta), 13, 0));
            Z51TrTareasEtiquetas_ID = A51TrTareasEtiquetas_ID;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load078( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey078( ) ;
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey078( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey078( ) ;
         if ( RcdFound8 == 0 )
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
         RcdFound8 = 0;
         /* Using cursor T000710 */
         pr_default.execute(8, new Object[] {A51TrTareasEtiquetas_ID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000710_A51TrTareasEtiquetas_ID[0] < A51TrTareasEtiquetas_ID ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000710_A51TrTareasEtiquetas_ID[0] > A51TrTareasEtiquetas_ID ) ) )
            {
               A51TrTareasEtiquetas_ID = T000710_A51TrTareasEtiquetas_ID[0];
               AssignAttri("", false, "A51TrTareasEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A51TrTareasEtiquetas_ID), 13, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound8 = 0;
         /* Using cursor T000711 */
         pr_default.execute(9, new Object[] {A51TrTareasEtiquetas_ID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000711_A51TrTareasEtiquetas_ID[0] > A51TrTareasEtiquetas_ID ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000711_A51TrTareasEtiquetas_ID[0] < A51TrTareasEtiquetas_ID ) ) )
            {
               A51TrTareasEtiquetas_ID = T000711_A51TrTareasEtiquetas_ID[0];
               AssignAttri("", false, "A51TrTareasEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A51TrTareasEtiquetas_ID), 13, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey078( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTrTareasEtiquetas_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert078( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A51TrTareasEtiquetas_ID != Z51TrTareasEtiquetas_ID )
               {
                  A51TrTareasEtiquetas_ID = Z51TrTareasEtiquetas_ID;
                  AssignAttri("", false, "A51TrTareasEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A51TrTareasEtiquetas_ID), 13, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRTAREASETIQUETAS_ID");
                  AnyError = 1;
                  GX_FocusControl = edtTrTareasEtiquetas_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTrTareasEtiquetas_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update078( ) ;
                  GX_FocusControl = edtTrTareasEtiquetas_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A51TrTareasEtiquetas_ID != Z51TrTareasEtiquetas_ID )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTrTareasEtiquetas_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert078( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRTAREASETIQUETAS_ID");
                     AnyError = 1;
                     GX_FocusControl = edtTrTareasEtiquetas_ID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTrTareasEtiquetas_ID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert078( ) ;
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
         if ( A51TrTareasEtiquetas_ID != Z51TrTareasEtiquetas_ID )
         {
            A51TrTareasEtiquetas_ID = Z51TrTareasEtiquetas_ID;
            AssignAttri("", false, "A51TrTareasEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A51TrTareasEtiquetas_ID), 13, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRTAREASETIQUETAS_ID");
            AnyError = 1;
            GX_FocusControl = edtTrTareasEtiquetas_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTrTareasEtiquetas_ID_Internalname;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TRTAREASETIQUETAS_ID");
            AnyError = 1;
            GX_FocusControl = edtTrTareasEtiquetas_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTrTareasEtiquetas_IDEtiqueta_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart078( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrTareasEtiquetas_IDEtiqueta_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd078( ) ;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrTareasEtiquetas_IDEtiqueta_Internalname;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrTareasEtiquetas_IDEtiqueta_Internalname;
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
         ScanStart078( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound8 != 0 )
            {
               ScanNext078( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrTareasEtiquetas_IDEtiqueta_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd078( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency078( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {A51TrTareasEtiquetas_ID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrTareasEtiquetas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z52TrTareasEtiquetas_TareaID != T00072_A52TrTareasEtiquetas_TareaID[0] ) || ( Z53TrTareasEtiquetas_IDEtiqueta != T00072_A53TrTareasEtiquetas_IDEtiqueta[0] ) )
            {
               if ( Z52TrTareasEtiquetas_TareaID != T00072_A52TrTareasEtiquetas_TareaID[0] )
               {
                  GXUtil.WriteLog("trtareasetiquetas:[seudo value changed for attri]"+"TrTareasEtiquetas_TareaID");
                  GXUtil.WriteLogRaw("Old: ",Z52TrTareasEtiquetas_TareaID);
                  GXUtil.WriteLogRaw("Current: ",T00072_A52TrTareasEtiquetas_TareaID[0]);
               }
               if ( Z53TrTareasEtiquetas_IDEtiqueta != T00072_A53TrTareasEtiquetas_IDEtiqueta[0] )
               {
                  GXUtil.WriteLog("trtareasetiquetas:[seudo value changed for attri]"+"TrTareasEtiquetas_IDEtiqueta");
                  GXUtil.WriteLogRaw("Old: ",Z53TrTareasEtiquetas_IDEtiqueta);
                  GXUtil.WriteLogRaw("Current: ",T00072_A53TrTareasEtiquetas_IDEtiqueta[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TrTareasEtiquetas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert078( )
      {
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable078( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM078( 0) ;
            CheckOptimisticConcurrency078( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm078( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert078( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000712 */
                     pr_default.execute(10, new Object[] {A52TrTareasEtiquetas_TareaID, A53TrTareasEtiquetas_IDEtiqueta});
                     A51TrTareasEtiquetas_ID = T000712_A51TrTareasEtiquetas_ID[0];
                     AssignAttri("", false, "A51TrTareasEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A51TrTareasEtiquetas_ID), 13, 0));
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("TrTareasEtiquetas") ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           GX_msglist.addItem(context.GetMessage( "GXM_sucadded", ""), "SuccessfullyAdded", 0, "", true);
                           ResetCaption070( ) ;
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
               Load078( ) ;
            }
            EndLevel078( ) ;
         }
         CloseExtendedTableCursors078( ) ;
      }

      protected void Update078( )
      {
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable078( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency078( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm078( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate078( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000713 */
                     pr_default.execute(11, new Object[] {A52TrTareasEtiquetas_TareaID, A53TrTareasEtiquetas_IDEtiqueta, A51TrTareasEtiquetas_ID});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("TrTareasEtiquetas") ;
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrTareasEtiquetas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate078( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           GX_msglist.addItem(context.GetMessage( "GXM_sucupdated", ""), "SuccessfullyUpdated", 0, "", true);
                           ResetCaption070( ) ;
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
            EndLevel078( ) ;
         }
         CloseExtendedTableCursors078( ) ;
      }

      protected void DeferredUpdate078( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency078( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls078( ) ;
            AfterConfirm078( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete078( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000714 */
                  pr_default.execute(12, new Object[] {A51TrTareasEtiquetas_ID});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("TrTareasEtiquetas") ;
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound8 == 0 )
                        {
                           InitAll078( ) ;
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
                        ResetCaption070( ) ;
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel078( ) ;
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls078( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000715 */
            pr_default.execute(13, new Object[] {A53TrTareasEtiquetas_IDEtiqueta});
            A54TrTareasEtiquetas_NombreEtiqueta = T000715_A54TrTareasEtiquetas_NombreEtiqueta[0];
            n54TrTareasEtiquetas_NombreEtiqueta = T000715_n54TrTareasEtiquetas_NombreEtiqueta[0];
            AssignAttri("", false, "A54TrTareasEtiquetas_NombreEtiqueta", A54TrTareasEtiquetas_NombreEtiqueta);
            pr_default.close(13);
         }
      }

      protected void EndLevel078( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete078( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            context.CommitDataStores("trtareasetiquetas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            context.RollbackDataStores("trtareasetiquetas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart078( )
      {
         /* Using cursor T000716 */
         pr_default.execute(14);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound8 = 1;
            A51TrTareasEtiquetas_ID = T000716_A51TrTareasEtiquetas_ID[0];
            AssignAttri("", false, "A51TrTareasEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A51TrTareasEtiquetas_ID), 13, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext078( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound8 = 1;
            A51TrTareasEtiquetas_ID = T000716_A51TrTareasEtiquetas_ID[0];
            AssignAttri("", false, "A51TrTareasEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A51TrTareasEtiquetas_ID), 13, 0));
         }
      }

      protected void ScanEnd078( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm078( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert078( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate078( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete078( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete078( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate078( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes078( )
      {
         edtTrTareasEtiquetas_ID_Enabled = 0;
         AssignProp("", false, edtTrTareasEtiquetas_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrTareasEtiquetas_ID_Enabled), 5, 0), true);
         edtTrTareasEtiquetas_IDEtiqueta_Enabled = 0;
         AssignProp("", false, edtTrTareasEtiquetas_IDEtiqueta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrTareasEtiquetas_IDEtiqueta_Enabled), 5, 0), true);
         edtTrTareasEtiquetas_NombreEtiqueta_Enabled = 0;
         AssignProp("", false, edtTrTareasEtiquetas_NombreEtiqueta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrTareasEtiquetas_NombreEtiqueta_Enabled), 5, 0), true);
         edtTrTareasEtiquetas_TareaID_Enabled = 0;
         AssignProp("", false, edtTrTareasEtiquetas_TareaID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrTareasEtiquetas_TareaID_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes078( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues070( )
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
         context.AddJavascriptSource("gxcfg.js", "?202210211744330", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trtareasetiquetas.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z51TrTareasEtiquetas_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z51TrTareasEtiquetas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z52TrTareasEtiquetas_TareaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z52TrTareasEtiquetas_TareaID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z53TrTareasEtiquetas_IDEtiqueta", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z53TrTareasEtiquetas_IDEtiqueta), 13, 0, ".", "")));
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
         return formatLink("trtareasetiquetas.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "TrTareasEtiquetas" ;
      }

      public override String GetPgmdesc( )
      {
         return "Tr Tareas Etiquetas" ;
      }

      protected void InitializeNonKey078( )
      {
         A53TrTareasEtiquetas_IDEtiqueta = 0;
         AssignAttri("", false, "A53TrTareasEtiquetas_IDEtiqueta", StringUtil.LTrimStr( (decimal)(A53TrTareasEtiquetas_IDEtiqueta), 13, 0));
         A54TrTareasEtiquetas_NombreEtiqueta = "";
         n54TrTareasEtiquetas_NombreEtiqueta = false;
         AssignAttri("", false, "A54TrTareasEtiquetas_NombreEtiqueta", A54TrTareasEtiquetas_NombreEtiqueta);
         A52TrTareasEtiquetas_TareaID = 0;
         AssignAttri("", false, "A52TrTareasEtiquetas_TareaID", StringUtil.LTrimStr( (decimal)(A52TrTareasEtiquetas_TareaID), 13, 0));
         Z52TrTareasEtiquetas_TareaID = 0;
         Z53TrTareasEtiquetas_IDEtiqueta = 0;
      }

      protected void InitAll078( )
      {
         A51TrTareasEtiquetas_ID = 0;
         AssignAttri("", false, "A51TrTareasEtiquetas_ID", StringUtil.LTrimStr( (decimal)(A51TrTareasEtiquetas_ID), 13, 0));
         InitializeNonKey078( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210211744335", true, true);
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
         context.AddJavascriptSource("trtareasetiquetas.js", "?202210211744336", false, true);
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
         edtTrTareasEtiquetas_ID_Internalname = "TRTAREASETIQUETAS_ID";
         edtTrTareasEtiquetas_IDEtiqueta_Internalname = "TRTAREASETIQUETAS_IDETIQUETA";
         edtTrTareasEtiquetas_NombreEtiqueta_Internalname = "TRTAREASETIQUETAS_NOMBREETIQUETA";
         edtTrTareasEtiquetas_TareaID_Internalname = "TRTAREASETIQUETAS_TAREAID";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Form.Internalname = "FORM";
         imgprompt_53_Internalname = "PROMPT_53";
         imgprompt_52_Internalname = "PROMPT_52";
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
         Form.Caption = "Tr Tareas Etiquetas";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         imgprompt_52_Visible = 1;
         imgprompt_52_Link = "";
         edtTrTareasEtiquetas_TareaID_Jsonclick = "";
         edtTrTareasEtiquetas_TareaID_Enabled = 1;
         edtTrTareasEtiquetas_NombreEtiqueta_Enabled = 0;
         imgprompt_53_Visible = 1;
         imgprompt_53_Link = "";
         edtTrTareasEtiquetas_IDEtiqueta_Jsonclick = "";
         edtTrTareasEtiquetas_IDEtiqueta_Enabled = 1;
         edtTrTareasEtiquetas_ID_Jsonclick = "";
         edtTrTareasEtiquetas_ID_Enabled = 1;
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
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtTrTareasEtiquetas_IDEtiqueta_Internalname;
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

      public void Valid_Trtareasetiquetas_id( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A53TrTareasEtiquetas_IDEtiqueta", StringUtil.LTrim( StringUtil.NToC( (decimal)(A53TrTareasEtiquetas_IDEtiqueta), 13, 0, ".", "")));
         AssignAttri("", false, "A52TrTareasEtiquetas_TareaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A52TrTareasEtiquetas_TareaID), 13, 0, ".", "")));
         AssignAttri("", false, "A54TrTareasEtiquetas_NombreEtiqueta", StringUtil.RTrim( A54TrTareasEtiquetas_NombreEtiqueta));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z51TrTareasEtiquetas_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z51TrTareasEtiquetas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z53TrTareasEtiquetas_IDEtiqueta", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z53TrTareasEtiquetas_IDEtiqueta), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z52TrTareasEtiquetas_TareaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z52TrTareasEtiquetas_TareaID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z54TrTareasEtiquetas_NombreEtiqueta", StringUtil.RTrim( Z54TrTareasEtiquetas_NombreEtiqueta));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Trtareasetiquetas_idetiqueta( )
      {
         n54TrTareasEtiquetas_NombreEtiqueta = false;
         /* Using cursor T000715 */
         pr_default.execute(13, new Object[] {A53TrTareasEtiquetas_IDEtiqueta});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Tr Etiquetas_STG'.", "ForeignKeyNotFound", 1, "TRTAREASETIQUETAS_IDETIQUETA");
            AnyError = 1;
            GX_FocusControl = edtTrTareasEtiquetas_IDEtiqueta_Internalname;
         }
         A54TrTareasEtiquetas_NombreEtiqueta = T000715_A54TrTareasEtiquetas_NombreEtiqueta[0];
         n54TrTareasEtiquetas_NombreEtiqueta = T000715_n54TrTareasEtiquetas_NombreEtiqueta[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A54TrTareasEtiquetas_NombreEtiqueta", StringUtil.RTrim( A54TrTareasEtiquetas_NombreEtiqueta));
      }

      public void Valid_Trtareasetiquetas_tareaid( )
      {
         /* Using cursor T000717 */
         pr_default.execute(15, new Object[] {A52TrTareasEtiquetas_TareaID});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Tr Gestion Tareas4_STG'.", "ForeignKeyNotFound", 1, "TRTAREASETIQUETAS_TAREAID");
            AnyError = 1;
            GX_FocusControl = edtTrTareasEtiquetas_TareaID_Internalname;
         }
         pr_default.close(15);
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
         setEventMetadata("VALID_TRTAREASETIQUETAS_ID","{handler:'Valid_Trtareasetiquetas_id',iparms:[{av:'A51TrTareasEtiquetas_ID',fld:'TRTAREASETIQUETAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TRTAREASETIQUETAS_ID",",oparms:[{av:'A53TrTareasEtiquetas_IDEtiqueta',fld:'TRTAREASETIQUETAS_IDETIQUETA',pic:'ZZZZZZZZZZZZ9'},{av:'A52TrTareasEtiquetas_TareaID',fld:'TRTAREASETIQUETAS_TAREAID',pic:'ZZZZZZZZZZZZ9'},{av:'A54TrTareasEtiquetas_NombreEtiqueta',fld:'TRTAREASETIQUETAS_NOMBREETIQUETA',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z51TrTareasEtiquetas_ID'},{av:'Z53TrTareasEtiquetas_IDEtiqueta'},{av:'Z52TrTareasEtiquetas_TareaID'},{av:'Z54TrTareasEtiquetas_NombreEtiqueta'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_TRTAREASETIQUETAS_IDETIQUETA","{handler:'Valid_Trtareasetiquetas_idetiqueta',iparms:[{av:'A53TrTareasEtiquetas_IDEtiqueta',fld:'TRTAREASETIQUETAS_IDETIQUETA',pic:'ZZZZZZZZZZZZ9'},{av:'A54TrTareasEtiquetas_NombreEtiqueta',fld:'TRTAREASETIQUETAS_NOMBREETIQUETA',pic:''}]");
         setEventMetadata("VALID_TRTAREASETIQUETAS_IDETIQUETA",",oparms:[{av:'A54TrTareasEtiquetas_NombreEtiqueta',fld:'TRTAREASETIQUETAS_NOMBREETIQUETA',pic:''}]}");
         setEventMetadata("VALID_TRTAREASETIQUETAS_TAREAID","{handler:'Valid_Trtareasetiquetas_tareaid',iparms:[{av:'A52TrTareasEtiquetas_TareaID',fld:'TRTAREASETIQUETAS_TAREAID',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("VALID_TRTAREASETIQUETAS_TAREAID",",oparms:[]}");
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
         pr_default.close(15);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
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
         A54TrTareasEtiquetas_NombreEtiqueta = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         Z54TrTareasEtiquetas_NombreEtiqueta = "";
         T00076_A51TrTareasEtiquetas_ID = new long[1] ;
         T00076_A54TrTareasEtiquetas_NombreEtiqueta = new String[] {""} ;
         T00076_n54TrTareasEtiquetas_NombreEtiqueta = new bool[] {false} ;
         T00076_A52TrTareasEtiquetas_TareaID = new long[1] ;
         T00076_A53TrTareasEtiquetas_IDEtiqueta = new long[1] ;
         T00075_A54TrTareasEtiquetas_NombreEtiqueta = new String[] {""} ;
         T00075_n54TrTareasEtiquetas_NombreEtiqueta = new bool[] {false} ;
         T00074_A52TrTareasEtiquetas_TareaID = new long[1] ;
         T00077_A54TrTareasEtiquetas_NombreEtiqueta = new String[] {""} ;
         T00077_n54TrTareasEtiquetas_NombreEtiqueta = new bool[] {false} ;
         T00078_A52TrTareasEtiquetas_TareaID = new long[1] ;
         T00079_A51TrTareasEtiquetas_ID = new long[1] ;
         T00073_A51TrTareasEtiquetas_ID = new long[1] ;
         T00073_A52TrTareasEtiquetas_TareaID = new long[1] ;
         T00073_A53TrTareasEtiquetas_IDEtiqueta = new long[1] ;
         sMode8 = "";
         T000710_A51TrTareasEtiquetas_ID = new long[1] ;
         T000711_A51TrTareasEtiquetas_ID = new long[1] ;
         T00072_A51TrTareasEtiquetas_ID = new long[1] ;
         T00072_A52TrTareasEtiquetas_TareaID = new long[1] ;
         T00072_A53TrTareasEtiquetas_IDEtiqueta = new long[1] ;
         T000712_A51TrTareasEtiquetas_ID = new long[1] ;
         T000715_A54TrTareasEtiquetas_NombreEtiqueta = new String[] {""} ;
         T000715_n54TrTareasEtiquetas_NombreEtiqueta = new bool[] {false} ;
         T000716_A51TrTareasEtiquetas_ID = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ54TrTareasEtiquetas_NombreEtiqueta = "";
         T000717_A52TrTareasEtiquetas_TareaID = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trtareasetiquetas__default(),
            new Object[][] {
                new Object[] {
               T00072_A51TrTareasEtiquetas_ID, T00072_A52TrTareasEtiquetas_TareaID, T00072_A53TrTareasEtiquetas_IDEtiqueta
               }
               , new Object[] {
               T00073_A51TrTareasEtiquetas_ID, T00073_A52TrTareasEtiquetas_TareaID, T00073_A53TrTareasEtiquetas_IDEtiqueta
               }
               , new Object[] {
               T00074_A52TrTareasEtiquetas_TareaID
               }
               , new Object[] {
               T00075_A54TrTareasEtiquetas_NombreEtiqueta, T00075_n54TrTareasEtiquetas_NombreEtiqueta
               }
               , new Object[] {
               T00076_A51TrTareasEtiquetas_ID, T00076_A54TrTareasEtiquetas_NombreEtiqueta, T00076_n54TrTareasEtiquetas_NombreEtiqueta, T00076_A52TrTareasEtiquetas_TareaID, T00076_A53TrTareasEtiquetas_IDEtiqueta
               }
               , new Object[] {
               T00077_A54TrTareasEtiquetas_NombreEtiqueta, T00077_n54TrTareasEtiquetas_NombreEtiqueta
               }
               , new Object[] {
               T00078_A52TrTareasEtiquetas_TareaID
               }
               , new Object[] {
               T00079_A51TrTareasEtiquetas_ID
               }
               , new Object[] {
               T000710_A51TrTareasEtiquetas_ID
               }
               , new Object[] {
               T000711_A51TrTareasEtiquetas_ID
               }
               , new Object[] {
               T000712_A51TrTareasEtiquetas_ID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000715_A54TrTareasEtiquetas_NombreEtiqueta, T000715_n54TrTareasEtiquetas_NombreEtiqueta
               }
               , new Object[] {
               T000716_A51TrTareasEtiquetas_ID
               }
               , new Object[] {
               T000717_A52TrTareasEtiquetas_TareaID
               }
            }
         );
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short GX_JID ;
      private short RcdFound8 ;
      private short nIsDirty_8 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTrTareasEtiquetas_ID_Enabled ;
      private int edtTrTareasEtiquetas_IDEtiqueta_Enabled ;
      private int imgprompt_53_Visible ;
      private int edtTrTareasEtiquetas_NombreEtiqueta_Enabled ;
      private int edtTrTareasEtiquetas_TareaID_Enabled ;
      private int imgprompt_52_Visible ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z51TrTareasEtiquetas_ID ;
      private long Z52TrTareasEtiquetas_TareaID ;
      private long Z53TrTareasEtiquetas_IDEtiqueta ;
      private long A53TrTareasEtiquetas_IDEtiqueta ;
      private long A52TrTareasEtiquetas_TareaID ;
      private long A51TrTareasEtiquetas_ID ;
      private long ZZ51TrTareasEtiquetas_ID ;
      private long ZZ53TrTareasEtiquetas_IDEtiqueta ;
      private long ZZ52TrTareasEtiquetas_TareaID ;
      private String sPrefix ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String GXKey ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtTrTareasEtiquetas_ID_Internalname ;
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
      private String edtTrTareasEtiquetas_ID_Jsonclick ;
      private String edtTrTareasEtiquetas_IDEtiqueta_Internalname ;
      private String edtTrTareasEtiquetas_IDEtiqueta_Jsonclick ;
      private String sImgUrl ;
      private String imgprompt_53_Internalname ;
      private String imgprompt_53_Link ;
      private String edtTrTareasEtiquetas_NombreEtiqueta_Internalname ;
      private String A54TrTareasEtiquetas_NombreEtiqueta ;
      private String edtTrTareasEtiquetas_TareaID_Internalname ;
      private String edtTrTareasEtiquetas_TareaID_Jsonclick ;
      private String imgprompt_52_Internalname ;
      private String imgprompt_52_Link ;
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
      private String Z54TrTareasEtiquetas_NombreEtiqueta ;
      private String sMode8 ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String ZZ54TrTareasEtiquetas_NombreEtiqueta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n54TrTareasEtiquetas_NombreEtiqueta ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] T00076_A51TrTareasEtiquetas_ID ;
      private String[] T00076_A54TrTareasEtiquetas_NombreEtiqueta ;
      private bool[] T00076_n54TrTareasEtiquetas_NombreEtiqueta ;
      private long[] T00076_A52TrTareasEtiquetas_TareaID ;
      private long[] T00076_A53TrTareasEtiquetas_IDEtiqueta ;
      private String[] T00075_A54TrTareasEtiquetas_NombreEtiqueta ;
      private bool[] T00075_n54TrTareasEtiquetas_NombreEtiqueta ;
      private long[] T00074_A52TrTareasEtiquetas_TareaID ;
      private String[] T00077_A54TrTareasEtiquetas_NombreEtiqueta ;
      private bool[] T00077_n54TrTareasEtiquetas_NombreEtiqueta ;
      private long[] T00078_A52TrTareasEtiquetas_TareaID ;
      private long[] T00079_A51TrTareasEtiquetas_ID ;
      private long[] T00073_A51TrTareasEtiquetas_ID ;
      private long[] T00073_A52TrTareasEtiquetas_TareaID ;
      private long[] T00073_A53TrTareasEtiquetas_IDEtiqueta ;
      private long[] T000710_A51TrTareasEtiquetas_ID ;
      private long[] T000711_A51TrTareasEtiquetas_ID ;
      private long[] T00072_A51TrTareasEtiquetas_ID ;
      private long[] T00072_A52TrTareasEtiquetas_TareaID ;
      private long[] T00072_A53TrTareasEtiquetas_IDEtiqueta ;
      private long[] T000712_A51TrTareasEtiquetas_ID ;
      private String[] T000715_A54TrTareasEtiquetas_NombreEtiqueta ;
      private bool[] T000715_n54TrTareasEtiquetas_NombreEtiqueta ;
      private long[] T000716_A51TrTareasEtiquetas_ID ;
      private long[] T000717_A52TrTareasEtiquetas_TareaID ;
      private GXWebForm Form ;
   }

   public class trtareasetiquetas__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00076 ;
          prmT00076 = new Object[] {
          new Object[] {"@TrTareasEtiquetas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00075 ;
          prmT00075 = new Object[] {
          new Object[] {"@TrTareasEtiquetas_IDEtiqueta",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00074 ;
          prmT00074 = new Object[] {
          new Object[] {"@TrTareasEtiquetas_TareaID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00077 ;
          prmT00077 = new Object[] {
          new Object[] {"@TrTareasEtiquetas_IDEtiqueta",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00078 ;
          prmT00078 = new Object[] {
          new Object[] {"@TrTareasEtiquetas_TareaID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00079 ;
          prmT00079 = new Object[] {
          new Object[] {"@TrTareasEtiquetas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00073 ;
          prmT00073 = new Object[] {
          new Object[] {"@TrTareasEtiquetas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000710 ;
          prmT000710 = new Object[] {
          new Object[] {"@TrTareasEtiquetas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000711 ;
          prmT000711 = new Object[] {
          new Object[] {"@TrTareasEtiquetas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00072 ;
          prmT00072 = new Object[] {
          new Object[] {"@TrTareasEtiquetas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000712 ;
          prmT000712 = new Object[] {
          new Object[] {"@TrTareasEtiquetas_TareaID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@TrTareasEtiquetas_IDEtiqueta",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000713 ;
          prmT000713 = new Object[] {
          new Object[] {"@TrTareasEtiquetas_TareaID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@TrTareasEtiquetas_IDEtiqueta",SqlDbType.Decimal,13,0} ,
          new Object[] {"@TrTareasEtiquetas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000714 ;
          prmT000714 = new Object[] {
          new Object[] {"@TrTareasEtiquetas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000716 ;
          prmT000716 = new Object[] {
          } ;
          Object[] prmT000715 ;
          prmT000715 = new Object[] {
          new Object[] {"@TrTareasEtiquetas_IDEtiqueta",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000717 ;
          prmT000717 = new Object[] {
          new Object[] {"@TrTareasEtiquetas_TareaID",SqlDbType.Decimal,13,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T00072", "SELECT [TrTareasEtiquetas_ID], [TrTareasEtiquetas_TareaID] AS TrTareasEtiquetas_TareaID, [TrTareasEtiquetas_IDEtiqueta] AS TrTareasEtiquetas_IDEtiqueta FROM TABLERO.[TrTareasEtiquetas] WITH (UPDLOCK) WHERE [TrTareasEtiquetas_ID] = @TrTareasEtiquetas_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00073", "SELECT [TrTareasEtiquetas_ID], [TrTareasEtiquetas_TareaID] AS TrTareasEtiquetas_TareaID, [TrTareasEtiquetas_IDEtiqueta] AS TrTareasEtiquetas_IDEtiqueta FROM TABLERO.[TrTareasEtiquetas] WHERE [TrTareasEtiquetas_ID] = @TrTareasEtiquetas_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00074", "SELECT [TrGestionTareas_ID] AS TrTareasEtiquetas_TareaID FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_ID] = @TrTareasEtiquetas_TareaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00075", "SELECT [TrEtiquetas_Nombre] AS TrTareasEtiquetas_NombreEtiqueta FROM TABLERO.[TrEtiquetas] WHERE [TrEtiquetas_ID] = @TrTareasEtiquetas_IDEtiqueta ",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00076", "SELECT TM1.[TrTareasEtiquetas_ID], T2.[TrEtiquetas_Nombre] AS TrTareasEtiquetas_NombreEtiqueta, TM1.[TrTareasEtiquetas_TareaID] AS TrTareasEtiquetas_TareaID, TM1.[TrTareasEtiquetas_IDEtiqueta] AS TrTareasEtiquetas_IDEtiqueta FROM (TABLERO.[TrTareasEtiquetas] TM1 INNER JOIN TABLERO.[TrEtiquetas] T2 ON T2.[TrEtiquetas_ID] = TM1.[TrTareasEtiquetas_IDEtiqueta]) WHERE TM1.[TrTareasEtiquetas_ID] = @TrTareasEtiquetas_ID ORDER BY TM1.[TrTareasEtiquetas_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00077", "SELECT [TrEtiquetas_Nombre] AS TrTareasEtiquetas_NombreEtiqueta FROM TABLERO.[TrEtiquetas] WHERE [TrEtiquetas_ID] = @TrTareasEtiquetas_IDEtiqueta ",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00078", "SELECT [TrGestionTareas_ID] AS TrTareasEtiquetas_TareaID FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_ID] = @TrTareasEtiquetas_TareaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00078,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00079", "SELECT [TrTareasEtiquetas_ID] FROM TABLERO.[TrTareasEtiquetas] WHERE [TrTareasEtiquetas_ID] = @TrTareasEtiquetas_ID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00079,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000710", "SELECT TOP 1 [TrTareasEtiquetas_ID] FROM TABLERO.[TrTareasEtiquetas] WHERE ( [TrTareasEtiquetas_ID] > @TrTareasEtiquetas_ID) ORDER BY [TrTareasEtiquetas_ID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000710,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000711", "SELECT TOP 1 [TrTareasEtiquetas_ID] FROM TABLERO.[TrTareasEtiquetas] WHERE ( [TrTareasEtiquetas_ID] < @TrTareasEtiquetas_ID) ORDER BY [TrTareasEtiquetas_ID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000711,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000712", "INSERT INTO TABLERO.[TrTareasEtiquetas]([TrTareasEtiquetas_TareaID], [TrTareasEtiquetas_IDEtiqueta]) VALUES(@TrTareasEtiquetas_TareaID, @TrTareasEtiquetas_IDEtiqueta); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000712)
             ,new CursorDef("T000713", "UPDATE TABLERO.[TrTareasEtiquetas] SET [TrTareasEtiquetas_TareaID]=@TrTareasEtiquetas_TareaID, [TrTareasEtiquetas_IDEtiqueta]=@TrTareasEtiquetas_IDEtiqueta  WHERE [TrTareasEtiquetas_ID] = @TrTareasEtiquetas_ID", GxErrorMask.GX_NOMASK,prmT000713)
             ,new CursorDef("T000714", "DELETE FROM TABLERO.[TrTareasEtiquetas]  WHERE [TrTareasEtiquetas_ID] = @TrTareasEtiquetas_ID", GxErrorMask.GX_NOMASK,prmT000714)
             ,new CursorDef("T000715", "SELECT [TrEtiquetas_Nombre] AS TrTareasEtiquetas_NombreEtiqueta FROM TABLERO.[TrEtiquetas] WHERE [TrEtiquetas_ID] = @TrTareasEtiquetas_IDEtiqueta ",true, GxErrorMask.GX_NOMASK, false, this,prmT000715,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000716", "SELECT [TrTareasEtiquetas_ID] FROM TABLERO.[TrTareasEtiquetas] ORDER BY [TrTareasEtiquetas_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000716,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000717", "SELECT [TrGestionTareas_ID] AS TrTareasEtiquetas_TareaID FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_ID] = @TrTareasEtiquetas_TareaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000717,1, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2) ;
                ((long[]) buf[2])[0] = rslt.getLong(3) ;
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((long[]) buf[1])[0] = rslt.getLong(2) ;
                ((long[]) buf[2])[0] = rslt.getLong(3) ;
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 3 :
                ((String[]) buf[0])[0] = rslt.getString(1, 256) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 256) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3) ;
                ((long[]) buf[4])[0] = rslt.getLong(4) ;
                return;
             case 5 :
                ((String[]) buf[0])[0] = rslt.getString(1, 256) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
                ((String[]) buf[0])[0] = rslt.getString(1, 256) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 15 :
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
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 3 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 4 :
                stmt.SetParameter(1, (long)parms[0]);
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
                return;
             case 9 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 10 :
                stmt.SetParameter(1, (long)parms[0]);
                stmt.SetParameter(2, (long)parms[1]);
                return;
             case 11 :
                stmt.SetParameter(1, (long)parms[0]);
                stmt.SetParameter(2, (long)parms[1]);
                stmt.SetParameter(3, (long)parms[2]);
                return;
             case 12 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 13 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 15 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
       }
    }

 }

}
