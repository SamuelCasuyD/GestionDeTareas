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
   public class trgestiontareas : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A11TrGestionTareas_IDTablero = (Guid)(StringUtil.StrToGuid( GetNextPar( )));
            AssignAttri("", false, "A11TrGestionTareas_IDTablero", A11TrGestionTareas_IDTablero.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A11TrGestionTareas_IDTablero) ;
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
            Form.Meta.addItem("description", "Tr Gestion Tareas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         GX_FocusControl = edtTrGestionTareas_ID_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trgestiontareas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public trgestiontareas( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Tr Gestion Tareas", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_TrGestionTareas.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrGestionTareas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrGestionTareas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrGestionTareas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrGestionTareas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TRGESTIONTAREAS_ID"+"'), id:'"+"TRGESTIONTAREAS_ID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_TrGestionTareas.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrGestionTareas_ID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTareas_ID_Internalname, "Gestion Tareas_ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrGestionTareas_ID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TrGestionTareas_ID), 13, 0, ".", "")), ((edtTrGestionTareas_ID_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A12TrGestionTareas_ID), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A12TrGestionTareas_ID), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTareas_ID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrGestionTareas_ID_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TrGestionTareas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrGestionTareas_IDTablero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTareas_IDTablero_Internalname, "Gestion Tareas_IDTablero", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrGestionTareas_IDTablero_Internalname, A11TrGestionTareas_IDTablero.ToString(), A11TrGestionTareas_IDTablero.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTareas_IDTablero_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrGestionTareas_IDTablero_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 1, 0, 0, true, "", "", false, "", "HLP_TrGestionTareas.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (String)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_11_Internalname, sImgUrl, imgprompt_11_Link, "", "", context.GetTheme( ), imgprompt_11_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TrGestionTareas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrGestionTareas_Nombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTareas_Nombre_Internalname, "Gestion Tareas_Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrGestionTareas_Nombre_Internalname, StringUtil.RTrim( A13TrGestionTareas_Nombre), StringUtil.RTrim( context.localUtil.Format( A13TrGestionTareas_Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTareas_Nombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrGestionTareas_Nombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TrGestionTareas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrGestionTareas_Descripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTareas_Descripcion_Internalname, "Gestion Tareas_Descripcion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTrGestionTareas_Descripcion_Internalname, A14TrGestionTareas_Descripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtTrGestionTareas_Descripcion_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_TrGestionTareas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrGestionTareas_FechaInicio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTareas_FechaInicio_Internalname, "Tareas_Fecha Inicio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrGestionTareas_FechaInicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrGestionTareas_FechaInicio_Internalname, context.localUtil.Format(A15TrGestionTareas_FechaInicio, "99/99/9999"), context.localUtil.Format( A15TrGestionTareas_FechaInicio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTareas_FechaInicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrGestionTareas_FechaInicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrGestionTareas.htm");
         GxWebStd.gx_bitmap( context, edtTrGestionTareas_FechaInicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrGestionTareas_FechaInicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrGestionTareas.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrGestionTareas_FechaFin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTareas_FechaFin_Internalname, "Tareas_Fecha Fin", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrGestionTareas_FechaFin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrGestionTareas_FechaFin_Internalname, context.localUtil.Format(A16TrGestionTareas_FechaFin, "99/99/9999"), context.localUtil.Format( A16TrGestionTareas_FechaFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTareas_FechaFin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrGestionTareas_FechaFin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrGestionTareas.htm");
         GxWebStd.gx_bitmap( context, edtTrGestionTareas_FechaFin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrGestionTareas_FechaFin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrGestionTareas.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrGestionTareas_FechaCreacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTareas_FechaCreacion_Internalname, "Tareas_Fecha Creacion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrGestionTareas_FechaCreacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrGestionTareas_FechaCreacion_Internalname, context.localUtil.Format(A17TrGestionTareas_FechaCreacion, "99/99/9999"), context.localUtil.Format( A17TrGestionTareas_FechaCreacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTareas_FechaCreacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrGestionTareas_FechaCreacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrGestionTareas.htm");
         GxWebStd.gx_bitmap( context, edtTrGestionTareas_FechaCreacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrGestionTareas_FechaCreacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrGestionTareas.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrGestionTareas_FechaModificacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTareas_FechaModificacion_Internalname, "Tareas_Fecha Modificacion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrGestionTareas_FechaModificacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrGestionTareas_FechaModificacion_Internalname, context.localUtil.Format(A18TrGestionTareas_FechaModificacion, "99/99/9999"), context.localUtil.Format( A18TrGestionTareas_FechaModificacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTareas_FechaModificacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrGestionTareas_FechaModificacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrGestionTareas.htm");
         GxWebStd.gx_bitmap( context, edtTrGestionTareas_FechaModificacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrGestionTareas_FechaModificacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrGestionTareas.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrGestionTareas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrGestionTareas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrGestionTareas.htm");
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
            Z12TrGestionTareas_ID = (long)(context.localUtil.CToN( cgiGet( "Z12TrGestionTareas_ID"), ".", ","));
            Z13TrGestionTareas_Nombre = cgiGet( "Z13TrGestionTareas_Nombre");
            n13TrGestionTareas_Nombre = (String.IsNullOrEmpty(StringUtil.RTrim( A13TrGestionTareas_Nombre)) ? true : false);
            Z15TrGestionTareas_FechaInicio = context.localUtil.CToD( cgiGet( "Z15TrGestionTareas_FechaInicio"), 0);
            n15TrGestionTareas_FechaInicio = ((DateTime.MinValue==A15TrGestionTareas_FechaInicio) ? true : false);
            Z16TrGestionTareas_FechaFin = context.localUtil.CToD( cgiGet( "Z16TrGestionTareas_FechaFin"), 0);
            n16TrGestionTareas_FechaFin = ((DateTime.MinValue==A16TrGestionTareas_FechaFin) ? true : false);
            Z17TrGestionTareas_FechaCreacion = context.localUtil.CToD( cgiGet( "Z17TrGestionTareas_FechaCreacion"), 0);
            n17TrGestionTareas_FechaCreacion = ((DateTime.MinValue==A17TrGestionTareas_FechaCreacion) ? true : false);
            Z18TrGestionTareas_FechaModificacion = context.localUtil.CToD( cgiGet( "Z18TrGestionTareas_FechaModificacion"), 0);
            n18TrGestionTareas_FechaModificacion = ((DateTime.MinValue==A18TrGestionTareas_FechaModificacion) ? true : false);
            Z11TrGestionTareas_IDTablero = (Guid)(StringUtil.StrToGuid( cgiGet( "Z11TrGestionTareas_IDTablero")));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtTrGestionTareas_ID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTrGestionTareas_ID_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRGESTIONTAREAS_ID");
               AnyError = 1;
               GX_FocusControl = edtTrGestionTareas_ID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A12TrGestionTareas_ID = 0;
               AssignAttri("", false, "A12TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(A12TrGestionTareas_ID), 13, 0));
            }
            else
            {
               A12TrGestionTareas_ID = (long)(context.localUtil.CToN( cgiGet( edtTrGestionTareas_ID_Internalname), ".", ","));
               AssignAttri("", false, "A12TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(A12TrGestionTareas_ID), 13, 0));
            }
            if ( StringUtil.StrCmp(cgiGet( edtTrGestionTareas_IDTablero_Internalname), "") == 0 )
            {
               A11TrGestionTareas_IDTablero = (Guid)(Guid.Empty);
               AssignAttri("", false, "A11TrGestionTareas_IDTablero", A11TrGestionTareas_IDTablero.ToString());
            }
            else
            {
               try
               {
                  A11TrGestionTareas_IDTablero = (Guid)(StringUtil.StrToGuid( cgiGet( edtTrGestionTareas_IDTablero_Internalname)));
                  AssignAttri("", false, "A11TrGestionTareas_IDTablero", A11TrGestionTareas_IDTablero.ToString());
               }
               catch ( Exception e )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "TRGESTIONTAREAS_IDTABLERO");
                  AnyError = 1;
                  GX_FocusControl = edtTrGestionTareas_IDTablero_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            A13TrGestionTareas_Nombre = cgiGet( edtTrGestionTareas_Nombre_Internalname);
            n13TrGestionTareas_Nombre = false;
            AssignAttri("", false, "A13TrGestionTareas_Nombre", A13TrGestionTareas_Nombre);
            n13TrGestionTareas_Nombre = (String.IsNullOrEmpty(StringUtil.RTrim( A13TrGestionTareas_Nombre)) ? true : false);
            A14TrGestionTareas_Descripcion = cgiGet( edtTrGestionTareas_Descripcion_Internalname);
            n14TrGestionTareas_Descripcion = false;
            AssignAttri("", false, "A14TrGestionTareas_Descripcion", A14TrGestionTareas_Descripcion);
            n14TrGestionTareas_Descripcion = (String.IsNullOrEmpty(StringUtil.RTrim( A14TrGestionTareas_Descripcion)) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrGestionTareas_FechaInicio_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tareas_Fecha Inicio"}), 1, "TRGESTIONTAREAS_FECHAINICIO");
               AnyError = 1;
               GX_FocusControl = edtTrGestionTareas_FechaInicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A15TrGestionTareas_FechaInicio = DateTime.MinValue;
               n15TrGestionTareas_FechaInicio = false;
               AssignAttri("", false, "A15TrGestionTareas_FechaInicio", context.localUtil.Format(A15TrGestionTareas_FechaInicio, "99/99/9999"));
            }
            else
            {
               A15TrGestionTareas_FechaInicio = context.localUtil.CToD( cgiGet( edtTrGestionTareas_FechaInicio_Internalname), 1);
               n15TrGestionTareas_FechaInicio = false;
               AssignAttri("", false, "A15TrGestionTareas_FechaInicio", context.localUtil.Format(A15TrGestionTareas_FechaInicio, "99/99/9999"));
            }
            n15TrGestionTareas_FechaInicio = ((DateTime.MinValue==A15TrGestionTareas_FechaInicio) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrGestionTareas_FechaFin_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tareas_Fecha Fin"}), 1, "TRGESTIONTAREAS_FECHAFIN");
               AnyError = 1;
               GX_FocusControl = edtTrGestionTareas_FechaFin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A16TrGestionTareas_FechaFin = DateTime.MinValue;
               n16TrGestionTareas_FechaFin = false;
               AssignAttri("", false, "A16TrGestionTareas_FechaFin", context.localUtil.Format(A16TrGestionTareas_FechaFin, "99/99/9999"));
            }
            else
            {
               A16TrGestionTareas_FechaFin = context.localUtil.CToD( cgiGet( edtTrGestionTareas_FechaFin_Internalname), 1);
               n16TrGestionTareas_FechaFin = false;
               AssignAttri("", false, "A16TrGestionTareas_FechaFin", context.localUtil.Format(A16TrGestionTareas_FechaFin, "99/99/9999"));
            }
            n16TrGestionTareas_FechaFin = ((DateTime.MinValue==A16TrGestionTareas_FechaFin) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrGestionTareas_FechaCreacion_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tareas_Fecha Creacion"}), 1, "TRGESTIONTAREAS_FECHACREACION");
               AnyError = 1;
               GX_FocusControl = edtTrGestionTareas_FechaCreacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A17TrGestionTareas_FechaCreacion = DateTime.MinValue;
               n17TrGestionTareas_FechaCreacion = false;
               AssignAttri("", false, "A17TrGestionTareas_FechaCreacion", context.localUtil.Format(A17TrGestionTareas_FechaCreacion, "99/99/9999"));
            }
            else
            {
               A17TrGestionTareas_FechaCreacion = context.localUtil.CToD( cgiGet( edtTrGestionTareas_FechaCreacion_Internalname), 1);
               n17TrGestionTareas_FechaCreacion = false;
               AssignAttri("", false, "A17TrGestionTareas_FechaCreacion", context.localUtil.Format(A17TrGestionTareas_FechaCreacion, "99/99/9999"));
            }
            n17TrGestionTareas_FechaCreacion = ((DateTime.MinValue==A17TrGestionTareas_FechaCreacion) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrGestionTareas_FechaModificacion_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tareas_Fecha Modificacion"}), 1, "TRGESTIONTAREAS_FECHAMODIFICACION");
               AnyError = 1;
               GX_FocusControl = edtTrGestionTareas_FechaModificacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A18TrGestionTareas_FechaModificacion = DateTime.MinValue;
               n18TrGestionTareas_FechaModificacion = false;
               AssignAttri("", false, "A18TrGestionTareas_FechaModificacion", context.localUtil.Format(A18TrGestionTareas_FechaModificacion, "99/99/9999"));
            }
            else
            {
               A18TrGestionTareas_FechaModificacion = context.localUtil.CToD( cgiGet( edtTrGestionTareas_FechaModificacion_Internalname), 1);
               n18TrGestionTareas_FechaModificacion = false;
               AssignAttri("", false, "A18TrGestionTareas_FechaModificacion", context.localUtil.Format(A18TrGestionTareas_FechaModificacion, "99/99/9999"));
            }
            n18TrGestionTareas_FechaModificacion = ((DateTime.MinValue==A18TrGestionTareas_FechaModificacion) ? true : false);
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
               A12TrGestionTareas_ID = (long)(NumberUtil.Val( GetNextPar( ), "."));
               AssignAttri("", false, "A12TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(A12TrGestionTareas_ID), 13, 0));
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
               InitAll022( ) ;
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
         DisableAttributes022( ) ;
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

      protected void ResetCaption020( )
      {
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z13TrGestionTareas_Nombre = T00023_A13TrGestionTareas_Nombre[0];
               Z15TrGestionTareas_FechaInicio = T00023_A15TrGestionTareas_FechaInicio[0];
               Z16TrGestionTareas_FechaFin = T00023_A16TrGestionTareas_FechaFin[0];
               Z17TrGestionTareas_FechaCreacion = T00023_A17TrGestionTareas_FechaCreacion[0];
               Z18TrGestionTareas_FechaModificacion = T00023_A18TrGestionTareas_FechaModificacion[0];
               Z11TrGestionTareas_IDTablero = (Guid)(T00023_A11TrGestionTareas_IDTablero[0]);
            }
            else
            {
               Z13TrGestionTareas_Nombre = A13TrGestionTareas_Nombre;
               Z15TrGestionTareas_FechaInicio = A15TrGestionTareas_FechaInicio;
               Z16TrGestionTareas_FechaFin = A16TrGestionTareas_FechaFin;
               Z17TrGestionTareas_FechaCreacion = A17TrGestionTareas_FechaCreacion;
               Z18TrGestionTareas_FechaModificacion = A18TrGestionTareas_FechaModificacion;
               Z11TrGestionTareas_IDTablero = (Guid)(A11TrGestionTareas_IDTablero);
            }
         }
         if ( GX_JID == -6 )
         {
            Z12TrGestionTareas_ID = A12TrGestionTareas_ID;
            Z13TrGestionTareas_Nombre = A13TrGestionTareas_Nombre;
            Z14TrGestionTareas_Descripcion = A14TrGestionTareas_Descripcion;
            Z15TrGestionTareas_FechaInicio = A15TrGestionTareas_FechaInicio;
            Z16TrGestionTareas_FechaFin = A16TrGestionTareas_FechaFin;
            Z17TrGestionTareas_FechaCreacion = A17TrGestionTareas_FechaCreacion;
            Z18TrGestionTareas_FechaModificacion = A18TrGestionTareas_FechaModificacion;
            Z11TrGestionTareas_IDTablero = (Guid)(A11TrGestionTareas_IDTablero);
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_11_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TRGESTIONTAREAS_IDTABLERO"+"'), id:'"+"TRGESTIONTAREAS_IDTABLERO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load022( )
      {
         /* Using cursor T00025 */
         pr_default.execute(3, new Object[] {A12TrGestionTareas_ID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound2 = 1;
            A13TrGestionTareas_Nombre = T00025_A13TrGestionTareas_Nombre[0];
            n13TrGestionTareas_Nombre = T00025_n13TrGestionTareas_Nombre[0];
            AssignAttri("", false, "A13TrGestionTareas_Nombre", A13TrGestionTareas_Nombre);
            A14TrGestionTareas_Descripcion = T00025_A14TrGestionTareas_Descripcion[0];
            n14TrGestionTareas_Descripcion = T00025_n14TrGestionTareas_Descripcion[0];
            AssignAttri("", false, "A14TrGestionTareas_Descripcion", A14TrGestionTareas_Descripcion);
            A15TrGestionTareas_FechaInicio = T00025_A15TrGestionTareas_FechaInicio[0];
            n15TrGestionTareas_FechaInicio = T00025_n15TrGestionTareas_FechaInicio[0];
            AssignAttri("", false, "A15TrGestionTareas_FechaInicio", context.localUtil.Format(A15TrGestionTareas_FechaInicio, "99/99/9999"));
            A16TrGestionTareas_FechaFin = T00025_A16TrGestionTareas_FechaFin[0];
            n16TrGestionTareas_FechaFin = T00025_n16TrGestionTareas_FechaFin[0];
            AssignAttri("", false, "A16TrGestionTareas_FechaFin", context.localUtil.Format(A16TrGestionTareas_FechaFin, "99/99/9999"));
            A17TrGestionTareas_FechaCreacion = T00025_A17TrGestionTareas_FechaCreacion[0];
            n17TrGestionTareas_FechaCreacion = T00025_n17TrGestionTareas_FechaCreacion[0];
            AssignAttri("", false, "A17TrGestionTareas_FechaCreacion", context.localUtil.Format(A17TrGestionTareas_FechaCreacion, "99/99/9999"));
            A18TrGestionTareas_FechaModificacion = T00025_A18TrGestionTareas_FechaModificacion[0];
            n18TrGestionTareas_FechaModificacion = T00025_n18TrGestionTareas_FechaModificacion[0];
            AssignAttri("", false, "A18TrGestionTareas_FechaModificacion", context.localUtil.Format(A18TrGestionTareas_FechaModificacion, "99/99/9999"));
            A11TrGestionTareas_IDTablero = (Guid)((Guid)(T00025_A11TrGestionTareas_IDTablero[0]));
            AssignAttri("", false, "A11TrGestionTareas_IDTablero", A11TrGestionTareas_IDTablero.ToString());
            ZM022( -6) ;
         }
         pr_default.close(3);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {A11TrGestionTareas_IDTablero});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Tr Gestion Tableros_STG'.", "ForeignKeyNotFound", 1, "TRGESTIONTAREAS_IDTABLERO");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTareas_IDTablero_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A15TrGestionTareas_FechaInicio) || ( A15TrGestionTareas_FechaInicio >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Tr Gestion Tareas_Fecha Inicio is out of range", "OutOfRange", 1, "TRGESTIONTAREAS_FECHAINICIO");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTareas_FechaInicio_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A16TrGestionTareas_FechaFin) || ( A16TrGestionTareas_FechaFin >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Tr Gestion Tareas_Fecha Fin is out of range", "OutOfRange", 1, "TRGESTIONTAREAS_FECHAFIN");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTareas_FechaFin_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A17TrGestionTareas_FechaCreacion) || ( A17TrGestionTareas_FechaCreacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Tr Gestion Tareas_Fecha Creacion is out of range", "OutOfRange", 1, "TRGESTIONTAREAS_FECHACREACION");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTareas_FechaCreacion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A18TrGestionTareas_FechaModificacion) || ( A18TrGestionTareas_FechaModificacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Tr Gestion Tareas_Fecha Modificacion is out of range", "OutOfRange", 1, "TRGESTIONTAREAS_FECHAMODIFICACION");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTareas_FechaModificacion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_7( Guid A11TrGestionTareas_IDTablero )
      {
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {A11TrGestionTareas_IDTablero});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Tr Gestion Tableros_STG'.", "ForeignKeyNotFound", 1, "TRGESTIONTAREAS_IDTABLERO");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTareas_IDTablero_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void GetKey022( )
      {
         /* Using cursor T00027 */
         pr_default.execute(5, new Object[] {A12TrGestionTareas_ID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A12TrGestionTareas_ID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 6) ;
            RcdFound2 = 1;
            A12TrGestionTareas_ID = T00023_A12TrGestionTareas_ID[0];
            AssignAttri("", false, "A12TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(A12TrGestionTareas_ID), 13, 0));
            A13TrGestionTareas_Nombre = T00023_A13TrGestionTareas_Nombre[0];
            n13TrGestionTareas_Nombre = T00023_n13TrGestionTareas_Nombre[0];
            AssignAttri("", false, "A13TrGestionTareas_Nombre", A13TrGestionTareas_Nombre);
            A14TrGestionTareas_Descripcion = T00023_A14TrGestionTareas_Descripcion[0];
            n14TrGestionTareas_Descripcion = T00023_n14TrGestionTareas_Descripcion[0];
            AssignAttri("", false, "A14TrGestionTareas_Descripcion", A14TrGestionTareas_Descripcion);
            A15TrGestionTareas_FechaInicio = T00023_A15TrGestionTareas_FechaInicio[0];
            n15TrGestionTareas_FechaInicio = T00023_n15TrGestionTareas_FechaInicio[0];
            AssignAttri("", false, "A15TrGestionTareas_FechaInicio", context.localUtil.Format(A15TrGestionTareas_FechaInicio, "99/99/9999"));
            A16TrGestionTareas_FechaFin = T00023_A16TrGestionTareas_FechaFin[0];
            n16TrGestionTareas_FechaFin = T00023_n16TrGestionTareas_FechaFin[0];
            AssignAttri("", false, "A16TrGestionTareas_FechaFin", context.localUtil.Format(A16TrGestionTareas_FechaFin, "99/99/9999"));
            A17TrGestionTareas_FechaCreacion = T00023_A17TrGestionTareas_FechaCreacion[0];
            n17TrGestionTareas_FechaCreacion = T00023_n17TrGestionTareas_FechaCreacion[0];
            AssignAttri("", false, "A17TrGestionTareas_FechaCreacion", context.localUtil.Format(A17TrGestionTareas_FechaCreacion, "99/99/9999"));
            A18TrGestionTareas_FechaModificacion = T00023_A18TrGestionTareas_FechaModificacion[0];
            n18TrGestionTareas_FechaModificacion = T00023_n18TrGestionTareas_FechaModificacion[0];
            AssignAttri("", false, "A18TrGestionTareas_FechaModificacion", context.localUtil.Format(A18TrGestionTareas_FechaModificacion, "99/99/9999"));
            A11TrGestionTareas_IDTablero = (Guid)((Guid)(T00023_A11TrGestionTareas_IDTablero[0]));
            AssignAttri("", false, "A11TrGestionTareas_IDTablero", A11TrGestionTareas_IDTablero.ToString());
            Z12TrGestionTareas_ID = A12TrGestionTareas_ID;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
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
         RcdFound2 = 0;
         /* Using cursor T00028 */
         pr_default.execute(6, new Object[] {A12TrGestionTareas_ID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00028_A12TrGestionTareas_ID[0] < A12TrGestionTareas_ID ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00028_A12TrGestionTareas_ID[0] > A12TrGestionTareas_ID ) ) )
            {
               A12TrGestionTareas_ID = T00028_A12TrGestionTareas_ID[0];
               AssignAttri("", false, "A12TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(A12TrGestionTareas_ID), 13, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T00029 */
         pr_default.execute(7, new Object[] {A12TrGestionTareas_ID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00029_A12TrGestionTareas_ID[0] > A12TrGestionTareas_ID ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00029_A12TrGestionTareas_ID[0] < A12TrGestionTareas_ID ) ) )
            {
               A12TrGestionTareas_ID = T00029_A12TrGestionTareas_ID[0];
               AssignAttri("", false, "A12TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(A12TrGestionTareas_ID), 13, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTrGestionTareas_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert022( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A12TrGestionTareas_ID != Z12TrGestionTareas_ID )
               {
                  A12TrGestionTareas_ID = Z12TrGestionTareas_ID;
                  AssignAttri("", false, "A12TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(A12TrGestionTareas_ID), 13, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRGESTIONTAREAS_ID");
                  AnyError = 1;
                  GX_FocusControl = edtTrGestionTareas_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTrGestionTareas_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update022( ) ;
                  GX_FocusControl = edtTrGestionTareas_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A12TrGestionTareas_ID != Z12TrGestionTareas_ID )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTrGestionTareas_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert022( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRGESTIONTAREAS_ID");
                     AnyError = 1;
                     GX_FocusControl = edtTrGestionTareas_ID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTrGestionTareas_ID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert022( ) ;
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
         if ( A12TrGestionTareas_ID != Z12TrGestionTareas_ID )
         {
            A12TrGestionTareas_ID = Z12TrGestionTareas_ID;
            AssignAttri("", false, "A12TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(A12TrGestionTareas_ID), 13, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRGESTIONTAREAS_ID");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTareas_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTrGestionTareas_ID_Internalname;
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
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TRGESTIONTAREAS_ID");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTareas_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTrGestionTareas_IDTablero_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrGestionTareas_IDTablero_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd022( ) ;
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
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrGestionTareas_IDTablero_Internalname;
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
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrGestionTareas_IDTablero_Internalname;
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
         ScanStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound2 != 0 )
            {
               ScanNext022( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrGestionTareas_IDTablero_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd022( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A12TrGestionTareas_ID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrGestionTareas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z13TrGestionTareas_Nombre, T00022_A13TrGestionTareas_Nombre[0]) != 0 ) || ( Z15TrGestionTareas_FechaInicio != T00022_A15TrGestionTareas_FechaInicio[0] ) || ( Z16TrGestionTareas_FechaFin != T00022_A16TrGestionTareas_FechaFin[0] ) || ( Z17TrGestionTareas_FechaCreacion != T00022_A17TrGestionTareas_FechaCreacion[0] ) || ( Z18TrGestionTareas_FechaModificacion != T00022_A18TrGestionTareas_FechaModificacion[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z11TrGestionTareas_IDTablero != T00022_A11TrGestionTareas_IDTablero[0] ) )
            {
               if ( StringUtil.StrCmp(Z13TrGestionTareas_Nombre, T00022_A13TrGestionTareas_Nombre[0]) != 0 )
               {
                  GXUtil.WriteLog("trgestiontareas:[seudo value changed for attri]"+"TrGestionTareas_Nombre");
                  GXUtil.WriteLogRaw("Old: ",Z13TrGestionTareas_Nombre);
                  GXUtil.WriteLogRaw("Current: ",T00022_A13TrGestionTareas_Nombre[0]);
               }
               if ( Z15TrGestionTareas_FechaInicio != T00022_A15TrGestionTareas_FechaInicio[0] )
               {
                  GXUtil.WriteLog("trgestiontareas:[seudo value changed for attri]"+"TrGestionTareas_FechaInicio");
                  GXUtil.WriteLogRaw("Old: ",Z15TrGestionTareas_FechaInicio);
                  GXUtil.WriteLogRaw("Current: ",T00022_A15TrGestionTareas_FechaInicio[0]);
               }
               if ( Z16TrGestionTareas_FechaFin != T00022_A16TrGestionTareas_FechaFin[0] )
               {
                  GXUtil.WriteLog("trgestiontareas:[seudo value changed for attri]"+"TrGestionTareas_FechaFin");
                  GXUtil.WriteLogRaw("Old: ",Z16TrGestionTareas_FechaFin);
                  GXUtil.WriteLogRaw("Current: ",T00022_A16TrGestionTareas_FechaFin[0]);
               }
               if ( Z17TrGestionTareas_FechaCreacion != T00022_A17TrGestionTareas_FechaCreacion[0] )
               {
                  GXUtil.WriteLog("trgestiontareas:[seudo value changed for attri]"+"TrGestionTareas_FechaCreacion");
                  GXUtil.WriteLogRaw("Old: ",Z17TrGestionTareas_FechaCreacion);
                  GXUtil.WriteLogRaw("Current: ",T00022_A17TrGestionTareas_FechaCreacion[0]);
               }
               if ( Z18TrGestionTareas_FechaModificacion != T00022_A18TrGestionTareas_FechaModificacion[0] )
               {
                  GXUtil.WriteLog("trgestiontareas:[seudo value changed for attri]"+"TrGestionTareas_FechaModificacion");
                  GXUtil.WriteLogRaw("Old: ",Z18TrGestionTareas_FechaModificacion);
                  GXUtil.WriteLogRaw("Current: ",T00022_A18TrGestionTareas_FechaModificacion[0]);
               }
               if ( Z11TrGestionTareas_IDTablero != T00022_A11TrGestionTareas_IDTablero[0] )
               {
                  GXUtil.WriteLog("trgestiontareas:[seudo value changed for attri]"+"TrGestionTareas_IDTablero");
                  GXUtil.WriteLogRaw("Old: ",Z11TrGestionTareas_IDTablero);
                  GXUtil.WriteLogRaw("Current: ",T00022_A11TrGestionTareas_IDTablero[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TrGestionTareas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000210 */
                     pr_default.execute(8, new Object[] {n13TrGestionTareas_Nombre, A13TrGestionTareas_Nombre, n14TrGestionTareas_Descripcion, A14TrGestionTareas_Descripcion, n15TrGestionTareas_FechaInicio, A15TrGestionTareas_FechaInicio, n16TrGestionTareas_FechaFin, A16TrGestionTareas_FechaFin, n17TrGestionTareas_FechaCreacion, A17TrGestionTareas_FechaCreacion, n18TrGestionTareas_FechaModificacion, A18TrGestionTareas_FechaModificacion, A11TrGestionTareas_IDTablero});
                     A12TrGestionTareas_ID = T000210_A12TrGestionTareas_ID[0];
                     AssignAttri("", false, "A12TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(A12TrGestionTareas_ID), 13, 0));
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("TrGestionTareas") ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           GX_msglist.addItem(context.GetMessage( "GXM_sucadded", ""), "SuccessfullyAdded", 0, "", true);
                           ResetCaption020( ) ;
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000211 */
                     pr_default.execute(9, new Object[] {n13TrGestionTareas_Nombre, A13TrGestionTareas_Nombre, n14TrGestionTareas_Descripcion, A14TrGestionTareas_Descripcion, n15TrGestionTareas_FechaInicio, A15TrGestionTareas_FechaInicio, n16TrGestionTareas_FechaFin, A16TrGestionTareas_FechaFin, n17TrGestionTareas_FechaCreacion, A17TrGestionTareas_FechaCreacion, n18TrGestionTareas_FechaModificacion, A18TrGestionTareas_FechaModificacion, A11TrGestionTareas_IDTablero, A12TrGestionTareas_ID});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("TrGestionTareas") ;
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrGestionTareas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           GX_msglist.addItem(context.GetMessage( "GXM_sucupdated", ""), "SuccessfullyUpdated", 0, "", true);
                           ResetCaption020( ) ;
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000212 */
                  pr_default.execute(10, new Object[] {A12TrGestionTareas_ID});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("TrGestionTareas") ;
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound2 == 0 )
                        {
                           InitAll022( ) ;
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
                        ResetCaption020( ) ;
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("trgestiontareas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("trgestiontareas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart022( )
      {
         /* Using cursor T000213 */
         pr_default.execute(11);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound2 = 1;
            A12TrGestionTareas_ID = T000213_A12TrGestionTareas_ID[0];
            AssignAttri("", false, "A12TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(A12TrGestionTareas_ID), 13, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound2 = 1;
            A12TrGestionTareas_ID = T000213_A12TrGestionTareas_ID[0];
            AssignAttri("", false, "A12TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(A12TrGestionTareas_ID), 13, 0));
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
         edtTrGestionTareas_ID_Enabled = 0;
         AssignProp("", false, edtTrGestionTareas_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_ID_Enabled), 5, 0), true);
         edtTrGestionTareas_IDTablero_Enabled = 0;
         AssignProp("", false, edtTrGestionTareas_IDTablero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_IDTablero_Enabled), 5, 0), true);
         edtTrGestionTareas_Nombre_Enabled = 0;
         AssignProp("", false, edtTrGestionTareas_Nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_Nombre_Enabled), 5, 0), true);
         edtTrGestionTareas_Descripcion_Enabled = 0;
         AssignProp("", false, edtTrGestionTareas_Descripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_Descripcion_Enabled), 5, 0), true);
         edtTrGestionTareas_FechaInicio_Enabled = 0;
         AssignProp("", false, edtTrGestionTareas_FechaInicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_FechaInicio_Enabled), 5, 0), true);
         edtTrGestionTareas_FechaFin_Enabled = 0;
         AssignProp("", false, edtTrGestionTareas_FechaFin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_FechaFin_Enabled), 5, 0), true);
         edtTrGestionTareas_FechaCreacion_Enabled = 0;
         AssignProp("", false, edtTrGestionTareas_FechaCreacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_FechaCreacion_Enabled), 5, 0), true);
         edtTrGestionTareas_FechaModificacion_Enabled = 0;
         AssignProp("", false, edtTrGestionTareas_FechaModificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_FechaModificacion_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues020( )
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
         context.AddJavascriptSource("gxcfg.js", "?202292722394032", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trgestiontareas.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z12TrGestionTareas_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12TrGestionTareas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z13TrGestionTareas_Nombre", StringUtil.RTrim( Z13TrGestionTareas_Nombre));
         GxWebStd.gx_hidden_field( context, "Z15TrGestionTareas_FechaInicio", context.localUtil.DToC( Z15TrGestionTareas_FechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z16TrGestionTareas_FechaFin", context.localUtil.DToC( Z16TrGestionTareas_FechaFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z17TrGestionTareas_FechaCreacion", context.localUtil.DToC( Z17TrGestionTareas_FechaCreacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z18TrGestionTareas_FechaModificacion", context.localUtil.DToC( Z18TrGestionTareas_FechaModificacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z11TrGestionTareas_IDTablero", Z11TrGestionTareas_IDTablero.ToString());
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
         return formatLink("trgestiontareas.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "TrGestionTareas" ;
      }

      public override String GetPgmdesc( )
      {
         return "Tr Gestion Tareas" ;
      }

      protected void InitializeNonKey022( )
      {
         A11TrGestionTareas_IDTablero = (Guid)(Guid.Empty);
         AssignAttri("", false, "A11TrGestionTareas_IDTablero", A11TrGestionTareas_IDTablero.ToString());
         A13TrGestionTareas_Nombre = "";
         n13TrGestionTareas_Nombre = false;
         AssignAttri("", false, "A13TrGestionTareas_Nombre", A13TrGestionTareas_Nombre);
         n13TrGestionTareas_Nombre = (String.IsNullOrEmpty(StringUtil.RTrim( A13TrGestionTareas_Nombre)) ? true : false);
         A14TrGestionTareas_Descripcion = "";
         n14TrGestionTareas_Descripcion = false;
         AssignAttri("", false, "A14TrGestionTareas_Descripcion", A14TrGestionTareas_Descripcion);
         n14TrGestionTareas_Descripcion = (String.IsNullOrEmpty(StringUtil.RTrim( A14TrGestionTareas_Descripcion)) ? true : false);
         A15TrGestionTareas_FechaInicio = DateTime.MinValue;
         n15TrGestionTareas_FechaInicio = false;
         AssignAttri("", false, "A15TrGestionTareas_FechaInicio", context.localUtil.Format(A15TrGestionTareas_FechaInicio, "99/99/9999"));
         n15TrGestionTareas_FechaInicio = ((DateTime.MinValue==A15TrGestionTareas_FechaInicio) ? true : false);
         A16TrGestionTareas_FechaFin = DateTime.MinValue;
         n16TrGestionTareas_FechaFin = false;
         AssignAttri("", false, "A16TrGestionTareas_FechaFin", context.localUtil.Format(A16TrGestionTareas_FechaFin, "99/99/9999"));
         n16TrGestionTareas_FechaFin = ((DateTime.MinValue==A16TrGestionTareas_FechaFin) ? true : false);
         A17TrGestionTareas_FechaCreacion = DateTime.MinValue;
         n17TrGestionTareas_FechaCreacion = false;
         AssignAttri("", false, "A17TrGestionTareas_FechaCreacion", context.localUtil.Format(A17TrGestionTareas_FechaCreacion, "99/99/9999"));
         n17TrGestionTareas_FechaCreacion = ((DateTime.MinValue==A17TrGestionTareas_FechaCreacion) ? true : false);
         A18TrGestionTareas_FechaModificacion = DateTime.MinValue;
         n18TrGestionTareas_FechaModificacion = false;
         AssignAttri("", false, "A18TrGestionTareas_FechaModificacion", context.localUtil.Format(A18TrGestionTareas_FechaModificacion, "99/99/9999"));
         n18TrGestionTareas_FechaModificacion = ((DateTime.MinValue==A18TrGestionTareas_FechaModificacion) ? true : false);
         Z13TrGestionTareas_Nombre = "";
         Z15TrGestionTareas_FechaInicio = DateTime.MinValue;
         Z16TrGestionTareas_FechaFin = DateTime.MinValue;
         Z17TrGestionTareas_FechaCreacion = DateTime.MinValue;
         Z18TrGestionTareas_FechaModificacion = DateTime.MinValue;
         Z11TrGestionTareas_IDTablero = (Guid)(Guid.Empty);
      }

      protected void InitAll022( )
      {
         A12TrGestionTareas_ID = 0;
         AssignAttri("", false, "A12TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(A12TrGestionTareas_ID), 13, 0));
         InitializeNonKey022( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202292722394035", true, true);
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
         context.AddJavascriptSource("trgestiontareas.js", "?202292722394036", false, true);
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
         edtTrGestionTareas_ID_Internalname = "TRGESTIONTAREAS_ID";
         edtTrGestionTareas_IDTablero_Internalname = "TRGESTIONTAREAS_IDTABLERO";
         edtTrGestionTareas_Nombre_Internalname = "TRGESTIONTAREAS_NOMBRE";
         edtTrGestionTareas_Descripcion_Internalname = "TRGESTIONTAREAS_DESCRIPCION";
         edtTrGestionTareas_FechaInicio_Internalname = "TRGESTIONTAREAS_FECHAINICIO";
         edtTrGestionTareas_FechaFin_Internalname = "TRGESTIONTAREAS_FECHAFIN";
         edtTrGestionTareas_FechaCreacion_Internalname = "TRGESTIONTAREAS_FECHACREACION";
         edtTrGestionTareas_FechaModificacion_Internalname = "TRGESTIONTAREAS_FECHAMODIFICACION";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_11_Internalname = "PROMPT_11";
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
         Form.Caption = "Tr Gestion Tareas";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTrGestionTareas_FechaModificacion_Jsonclick = "";
         edtTrGestionTareas_FechaModificacion_Enabled = 1;
         edtTrGestionTareas_FechaCreacion_Jsonclick = "";
         edtTrGestionTareas_FechaCreacion_Enabled = 1;
         edtTrGestionTareas_FechaFin_Jsonclick = "";
         edtTrGestionTareas_FechaFin_Enabled = 1;
         edtTrGestionTareas_FechaInicio_Jsonclick = "";
         edtTrGestionTareas_FechaInicio_Enabled = 1;
         edtTrGestionTareas_Descripcion_Enabled = 1;
         edtTrGestionTareas_Nombre_Jsonclick = "";
         edtTrGestionTareas_Nombre_Enabled = 1;
         imgprompt_11_Visible = 1;
         imgprompt_11_Link = "";
         edtTrGestionTareas_IDTablero_Jsonclick = "";
         edtTrGestionTareas_IDTablero_Enabled = 1;
         edtTrGestionTareas_ID_Jsonclick = "";
         edtTrGestionTareas_ID_Enabled = 1;
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
         GX_FocusControl = edtTrGestionTareas_IDTablero_Internalname;
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

      public void Valid_Trgestiontareas_id( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A11TrGestionTareas_IDTablero", A11TrGestionTareas_IDTablero.ToString());
         AssignAttri("", false, "A13TrGestionTareas_Nombre", StringUtil.RTrim( A13TrGestionTareas_Nombre));
         AssignAttri("", false, "A14TrGestionTareas_Descripcion", A14TrGestionTareas_Descripcion);
         AssignAttri("", false, "A15TrGestionTareas_FechaInicio", context.localUtil.Format(A15TrGestionTareas_FechaInicio, "99/99/9999"));
         AssignAttri("", false, "A16TrGestionTareas_FechaFin", context.localUtil.Format(A16TrGestionTareas_FechaFin, "99/99/9999"));
         AssignAttri("", false, "A17TrGestionTareas_FechaCreacion", context.localUtil.Format(A17TrGestionTareas_FechaCreacion, "99/99/9999"));
         AssignAttri("", false, "A18TrGestionTareas_FechaModificacion", context.localUtil.Format(A18TrGestionTareas_FechaModificacion, "99/99/9999"));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z12TrGestionTareas_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12TrGestionTareas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z11TrGestionTareas_IDTablero", Z11TrGestionTareas_IDTablero.ToString());
         GxWebStd.gx_hidden_field( context, "Z13TrGestionTareas_Nombre", StringUtil.RTrim( Z13TrGestionTareas_Nombre));
         GxWebStd.gx_hidden_field( context, "Z14TrGestionTareas_Descripcion", Z14TrGestionTareas_Descripcion);
         GxWebStd.gx_hidden_field( context, "Z15TrGestionTareas_FechaInicio", context.localUtil.Format(Z15TrGestionTareas_FechaInicio, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z16TrGestionTareas_FechaFin", context.localUtil.Format(Z16TrGestionTareas_FechaFin, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z17TrGestionTareas_FechaCreacion", context.localUtil.Format(Z17TrGestionTareas_FechaCreacion, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z18TrGestionTareas_FechaModificacion", context.localUtil.Format(Z18TrGestionTareas_FechaModificacion, "99/99/9999"));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Trgestiontareas_idtablero( )
      {
         /* Using cursor T000214 */
         pr_default.execute(12, new Object[] {A11TrGestionTareas_IDTablero});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No matching 'Tr Gestion Tableros_STG'.", "ForeignKeyNotFound", 1, "TRGESTIONTAREAS_IDTABLERO");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTareas_IDTablero_Internalname;
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
         setEventMetadata("VALID_TRGESTIONTAREAS_ID","{handler:'Valid_Trgestiontareas_id',iparms:[{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TRGESTIONTAREAS_ID",",oparms:[{av:'A11TrGestionTareas_IDTablero',fld:'TRGESTIONTAREAS_IDTABLERO',pic:''},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A17TrGestionTareas_FechaCreacion',fld:'TRGESTIONTAREAS_FECHACREACION',pic:''},{av:'A18TrGestionTareas_FechaModificacion',fld:'TRGESTIONTAREAS_FECHAMODIFICACION',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z12TrGestionTareas_ID'},{av:'Z11TrGestionTareas_IDTablero'},{av:'Z13TrGestionTareas_Nombre'},{av:'Z14TrGestionTareas_Descripcion'},{av:'Z15TrGestionTareas_FechaInicio'},{av:'Z16TrGestionTareas_FechaFin'},{av:'Z17TrGestionTareas_FechaCreacion'},{av:'Z18TrGestionTareas_FechaModificacion'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_TRGESTIONTAREAS_IDTABLERO","{handler:'Valid_Trgestiontareas_idtablero',iparms:[{av:'A11TrGestionTareas_IDTablero',fld:'TRGESTIONTAREAS_IDTABLERO',pic:''}]");
         setEventMetadata("VALID_TRGESTIONTAREAS_IDTABLERO",",oparms:[]}");
         setEventMetadata("VALID_TRGESTIONTAREAS_FECHAINICIO","{handler:'Valid_Trgestiontareas_fechainicio',iparms:[]");
         setEventMetadata("VALID_TRGESTIONTAREAS_FECHAINICIO",",oparms:[]}");
         setEventMetadata("VALID_TRGESTIONTAREAS_FECHAFIN","{handler:'Valid_Trgestiontareas_fechafin',iparms:[]");
         setEventMetadata("VALID_TRGESTIONTAREAS_FECHAFIN",",oparms:[]}");
         setEventMetadata("VALID_TRGESTIONTAREAS_FECHACREACION","{handler:'Valid_Trgestiontareas_fechacreacion',iparms:[]");
         setEventMetadata("VALID_TRGESTIONTAREAS_FECHACREACION",",oparms:[]}");
         setEventMetadata("VALID_TRGESTIONTAREAS_FECHAMODIFICACION","{handler:'Valid_Trgestiontareas_fechamodificacion',iparms:[]");
         setEventMetadata("VALID_TRGESTIONTAREAS_FECHAMODIFICACION",",oparms:[]}");
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
         Z13TrGestionTareas_Nombre = "";
         Z15TrGestionTareas_FechaInicio = DateTime.MinValue;
         Z16TrGestionTareas_FechaFin = DateTime.MinValue;
         Z17TrGestionTareas_FechaCreacion = DateTime.MinValue;
         Z18TrGestionTareas_FechaModificacion = DateTime.MinValue;
         Z11TrGestionTareas_IDTablero = (Guid)(Guid.Empty);
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A11TrGestionTareas_IDTablero = (Guid)(Guid.Empty);
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
         sImgUrl = "";
         A13TrGestionTareas_Nombre = "";
         A14TrGestionTareas_Descripcion = "";
         A15TrGestionTareas_FechaInicio = DateTime.MinValue;
         A16TrGestionTareas_FechaFin = DateTime.MinValue;
         A17TrGestionTareas_FechaCreacion = DateTime.MinValue;
         A18TrGestionTareas_FechaModificacion = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         Z14TrGestionTareas_Descripcion = "";
         T00025_A12TrGestionTareas_ID = new long[1] ;
         T00025_A13TrGestionTareas_Nombre = new String[] {""} ;
         T00025_n13TrGestionTareas_Nombre = new bool[] {false} ;
         T00025_A14TrGestionTareas_Descripcion = new String[] {""} ;
         T00025_n14TrGestionTareas_Descripcion = new bool[] {false} ;
         T00025_A15TrGestionTareas_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         T00025_n15TrGestionTareas_FechaInicio = new bool[] {false} ;
         T00025_A16TrGestionTareas_FechaFin = new DateTime[] {DateTime.MinValue} ;
         T00025_n16TrGestionTareas_FechaFin = new bool[] {false} ;
         T00025_A17TrGestionTareas_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00025_n17TrGestionTareas_FechaCreacion = new bool[] {false} ;
         T00025_A18TrGestionTareas_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00025_n18TrGestionTareas_FechaModificacion = new bool[] {false} ;
         T00025_A11TrGestionTareas_IDTablero = new Guid[] {Guid.Empty} ;
         T00024_A11TrGestionTareas_IDTablero = new Guid[] {Guid.Empty} ;
         T00026_A11TrGestionTareas_IDTablero = new Guid[] {Guid.Empty} ;
         T00027_A12TrGestionTareas_ID = new long[1] ;
         T00023_A12TrGestionTareas_ID = new long[1] ;
         T00023_A13TrGestionTareas_Nombre = new String[] {""} ;
         T00023_n13TrGestionTareas_Nombre = new bool[] {false} ;
         T00023_A14TrGestionTareas_Descripcion = new String[] {""} ;
         T00023_n14TrGestionTareas_Descripcion = new bool[] {false} ;
         T00023_A15TrGestionTareas_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         T00023_n15TrGestionTareas_FechaInicio = new bool[] {false} ;
         T00023_A16TrGestionTareas_FechaFin = new DateTime[] {DateTime.MinValue} ;
         T00023_n16TrGestionTareas_FechaFin = new bool[] {false} ;
         T00023_A17TrGestionTareas_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00023_n17TrGestionTareas_FechaCreacion = new bool[] {false} ;
         T00023_A18TrGestionTareas_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00023_n18TrGestionTareas_FechaModificacion = new bool[] {false} ;
         T00023_A11TrGestionTareas_IDTablero = new Guid[] {Guid.Empty} ;
         sMode2 = "";
         T00028_A12TrGestionTareas_ID = new long[1] ;
         T00029_A12TrGestionTareas_ID = new long[1] ;
         T00022_A12TrGestionTareas_ID = new long[1] ;
         T00022_A13TrGestionTareas_Nombre = new String[] {""} ;
         T00022_n13TrGestionTareas_Nombre = new bool[] {false} ;
         T00022_A14TrGestionTareas_Descripcion = new String[] {""} ;
         T00022_n14TrGestionTareas_Descripcion = new bool[] {false} ;
         T00022_A15TrGestionTareas_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         T00022_n15TrGestionTareas_FechaInicio = new bool[] {false} ;
         T00022_A16TrGestionTareas_FechaFin = new DateTime[] {DateTime.MinValue} ;
         T00022_n16TrGestionTareas_FechaFin = new bool[] {false} ;
         T00022_A17TrGestionTareas_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00022_n17TrGestionTareas_FechaCreacion = new bool[] {false} ;
         T00022_A18TrGestionTareas_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00022_n18TrGestionTareas_FechaModificacion = new bool[] {false} ;
         T00022_A11TrGestionTareas_IDTablero = new Guid[] {Guid.Empty} ;
         T000210_A12TrGestionTareas_ID = new long[1] ;
         T000213_A12TrGestionTareas_ID = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ11TrGestionTareas_IDTablero = (Guid)(Guid.Empty);
         ZZ13TrGestionTareas_Nombre = "";
         ZZ14TrGestionTareas_Descripcion = "";
         ZZ15TrGestionTareas_FechaInicio = DateTime.MinValue;
         ZZ16TrGestionTareas_FechaFin = DateTime.MinValue;
         ZZ17TrGestionTareas_FechaCreacion = DateTime.MinValue;
         ZZ18TrGestionTareas_FechaModificacion = DateTime.MinValue;
         T000214_A11TrGestionTareas_IDTablero = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trgestiontareas__default(),
            new Object[][] {
                new Object[] {
               T00022_A12TrGestionTareas_ID, T00022_A13TrGestionTareas_Nombre, T00022_n13TrGestionTareas_Nombre, T00022_A14TrGestionTareas_Descripcion, T00022_n14TrGestionTareas_Descripcion, T00022_A15TrGestionTareas_FechaInicio, T00022_n15TrGestionTareas_FechaInicio, T00022_A16TrGestionTareas_FechaFin, T00022_n16TrGestionTareas_FechaFin, T00022_A17TrGestionTareas_FechaCreacion,
               T00022_n17TrGestionTareas_FechaCreacion, T00022_A18TrGestionTareas_FechaModificacion, T00022_n18TrGestionTareas_FechaModificacion, T00022_A11TrGestionTareas_IDTablero
               }
               , new Object[] {
               T00023_A12TrGestionTareas_ID, T00023_A13TrGestionTareas_Nombre, T00023_n13TrGestionTareas_Nombre, T00023_A14TrGestionTareas_Descripcion, T00023_n14TrGestionTareas_Descripcion, T00023_A15TrGestionTareas_FechaInicio, T00023_n15TrGestionTareas_FechaInicio, T00023_A16TrGestionTareas_FechaFin, T00023_n16TrGestionTareas_FechaFin, T00023_A17TrGestionTareas_FechaCreacion,
               T00023_n17TrGestionTareas_FechaCreacion, T00023_A18TrGestionTareas_FechaModificacion, T00023_n18TrGestionTareas_FechaModificacion, T00023_A11TrGestionTareas_IDTablero
               }
               , new Object[] {
               T00024_A11TrGestionTareas_IDTablero
               }
               , new Object[] {
               T00025_A12TrGestionTareas_ID, T00025_A13TrGestionTareas_Nombre, T00025_n13TrGestionTareas_Nombre, T00025_A14TrGestionTareas_Descripcion, T00025_n14TrGestionTareas_Descripcion, T00025_A15TrGestionTareas_FechaInicio, T00025_n15TrGestionTareas_FechaInicio, T00025_A16TrGestionTareas_FechaFin, T00025_n16TrGestionTareas_FechaFin, T00025_A17TrGestionTareas_FechaCreacion,
               T00025_n17TrGestionTareas_FechaCreacion, T00025_A18TrGestionTareas_FechaModificacion, T00025_n18TrGestionTareas_FechaModificacion, T00025_A11TrGestionTareas_IDTablero
               }
               , new Object[] {
               T00026_A11TrGestionTareas_IDTablero
               }
               , new Object[] {
               T00027_A12TrGestionTareas_ID
               }
               , new Object[] {
               T00028_A12TrGestionTareas_ID
               }
               , new Object[] {
               T00029_A12TrGestionTareas_ID
               }
               , new Object[] {
               T000210_A12TrGestionTareas_ID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000213_A12TrGestionTareas_ID
               }
               , new Object[] {
               T000214_A11TrGestionTareas_IDTablero
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
      private short RcdFound2 ;
      private short nIsDirty_2 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTrGestionTareas_ID_Enabled ;
      private int edtTrGestionTareas_IDTablero_Enabled ;
      private int imgprompt_11_Visible ;
      private int edtTrGestionTareas_Nombre_Enabled ;
      private int edtTrGestionTareas_Descripcion_Enabled ;
      private int edtTrGestionTareas_FechaInicio_Enabled ;
      private int edtTrGestionTareas_FechaFin_Enabled ;
      private int edtTrGestionTareas_FechaCreacion_Enabled ;
      private int edtTrGestionTareas_FechaModificacion_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z12TrGestionTareas_ID ;
      private long A12TrGestionTareas_ID ;
      private long ZZ12TrGestionTareas_ID ;
      private String sPrefix ;
      private String Z13TrGestionTareas_Nombre ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String GXKey ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtTrGestionTareas_ID_Internalname ;
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
      private String edtTrGestionTareas_ID_Jsonclick ;
      private String edtTrGestionTareas_IDTablero_Internalname ;
      private String edtTrGestionTareas_IDTablero_Jsonclick ;
      private String sImgUrl ;
      private String imgprompt_11_Internalname ;
      private String imgprompt_11_Link ;
      private String edtTrGestionTareas_Nombre_Internalname ;
      private String A13TrGestionTareas_Nombre ;
      private String edtTrGestionTareas_Nombre_Jsonclick ;
      private String edtTrGestionTareas_Descripcion_Internalname ;
      private String edtTrGestionTareas_FechaInicio_Internalname ;
      private String edtTrGestionTareas_FechaInicio_Jsonclick ;
      private String edtTrGestionTareas_FechaFin_Internalname ;
      private String edtTrGestionTareas_FechaFin_Jsonclick ;
      private String edtTrGestionTareas_FechaCreacion_Internalname ;
      private String edtTrGestionTareas_FechaCreacion_Jsonclick ;
      private String edtTrGestionTareas_FechaModificacion_Internalname ;
      private String edtTrGestionTareas_FechaModificacion_Jsonclick ;
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
      private String sMode2 ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String ZZ13TrGestionTareas_Nombre ;
      private DateTime Z15TrGestionTareas_FechaInicio ;
      private DateTime Z16TrGestionTareas_FechaFin ;
      private DateTime Z17TrGestionTareas_FechaCreacion ;
      private DateTime Z18TrGestionTareas_FechaModificacion ;
      private DateTime A15TrGestionTareas_FechaInicio ;
      private DateTime A16TrGestionTareas_FechaFin ;
      private DateTime A17TrGestionTareas_FechaCreacion ;
      private DateTime A18TrGestionTareas_FechaModificacion ;
      private DateTime ZZ15TrGestionTareas_FechaInicio ;
      private DateTime ZZ16TrGestionTareas_FechaFin ;
      private DateTime ZZ17TrGestionTareas_FechaCreacion ;
      private DateTime ZZ18TrGestionTareas_FechaModificacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n13TrGestionTareas_Nombre ;
      private bool n15TrGestionTareas_FechaInicio ;
      private bool n16TrGestionTareas_FechaFin ;
      private bool n17TrGestionTareas_FechaCreacion ;
      private bool n18TrGestionTareas_FechaModificacion ;
      private bool n14TrGestionTareas_Descripcion ;
      private bool Gx_longc ;
      private String A14TrGestionTareas_Descripcion ;
      private String Z14TrGestionTareas_Descripcion ;
      private String ZZ14TrGestionTareas_Descripcion ;
      private Guid Z11TrGestionTareas_IDTablero ;
      private Guid A11TrGestionTareas_IDTablero ;
      private Guid ZZ11TrGestionTareas_IDTablero ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] T00025_A12TrGestionTareas_ID ;
      private String[] T00025_A13TrGestionTareas_Nombre ;
      private bool[] T00025_n13TrGestionTareas_Nombre ;
      private String[] T00025_A14TrGestionTareas_Descripcion ;
      private bool[] T00025_n14TrGestionTareas_Descripcion ;
      private DateTime[] T00025_A15TrGestionTareas_FechaInicio ;
      private bool[] T00025_n15TrGestionTareas_FechaInicio ;
      private DateTime[] T00025_A16TrGestionTareas_FechaFin ;
      private bool[] T00025_n16TrGestionTareas_FechaFin ;
      private DateTime[] T00025_A17TrGestionTareas_FechaCreacion ;
      private bool[] T00025_n17TrGestionTareas_FechaCreacion ;
      private DateTime[] T00025_A18TrGestionTareas_FechaModificacion ;
      private bool[] T00025_n18TrGestionTareas_FechaModificacion ;
      private Guid[] T00025_A11TrGestionTareas_IDTablero ;
      private Guid[] T00024_A11TrGestionTareas_IDTablero ;
      private Guid[] T00026_A11TrGestionTareas_IDTablero ;
      private long[] T00027_A12TrGestionTareas_ID ;
      private long[] T00023_A12TrGestionTareas_ID ;
      private String[] T00023_A13TrGestionTareas_Nombre ;
      private bool[] T00023_n13TrGestionTareas_Nombre ;
      private String[] T00023_A14TrGestionTareas_Descripcion ;
      private bool[] T00023_n14TrGestionTareas_Descripcion ;
      private DateTime[] T00023_A15TrGestionTareas_FechaInicio ;
      private bool[] T00023_n15TrGestionTareas_FechaInicio ;
      private DateTime[] T00023_A16TrGestionTareas_FechaFin ;
      private bool[] T00023_n16TrGestionTareas_FechaFin ;
      private DateTime[] T00023_A17TrGestionTareas_FechaCreacion ;
      private bool[] T00023_n17TrGestionTareas_FechaCreacion ;
      private DateTime[] T00023_A18TrGestionTareas_FechaModificacion ;
      private bool[] T00023_n18TrGestionTareas_FechaModificacion ;
      private Guid[] T00023_A11TrGestionTareas_IDTablero ;
      private long[] T00028_A12TrGestionTareas_ID ;
      private long[] T00029_A12TrGestionTareas_ID ;
      private long[] T00022_A12TrGestionTareas_ID ;
      private String[] T00022_A13TrGestionTareas_Nombre ;
      private bool[] T00022_n13TrGestionTareas_Nombre ;
      private String[] T00022_A14TrGestionTareas_Descripcion ;
      private bool[] T00022_n14TrGestionTareas_Descripcion ;
      private DateTime[] T00022_A15TrGestionTareas_FechaInicio ;
      private bool[] T00022_n15TrGestionTareas_FechaInicio ;
      private DateTime[] T00022_A16TrGestionTareas_FechaFin ;
      private bool[] T00022_n16TrGestionTareas_FechaFin ;
      private DateTime[] T00022_A17TrGestionTareas_FechaCreacion ;
      private bool[] T00022_n17TrGestionTareas_FechaCreacion ;
      private DateTime[] T00022_A18TrGestionTareas_FechaModificacion ;
      private bool[] T00022_n18TrGestionTareas_FechaModificacion ;
      private Guid[] T00022_A11TrGestionTareas_IDTablero ;
      private long[] T000210_A12TrGestionTareas_ID ;
      private long[] T000213_A12TrGestionTareas_ID ;
      private Guid[] T000214_A11TrGestionTareas_IDTablero ;
      private GXWebForm Form ;
   }

   public class trgestiontareas__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00025 ;
          prmT00025 = new Object[] {
          new Object[] {"@TrGestionTareas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00024 ;
          prmT00024 = new Object[] {
          new Object[] {"@TrGestionTareas_IDTablero",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT00026 ;
          prmT00026 = new Object[] {
          new Object[] {"@TrGestionTareas_IDTablero",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT00027 ;
          prmT00027 = new Object[] {
          new Object[] {"@TrGestionTareas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00023 ;
          prmT00023 = new Object[] {
          new Object[] {"@TrGestionTareas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00028 ;
          prmT00028 = new Object[] {
          new Object[] {"@TrGestionTareas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00029 ;
          prmT00029 = new Object[] {
          new Object[] {"@TrGestionTareas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00022 ;
          prmT00022 = new Object[] {
          new Object[] {"@TrGestionTareas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000210 ;
          prmT000210 = new Object[] {
          new Object[] {"@TrGestionTareas_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@TrGestionTareas_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTareas_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTareas_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTareas_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTareas_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTareas_IDTablero",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT000211 ;
          prmT000211 = new Object[] {
          new Object[] {"@TrGestionTareas_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@TrGestionTareas_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTareas_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTareas_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTareas_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTareas_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTareas_IDTablero",SqlDbType.UniqueIdentifier,4,0} ,
          new Object[] {"@TrGestionTareas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000212 ;
          prmT000212 = new Object[] {
          new Object[] {"@TrGestionTareas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000213 ;
          prmT000213 = new Object[] {
          } ;
          Object[] prmT000214 ;
          prmT000214 = new Object[] {
          new Object[] {"@TrGestionTareas_IDTablero",SqlDbType.UniqueIdentifier,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T00022", "SELECT [TrGestionTareas_ID], [TrGestionTareas_Nombre], [TrGestionTareas_Descripcion], [TrGestionTareas_FechaInicio], [TrGestionTareas_FechaFin], [TrGestionTareas_FechaCreacion], [TrGestionTareas_FechaModificacion], [TrGestionTareas_IDTablero] AS TrGestionTareas_IDTablero FROM TABLERO.[TrGestionTareas] WITH (UPDLOCK) WHERE [TrGestionTareas_ID] = @TrGestionTareas_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00023", "SELECT [TrGestionTareas_ID], [TrGestionTareas_Nombre], [TrGestionTareas_Descripcion], [TrGestionTareas_FechaInicio], [TrGestionTareas_FechaFin], [TrGestionTareas_FechaCreacion], [TrGestionTareas_FechaModificacion], [TrGestionTareas_IDTablero] AS TrGestionTareas_IDTablero FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_ID] = @TrGestionTareas_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00024", "SELECT [TrGestionTableros_ID] AS TrGestionTareas_IDTablero FROM TABLERO.[TrGestionTableros] WHERE [TrGestionTableros_ID] = @TrGestionTareas_IDTablero ",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00025", "SELECT TM1.[TrGestionTareas_ID], TM1.[TrGestionTareas_Nombre], TM1.[TrGestionTareas_Descripcion], TM1.[TrGestionTareas_FechaInicio], TM1.[TrGestionTareas_FechaFin], TM1.[TrGestionTareas_FechaCreacion], TM1.[TrGestionTareas_FechaModificacion], TM1.[TrGestionTareas_IDTablero] AS TrGestionTareas_IDTablero FROM TABLERO.[TrGestionTareas] TM1 WHERE TM1.[TrGestionTareas_ID] = @TrGestionTareas_ID ORDER BY TM1.[TrGestionTareas_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00026", "SELECT [TrGestionTableros_ID] AS TrGestionTareas_IDTablero FROM TABLERO.[TrGestionTableros] WHERE [TrGestionTableros_ID] = @TrGestionTareas_IDTablero ",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00027", "SELECT [TrGestionTareas_ID] FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_ID] = @TrGestionTareas_ID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00028", "SELECT TOP 1 [TrGestionTareas_ID] FROM TABLERO.[TrGestionTareas] WHERE ( [TrGestionTareas_ID] > @TrGestionTareas_ID) ORDER BY [TrGestionTareas_ID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00029", "SELECT TOP 1 [TrGestionTareas_ID] FROM TABLERO.[TrGestionTareas] WHERE ( [TrGestionTareas_ID] < @TrGestionTareas_ID) ORDER BY [TrGestionTareas_ID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000210", "INSERT INTO TABLERO.[TrGestionTareas]([TrGestionTareas_Nombre], [TrGestionTareas_Descripcion], [TrGestionTareas_FechaInicio], [TrGestionTareas_FechaFin], [TrGestionTareas_FechaCreacion], [TrGestionTareas_FechaModificacion], [TrGestionTareas_IDTablero]) VALUES(@TrGestionTareas_Nombre, @TrGestionTareas_Descripcion, @TrGestionTareas_FechaInicio, @TrGestionTareas_FechaFin, @TrGestionTareas_FechaCreacion, @TrGestionTareas_FechaModificacion, @TrGestionTareas_IDTablero); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000210)
             ,new CursorDef("T000211", "UPDATE TABLERO.[TrGestionTareas] SET [TrGestionTareas_Nombre]=@TrGestionTareas_Nombre, [TrGestionTareas_Descripcion]=@TrGestionTareas_Descripcion, [TrGestionTareas_FechaInicio]=@TrGestionTareas_FechaInicio, [TrGestionTareas_FechaFin]=@TrGestionTareas_FechaFin, [TrGestionTareas_FechaCreacion]=@TrGestionTareas_FechaCreacion, [TrGestionTareas_FechaModificacion]=@TrGestionTareas_FechaModificacion, [TrGestionTareas_IDTablero]=@TrGestionTareas_IDTablero  WHERE [TrGestionTareas_ID] = @TrGestionTareas_ID", GxErrorMask.GX_NOMASK,prmT000211)
             ,new CursorDef("T000212", "DELETE FROM TABLERO.[TrGestionTareas]  WHERE [TrGestionTareas_ID] = @TrGestionTareas_ID", GxErrorMask.GX_NOMASK,prmT000212)
             ,new CursorDef("T000213", "SELECT [TrGestionTareas_ID] FROM TABLERO.[TrGestionTareas] ORDER BY [TrGestionTareas_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000213,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000214", "SELECT [TrGestionTableros_ID] AS TrGestionTareas_IDTablero FROM TABLERO.[TrGestionTableros] WHERE [TrGestionTableros_ID] = @TrGestionTareas_IDTablero ",true, GxErrorMask.GX_NOMASK, false, this,prmT000214,1, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[13])[0] = rslt.getGuid(8) ;
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
                ((Guid[]) buf[13])[0] = rslt.getGuid(8) ;
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
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
                ((Guid[]) buf[13])[0] = rslt.getGuid(8) ;
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
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
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 1 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 2 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 3 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 4 :
                stmt.SetParameter(1, (Guid)parms[0]);
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
                stmt.SetParameter(7, (Guid)parms[12]);
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
                stmt.SetParameter(7, (Guid)parms[12]);
                stmt.SetParameter(8, (long)parms[13]);
                return;
             case 10 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 12 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
       }
    }

 }

}
