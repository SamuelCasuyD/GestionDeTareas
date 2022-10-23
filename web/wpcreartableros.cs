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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wpcreartableros : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpcreartableros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public wpcreartableros( IGxContext context )
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

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
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
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("masterpage", "GeneXus.Programs.masterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
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

      public override short ExecuteStartEvent( )
      {
         PA1U2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1U2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 947160), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202210211744754", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle = bodyStyle + " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpcreartableros.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_FECHACREACION", GetSecureSignedToken( "", AV23TrGestionTableros_FechaCreacion, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_ESTADO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22TrGestionTableros_Estado), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_boolean_hidden_field( context, "vCONFIRMATIONREQUIRED", AV26ConfirmationRequired);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCREARTABLERO_SDT", AV21CrearTablero_SDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCREARTABLERO_SDT", AV21CrearTablero_SDT);
         }
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTABLEROS_FECHACREACION", context.localUtil.DToC( AV23TrGestionTableros_FechaCreacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_FECHACREACION", GetSecureSignedToken( "", AV23TrGestionTableros_FechaCreacion, context));
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTABLEROS_ESTADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22TrGestionTableros_Estado), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_ESTADO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22TrGestionTableros_Estado), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCONFIRMATIONSUBID", StringUtil.RTrim( AV27ConfirmationSubId));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((String)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE1U2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1U2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("wpcreartableros.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "WpCrearTableros" ;
      }

      public override String GetPgmdesc( )
      {
         return "Gestión del tablero" ;
      }

      protected void WB1U0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TitleContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection2_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "h1");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Nuevo tablero", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, "HLP_WpCrearTableros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "h1");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divContenttable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_WebPanelDesignerContent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpGroup_Internalname, "Ingrese los datos solicitados", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_WpCrearTableros.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_group_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-1", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_attributes_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_attributes_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TabularContentContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_Internalname, "Nombre de tablero : ", "", "", lblTextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpCrearTableros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontableros_nombre_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontableros_nombre_Internalname, StringUtil.RTrim( AV12TrGestionTableros_Nombre), StringUtil.RTrim( context.localUtil.Format( AV12TrGestionTableros_Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontableros_nombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTrgestiontableros_nombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WpCrearTableros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Descripción : ", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpCrearTableros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontableros_descripcion_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = "";
            ClassString = "Attribute_Trn";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavTrgestiontableros_descripcion_Internalname, AV13TrGestionTableros_Descripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", 0, 1, edtavTrgestiontableros_descripcion_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WpCrearTableros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Comentario : ", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpCrearTableros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontableros_comentario_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = "";
            ClassString = "Attribute_Trn";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavTrgestiontableros_comentario_Internalname, AV14TrGestionTableros_Comentario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", 0, 1, edtavTrgestiontableros_comentario_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WpCrearTableros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Tipo de tablero : ", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpCrearTableros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontableros_tipotablero_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontableros_tipotablero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15TrGestionTableros_TipoTablero), 4, 0, ".", "")), ((edtavTrgestiontableros_tipotablero_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV15TrGestionTableros_TipoTablero), "ZZZ9")) : context.localUtil.Format( (decimal)(AV15TrGestionTableros_TipoTablero), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontableros_tipotablero_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTrgestiontableros_tipotablero_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpCrearTableros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Fecha de inicio : ", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpCrearTableros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontableros_fechainicio_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTrgestiontableros_fechainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontableros_fechainicio_Internalname, context.localUtil.Format(AV16TrGestionTableros_FechaInicio, "99/99/9999"), context.localUtil.Format( AV16TrGestionTableros_FechaInicio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontableros_fechainicio_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTrgestiontableros_fechainicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpCrearTableros.htm");
            GxWebStd.gx_bitmap( context, edtavTrgestiontableros_fechainicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrgestiontableros_fechainicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpCrearTableros.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Fecha de fin : ", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpCrearTableros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontableros_fechafin_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTrgestiontableros_fechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontableros_fechafin_Internalname, context.localUtil.Format(AV17TrGestionTableros_FechaFin, "99/99/9999"), context.localUtil.Format( AV17TrGestionTableros_FechaFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontableros_fechafin_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTrgestiontableros_fechafin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpCrearTableros.htm");
            GxWebStd.gx_bitmap( context, edtavTrgestiontableros_fechafin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrgestiontableros_fechafin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpCrearTableros.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_containernode_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_80_1U2( true) ;
         }
         else
         {
            wb_table1_80_1U2( false) ;
         }
         return  ;
      }

      protected void wb_table1_80_1U2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table2_86_1U2( true) ;
         }
         else
         {
            wb_table2_86_1U2( false) ;
         }
         return  ;
      }

      protected void wb_table2_86_1U2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, "K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START1U2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 16_0_10-142546", 0) ;
            }
            Form.Meta.addItem("description", "Gestión del tablero", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1U0( ) ;
      }

      protected void WS1U2( )
      {
         START1U2( ) ;
         EVT1U2( ) ;
      }

      protected void EVT1U2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E111U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E121U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_CREARTABLERO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_CrearTablero' */
                              E131U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CONFIRMYES'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'ConfirmYes' */
                              E141U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E151U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
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
      }

      protected void WE1U2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA1U2( )
      {
         if ( nDonePA == 0 )
         {
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavTrgestiontableros_nombre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavConfirmmessage_Enabled = 0;
         AssignProp("", false, edtavConfirmmessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConfirmmessage_Enabled), 5, 0), true);
      }

      protected void RF1U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E121U2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E151U2 ();
            WB1U0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes1U2( )
      {
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTABLEROS_FECHACREACION", context.localUtil.DToC( AV23TrGestionTableros_FechaCreacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_FECHACREACION", GetSecureSignedToken( "", AV23TrGestionTableros_FechaCreacion, context));
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTABLEROS_ESTADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22TrGestionTableros_Estado), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_ESTADO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22TrGestionTableros_Estado), "ZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavConfirmmessage_Enabled = 0;
         AssignProp("", false, edtavConfirmmessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConfirmmessage_Enabled), 5, 0), true);
      }

      protected void STRUP1U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E111U2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            AV27ConfirmationSubId = cgiGet( "vCONFIRMATIONSUBID");
            /* Read variables values. */
            AV12TrGestionTableros_Nombre = cgiGet( edtavTrgestiontableros_nombre_Internalname);
            AssignAttri("", false, "AV12TrGestionTableros_Nombre", AV12TrGestionTableros_Nombre);
            AV13TrGestionTableros_Descripcion = cgiGet( edtavTrgestiontableros_descripcion_Internalname);
            AssignAttri("", false, "AV13TrGestionTableros_Descripcion", AV13TrGestionTableros_Descripcion);
            AV14TrGestionTableros_Comentario = cgiGet( edtavTrgestiontableros_comentario_Internalname);
            AssignAttri("", false, "AV14TrGestionTableros_Comentario", AV14TrGestionTableros_Comentario);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTrgestiontableros_tipotablero_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTrgestiontableros_tipotablero_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTRGESTIONTABLEROS_TIPOTABLERO");
               GX_FocusControl = edtavTrgestiontableros_tipotablero_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15TrGestionTableros_TipoTablero = 0;
               AssignAttri("", false, "AV15TrGestionTableros_TipoTablero", StringUtil.LTrimStr( (decimal)(AV15TrGestionTableros_TipoTablero), 4, 0));
            }
            else
            {
               AV15TrGestionTableros_TipoTablero = (short)(context.localUtil.CToN( cgiGet( edtavTrgestiontableros_tipotablero_Internalname), ".", ","));
               AssignAttri("", false, "AV15TrGestionTableros_TipoTablero", StringUtil.LTrimStr( (decimal)(AV15TrGestionTableros_TipoTablero), 4, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTrgestiontableros_fechainicio_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Inicio"}), 1, "vTRGESTIONTABLEROS_FECHAINICIO");
               GX_FocusControl = edtavTrgestiontableros_fechainicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16TrGestionTableros_FechaInicio = DateTime.MinValue;
               AssignAttri("", false, "AV16TrGestionTableros_FechaInicio", context.localUtil.Format(AV16TrGestionTableros_FechaInicio, "99/99/9999"));
            }
            else
            {
               AV16TrGestionTableros_FechaInicio = context.localUtil.CToD( cgiGet( edtavTrgestiontableros_fechainicio_Internalname), 2);
               AssignAttri("", false, "AV16TrGestionTableros_FechaInicio", context.localUtil.Format(AV16TrGestionTableros_FechaInicio, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTrgestiontableros_fechafin_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Fin"}), 1, "vTRGESTIONTABLEROS_FECHAFIN");
               GX_FocusControl = edtavTrgestiontableros_fechafin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17TrGestionTableros_FechaFin = DateTime.MinValue;
               AssignAttri("", false, "AV17TrGestionTableros_FechaFin", context.localUtil.Format(AV17TrGestionTableros_FechaFin, "99/99/9999"));
            }
            else
            {
               AV17TrGestionTableros_FechaFin = context.localUtil.CToD( cgiGet( edtavTrgestiontableros_fechafin_Internalname), 2);
               AssignAttri("", false, "AV17TrGestionTableros_FechaFin", context.localUtil.Format(AV17TrGestionTableros_FechaFin, "99/99/9999"));
            }
            AV25ConfirmMessage = cgiGet( edtavConfirmmessage_Internalname);
            AssignAttri("", false, "AV25ConfirmMessage", AV25ConfirmMessage);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void S122( )
      {
         /* 'U_STARTPAGE' Routine */
      }

      protected void S132( )
      {
         /* 'U_REFRESHPAGE' Routine */
      }

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E111U2 ();
         if (returnInSub) return;
      }

      protected void E111U2( )
      {
         /* Start Routine */
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         tblTableconditionalconfirm_Visible = 0;
         AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
      }

      protected void E121U2( )
      {
         /* Refresh Routine */
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         AV26ConfirmationRequired = false;
         AssignAttri("", false, "AV26ConfirmationRequired", AV26ConfirmationRequired);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E131U2( )
      {
         /* 'E_CrearTablero' Routine */
         AV25ConfirmMessage = "¿Está seguro?";
         AssignAttri("", false, "AV25ConfirmMessage", AV25ConfirmMessage);
         /* Execute user subroutine: 'U_CONFIRMATIONREQUIRED(CREARTABLERO)' */
         S142 ();
         if (returnInSub) return;
         if ( AV26ConfirmationRequired )
         {
            AV27ConfirmationSubId = "'U_CrearTablero'";
            AssignAttri("", false, "AV27ConfirmationSubId", AV27ConfirmationSubId);
            tblTableconditionalconfirm_Visible = 1;
            AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
         }
         else
         {
            /* Execute user subroutine: 'U_CREARTABLERO' */
            S152 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21CrearTablero_SDT", AV21CrearTablero_SDT);
      }

      protected void S152( )
      {
         /* 'U_CREARTABLERO' Routine */
         AV21CrearTablero_SDT.gxTpr_Trgestiontableros_nombre = AV12TrGestionTableros_Nombre;
         AV21CrearTablero_SDT.gxTpr_Trgestiontableros_descripcion = AV13TrGestionTableros_Descripcion;
         AV21CrearTablero_SDT.gxTpr_Trgestiontableros_comentario = AV14TrGestionTableros_Comentario;
         AV21CrearTablero_SDT.gxTpr_Trgestiontableros_tipotablero = AV15TrGestionTableros_TipoTablero;
         AV21CrearTablero_SDT.gxTpr_Trgestiontableros_fechainicio = AV16TrGestionTableros_FechaInicio;
         AV21CrearTablero_SDT.gxTpr_Trgestiontableros_fechafin = AV17TrGestionTableros_FechaFin;
         AV21CrearTablero_SDT.gxTpr_Trgestiontableros_fechacreacion = AV23TrGestionTableros_FechaCreacion;
         AV21CrearTablero_SDT.gxTpr_Trgestiontableros_estado = AV22TrGestionTableros_Estado;
         new tpcreartablero(context ).execute(  AV21CrearTablero_SDT,  "INS") ;
         context.DoAjaxRefresh();
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E141U2( )
      {
         /* 'ConfirmYes' Routine */
         tblTableconditionalconfirm_Visible = 0;
         AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV27ConfirmationSubId, "'U_CrearTablero'") == 0 )
         {
            /* Execute user subroutine: 'U_CREARTABLERO' */
            S152 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21CrearTablero_SDT", AV21CrearTablero_SDT);
      }

      protected void S142( )
      {
         /* 'U_CONFIRMATIONREQUIRED(CREARTABLERO)' Routine */
         AV26ConfirmationRequired = true;
         AssignAttri("", false, "AV26ConfirmationRequired", AV26ConfirmationRequired);
      }

      protected void nextLoad( )
      {
      }

      protected void E151U2( )
      {
         /* Load Routine */
      }

      protected void wb_table2_86_1U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTableconditionalconfirm_Visible == 0 )
            {
               sStyleString = sStyleString + "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTableconditionalconfirm_Internalname, tblTableconditionalconfirm_Internalname, "", "Table_ConditionalConfirm", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table3_89_1U2( true) ;
         }
         else
         {
            wb_table3_89_1U2( false) ;
         }
         return  ;
      }

      protected void wb_table3_89_1U2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_86_1U2e( true) ;
         }
         else
         {
            wb_table2_86_1U2e( false) ;
         }
      }

      protected void wb_table3_89_1U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblSection_condconf_dialog_Internalname, tblSection_condconf_dialog_Internalname, "", "Section_CondConf_Dialog", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table4_92_1U2( true) ;
         }
         else
         {
            wb_table4_92_1U2( false) ;
         }
         return  ;
      }

      protected void wb_table4_92_1U2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_89_1U2e( true) ;
         }
         else
         {
            wb_table3_89_1U2e( false) ;
         }
      }

      protected void wb_table4_92_1U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblSection_condconf_dialog_inner_Internalname, tblSection_condconf_dialog_inner_Internalname, "", "Section_CondConf_DialogInner", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConfirmmessage_Internalname, "Confirm Message", "gx-form-item Attribute_ConditionalConfirmLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfirmmessage_Internalname, StringUtil.RTrim( AV25ConfirmMessage), StringUtil.RTrim( context.localUtil.Format( AV25ConfirmMessage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfirmmessage_Jsonclick, 0, "Attribute_ConditionalConfirm", "", "", "", "", 1, edtavConfirmmessage_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WpCrearTableros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table5_99_1U2( true) ;
         }
         else
         {
            wb_table5_99_1U2( false) ;
         }
         return  ;
      }

      protected void wb_table5_99_1U2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_92_1U2e( true) ;
         }
         else
         {
            wb_table4_92_1U2e( false) ;
         }
      }

      protected void wb_table5_99_1U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblConfirm_hidden_actionstable_Internalname, tblConfirm_hidden_actionstable_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction_Confirm";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttI_buttonconfirmyes_Internalname, "", "Aceptar", bttI_buttonconfirmyes_Jsonclick, 5, "Aceptar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CONFIRMYES\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpCrearTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttI_buttonconfirmno_Internalname, "", "Cancelar", bttI_buttonconfirmno_Jsonclick, 7, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e161u1_client"+"'", TempTags, "", 2, "HLP_WpCrearTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_99_1U2e( true) ;
         }
         else
         {
            wb_table5_99_1U2e( false) ;
         }
      }

      protected void wb_table1_80_1U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableleft_actions_Internalname, tblActionscontainertableleft_actions_Internalname, "", "K2BToolsTableActionsLeftContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCreartablero_Internalname, "", "Crear Tablero", bttCreartablero_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_CREARTABLERO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpCrearTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_80_1U2e( true) ;
         }
         else
         {
            wb_table1_80_1U2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override String getresponse( String sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA1U2( ) ;
         WS1U2( ) ;
         WE1U2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( String sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("K2BControlBeautify/montrezorro-bootstrap-checkbox/css/bootstrap-checkbox.css", "");
         AddStyleSheetFile("K2BControlBeautify/silviomoreto-bootstrap-select/dist/css/bootstrap-select.css", "");
         AddStyleSheetFile("K2BControlBeautify/toastr-master/toastr.min.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210211744817", true, true);
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
         context.AddJavascriptSource("wpcreartableros.js", "?202210211744818", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divSection2_Internalname = "SECTION2";
         divTable1_Internalname = "TABLE1";
         lblTextblock_Internalname = "TEXTBLOCK";
         edtavTrgestiontableros_nombre_Internalname = "vTRGESTIONTABLEROS_NOMBRE";
         divTable_container_trgestiontableros_nombre_Internalname = "TABLE_CONTAINER_TRGESTIONTABLEROS_NOMBRE";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtavTrgestiontableros_descripcion_Internalname = "vTRGESTIONTABLEROS_DESCRIPCION";
         divTable_container_trgestiontableros_descripcion_Internalname = "TABLE_CONTAINER_TRGESTIONTABLEROS_DESCRIPCION";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtavTrgestiontableros_comentario_Internalname = "vTRGESTIONTABLEROS_COMENTARIO";
         divTable_container_trgestiontableros_comentario_Internalname = "TABLE_CONTAINER_TRGESTIONTABLEROS_COMENTARIO";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtavTrgestiontableros_tipotablero_Internalname = "vTRGESTIONTABLEROS_TIPOTABLERO";
         divTable_container_trgestiontableros_tipotablero_Internalname = "TABLE_CONTAINER_TRGESTIONTABLEROS_TIPOTABLERO";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtavTrgestiontableros_fechainicio_Internalname = "vTRGESTIONTABLEROS_FECHAINICIO";
         divTable_container_trgestiontableros_fechainicio_Internalname = "TABLE_CONTAINER_TRGESTIONTABLEROS_FECHAINICIO";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtavTrgestiontableros_fechafin_Internalname = "vTRGESTIONTABLEROS_FECHAFIN";
         divTable_container_trgestiontableros_fechafin_Internalname = "TABLE_CONTAINER_TRGESTIONTABLEROS_FECHAFIN";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divResponsivetable_mainattributes_attributes_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES";
         divMaingroupresponsivetable_group_Internalname = "MAINGROUPRESPONSIVETABLE_GROUP";
         grpGroup_Internalname = "GROUP";
         bttCreartablero_Internalname = "CREARTABLERO";
         tblActionscontainertableleft_actions_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divContenttable_Internalname = "CONTENTTABLE";
         edtavConfirmmessage_Internalname = "vCONFIRMMESSAGE";
         bttI_buttonconfirmyes_Internalname = "I_BUTTONCONFIRMYES";
         bttI_buttonconfirmno_Internalname = "I_BUTTONCONFIRMNO";
         tblConfirm_hidden_actionstable_Internalname = "CONFIRM_HIDDEN_ACTIONSTABLE";
         tblSection_condconf_dialog_inner_Internalname = "SECTION_CONDCONF_DIALOG_INNER";
         tblSection_condconf_dialog_Internalname = "SECTION_CONDCONF_DIALOG";
         tblTableconditionalconfirm_Internalname = "TABLECONDITIONALCONFIRM";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavConfirmmessage_Jsonclick = "";
         edtavConfirmmessage_Enabled = 1;
         tblTableconditionalconfirm_Visible = 1;
         edtavTrgestiontableros_fechafin_Jsonclick = "";
         edtavTrgestiontableros_fechafin_Enabled = 1;
         edtavTrgestiontableros_fechainicio_Jsonclick = "";
         edtavTrgestiontableros_fechainicio_Enabled = 1;
         edtavTrgestiontableros_tipotablero_Jsonclick = "";
         edtavTrgestiontableros_tipotablero_Enabled = 1;
         edtavTrgestiontableros_comentario_Enabled = 1;
         edtavTrgestiontableros_descripcion_Enabled = 1;
         edtavTrgestiontableros_nombre_Jsonclick = "";
         edtavTrgestiontableros_nombre_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Gestión del tablero";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV23TrGestionTableros_FechaCreacion',fld:'vTRGESTIONTABLEROS_FECHACREACION',pic:'',hsh:true},{av:'AV22TrGestionTableros_Estado',fld:'vTRGESTIONTABLEROS_ESTADO',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV26ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''}]}");
         setEventMetadata("'E_CREARTABLERO'","{handler:'E131U2',iparms:[{av:'AV26ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV12TrGestionTableros_Nombre',fld:'vTRGESTIONTABLEROS_NOMBRE',pic:''},{av:'AV21CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''},{av:'AV13TrGestionTableros_Descripcion',fld:'vTRGESTIONTABLEROS_DESCRIPCION',pic:''},{av:'AV14TrGestionTableros_Comentario',fld:'vTRGESTIONTABLEROS_COMENTARIO',pic:''},{av:'AV15TrGestionTableros_TipoTablero',fld:'vTRGESTIONTABLEROS_TIPOTABLERO',pic:'ZZZ9'},{av:'AV16TrGestionTableros_FechaInicio',fld:'vTRGESTIONTABLEROS_FECHAINICIO',pic:''},{av:'AV17TrGestionTableros_FechaFin',fld:'vTRGESTIONTABLEROS_FECHAFIN',pic:''},{av:'AV23TrGestionTableros_FechaCreacion',fld:'vTRGESTIONTABLEROS_FECHACREACION',pic:'',hsh:true},{av:'AV22TrGestionTableros_Estado',fld:'vTRGESTIONTABLEROS_ESTADO',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'E_CREARTABLERO'",",oparms:[{av:'AV25ConfirmMessage',fld:'vCONFIRMMESSAGE',pic:''},{av:'AV27ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'},{av:'AV26ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV21CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''}]}");
         setEventMetadata("'CONFIRMNO'","{handler:'E161U1',iparms:[]");
         setEventMetadata("'CONFIRMNO'",",oparms:[{av:'AV27ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'}]}");
         setEventMetadata("'CONFIRMYES'","{handler:'E141U2',iparms:[{av:'AV27ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'AV12TrGestionTableros_Nombre',fld:'vTRGESTIONTABLEROS_NOMBRE',pic:''},{av:'AV21CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''},{av:'AV13TrGestionTableros_Descripcion',fld:'vTRGESTIONTABLEROS_DESCRIPCION',pic:''},{av:'AV14TrGestionTableros_Comentario',fld:'vTRGESTIONTABLEROS_COMENTARIO',pic:''},{av:'AV15TrGestionTableros_TipoTablero',fld:'vTRGESTIONTABLEROS_TIPOTABLERO',pic:'ZZZ9'},{av:'AV16TrGestionTableros_FechaInicio',fld:'vTRGESTIONTABLEROS_FECHAINICIO',pic:''},{av:'AV17TrGestionTableros_FechaFin',fld:'vTRGESTIONTABLEROS_FECHAFIN',pic:''},{av:'AV23TrGestionTableros_FechaCreacion',fld:'vTRGESTIONTABLEROS_FECHACREACION',pic:'',hsh:true},{av:'AV22TrGestionTableros_Estado',fld:'vTRGESTIONTABLEROS_ESTADO',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'CONFIRMYES'",",oparms:[{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'},{av:'AV21CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''}]}");
         setEventMetadata("VALIDV_TRGESTIONTABLEROS_FECHAINICIO","{handler:'Validv_Trgestiontableros_fechainicio',iparms:[]");
         setEventMetadata("VALIDV_TRGESTIONTABLEROS_FECHAINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_TRGESTIONTABLEROS_FECHAFIN","{handler:'Validv_Trgestiontableros_fechafin',iparms:[]");
         setEventMetadata("VALIDV_TRGESTIONTABLEROS_FECHAFIN",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV23TrGestionTableros_FechaCreacion = DateTime.MinValue;
         GXKey = "";
         AV21CrearTablero_SDT = new SdtCrearTablero_SDT(context);
         AV27ConfirmationSubId = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblTextblock_Jsonclick = "";
         TempTags = "";
         AV12TrGestionTableros_Nombre = "";
         lblTextblock1_Jsonclick = "";
         AV13TrGestionTableros_Descripcion = "";
         lblTextblock2_Jsonclick = "";
         AV14TrGestionTableros_Comentario = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         AV16TrGestionTableros_FechaInicio = DateTime.MinValue;
         lblTextblock5_Jsonclick = "";
         AV17TrGestionTableros_FechaFin = DateTime.MinValue;
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV25ConfirmMessage = "";
         sStyleString = "";
         bttI_buttonconfirmyes_Jsonclick = "";
         bttI_buttonconfirmno_Jsonclick = "";
         bttCreartablero_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavConfirmmessage_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV22TrGestionTableros_Estado ;
      private short wbEnd ;
      private short wbStart ;
      private short AV15TrGestionTableros_TipoTablero ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavTrgestiontableros_nombre_Enabled ;
      private int edtavTrgestiontableros_descripcion_Enabled ;
      private int edtavTrgestiontableros_comentario_Enabled ;
      private int edtavTrgestiontableros_tipotablero_Enabled ;
      private int edtavTrgestiontableros_fechainicio_Enabled ;
      private int edtavTrgestiontableros_fechafin_Enabled ;
      private int edtavConfirmmessage_Enabled ;
      private int tblTableconditionalconfirm_Visible ;
      private int idxLst ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String AV27ConfirmationSubId ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divTable1_Internalname ;
      private String divSection2_Internalname ;
      private String lblTitle_Internalname ;
      private String lblTitle_Jsonclick ;
      private String ClassString ;
      private String StyleString ;
      private String divContenttable_Internalname ;
      private String grpGroup_Internalname ;
      private String divMaingroupresponsivetable_group_Internalname ;
      private String divResponsivetable_mainattributes_attributes_Internalname ;
      private String divAttributescontainertable_attributes_Internalname ;
      private String lblTextblock_Internalname ;
      private String lblTextblock_Jsonclick ;
      private String divTable_container_trgestiontableros_nombre_Internalname ;
      private String TempTags ;
      private String edtavTrgestiontableros_nombre_Internalname ;
      private String AV12TrGestionTableros_Nombre ;
      private String edtavTrgestiontableros_nombre_Jsonclick ;
      private String lblTextblock1_Internalname ;
      private String lblTextblock1_Jsonclick ;
      private String divTable_container_trgestiontableros_descripcion_Internalname ;
      private String edtavTrgestiontableros_descripcion_Internalname ;
      private String lblTextblock2_Internalname ;
      private String lblTextblock2_Jsonclick ;
      private String divTable_container_trgestiontableros_comentario_Internalname ;
      private String edtavTrgestiontableros_comentario_Internalname ;
      private String lblTextblock3_Internalname ;
      private String lblTextblock3_Jsonclick ;
      private String divTable_container_trgestiontableros_tipotablero_Internalname ;
      private String edtavTrgestiontableros_tipotablero_Internalname ;
      private String edtavTrgestiontableros_tipotablero_Jsonclick ;
      private String lblTextblock4_Internalname ;
      private String lblTextblock4_Jsonclick ;
      private String divTable_container_trgestiontableros_fechainicio_Internalname ;
      private String edtavTrgestiontableros_fechainicio_Internalname ;
      private String edtavTrgestiontableros_fechainicio_Jsonclick ;
      private String lblTextblock5_Internalname ;
      private String lblTextblock5_Jsonclick ;
      private String divTable_container_trgestiontableros_fechafin_Internalname ;
      private String edtavTrgestiontableros_fechafin_Internalname ;
      private String edtavTrgestiontableros_fechafin_Jsonclick ;
      private String divResponsivetable_containernode_actions_Internalname ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavConfirmmessage_Internalname ;
      private String AV25ConfirmMessage ;
      private String tblTableconditionalconfirm_Internalname ;
      private String sStyleString ;
      private String tblSection_condconf_dialog_Internalname ;
      private String tblSection_condconf_dialog_inner_Internalname ;
      private String edtavConfirmmessage_Jsonclick ;
      private String tblConfirm_hidden_actionstable_Internalname ;
      private String bttI_buttonconfirmyes_Internalname ;
      private String bttI_buttonconfirmyes_Jsonclick ;
      private String bttI_buttonconfirmno_Internalname ;
      private String bttI_buttonconfirmno_Jsonclick ;
      private String tblActionscontainertableleft_actions_Internalname ;
      private String bttCreartablero_Internalname ;
      private String bttCreartablero_Jsonclick ;
      private DateTime AV23TrGestionTableros_FechaCreacion ;
      private DateTime AV16TrGestionTableros_FechaInicio ;
      private DateTime AV17TrGestionTableros_FechaFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV26ConfirmationRequired ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private String AV13TrGestionTableros_Descripcion ;
      private String AV14TrGestionTableros_Comentario ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtCrearTablero_SDT AV21CrearTablero_SDT ;
   }

}
