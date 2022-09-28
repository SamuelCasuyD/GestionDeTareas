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
   public class trgestiontableros : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            Form.Meta.addItem("description", "Tr Gestion Tableros", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         GX_FocusControl = edtTrGestionTableros_ID_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trgestiontableros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public trgestiontableros( IGxContext context )
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
         chkTrGestionTableros_Estado = new GXCheckbox();
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdmasterpage", "GeneXus.Programs.rwdmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
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
         A10TrGestionTableros_Estado = StringUtil.StrToBool( StringUtil.BoolToStr( A10TrGestionTableros_Estado));
         n10TrGestionTableros_Estado = false;
         AssignAttri("", false, "A10TrGestionTableros_Estado", A10TrGestionTableros_Estado);
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
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "TableTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Tr Gestion Tableros", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 ToolbarCellClass", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TRGESTIONTABLEROS_ID"+"'), id:'"+"TRGESTIONTABLEROS_ID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCellAdvanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrGestionTableros_ID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTableros_ID_Internalname, "Gestion Tableros_ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrGestionTableros_ID_Internalname, A1TrGestionTableros_ID.ToString(), A1TrGestionTableros_ID.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTableros_ID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrGestionTableros_ID_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 1, 0, 0, true, "", "", false, "", "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrGestionTableros_Nombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTableros_Nombre_Internalname, "Gestion Tableros_Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrGestionTableros_Nombre_Internalname, StringUtil.RTrim( A2TrGestionTableros_Nombre), StringUtil.RTrim( context.localUtil.Format( A2TrGestionTableros_Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTableros_Nombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrGestionTableros_Nombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrGestionTableros_Comentario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTableros_Comentario_Internalname, "Gestion Tableros_Comentario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTrGestionTableros_Comentario_Internalname, A6TrGestionTableros_Comentario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtTrGestionTableros_Comentario_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrGestionTableros_Descripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTableros_Descripcion_Internalname, "Gestion Tableros_Descripcion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTrGestionTableros_Descripcion_Internalname, A5TrGestionTableros_Descripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtTrGestionTableros_Descripcion_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrGestionTableros_TipoTablero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTableros_TipoTablero_Internalname, "Tableros_Tipo Tablero", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrGestionTableros_TipoTablero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TrGestionTableros_TipoTablero), 4, 0, ".", "")), ((edtTrGestionTableros_TipoTablero_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A9TrGestionTableros_TipoTablero), "ZZZ9")) : context.localUtil.Format( (decimal)(A9TrGestionTableros_TipoTablero), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTableros_TipoTablero_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrGestionTableros_TipoTablero_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrGestionTableros_FechaInicio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTableros_FechaInicio_Internalname, "Tableros_Fecha Inicio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrGestionTableros_FechaInicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrGestionTableros_FechaInicio_Internalname, context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"), context.localUtil.Format( A3TrGestionTableros_FechaInicio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTableros_FechaInicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrGestionTableros_FechaInicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrGestionTableros.htm");
         GxWebStd.gx_bitmap( context, edtTrGestionTableros_FechaInicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrGestionTableros_FechaInicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrGestionTableros.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrGestionTableros_FechaFin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTableros_FechaFin_Internalname, "Tableros_Fecha Fin", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrGestionTableros_FechaFin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrGestionTableros_FechaFin_Internalname, context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"), context.localUtil.Format( A4TrGestionTableros_FechaFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTableros_FechaFin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrGestionTableros_FechaFin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrGestionTableros.htm");
         GxWebStd.gx_bitmap( context, edtTrGestionTableros_FechaFin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrGestionTableros_FechaFin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrGestionTableros.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrGestionTableros_FechaCreacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTableros_FechaCreacion_Internalname, "Tableros_Fecha Creacion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrGestionTableros_FechaCreacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrGestionTableros_FechaCreacion_Internalname, context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"), context.localUtil.Format( A7TrGestionTableros_FechaCreacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTableros_FechaCreacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrGestionTableros_FechaCreacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrGestionTableros.htm");
         GxWebStd.gx_bitmap( context, edtTrGestionTableros_FechaCreacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrGestionTableros_FechaCreacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrGestionTableros.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrGestionTableros_FechaModificacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTableros_FechaModificacion_Internalname, "Tableros_Fecha Modificacion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrGestionTableros_FechaModificacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrGestionTableros_FechaModificacion_Internalname, context.localUtil.Format(A8TrGestionTableros_FechaModificacion, "99/99/9999"), context.localUtil.Format( A8TrGestionTableros_FechaModificacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTableros_FechaModificacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrGestionTableros_FechaModificacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrGestionTableros.htm");
         GxWebStd.gx_bitmap( context, edtTrGestionTableros_FechaModificacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrGestionTableros_FechaModificacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrGestionTableros.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkTrGestionTableros_Estado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTrGestionTableros_Estado_Internalname, "Gestion Tableros_Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTrGestionTableros_Estado_Internalname, StringUtil.BoolToStr( A10TrGestionTableros_Estado), "", "Gestion Tableros_Estado", 1, chkTrGestionTableros_Estado.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(79, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,79);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
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
            Z1TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( cgiGet( "Z1TrGestionTableros_ID")));
            Z2TrGestionTableros_Nombre = cgiGet( "Z2TrGestionTableros_Nombre");
            n2TrGestionTableros_Nombre = (String.IsNullOrEmpty(StringUtil.RTrim( A2TrGestionTableros_Nombre)) ? true : false);
            Z9TrGestionTableros_TipoTablero = (short)(context.localUtil.CToN( cgiGet( "Z9TrGestionTableros_TipoTablero"), ".", ","));
            n9TrGestionTableros_TipoTablero = ((0==A9TrGestionTableros_TipoTablero) ? true : false);
            Z3TrGestionTableros_FechaInicio = context.localUtil.CToD( cgiGet( "Z3TrGestionTableros_FechaInicio"), 0);
            n3TrGestionTableros_FechaInicio = ((DateTime.MinValue==A3TrGestionTableros_FechaInicio) ? true : false);
            Z4TrGestionTableros_FechaFin = context.localUtil.CToD( cgiGet( "Z4TrGestionTableros_FechaFin"), 0);
            n4TrGestionTableros_FechaFin = ((DateTime.MinValue==A4TrGestionTableros_FechaFin) ? true : false);
            Z7TrGestionTableros_FechaCreacion = context.localUtil.CToD( cgiGet( "Z7TrGestionTableros_FechaCreacion"), 0);
            n7TrGestionTableros_FechaCreacion = ((DateTime.MinValue==A7TrGestionTableros_FechaCreacion) ? true : false);
            Z8TrGestionTableros_FechaModificacion = context.localUtil.CToD( cgiGet( "Z8TrGestionTableros_FechaModificacion"), 0);
            n8TrGestionTableros_FechaModificacion = ((DateTime.MinValue==A8TrGestionTableros_FechaModificacion) ? true : false);
            Z10TrGestionTableros_Estado = StringUtil.StrToBool( cgiGet( "Z10TrGestionTableros_Estado"));
            n10TrGestionTableros_Estado = ((false==A10TrGestionTableros_Estado) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtTrGestionTableros_ID_Internalname), "") == 0 )
            {
               A1TrGestionTableros_ID = (Guid)(Guid.Empty);
               AssignAttri("", false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
            }
            else
            {
               try
               {
                  A1TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( cgiGet( edtTrGestionTableros_ID_Internalname)));
                  AssignAttri("", false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
               }
               catch ( Exception e )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "TRGESTIONTABLEROS_ID");
                  AnyError = 1;
                  GX_FocusControl = edtTrGestionTableros_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            A2TrGestionTableros_Nombre = cgiGet( edtTrGestionTableros_Nombre_Internalname);
            n2TrGestionTableros_Nombre = false;
            AssignAttri("", false, "A2TrGestionTableros_Nombre", A2TrGestionTableros_Nombre);
            n2TrGestionTableros_Nombre = (String.IsNullOrEmpty(StringUtil.RTrim( A2TrGestionTableros_Nombre)) ? true : false);
            A6TrGestionTableros_Comentario = cgiGet( edtTrGestionTableros_Comentario_Internalname);
            n6TrGestionTableros_Comentario = false;
            AssignAttri("", false, "A6TrGestionTableros_Comentario", A6TrGestionTableros_Comentario);
            n6TrGestionTableros_Comentario = (String.IsNullOrEmpty(StringUtil.RTrim( A6TrGestionTableros_Comentario)) ? true : false);
            A5TrGestionTableros_Descripcion = cgiGet( edtTrGestionTableros_Descripcion_Internalname);
            n5TrGestionTableros_Descripcion = false;
            AssignAttri("", false, "A5TrGestionTableros_Descripcion", A5TrGestionTableros_Descripcion);
            n5TrGestionTableros_Descripcion = (String.IsNullOrEmpty(StringUtil.RTrim( A5TrGestionTableros_Descripcion)) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTrGestionTableros_TipoTablero_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTrGestionTableros_TipoTablero_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRGESTIONTABLEROS_TIPOTABLERO");
               AnyError = 1;
               GX_FocusControl = edtTrGestionTableros_TipoTablero_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A9TrGestionTableros_TipoTablero = 0;
               n9TrGestionTableros_TipoTablero = false;
               AssignAttri("", false, "A9TrGestionTableros_TipoTablero", StringUtil.LTrimStr( (decimal)(A9TrGestionTableros_TipoTablero), 4, 0));
            }
            else
            {
               A9TrGestionTableros_TipoTablero = (short)(context.localUtil.CToN( cgiGet( edtTrGestionTableros_TipoTablero_Internalname), ".", ","));
               n9TrGestionTableros_TipoTablero = false;
               AssignAttri("", false, "A9TrGestionTableros_TipoTablero", StringUtil.LTrimStr( (decimal)(A9TrGestionTableros_TipoTablero), 4, 0));
            }
            n9TrGestionTableros_TipoTablero = ((0==A9TrGestionTableros_TipoTablero) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrGestionTableros_FechaInicio_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tableros_Fecha Inicio"}), 1, "TRGESTIONTABLEROS_FECHAINICIO");
               AnyError = 1;
               GX_FocusControl = edtTrGestionTableros_FechaInicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A3TrGestionTableros_FechaInicio = DateTime.MinValue;
               n3TrGestionTableros_FechaInicio = false;
               AssignAttri("", false, "A3TrGestionTableros_FechaInicio", context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"));
            }
            else
            {
               A3TrGestionTableros_FechaInicio = context.localUtil.CToD( cgiGet( edtTrGestionTableros_FechaInicio_Internalname), 1);
               n3TrGestionTableros_FechaInicio = false;
               AssignAttri("", false, "A3TrGestionTableros_FechaInicio", context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"));
            }
            n3TrGestionTableros_FechaInicio = ((DateTime.MinValue==A3TrGestionTableros_FechaInicio) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrGestionTableros_FechaFin_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tableros_Fecha Fin"}), 1, "TRGESTIONTABLEROS_FECHAFIN");
               AnyError = 1;
               GX_FocusControl = edtTrGestionTableros_FechaFin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A4TrGestionTableros_FechaFin = DateTime.MinValue;
               n4TrGestionTableros_FechaFin = false;
               AssignAttri("", false, "A4TrGestionTableros_FechaFin", context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"));
            }
            else
            {
               A4TrGestionTableros_FechaFin = context.localUtil.CToD( cgiGet( edtTrGestionTableros_FechaFin_Internalname), 1);
               n4TrGestionTableros_FechaFin = false;
               AssignAttri("", false, "A4TrGestionTableros_FechaFin", context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"));
            }
            n4TrGestionTableros_FechaFin = ((DateTime.MinValue==A4TrGestionTableros_FechaFin) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrGestionTableros_FechaCreacion_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tableros_Fecha Creacion"}), 1, "TRGESTIONTABLEROS_FECHACREACION");
               AnyError = 1;
               GX_FocusControl = edtTrGestionTableros_FechaCreacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A7TrGestionTableros_FechaCreacion = DateTime.MinValue;
               n7TrGestionTableros_FechaCreacion = false;
               AssignAttri("", false, "A7TrGestionTableros_FechaCreacion", context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"));
            }
            else
            {
               A7TrGestionTableros_FechaCreacion = context.localUtil.CToD( cgiGet( edtTrGestionTableros_FechaCreacion_Internalname), 1);
               n7TrGestionTableros_FechaCreacion = false;
               AssignAttri("", false, "A7TrGestionTableros_FechaCreacion", context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"));
            }
            n7TrGestionTableros_FechaCreacion = ((DateTime.MinValue==A7TrGestionTableros_FechaCreacion) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrGestionTableros_FechaModificacion_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tableros_Fecha Modificacion"}), 1, "TRGESTIONTABLEROS_FECHAMODIFICACION");
               AnyError = 1;
               GX_FocusControl = edtTrGestionTableros_FechaModificacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A8TrGestionTableros_FechaModificacion = DateTime.MinValue;
               n8TrGestionTableros_FechaModificacion = false;
               AssignAttri("", false, "A8TrGestionTableros_FechaModificacion", context.localUtil.Format(A8TrGestionTableros_FechaModificacion, "99/99/9999"));
            }
            else
            {
               A8TrGestionTableros_FechaModificacion = context.localUtil.CToD( cgiGet( edtTrGestionTableros_FechaModificacion_Internalname), 1);
               n8TrGestionTableros_FechaModificacion = false;
               AssignAttri("", false, "A8TrGestionTableros_FechaModificacion", context.localUtil.Format(A8TrGestionTableros_FechaModificacion, "99/99/9999"));
            }
            n8TrGestionTableros_FechaModificacion = ((DateTime.MinValue==A8TrGestionTableros_FechaModificacion) ? true : false);
            A10TrGestionTableros_Estado = StringUtil.StrToBool( cgiGet( chkTrGestionTableros_Estado_Internalname));
            n10TrGestionTableros_Estado = false;
            AssignAttri("", false, "A10TrGestionTableros_Estado", A10TrGestionTableros_Estado);
            n10TrGestionTableros_Estado = ((false==A10TrGestionTableros_Estado) ? true : false);
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
               A1TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( GetNextPar( )));
               AssignAttri("", false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
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
               InitAll011( ) ;
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
         DisableAttributes011( ) ;
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

      protected void ResetCaption010( )
      {
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2TrGestionTableros_Nombre = T00013_A2TrGestionTableros_Nombre[0];
               Z9TrGestionTableros_TipoTablero = T00013_A9TrGestionTableros_TipoTablero[0];
               Z3TrGestionTableros_FechaInicio = T00013_A3TrGestionTableros_FechaInicio[0];
               Z4TrGestionTableros_FechaFin = T00013_A4TrGestionTableros_FechaFin[0];
               Z7TrGestionTableros_FechaCreacion = T00013_A7TrGestionTableros_FechaCreacion[0];
               Z8TrGestionTableros_FechaModificacion = T00013_A8TrGestionTableros_FechaModificacion[0];
               Z10TrGestionTableros_Estado = T00013_A10TrGestionTableros_Estado[0];
            }
            else
            {
               Z2TrGestionTableros_Nombre = A2TrGestionTableros_Nombre;
               Z9TrGestionTableros_TipoTablero = A9TrGestionTableros_TipoTablero;
               Z3TrGestionTableros_FechaInicio = A3TrGestionTableros_FechaInicio;
               Z4TrGestionTableros_FechaFin = A4TrGestionTableros_FechaFin;
               Z7TrGestionTableros_FechaCreacion = A7TrGestionTableros_FechaCreacion;
               Z8TrGestionTableros_FechaModificacion = A8TrGestionTableros_FechaModificacion;
               Z10TrGestionTableros_Estado = A10TrGestionTableros_Estado;
            }
         }
         if ( GX_JID == -6 )
         {
            Z1TrGestionTableros_ID = (Guid)(A1TrGestionTableros_ID);
            Z2TrGestionTableros_Nombre = A2TrGestionTableros_Nombre;
            Z6TrGestionTableros_Comentario = A6TrGestionTableros_Comentario;
            Z5TrGestionTableros_Descripcion = A5TrGestionTableros_Descripcion;
            Z9TrGestionTableros_TipoTablero = A9TrGestionTableros_TipoTablero;
            Z3TrGestionTableros_FechaInicio = A3TrGestionTableros_FechaInicio;
            Z4TrGestionTableros_FechaFin = A4TrGestionTableros_FechaFin;
            Z7TrGestionTableros_FechaCreacion = A7TrGestionTableros_FechaCreacion;
            Z8TrGestionTableros_FechaModificacion = A8TrGestionTableros_FechaModificacion;
            Z10TrGestionTableros_Estado = A10TrGestionTableros_Estado;
         }
      }

      protected void standaloneNotModal( )
      {
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

      protected void Load011( )
      {
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {A1TrGestionTableros_ID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A2TrGestionTableros_Nombre = T00014_A2TrGestionTableros_Nombre[0];
            n2TrGestionTableros_Nombre = T00014_n2TrGestionTableros_Nombre[0];
            AssignAttri("", false, "A2TrGestionTableros_Nombre", A2TrGestionTableros_Nombre);
            A6TrGestionTableros_Comentario = T00014_A6TrGestionTableros_Comentario[0];
            n6TrGestionTableros_Comentario = T00014_n6TrGestionTableros_Comentario[0];
            AssignAttri("", false, "A6TrGestionTableros_Comentario", A6TrGestionTableros_Comentario);
            A5TrGestionTableros_Descripcion = T00014_A5TrGestionTableros_Descripcion[0];
            n5TrGestionTableros_Descripcion = T00014_n5TrGestionTableros_Descripcion[0];
            AssignAttri("", false, "A5TrGestionTableros_Descripcion", A5TrGestionTableros_Descripcion);
            A9TrGestionTableros_TipoTablero = T00014_A9TrGestionTableros_TipoTablero[0];
            n9TrGestionTableros_TipoTablero = T00014_n9TrGestionTableros_TipoTablero[0];
            AssignAttri("", false, "A9TrGestionTableros_TipoTablero", StringUtil.LTrimStr( (decimal)(A9TrGestionTableros_TipoTablero), 4, 0));
            A3TrGestionTableros_FechaInicio = T00014_A3TrGestionTableros_FechaInicio[0];
            n3TrGestionTableros_FechaInicio = T00014_n3TrGestionTableros_FechaInicio[0];
            AssignAttri("", false, "A3TrGestionTableros_FechaInicio", context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"));
            A4TrGestionTableros_FechaFin = T00014_A4TrGestionTableros_FechaFin[0];
            n4TrGestionTableros_FechaFin = T00014_n4TrGestionTableros_FechaFin[0];
            AssignAttri("", false, "A4TrGestionTableros_FechaFin", context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"));
            A7TrGestionTableros_FechaCreacion = T00014_A7TrGestionTableros_FechaCreacion[0];
            n7TrGestionTableros_FechaCreacion = T00014_n7TrGestionTableros_FechaCreacion[0];
            AssignAttri("", false, "A7TrGestionTableros_FechaCreacion", context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"));
            A8TrGestionTableros_FechaModificacion = T00014_A8TrGestionTableros_FechaModificacion[0];
            n8TrGestionTableros_FechaModificacion = T00014_n8TrGestionTableros_FechaModificacion[0];
            AssignAttri("", false, "A8TrGestionTableros_FechaModificacion", context.localUtil.Format(A8TrGestionTableros_FechaModificacion, "99/99/9999"));
            A10TrGestionTableros_Estado = T00014_A10TrGestionTableros_Estado[0];
            n10TrGestionTableros_Estado = T00014_n10TrGestionTableros_Estado[0];
            AssignAttri("", false, "A10TrGestionTableros_Estado", A10TrGestionTableros_Estado);
            ZM011( -6) ;
         }
         pr_default.close(2);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A3TrGestionTableros_FechaInicio) || ( A3TrGestionTableros_FechaInicio >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Tr Gestion Tableros_Fecha Inicio is out of range", "OutOfRange", 1, "TRGESTIONTABLEROS_FECHAINICIO");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTableros_FechaInicio_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A4TrGestionTableros_FechaFin) || ( A4TrGestionTableros_FechaFin >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Tr Gestion Tableros_Fecha Fin is out of range", "OutOfRange", 1, "TRGESTIONTABLEROS_FECHAFIN");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTableros_FechaFin_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A7TrGestionTableros_FechaCreacion) || ( A7TrGestionTableros_FechaCreacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Tr Gestion Tableros_Fecha Creacion is out of range", "OutOfRange", 1, "TRGESTIONTABLEROS_FECHACREACION");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTableros_FechaCreacion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A8TrGestionTableros_FechaModificacion) || ( A8TrGestionTableros_FechaModificacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Tr Gestion Tableros_Fecha Modificacion is out of range", "OutOfRange", 1, "TRGESTIONTABLEROS_FECHAMODIFICACION");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTableros_FechaModificacion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor T00015 */
         pr_default.execute(3, new Object[] {A1TrGestionTableros_ID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A1TrGestionTableros_ID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 6) ;
            RcdFound1 = 1;
            A1TrGestionTableros_ID = (Guid)((Guid)(T00013_A1TrGestionTableros_ID[0]));
            AssignAttri("", false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
            A2TrGestionTableros_Nombre = T00013_A2TrGestionTableros_Nombre[0];
            n2TrGestionTableros_Nombre = T00013_n2TrGestionTableros_Nombre[0];
            AssignAttri("", false, "A2TrGestionTableros_Nombre", A2TrGestionTableros_Nombre);
            A6TrGestionTableros_Comentario = T00013_A6TrGestionTableros_Comentario[0];
            n6TrGestionTableros_Comentario = T00013_n6TrGestionTableros_Comentario[0];
            AssignAttri("", false, "A6TrGestionTableros_Comentario", A6TrGestionTableros_Comentario);
            A5TrGestionTableros_Descripcion = T00013_A5TrGestionTableros_Descripcion[0];
            n5TrGestionTableros_Descripcion = T00013_n5TrGestionTableros_Descripcion[0];
            AssignAttri("", false, "A5TrGestionTableros_Descripcion", A5TrGestionTableros_Descripcion);
            A9TrGestionTableros_TipoTablero = T00013_A9TrGestionTableros_TipoTablero[0];
            n9TrGestionTableros_TipoTablero = T00013_n9TrGestionTableros_TipoTablero[0];
            AssignAttri("", false, "A9TrGestionTableros_TipoTablero", StringUtil.LTrimStr( (decimal)(A9TrGestionTableros_TipoTablero), 4, 0));
            A3TrGestionTableros_FechaInicio = T00013_A3TrGestionTableros_FechaInicio[0];
            n3TrGestionTableros_FechaInicio = T00013_n3TrGestionTableros_FechaInicio[0];
            AssignAttri("", false, "A3TrGestionTableros_FechaInicio", context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"));
            A4TrGestionTableros_FechaFin = T00013_A4TrGestionTableros_FechaFin[0];
            n4TrGestionTableros_FechaFin = T00013_n4TrGestionTableros_FechaFin[0];
            AssignAttri("", false, "A4TrGestionTableros_FechaFin", context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"));
            A7TrGestionTableros_FechaCreacion = T00013_A7TrGestionTableros_FechaCreacion[0];
            n7TrGestionTableros_FechaCreacion = T00013_n7TrGestionTableros_FechaCreacion[0];
            AssignAttri("", false, "A7TrGestionTableros_FechaCreacion", context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"));
            A8TrGestionTableros_FechaModificacion = T00013_A8TrGestionTableros_FechaModificacion[0];
            n8TrGestionTableros_FechaModificacion = T00013_n8TrGestionTableros_FechaModificacion[0];
            AssignAttri("", false, "A8TrGestionTableros_FechaModificacion", context.localUtil.Format(A8TrGestionTableros_FechaModificacion, "99/99/9999"));
            A10TrGestionTableros_Estado = T00013_A10TrGestionTableros_Estado[0];
            n10TrGestionTableros_Estado = T00013_n10TrGestionTableros_Estado[0];
            AssignAttri("", false, "A10TrGestionTableros_Estado", A10TrGestionTableros_Estado);
            Z1TrGestionTableros_ID = (Guid)(A1TrGestionTableros_ID);
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
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
         RcdFound1 = 0;
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {A1TrGestionTableros_ID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T00016_A1TrGestionTableros_ID[0], A1TrGestionTableros_ID, 1) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T00016_A1TrGestionTableros_ID[0], A1TrGestionTableros_ID, 1) > 0 ) ) )
            {
               A1TrGestionTableros_ID = (Guid)((Guid)(T00016_A1TrGestionTableros_ID[0]));
               AssignAttri("", false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
               RcdFound1 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {A1TrGestionTableros_ID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T00017_A1TrGestionTableros_ID[0], A1TrGestionTableros_ID, 1) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T00017_A1TrGestionTableros_ID[0], A1TrGestionTableros_ID, 1) < 0 ) ) )
            {
               A1TrGestionTableros_ID = (Guid)((Guid)(T00017_A1TrGestionTableros_ID[0]));
               AssignAttri("", false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
               RcdFound1 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTrGestionTableros_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert011( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1TrGestionTableros_ID != Z1TrGestionTableros_ID )
               {
                  A1TrGestionTableros_ID = (Guid)(Z1TrGestionTableros_ID);
                  AssignAttri("", false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRGESTIONTABLEROS_ID");
                  AnyError = 1;
                  GX_FocusControl = edtTrGestionTableros_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTrGestionTableros_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update011( ) ;
                  GX_FocusControl = edtTrGestionTableros_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1TrGestionTableros_ID != Z1TrGestionTableros_ID )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTrGestionTableros_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert011( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRGESTIONTABLEROS_ID");
                     AnyError = 1;
                     GX_FocusControl = edtTrGestionTableros_ID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTrGestionTableros_ID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert011( ) ;
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
         if ( A1TrGestionTableros_ID != Z1TrGestionTableros_ID )
         {
            A1TrGestionTableros_ID = (Guid)(Z1TrGestionTableros_ID);
            AssignAttri("", false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRGESTIONTABLEROS_ID");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTableros_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTrGestionTableros_ID_Internalname;
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
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TRGESTIONTABLEROS_ID");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTableros_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTrGestionTableros_Nombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrGestionTableros_Nombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd011( ) ;
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
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrGestionTableros_Nombre_Internalname;
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
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrGestionTableros_Nombre_Internalname;
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
         ScanStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound1 != 0 )
            {
               ScanNext011( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrGestionTableros_Nombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd011( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {A1TrGestionTableros_ID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrGestionTableros"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2TrGestionTableros_Nombre, T00012_A2TrGestionTableros_Nombre[0]) != 0 ) || ( Z9TrGestionTableros_TipoTablero != T00012_A9TrGestionTableros_TipoTablero[0] ) || ( Z3TrGestionTableros_FechaInicio != T00012_A3TrGestionTableros_FechaInicio[0] ) || ( Z4TrGestionTableros_FechaFin != T00012_A4TrGestionTableros_FechaFin[0] ) || ( Z7TrGestionTableros_FechaCreacion != T00012_A7TrGestionTableros_FechaCreacion[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z8TrGestionTableros_FechaModificacion != T00012_A8TrGestionTableros_FechaModificacion[0] ) || ( Z10TrGestionTableros_Estado != T00012_A10TrGestionTableros_Estado[0] ) )
            {
               if ( StringUtil.StrCmp(Z2TrGestionTableros_Nombre, T00012_A2TrGestionTableros_Nombre[0]) != 0 )
               {
                  GXUtil.WriteLog("trgestiontableros:[seudo value changed for attri]"+"TrGestionTableros_Nombre");
                  GXUtil.WriteLogRaw("Old: ",Z2TrGestionTableros_Nombre);
                  GXUtil.WriteLogRaw("Current: ",T00012_A2TrGestionTableros_Nombre[0]);
               }
               if ( Z9TrGestionTableros_TipoTablero != T00012_A9TrGestionTableros_TipoTablero[0] )
               {
                  GXUtil.WriteLog("trgestiontableros:[seudo value changed for attri]"+"TrGestionTableros_TipoTablero");
                  GXUtil.WriteLogRaw("Old: ",Z9TrGestionTableros_TipoTablero);
                  GXUtil.WriteLogRaw("Current: ",T00012_A9TrGestionTableros_TipoTablero[0]);
               }
               if ( Z3TrGestionTableros_FechaInicio != T00012_A3TrGestionTableros_FechaInicio[0] )
               {
                  GXUtil.WriteLog("trgestiontableros:[seudo value changed for attri]"+"TrGestionTableros_FechaInicio");
                  GXUtil.WriteLogRaw("Old: ",Z3TrGestionTableros_FechaInicio);
                  GXUtil.WriteLogRaw("Current: ",T00012_A3TrGestionTableros_FechaInicio[0]);
               }
               if ( Z4TrGestionTableros_FechaFin != T00012_A4TrGestionTableros_FechaFin[0] )
               {
                  GXUtil.WriteLog("trgestiontableros:[seudo value changed for attri]"+"TrGestionTableros_FechaFin");
                  GXUtil.WriteLogRaw("Old: ",Z4TrGestionTableros_FechaFin);
                  GXUtil.WriteLogRaw("Current: ",T00012_A4TrGestionTableros_FechaFin[0]);
               }
               if ( Z7TrGestionTableros_FechaCreacion != T00012_A7TrGestionTableros_FechaCreacion[0] )
               {
                  GXUtil.WriteLog("trgestiontableros:[seudo value changed for attri]"+"TrGestionTableros_FechaCreacion");
                  GXUtil.WriteLogRaw("Old: ",Z7TrGestionTableros_FechaCreacion);
                  GXUtil.WriteLogRaw("Current: ",T00012_A7TrGestionTableros_FechaCreacion[0]);
               }
               if ( Z8TrGestionTableros_FechaModificacion != T00012_A8TrGestionTableros_FechaModificacion[0] )
               {
                  GXUtil.WriteLog("trgestiontableros:[seudo value changed for attri]"+"TrGestionTableros_FechaModificacion");
                  GXUtil.WriteLogRaw("Old: ",Z8TrGestionTableros_FechaModificacion);
                  GXUtil.WriteLogRaw("Current: ",T00012_A8TrGestionTableros_FechaModificacion[0]);
               }
               if ( Z10TrGestionTableros_Estado != T00012_A10TrGestionTableros_Estado[0] )
               {
                  GXUtil.WriteLog("trgestiontableros:[seudo value changed for attri]"+"TrGestionTableros_Estado");
                  GXUtil.WriteLogRaw("Old: ",Z10TrGestionTableros_Estado);
                  GXUtil.WriteLogRaw("Current: ",T00012_A10TrGestionTableros_Estado[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TrGestionTableros"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00018 */
                     pr_default.execute(6, new Object[] {A1TrGestionTableros_ID, n2TrGestionTableros_Nombre, A2TrGestionTableros_Nombre, n6TrGestionTableros_Comentario, A6TrGestionTableros_Comentario, n5TrGestionTableros_Descripcion, A5TrGestionTableros_Descripcion, n9TrGestionTableros_TipoTablero, A9TrGestionTableros_TipoTablero, n3TrGestionTableros_FechaInicio, A3TrGestionTableros_FechaInicio, n4TrGestionTableros_FechaFin, A4TrGestionTableros_FechaFin, n7TrGestionTableros_FechaCreacion, A7TrGestionTableros_FechaCreacion, n8TrGestionTableros_FechaModificacion, A8TrGestionTableros_FechaModificacion, n10TrGestionTableros_Estado, A10TrGestionTableros_Estado});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("TrGestionTableros") ;
                     if ( (pr_default.getStatus(6) == 1) )
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
                           ResetCaption010( ) ;
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00019 */
                     pr_default.execute(7, new Object[] {n2TrGestionTableros_Nombre, A2TrGestionTableros_Nombre, n6TrGestionTableros_Comentario, A6TrGestionTableros_Comentario, n5TrGestionTableros_Descripcion, A5TrGestionTableros_Descripcion, n9TrGestionTableros_TipoTablero, A9TrGestionTableros_TipoTablero, n3TrGestionTableros_FechaInicio, A3TrGestionTableros_FechaInicio, n4TrGestionTableros_FechaFin, A4TrGestionTableros_FechaFin, n7TrGestionTableros_FechaCreacion, A7TrGestionTableros_FechaCreacion, n8TrGestionTableros_FechaModificacion, A8TrGestionTableros_FechaModificacion, n10TrGestionTableros_Estado, A10TrGestionTableros_Estado, A1TrGestionTableros_ID});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("TrGestionTableros") ;
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrGestionTableros"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           GX_msglist.addItem(context.GetMessage( "GXM_sucupdated", ""), "SuccessfullyUpdated", 0, "", true);
                           ResetCaption010( ) ;
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
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000110 */
                  pr_default.execute(8, new Object[] {A1TrGestionTableros_ID});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("TrGestionTableros") ;
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound1 == 0 )
                        {
                           InitAll011( ) ;
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
                        ResetCaption010( ) ;
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
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000111 */
            pr_default.execute(9, new Object[] {A1TrGestionTableros_ID});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tr Gestion Tareas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("trgestiontableros",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("trgestiontableros",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart011( )
      {
         /* Using cursor T000112 */
         pr_default.execute(10);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound1 = 1;
            A1TrGestionTableros_ID = (Guid)((Guid)(T000112_A1TrGestionTableros_ID[0]));
            AssignAttri("", false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound1 = 1;
            A1TrGestionTableros_ID = (Guid)((Guid)(T000112_A1TrGestionTableros_ID[0]));
            AssignAttri("", false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
         }
      }

      protected void ScanEnd011( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
         edtTrGestionTableros_ID_Enabled = 0;
         AssignProp("", false, edtTrGestionTableros_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_ID_Enabled), 5, 0), true);
         edtTrGestionTableros_Nombre_Enabled = 0;
         AssignProp("", false, edtTrGestionTableros_Nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_Nombre_Enabled), 5, 0), true);
         edtTrGestionTableros_Comentario_Enabled = 0;
         AssignProp("", false, edtTrGestionTableros_Comentario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_Comentario_Enabled), 5, 0), true);
         edtTrGestionTableros_Descripcion_Enabled = 0;
         AssignProp("", false, edtTrGestionTableros_Descripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_Descripcion_Enabled), 5, 0), true);
         edtTrGestionTableros_TipoTablero_Enabled = 0;
         AssignProp("", false, edtTrGestionTableros_TipoTablero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_TipoTablero_Enabled), 5, 0), true);
         edtTrGestionTableros_FechaInicio_Enabled = 0;
         AssignProp("", false, edtTrGestionTableros_FechaInicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_FechaInicio_Enabled), 5, 0), true);
         edtTrGestionTableros_FechaFin_Enabled = 0;
         AssignProp("", false, edtTrGestionTableros_FechaFin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_FechaFin_Enabled), 5, 0), true);
         edtTrGestionTableros_FechaCreacion_Enabled = 0;
         AssignProp("", false, edtTrGestionTableros_FechaCreacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_FechaCreacion_Enabled), 5, 0), true);
         edtTrGestionTableros_FechaModificacion_Enabled = 0;
         AssignProp("", false, edtTrGestionTableros_FechaModificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_FechaModificacion_Enabled), 5, 0), true);
         chkTrGestionTableros_Estado.Enabled = 0;
         AssignProp("", false, chkTrGestionTableros_Estado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTrGestionTableros_Estado.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues010( )
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
         context.AddJavascriptSource("gxcfg.js", "?202292722393849", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trgestiontableros.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z1TrGestionTableros_ID", Z1TrGestionTableros_ID.ToString());
         GxWebStd.gx_hidden_field( context, "Z2TrGestionTableros_Nombre", StringUtil.RTrim( Z2TrGestionTableros_Nombre));
         GxWebStd.gx_hidden_field( context, "Z9TrGestionTableros_TipoTablero", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9TrGestionTableros_TipoTablero), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z3TrGestionTableros_FechaInicio", context.localUtil.DToC( Z3TrGestionTableros_FechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z4TrGestionTableros_FechaFin", context.localUtil.DToC( Z4TrGestionTableros_FechaFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z7TrGestionTableros_FechaCreacion", context.localUtil.DToC( Z7TrGestionTableros_FechaCreacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z8TrGestionTableros_FechaModificacion", context.localUtil.DToC( Z8TrGestionTableros_FechaModificacion, 0, "/"));
         GxWebStd.gx_boolean_hidden_field( context, "Z10TrGestionTableros_Estado", Z10TrGestionTableros_Estado);
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
         return formatLink("trgestiontableros.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "TrGestionTableros" ;
      }

      public override String GetPgmdesc( )
      {
         return "Tr Gestion Tableros" ;
      }

      protected void InitializeNonKey011( )
      {
         A2TrGestionTableros_Nombre = "";
         n2TrGestionTableros_Nombre = false;
         AssignAttri("", false, "A2TrGestionTableros_Nombre", A2TrGestionTableros_Nombre);
         n2TrGestionTableros_Nombre = (String.IsNullOrEmpty(StringUtil.RTrim( A2TrGestionTableros_Nombre)) ? true : false);
         A6TrGestionTableros_Comentario = "";
         n6TrGestionTableros_Comentario = false;
         AssignAttri("", false, "A6TrGestionTableros_Comentario", A6TrGestionTableros_Comentario);
         n6TrGestionTableros_Comentario = (String.IsNullOrEmpty(StringUtil.RTrim( A6TrGestionTableros_Comentario)) ? true : false);
         A5TrGestionTableros_Descripcion = "";
         n5TrGestionTableros_Descripcion = false;
         AssignAttri("", false, "A5TrGestionTableros_Descripcion", A5TrGestionTableros_Descripcion);
         n5TrGestionTableros_Descripcion = (String.IsNullOrEmpty(StringUtil.RTrim( A5TrGestionTableros_Descripcion)) ? true : false);
         A9TrGestionTableros_TipoTablero = 0;
         n9TrGestionTableros_TipoTablero = false;
         AssignAttri("", false, "A9TrGestionTableros_TipoTablero", StringUtil.LTrimStr( (decimal)(A9TrGestionTableros_TipoTablero), 4, 0));
         n9TrGestionTableros_TipoTablero = ((0==A9TrGestionTableros_TipoTablero) ? true : false);
         A3TrGestionTableros_FechaInicio = DateTime.MinValue;
         n3TrGestionTableros_FechaInicio = false;
         AssignAttri("", false, "A3TrGestionTableros_FechaInicio", context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"));
         n3TrGestionTableros_FechaInicio = ((DateTime.MinValue==A3TrGestionTableros_FechaInicio) ? true : false);
         A4TrGestionTableros_FechaFin = DateTime.MinValue;
         n4TrGestionTableros_FechaFin = false;
         AssignAttri("", false, "A4TrGestionTableros_FechaFin", context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"));
         n4TrGestionTableros_FechaFin = ((DateTime.MinValue==A4TrGestionTableros_FechaFin) ? true : false);
         A7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         n7TrGestionTableros_FechaCreacion = false;
         AssignAttri("", false, "A7TrGestionTableros_FechaCreacion", context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"));
         n7TrGestionTableros_FechaCreacion = ((DateTime.MinValue==A7TrGestionTableros_FechaCreacion) ? true : false);
         A8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         n8TrGestionTableros_FechaModificacion = false;
         AssignAttri("", false, "A8TrGestionTableros_FechaModificacion", context.localUtil.Format(A8TrGestionTableros_FechaModificacion, "99/99/9999"));
         n8TrGestionTableros_FechaModificacion = ((DateTime.MinValue==A8TrGestionTableros_FechaModificacion) ? true : false);
         A10TrGestionTableros_Estado = false;
         n10TrGestionTableros_Estado = false;
         AssignAttri("", false, "A10TrGestionTableros_Estado", A10TrGestionTableros_Estado);
         n10TrGestionTableros_Estado = ((false==A10TrGestionTableros_Estado) ? true : false);
         Z2TrGestionTableros_Nombre = "";
         Z9TrGestionTableros_TipoTablero = 0;
         Z3TrGestionTableros_FechaInicio = DateTime.MinValue;
         Z4TrGestionTableros_FechaFin = DateTime.MinValue;
         Z7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         Z8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         Z10TrGestionTableros_Estado = false;
      }

      protected void InitAll011( )
      {
         A1TrGestionTableros_ID = (Guid)(Guid.Empty);
         AssignAttri("", false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
         InitializeNonKey011( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202292722393853", true, true);
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
         context.AddJavascriptSource("trgestiontableros.js", "?202292722393853", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtTrGestionTableros_ID_Internalname = "TRGESTIONTABLEROS_ID";
         edtTrGestionTableros_Nombre_Internalname = "TRGESTIONTABLEROS_NOMBRE";
         edtTrGestionTableros_Comentario_Internalname = "TRGESTIONTABLEROS_COMENTARIO";
         edtTrGestionTableros_Descripcion_Internalname = "TRGESTIONTABLEROS_DESCRIPCION";
         edtTrGestionTableros_TipoTablero_Internalname = "TRGESTIONTABLEROS_TIPOTABLERO";
         edtTrGestionTableros_FechaInicio_Internalname = "TRGESTIONTABLEROS_FECHAINICIO";
         edtTrGestionTableros_FechaFin_Internalname = "TRGESTIONTABLEROS_FECHAFIN";
         edtTrGestionTableros_FechaCreacion_Internalname = "TRGESTIONTABLEROS_FECHACREACION";
         edtTrGestionTableros_FechaModificacion_Internalname = "TRGESTIONTABLEROS_FECHAMODIFICACION";
         chkTrGestionTableros_Estado_Internalname = "TRGESTIONTABLEROS_ESTADO";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Tr Gestion Tableros";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkTrGestionTableros_Estado.Enabled = 1;
         edtTrGestionTableros_FechaModificacion_Jsonclick = "";
         edtTrGestionTableros_FechaModificacion_Enabled = 1;
         edtTrGestionTableros_FechaCreacion_Jsonclick = "";
         edtTrGestionTableros_FechaCreacion_Enabled = 1;
         edtTrGestionTableros_FechaFin_Jsonclick = "";
         edtTrGestionTableros_FechaFin_Enabled = 1;
         edtTrGestionTableros_FechaInicio_Jsonclick = "";
         edtTrGestionTableros_FechaInicio_Enabled = 1;
         edtTrGestionTableros_TipoTablero_Jsonclick = "";
         edtTrGestionTableros_TipoTablero_Enabled = 1;
         edtTrGestionTableros_Descripcion_Enabled = 1;
         edtTrGestionTableros_Comentario_Enabled = 1;
         edtTrGestionTableros_Nombre_Jsonclick = "";
         edtTrGestionTableros_Nombre_Enabled = 1;
         edtTrGestionTableros_ID_Jsonclick = "";
         edtTrGestionTableros_ID_Enabled = 1;
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
         chkTrGestionTableros_Estado.Name = "TRGESTIONTABLEROS_ESTADO";
         chkTrGestionTableros_Estado.WebTags = "";
         chkTrGestionTableros_Estado.Caption = "";
         AssignProp("", false, chkTrGestionTableros_Estado_Internalname, "TitleCaption", chkTrGestionTableros_Estado.Caption, true);
         chkTrGestionTableros_Estado.CheckedValue = "false";
         A10TrGestionTableros_Estado = StringUtil.StrToBool( StringUtil.BoolToStr( A10TrGestionTableros_Estado));
         n10TrGestionTableros_Estado = false;
         AssignAttri("", false, "A10TrGestionTableros_Estado", A10TrGestionTableros_Estado);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtTrGestionTableros_Nombre_Internalname;
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

      public void Valid_Trgestiontableros_id( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A10TrGestionTableros_Estado = StringUtil.StrToBool( StringUtil.BoolToStr( A10TrGestionTableros_Estado));
         n10TrGestionTableros_Estado = false;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2TrGestionTableros_Nombre", StringUtil.RTrim( A2TrGestionTableros_Nombre));
         AssignAttri("", false, "A6TrGestionTableros_Comentario", A6TrGestionTableros_Comentario);
         AssignAttri("", false, "A5TrGestionTableros_Descripcion", A5TrGestionTableros_Descripcion);
         AssignAttri("", false, "A9TrGestionTableros_TipoTablero", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TrGestionTableros_TipoTablero), 4, 0, ".", "")));
         AssignAttri("", false, "A3TrGestionTableros_FechaInicio", context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"));
         AssignAttri("", false, "A4TrGestionTableros_FechaFin", context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"));
         AssignAttri("", false, "A7TrGestionTableros_FechaCreacion", context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"));
         AssignAttri("", false, "A8TrGestionTableros_FechaModificacion", context.localUtil.Format(A8TrGestionTableros_FechaModificacion, "99/99/9999"));
         AssignAttri("", false, "A10TrGestionTableros_Estado", A10TrGestionTableros_Estado);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z1TrGestionTableros_ID", Z1TrGestionTableros_ID.ToString());
         GxWebStd.gx_hidden_field( context, "Z2TrGestionTableros_Nombre", StringUtil.RTrim( Z2TrGestionTableros_Nombre));
         GxWebStd.gx_hidden_field( context, "Z6TrGestionTableros_Comentario", Z6TrGestionTableros_Comentario);
         GxWebStd.gx_hidden_field( context, "Z5TrGestionTableros_Descripcion", Z5TrGestionTableros_Descripcion);
         GxWebStd.gx_hidden_field( context, "Z9TrGestionTableros_TipoTablero", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9TrGestionTableros_TipoTablero), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z3TrGestionTableros_FechaInicio", context.localUtil.Format(Z3TrGestionTableros_FechaInicio, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z4TrGestionTableros_FechaFin", context.localUtil.Format(Z4TrGestionTableros_FechaFin, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z7TrGestionTableros_FechaCreacion", context.localUtil.Format(Z7TrGestionTableros_FechaCreacion, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z8TrGestionTableros_FechaModificacion", context.localUtil.Format(Z8TrGestionTableros_FechaModificacion, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z10TrGestionTableros_Estado", StringUtil.BoolToStr( Z10TrGestionTableros_Estado));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A10TrGestionTableros_Estado',fld:'TRGESTIONTABLEROS_ESTADO',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A10TrGestionTableros_Estado',fld:'TRGESTIONTABLEROS_ESTADO',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A10TrGestionTableros_Estado',fld:'TRGESTIONTABLEROS_ESTADO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A10TrGestionTableros_Estado',fld:'TRGESTIONTABLEROS_ESTADO',pic:''}]}");
         setEventMetadata("VALID_TRGESTIONTABLEROS_ID","{handler:'Valid_Trgestiontableros_id',iparms:[{av:'A1TrGestionTableros_ID',fld:'TRGESTIONTABLEROS_ID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A10TrGestionTableros_Estado',fld:'TRGESTIONTABLEROS_ESTADO',pic:''}]");
         setEventMetadata("VALID_TRGESTIONTABLEROS_ID",",oparms:[{av:'A2TrGestionTableros_Nombre',fld:'TRGESTIONTABLEROS_NOMBRE',pic:''},{av:'A6TrGestionTableros_Comentario',fld:'TRGESTIONTABLEROS_COMENTARIO',pic:''},{av:'A5TrGestionTableros_Descripcion',fld:'TRGESTIONTABLEROS_DESCRIPCION',pic:''},{av:'A9TrGestionTableros_TipoTablero',fld:'TRGESTIONTABLEROS_TIPOTABLERO',pic:'ZZZ9'},{av:'A3TrGestionTableros_FechaInicio',fld:'TRGESTIONTABLEROS_FECHAINICIO',pic:''},{av:'A4TrGestionTableros_FechaFin',fld:'TRGESTIONTABLEROS_FECHAFIN',pic:''},{av:'A7TrGestionTableros_FechaCreacion',fld:'TRGESTIONTABLEROS_FECHACREACION',pic:''},{av:'A8TrGestionTableros_FechaModificacion',fld:'TRGESTIONTABLEROS_FECHAMODIFICACION',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z1TrGestionTableros_ID'},{av:'Z2TrGestionTableros_Nombre'},{av:'Z6TrGestionTableros_Comentario'},{av:'Z5TrGestionTableros_Descripcion'},{av:'Z9TrGestionTableros_TipoTablero'},{av:'Z3TrGestionTableros_FechaInicio'},{av:'Z4TrGestionTableros_FechaFin'},{av:'Z7TrGestionTableros_FechaCreacion'},{av:'Z8TrGestionTableros_FechaModificacion'},{av:'Z10TrGestionTableros_Estado'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A10TrGestionTableros_Estado',fld:'TRGESTIONTABLEROS_ESTADO',pic:''}]}");
         setEventMetadata("VALID_TRGESTIONTABLEROS_FECHAINICIO","{handler:'Valid_Trgestiontableros_fechainicio',iparms:[{av:'A10TrGestionTableros_Estado',fld:'TRGESTIONTABLEROS_ESTADO',pic:''}]");
         setEventMetadata("VALID_TRGESTIONTABLEROS_FECHAINICIO",",oparms:[{av:'A10TrGestionTableros_Estado',fld:'TRGESTIONTABLEROS_ESTADO',pic:''}]}");
         setEventMetadata("VALID_TRGESTIONTABLEROS_FECHAFIN","{handler:'Valid_Trgestiontableros_fechafin',iparms:[{av:'A10TrGestionTableros_Estado',fld:'TRGESTIONTABLEROS_ESTADO',pic:''}]");
         setEventMetadata("VALID_TRGESTIONTABLEROS_FECHAFIN",",oparms:[{av:'A10TrGestionTableros_Estado',fld:'TRGESTIONTABLEROS_ESTADO',pic:''}]}");
         setEventMetadata("VALID_TRGESTIONTABLEROS_FECHACREACION","{handler:'Valid_Trgestiontableros_fechacreacion',iparms:[{av:'A10TrGestionTableros_Estado',fld:'TRGESTIONTABLEROS_ESTADO',pic:''}]");
         setEventMetadata("VALID_TRGESTIONTABLEROS_FECHACREACION",",oparms:[{av:'A10TrGestionTableros_Estado',fld:'TRGESTIONTABLEROS_ESTADO',pic:''}]}");
         setEventMetadata("VALID_TRGESTIONTABLEROS_FECHAMODIFICACION","{handler:'Valid_Trgestiontableros_fechamodificacion',iparms:[{av:'A10TrGestionTableros_Estado',fld:'TRGESTIONTABLEROS_ESTADO',pic:''}]");
         setEventMetadata("VALID_TRGESTIONTABLEROS_FECHAMODIFICACION",",oparms:[{av:'A10TrGestionTableros_Estado',fld:'TRGESTIONTABLEROS_ESTADO',pic:''}]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z1TrGestionTableros_ID = (Guid)(Guid.Empty);
         Z2TrGestionTableros_Nombre = "";
         Z3TrGestionTableros_FechaInicio = DateTime.MinValue;
         Z4TrGestionTableros_FechaFin = DateTime.MinValue;
         Z7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         Z8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A1TrGestionTableros_ID = (Guid)(Guid.Empty);
         A2TrGestionTableros_Nombre = "";
         A6TrGestionTableros_Comentario = "";
         A5TrGestionTableros_Descripcion = "";
         A3TrGestionTableros_FechaInicio = DateTime.MinValue;
         A4TrGestionTableros_FechaFin = DateTime.MinValue;
         A7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         A8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         Z6TrGestionTableros_Comentario = "";
         Z5TrGestionTableros_Descripcion = "";
         T00014_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         T00014_A2TrGestionTableros_Nombre = new String[] {""} ;
         T00014_n2TrGestionTableros_Nombre = new bool[] {false} ;
         T00014_A6TrGestionTableros_Comentario = new String[] {""} ;
         T00014_n6TrGestionTableros_Comentario = new bool[] {false} ;
         T00014_A5TrGestionTableros_Descripcion = new String[] {""} ;
         T00014_n5TrGestionTableros_Descripcion = new bool[] {false} ;
         T00014_A9TrGestionTableros_TipoTablero = new short[1] ;
         T00014_n9TrGestionTableros_TipoTablero = new bool[] {false} ;
         T00014_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         T00014_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         T00014_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         T00014_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         T00014_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00014_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         T00014_A8TrGestionTableros_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00014_n8TrGestionTableros_FechaModificacion = new bool[] {false} ;
         T00014_A10TrGestionTableros_Estado = new bool[] {false} ;
         T00014_n10TrGestionTableros_Estado = new bool[] {false} ;
         T00015_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         T00013_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         T00013_A2TrGestionTableros_Nombre = new String[] {""} ;
         T00013_n2TrGestionTableros_Nombre = new bool[] {false} ;
         T00013_A6TrGestionTableros_Comentario = new String[] {""} ;
         T00013_n6TrGestionTableros_Comentario = new bool[] {false} ;
         T00013_A5TrGestionTableros_Descripcion = new String[] {""} ;
         T00013_n5TrGestionTableros_Descripcion = new bool[] {false} ;
         T00013_A9TrGestionTableros_TipoTablero = new short[1] ;
         T00013_n9TrGestionTableros_TipoTablero = new bool[] {false} ;
         T00013_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         T00013_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         T00013_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         T00013_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         T00013_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00013_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         T00013_A8TrGestionTableros_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00013_n8TrGestionTableros_FechaModificacion = new bool[] {false} ;
         T00013_A10TrGestionTableros_Estado = new bool[] {false} ;
         T00013_n10TrGestionTableros_Estado = new bool[] {false} ;
         sMode1 = "";
         T00016_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         T00017_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         T00012_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         T00012_A2TrGestionTableros_Nombre = new String[] {""} ;
         T00012_n2TrGestionTableros_Nombre = new bool[] {false} ;
         T00012_A6TrGestionTableros_Comentario = new String[] {""} ;
         T00012_n6TrGestionTableros_Comentario = new bool[] {false} ;
         T00012_A5TrGestionTableros_Descripcion = new String[] {""} ;
         T00012_n5TrGestionTableros_Descripcion = new bool[] {false} ;
         T00012_A9TrGestionTableros_TipoTablero = new short[1] ;
         T00012_n9TrGestionTableros_TipoTablero = new bool[] {false} ;
         T00012_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         T00012_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         T00012_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         T00012_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         T00012_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00012_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         T00012_A8TrGestionTableros_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00012_n8TrGestionTableros_FechaModificacion = new bool[] {false} ;
         T00012_A10TrGestionTableros_Estado = new bool[] {false} ;
         T00012_n10TrGestionTableros_Estado = new bool[] {false} ;
         T000111_A12TrGestionTareas_ID = new long[1] ;
         T000112_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1TrGestionTableros_ID = (Guid)(Guid.Empty);
         ZZ2TrGestionTableros_Nombre = "";
         ZZ6TrGestionTableros_Comentario = "";
         ZZ5TrGestionTableros_Descripcion = "";
         ZZ3TrGestionTableros_FechaInicio = DateTime.MinValue;
         ZZ4TrGestionTableros_FechaFin = DateTime.MinValue;
         ZZ7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         ZZ8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trgestiontableros__default(),
            new Object[][] {
                new Object[] {
               T00012_A1TrGestionTableros_ID, T00012_A2TrGestionTableros_Nombre, T00012_n2TrGestionTableros_Nombre, T00012_A6TrGestionTableros_Comentario, T00012_n6TrGestionTableros_Comentario, T00012_A5TrGestionTableros_Descripcion, T00012_n5TrGestionTableros_Descripcion, T00012_A9TrGestionTableros_TipoTablero, T00012_n9TrGestionTableros_TipoTablero, T00012_A3TrGestionTableros_FechaInicio,
               T00012_n3TrGestionTableros_FechaInicio, T00012_A4TrGestionTableros_FechaFin, T00012_n4TrGestionTableros_FechaFin, T00012_A7TrGestionTableros_FechaCreacion, T00012_n7TrGestionTableros_FechaCreacion, T00012_A8TrGestionTableros_FechaModificacion, T00012_n8TrGestionTableros_FechaModificacion, T00012_A10TrGestionTableros_Estado, T00012_n10TrGestionTableros_Estado
               }
               , new Object[] {
               T00013_A1TrGestionTableros_ID, T00013_A2TrGestionTableros_Nombre, T00013_n2TrGestionTableros_Nombre, T00013_A6TrGestionTableros_Comentario, T00013_n6TrGestionTableros_Comentario, T00013_A5TrGestionTableros_Descripcion, T00013_n5TrGestionTableros_Descripcion, T00013_A9TrGestionTableros_TipoTablero, T00013_n9TrGestionTableros_TipoTablero, T00013_A3TrGestionTableros_FechaInicio,
               T00013_n3TrGestionTableros_FechaInicio, T00013_A4TrGestionTableros_FechaFin, T00013_n4TrGestionTableros_FechaFin, T00013_A7TrGestionTableros_FechaCreacion, T00013_n7TrGestionTableros_FechaCreacion, T00013_A8TrGestionTableros_FechaModificacion, T00013_n8TrGestionTableros_FechaModificacion, T00013_A10TrGestionTableros_Estado, T00013_n10TrGestionTableros_Estado
               }
               , new Object[] {
               T00014_A1TrGestionTableros_ID, T00014_A2TrGestionTableros_Nombre, T00014_n2TrGestionTableros_Nombre, T00014_A6TrGestionTableros_Comentario, T00014_n6TrGestionTableros_Comentario, T00014_A5TrGestionTableros_Descripcion, T00014_n5TrGestionTableros_Descripcion, T00014_A9TrGestionTableros_TipoTablero, T00014_n9TrGestionTableros_TipoTablero, T00014_A3TrGestionTableros_FechaInicio,
               T00014_n3TrGestionTableros_FechaInicio, T00014_A4TrGestionTableros_FechaFin, T00014_n4TrGestionTableros_FechaFin, T00014_A7TrGestionTableros_FechaCreacion, T00014_n7TrGestionTableros_FechaCreacion, T00014_A8TrGestionTableros_FechaModificacion, T00014_n8TrGestionTableros_FechaModificacion, T00014_A10TrGestionTableros_Estado, T00014_n10TrGestionTableros_Estado
               }
               , new Object[] {
               T00015_A1TrGestionTableros_ID
               }
               , new Object[] {
               T00016_A1TrGestionTableros_ID
               }
               , new Object[] {
               T00017_A1TrGestionTableros_ID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000111_A12TrGestionTareas_ID
               }
               , new Object[] {
               T000112_A1TrGestionTableros_ID
               }
            }
         );
      }

      private short Z9TrGestionTableros_TipoTablero ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A9TrGestionTableros_TipoTablero ;
      private short GX_JID ;
      private short RcdFound1 ;
      private short nIsDirty_1 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ9TrGestionTableros_TipoTablero ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTrGestionTableros_ID_Enabled ;
      private int edtTrGestionTableros_Nombre_Enabled ;
      private int edtTrGestionTableros_Comentario_Enabled ;
      private int edtTrGestionTableros_Descripcion_Enabled ;
      private int edtTrGestionTableros_TipoTablero_Enabled ;
      private int edtTrGestionTableros_FechaInicio_Enabled ;
      private int edtTrGestionTableros_FechaFin_Enabled ;
      private int edtTrGestionTableros_FechaCreacion_Enabled ;
      private int edtTrGestionTableros_FechaModificacion_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private String sPrefix ;
      private String Z2TrGestionTableros_Nombre ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String GXKey ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtTrGestionTableros_ID_Internalname ;
      private String divMaintable_Internalname ;
      private String divTitlecontainer_Internalname ;
      private String lblTitle_Internalname ;
      private String lblTitle_Jsonclick ;
      private String ClassString ;
      private String StyleString ;
      private String divFormcontainer_Internalname ;
      private String divToolbarcell_Internalname ;
      private String TempTags ;
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
      private String edtTrGestionTableros_ID_Jsonclick ;
      private String edtTrGestionTableros_Nombre_Internalname ;
      private String A2TrGestionTableros_Nombre ;
      private String edtTrGestionTableros_Nombre_Jsonclick ;
      private String edtTrGestionTableros_Comentario_Internalname ;
      private String edtTrGestionTableros_Descripcion_Internalname ;
      private String edtTrGestionTableros_TipoTablero_Internalname ;
      private String edtTrGestionTableros_TipoTablero_Jsonclick ;
      private String edtTrGestionTableros_FechaInicio_Internalname ;
      private String edtTrGestionTableros_FechaInicio_Jsonclick ;
      private String edtTrGestionTableros_FechaFin_Internalname ;
      private String edtTrGestionTableros_FechaFin_Jsonclick ;
      private String edtTrGestionTableros_FechaCreacion_Internalname ;
      private String edtTrGestionTableros_FechaCreacion_Jsonclick ;
      private String edtTrGestionTableros_FechaModificacion_Internalname ;
      private String edtTrGestionTableros_FechaModificacion_Jsonclick ;
      private String chkTrGestionTableros_Estado_Internalname ;
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
      private String sMode1 ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String ZZ2TrGestionTableros_Nombre ;
      private DateTime Z3TrGestionTableros_FechaInicio ;
      private DateTime Z4TrGestionTableros_FechaFin ;
      private DateTime Z7TrGestionTableros_FechaCreacion ;
      private DateTime Z8TrGestionTableros_FechaModificacion ;
      private DateTime A3TrGestionTableros_FechaInicio ;
      private DateTime A4TrGestionTableros_FechaFin ;
      private DateTime A7TrGestionTableros_FechaCreacion ;
      private DateTime A8TrGestionTableros_FechaModificacion ;
      private DateTime ZZ3TrGestionTableros_FechaInicio ;
      private DateTime ZZ4TrGestionTableros_FechaFin ;
      private DateTime ZZ7TrGestionTableros_FechaCreacion ;
      private DateTime ZZ8TrGestionTableros_FechaModificacion ;
      private bool Z10TrGestionTableros_Estado ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A10TrGestionTableros_Estado ;
      private bool n10TrGestionTableros_Estado ;
      private bool n2TrGestionTableros_Nombre ;
      private bool n9TrGestionTableros_TipoTablero ;
      private bool n3TrGestionTableros_FechaInicio ;
      private bool n4TrGestionTableros_FechaFin ;
      private bool n7TrGestionTableros_FechaCreacion ;
      private bool n8TrGestionTableros_FechaModificacion ;
      private bool n6TrGestionTableros_Comentario ;
      private bool n5TrGestionTableros_Descripcion ;
      private bool Gx_longc ;
      private bool ZZ10TrGestionTableros_Estado ;
      private String A6TrGestionTableros_Comentario ;
      private String A5TrGestionTableros_Descripcion ;
      private String Z6TrGestionTableros_Comentario ;
      private String Z5TrGestionTableros_Descripcion ;
      private String ZZ6TrGestionTableros_Comentario ;
      private String ZZ5TrGestionTableros_Descripcion ;
      private Guid Z1TrGestionTableros_ID ;
      private Guid A1TrGestionTableros_ID ;
      private Guid ZZ1TrGestionTableros_ID ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkTrGestionTableros_Estado ;
      private IDataStoreProvider pr_default ;
      private Guid[] T00014_A1TrGestionTableros_ID ;
      private String[] T00014_A2TrGestionTableros_Nombre ;
      private bool[] T00014_n2TrGestionTableros_Nombre ;
      private String[] T00014_A6TrGestionTableros_Comentario ;
      private bool[] T00014_n6TrGestionTableros_Comentario ;
      private String[] T00014_A5TrGestionTableros_Descripcion ;
      private bool[] T00014_n5TrGestionTableros_Descripcion ;
      private short[] T00014_A9TrGestionTableros_TipoTablero ;
      private bool[] T00014_n9TrGestionTableros_TipoTablero ;
      private DateTime[] T00014_A3TrGestionTableros_FechaInicio ;
      private bool[] T00014_n3TrGestionTableros_FechaInicio ;
      private DateTime[] T00014_A4TrGestionTableros_FechaFin ;
      private bool[] T00014_n4TrGestionTableros_FechaFin ;
      private DateTime[] T00014_A7TrGestionTableros_FechaCreacion ;
      private bool[] T00014_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] T00014_A8TrGestionTableros_FechaModificacion ;
      private bool[] T00014_n8TrGestionTableros_FechaModificacion ;
      private bool[] T00014_A10TrGestionTableros_Estado ;
      private bool[] T00014_n10TrGestionTableros_Estado ;
      private Guid[] T00015_A1TrGestionTableros_ID ;
      private Guid[] T00013_A1TrGestionTableros_ID ;
      private String[] T00013_A2TrGestionTableros_Nombre ;
      private bool[] T00013_n2TrGestionTableros_Nombre ;
      private String[] T00013_A6TrGestionTableros_Comentario ;
      private bool[] T00013_n6TrGestionTableros_Comentario ;
      private String[] T00013_A5TrGestionTableros_Descripcion ;
      private bool[] T00013_n5TrGestionTableros_Descripcion ;
      private short[] T00013_A9TrGestionTableros_TipoTablero ;
      private bool[] T00013_n9TrGestionTableros_TipoTablero ;
      private DateTime[] T00013_A3TrGestionTableros_FechaInicio ;
      private bool[] T00013_n3TrGestionTableros_FechaInicio ;
      private DateTime[] T00013_A4TrGestionTableros_FechaFin ;
      private bool[] T00013_n4TrGestionTableros_FechaFin ;
      private DateTime[] T00013_A7TrGestionTableros_FechaCreacion ;
      private bool[] T00013_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] T00013_A8TrGestionTableros_FechaModificacion ;
      private bool[] T00013_n8TrGestionTableros_FechaModificacion ;
      private bool[] T00013_A10TrGestionTableros_Estado ;
      private bool[] T00013_n10TrGestionTableros_Estado ;
      private Guid[] T00016_A1TrGestionTableros_ID ;
      private Guid[] T00017_A1TrGestionTableros_ID ;
      private Guid[] T00012_A1TrGestionTableros_ID ;
      private String[] T00012_A2TrGestionTableros_Nombre ;
      private bool[] T00012_n2TrGestionTableros_Nombre ;
      private String[] T00012_A6TrGestionTableros_Comentario ;
      private bool[] T00012_n6TrGestionTableros_Comentario ;
      private String[] T00012_A5TrGestionTableros_Descripcion ;
      private bool[] T00012_n5TrGestionTableros_Descripcion ;
      private short[] T00012_A9TrGestionTableros_TipoTablero ;
      private bool[] T00012_n9TrGestionTableros_TipoTablero ;
      private DateTime[] T00012_A3TrGestionTableros_FechaInicio ;
      private bool[] T00012_n3TrGestionTableros_FechaInicio ;
      private DateTime[] T00012_A4TrGestionTableros_FechaFin ;
      private bool[] T00012_n4TrGestionTableros_FechaFin ;
      private DateTime[] T00012_A7TrGestionTableros_FechaCreacion ;
      private bool[] T00012_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] T00012_A8TrGestionTableros_FechaModificacion ;
      private bool[] T00012_n8TrGestionTableros_FechaModificacion ;
      private bool[] T00012_A10TrGestionTableros_Estado ;
      private bool[] T00012_n10TrGestionTableros_Estado ;
      private long[] T000111_A12TrGestionTareas_ID ;
      private Guid[] T000112_A1TrGestionTableros_ID ;
      private GXWebForm Form ;
   }

   public class trgestiontableros__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00014 ;
          prmT00014 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT00015 ;
          prmT00015 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT00013 ;
          prmT00013 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT00016 ;
          prmT00016 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT00017 ;
          prmT00017 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT00012 ;
          prmT00012 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT00018 ;
          prmT00018 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0} ,
          new Object[] {"@TrGestionTableros_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@TrGestionTableros_Comentario",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_TipoTablero",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrGestionTableros_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_Estado",SqlDbType.Bit,4,0}
          } ;
          Object[] prmT00019 ;
          prmT00019 = new Object[] {
          new Object[] {"@TrGestionTableros_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@TrGestionTableros_Comentario",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_TipoTablero",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrGestionTableros_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_Estado",SqlDbType.Bit,4,0} ,
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT000110 ;
          prmT000110 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT000111 ;
          prmT000111 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT000112 ;
          prmT000112 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("T00012", "SELECT [TrGestionTableros_ID], [TrGestionTableros_Nombre], [TrGestionTableros_Comentario], [TrGestionTableros_Descripcion], [TrGestionTableros_TipoTablero], [TrGestionTableros_FechaInicio], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaCreacion], [TrGestionTableros_FechaModificacion], [TrGestionTableros_Estado] FROM TABLERO.[TrGestionTableros] WITH (UPDLOCK) WHERE [TrGestionTableros_ID] = @TrGestionTableros_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00013", "SELECT [TrGestionTableros_ID], [TrGestionTableros_Nombre], [TrGestionTableros_Comentario], [TrGestionTableros_Descripcion], [TrGestionTableros_TipoTablero], [TrGestionTableros_FechaInicio], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaCreacion], [TrGestionTableros_FechaModificacion], [TrGestionTableros_Estado] FROM TABLERO.[TrGestionTableros] WHERE [TrGestionTableros_ID] = @TrGestionTableros_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00014", "SELECT TM1.[TrGestionTableros_ID], TM1.[TrGestionTableros_Nombre], TM1.[TrGestionTableros_Comentario], TM1.[TrGestionTableros_Descripcion], TM1.[TrGestionTableros_TipoTablero], TM1.[TrGestionTableros_FechaInicio], TM1.[TrGestionTableros_FechaFin], TM1.[TrGestionTableros_FechaCreacion], TM1.[TrGestionTableros_FechaModificacion], TM1.[TrGestionTableros_Estado] FROM TABLERO.[TrGestionTableros] TM1 WHERE TM1.[TrGestionTableros_ID] = @TrGestionTableros_ID ORDER BY TM1.[TrGestionTableros_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00015", "SELECT [TrGestionTableros_ID] FROM TABLERO.[TrGestionTableros] WHERE [TrGestionTableros_ID] = @TrGestionTableros_ID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00016", "SELECT TOP 1 [TrGestionTableros_ID] FROM TABLERO.[TrGestionTableros] WHERE ( [TrGestionTableros_ID] > @TrGestionTableros_ID) ORDER BY [TrGestionTableros_ID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00017", "SELECT TOP 1 [TrGestionTableros_ID] FROM TABLERO.[TrGestionTableros] WHERE ( [TrGestionTableros_ID] < @TrGestionTableros_ID) ORDER BY [TrGestionTableros_ID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00018", "INSERT INTO TABLERO.[TrGestionTableros]([TrGestionTableros_ID], [TrGestionTableros_Nombre], [TrGestionTableros_Comentario], [TrGestionTableros_Descripcion], [TrGestionTableros_TipoTablero], [TrGestionTableros_FechaInicio], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaCreacion], [TrGestionTableros_FechaModificacion], [TrGestionTableros_Estado]) VALUES(@TrGestionTableros_ID, @TrGestionTableros_Nombre, @TrGestionTableros_Comentario, @TrGestionTableros_Descripcion, @TrGestionTableros_TipoTablero, @TrGestionTableros_FechaInicio, @TrGestionTableros_FechaFin, @TrGestionTableros_FechaCreacion, @TrGestionTableros_FechaModificacion, @TrGestionTableros_Estado)", GxErrorMask.GX_NOMASK,prmT00018)
             ,new CursorDef("T00019", "UPDATE TABLERO.[TrGestionTableros] SET [TrGestionTableros_Nombre]=@TrGestionTableros_Nombre, [TrGestionTableros_Comentario]=@TrGestionTableros_Comentario, [TrGestionTableros_Descripcion]=@TrGestionTableros_Descripcion, [TrGestionTableros_TipoTablero]=@TrGestionTableros_TipoTablero, [TrGestionTableros_FechaInicio]=@TrGestionTableros_FechaInicio, [TrGestionTableros_FechaFin]=@TrGestionTableros_FechaFin, [TrGestionTableros_FechaCreacion]=@TrGestionTableros_FechaCreacion, [TrGestionTableros_FechaModificacion]=@TrGestionTableros_FechaModificacion, [TrGestionTableros_Estado]=@TrGestionTableros_Estado  WHERE [TrGestionTableros_ID] = @TrGestionTableros_ID", GxErrorMask.GX_NOMASK,prmT00019)
             ,new CursorDef("T000110", "DELETE FROM TABLERO.[TrGestionTableros]  WHERE [TrGestionTableros_ID] = @TrGestionTableros_ID", GxErrorMask.GX_NOMASK,prmT000110)
             ,new CursorDef("T000111", "SELECT TOP 1 [TrGestionTareas_ID] FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_IDTablero] = @TrGestionTableros_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000111,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000112", "SELECT [TrGestionTableros_ID] FROM TABLERO.[TrGestionTableros] ORDER BY [TrGestionTableros_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000112,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10) ;
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10) ;
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10) ;
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 10 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
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
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 1 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 2 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 3 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 4 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 5 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 6 :
                stmt.SetParameter(1, (Guid)parms[0]);
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
                   stmt.setNull( 4 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(4, (String)parms[6]);
                }
                if ( (bool)parms[7] )
                {
                   stmt.setNull( 5 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(5, (short)parms[8]);
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
                   stmt.setNull( 8 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(8, (DateTime)parms[14]);
                }
                if ( (bool)parms[15] )
                {
                   stmt.setNull( 9 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(9, (DateTime)parms[16]);
                }
                if ( (bool)parms[17] )
                {
                   stmt.setNull( 10 , SqlDbType.Bit );
                }
                else
                {
                   stmt.SetParameter(10, (bool)parms[18]);
                }
                return;
             case 7 :
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
                   stmt.setNull( 3 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(3, (String)parms[5]);
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
                   stmt.setNull( 7 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(7, (DateTime)parms[13]);
                }
                if ( (bool)parms[14] )
                {
                   stmt.setNull( 8 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(8, (DateTime)parms[15]);
                }
                if ( (bool)parms[16] )
                {
                   stmt.setNull( 9 , SqlDbType.Bit );
                }
                else
                {
                   stmt.SetParameter(9, (bool)parms[17]);
                }
                stmt.SetParameter(10, (Guid)parms[18]);
                return;
             case 8 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 9 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
       }
    }

 }

}
