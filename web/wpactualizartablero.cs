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
   public class wpactualizartablero : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpactualizartablero( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public wpactualizartablero( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( Guid aP0_TrGestionTableros_ID )
      {
         this.AV5TrGestionTableros_ID = aP0_TrGestionTableros_ID;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavTrgestiontableros_estado = new GXCombobox();
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV5TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( gxfirstwebparm));
               AssignAttri("", false, "AV5TrGestionTableros_ID", AV5TrGestionTableros_ID.ToString());
               GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_ID", GetSecureSignedToken( "", AV5TrGestionTableros_ID, context));
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
         PA1V2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1V2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210202185793", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 947160), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpactualizartablero.aspx") + "?" + UrlEncode(AV5TrGestionTableros_ID.ToString())+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_ID", GetSecureSignedToken( "", AV5TrGestionTableros_ID, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"WpActualizarTablero");
         forbiddenHiddens.Add("TrGestionTableros_FechaCreacion", context.localUtil.Format(AV21TrGestionTableros_FechaCreacion, "99/99/9999"));
         forbiddenHiddens.Add("TrGestionTableros_FechaModificacion", context.localUtil.Format(AV24TrGestionTableros_FechaModificacion, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wpactualizartablero:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_ID", A1TrGestionTableros_ID.ToString());
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTABLEROS_ID", AV5TrGestionTableros_ID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_ID", GetSecureSignedToken( "", AV5TrGestionTableros_ID, context));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_NOMBRE", StringUtil.RTrim( A2TrGestionTableros_Nombre));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_DESCRIPCION", A5TrGestionTableros_Descripcion);
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_COMENTARIO", A6TrGestionTableros_Comentario);
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_TIPOTABLERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TrGestionTableros_TipoTablero), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_FECHAINICIO", context.localUtil.DToC( A3TrGestionTableros_FechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_FECHAFIN", context.localUtil.DToC( A4TrGestionTableros_FechaFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_FECHACREACION", context.localUtil.DToC( A7TrGestionTableros_FechaCreacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_FECHAMODIFICACION", context.localUtil.DToC( A8TrGestionTableros_FechaModificacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_ESTADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10TrGestionTableros_Estado), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vCONFIRMATIONREQUIRED", AV29ConfirmationRequired);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCREARTABLERO_SDT", AV26CrearTablero_SDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCREARTABLERO_SDT", AV26CrearTablero_SDT);
         }
         GxWebStd.gx_hidden_field( context, "vCONFIRMATIONSUBID", StringUtil.RTrim( AV30ConfirmationSubId));
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
            WE1V2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1V2( ) ;
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
         return formatLink("wpactualizartablero.aspx") + "?" + UrlEncode(AV5TrGestionTableros_ID.ToString()) ;
      }

      public override String GetPgmname( )
      {
         return "WpActualizarTablero" ;
      }

      public override String GetPgmdesc( )
      {
         return "Modificar tablero" ;
      }

      protected void WB1V0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Modificación", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, "HLP_WpActualizarTablero.htm");
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
            GxWebStd.gx_group_start( context, grpGroup_Internalname, "Crear Nuevo tablero", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_WpActualizarTablero.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock_Internalname, "Nombre de tablero : ", "", "", lblTextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpActualizarTablero.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontableros_nombre_Internalname, StringUtil.RTrim( AV13TrGestionTableros_Nombre), StringUtil.RTrim( context.localUtil.Format( AV13TrGestionTableros_Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontableros_nombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTrgestiontableros_nombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WpActualizarTablero.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Descripción : ", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpActualizarTablero.htm");
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
            GxWebStd.gx_html_textarea( context, edtavTrgestiontableros_descripcion_Internalname, AV14TrGestionTableros_Descripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", 0, 1, edtavTrgestiontableros_descripcion_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WpActualizarTablero.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Comentario : ", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpActualizarTablero.htm");
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
            GxWebStd.gx_html_textarea( context, edtavTrgestiontableros_comentario_Internalname, AV15TrGestionTableros_Comentario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", 0, 1, edtavTrgestiontableros_comentario_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WpActualizarTablero.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Tipo de tablero : ", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpActualizarTablero.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontableros_tipotablero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16TrGestionTableros_TipoTablero), 4, 0, ".", "")), ((edtavTrgestiontableros_tipotablero_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV16TrGestionTableros_TipoTablero), "ZZZ9")) : context.localUtil.Format( (decimal)(AV16TrGestionTableros_TipoTablero), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontableros_tipotablero_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTrgestiontableros_tipotablero_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpActualizarTablero.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Fecha de inicio : ", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpActualizarTablero.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontableros_fechainicio_Internalname, context.localUtil.Format(AV17TrGestionTableros_FechaInicio, "99/99/9999"), context.localUtil.Format( AV17TrGestionTableros_FechaInicio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontableros_fechainicio_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTrgestiontableros_fechainicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpActualizarTablero.htm");
            GxWebStd.gx_bitmap( context, edtavTrgestiontableros_fechainicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrgestiontableros_fechainicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpActualizarTablero.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Fecha de fin : ", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpActualizarTablero.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontableros_fechafin_Internalname, context.localUtil.Format(AV18TrGestionTableros_FechaFin, "99/99/9999"), context.localUtil.Format( AV18TrGestionTableros_FechaFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontableros_fechafin_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTrgestiontableros_fechafin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpActualizarTablero.htm");
            GxWebStd.gx_bitmap( context, edtavTrgestiontableros_fechafin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrgestiontableros_fechafin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpActualizarTablero.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Fecha de creación : ", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpActualizarTablero.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontableros_fechacreacion_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTrgestiontableros_fechacreacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontableros_fechacreacion_Internalname, context.localUtil.Format(AV21TrGestionTableros_FechaCreacion, "99/99/9999"), context.localUtil.Format( AV21TrGestionTableros_FechaCreacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontableros_fechacreacion_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTrgestiontableros_fechacreacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpActualizarTablero.htm");
            GxWebStd.gx_bitmap( context, edtavTrgestiontableros_fechacreacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrgestiontableros_fechacreacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpActualizarTablero.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Fecha de modificación : ", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpActualizarTablero.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontableros_fechamodificacion_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTrgestiontableros_fechamodificacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontableros_fechamodificacion_Internalname, context.localUtil.Format(AV24TrGestionTableros_FechaModificacion, "99/99/9999"), context.localUtil.Format( AV24TrGestionTableros_FechaModificacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontableros_fechamodificacion_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTrgestiontableros_fechamodificacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpActualizarTablero.htm");
            GxWebStd.gx_bitmap( context, edtavTrgestiontableros_fechamodificacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrgestiontableros_fechamodificacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpActualizarTablero.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Estado : ", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpActualizarTablero.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontableros_estado_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTrgestiontableros_estado, cmbavTrgestiontableros_estado_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25TrGestionTableros_Estado), 4, 0)), 1, cmbavTrgestiontableros_estado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavTrgestiontableros_estado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "", true, "HLP_WpActualizarTablero.htm");
            cmbavTrgestiontableros_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25TrGestionTableros_Estado), 4, 0));
            AssignProp("", false, cmbavTrgestiontableros_estado_Internalname, "Values", (String)(cmbavTrgestiontableros_estado.ToJavascriptSource()), true);
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
            wb_table1_104_1V2( true) ;
         }
         else
         {
            wb_table1_104_1V2( false) ;
         }
         return  ;
      }

      protected void wb_table1_104_1V2e( bool wbgen )
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
            wb_table2_110_1V2( true) ;
         }
         else
         {
            wb_table2_110_1V2( false) ;
         }
         return  ;
      }

      protected void wb_table2_110_1V2e( bool wbgen )
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

      protected void START1V2( )
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
            Form.Meta.addItem("description", "Modificar tablero", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1V0( ) ;
      }

      protected void WS1V2( )
      {
         START1V2( ) ;
         EVT1V2( ) ;
      }

      protected void EVT1V2( )
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
                              E111V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E121V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_MODIFICARTABLERO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_ModificarTablero' */
                              E131V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CONFIRMYES'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'ConfirmYes' */
                              E141V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E151V2 ();
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

      protected void WE1V2( )
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

      protected void PA1V2( )
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
         if ( cmbavTrgestiontableros_estado.ItemCount > 0 )
         {
            AV25TrGestionTableros_Estado = (short)(NumberUtil.Val( cmbavTrgestiontableros_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25TrGestionTableros_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV25TrGestionTableros_Estado", StringUtil.LTrimStr( (decimal)(AV25TrGestionTableros_Estado), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTrgestiontableros_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25TrGestionTableros_Estado), 4, 0));
            AssignProp("", false, cmbavTrgestiontableros_estado_Internalname, "Values", cmbavTrgestiontableros_estado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavTrgestiontableros_fechacreacion_Enabled = 0;
         AssignProp("", false, edtavTrgestiontableros_fechacreacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontableros_fechacreacion_Enabled), 5, 0), true);
         edtavTrgestiontableros_fechamodificacion_Enabled = 0;
         AssignProp("", false, edtavTrgestiontableros_fechamodificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontableros_fechamodificacion_Enabled), 5, 0), true);
         edtavConfirmmessage_Enabled = 0;
         AssignProp("", false, edtavConfirmmessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConfirmmessage_Enabled), 5, 0), true);
      }

      protected void RF1V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E121V2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E151V2 ();
            WB1V0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes1V2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavTrgestiontableros_fechacreacion_Enabled = 0;
         AssignProp("", false, edtavTrgestiontableros_fechacreacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontableros_fechacreacion_Enabled), 5, 0), true);
         edtavTrgestiontableros_fechamodificacion_Enabled = 0;
         AssignProp("", false, edtavTrgestiontableros_fechamodificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontableros_fechamodificacion_Enabled), 5, 0), true);
         edtavConfirmmessage_Enabled = 0;
         AssignProp("", false, edtavConfirmmessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConfirmmessage_Enabled), 5, 0), true);
      }

      protected void STRUP1V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E111V2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            AV30ConfirmationSubId = cgiGet( "vCONFIRMATIONSUBID");
            /* Read variables values. */
            AV13TrGestionTableros_Nombre = cgiGet( edtavTrgestiontableros_nombre_Internalname);
            AssignAttri("", false, "AV13TrGestionTableros_Nombre", AV13TrGestionTableros_Nombre);
            AV14TrGestionTableros_Descripcion = cgiGet( edtavTrgestiontableros_descripcion_Internalname);
            AssignAttri("", false, "AV14TrGestionTableros_Descripcion", AV14TrGestionTableros_Descripcion);
            AV15TrGestionTableros_Comentario = cgiGet( edtavTrgestiontableros_comentario_Internalname);
            AssignAttri("", false, "AV15TrGestionTableros_Comentario", AV15TrGestionTableros_Comentario);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTrgestiontableros_tipotablero_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTrgestiontableros_tipotablero_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTRGESTIONTABLEROS_TIPOTABLERO");
               GX_FocusControl = edtavTrgestiontableros_tipotablero_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16TrGestionTableros_TipoTablero = 0;
               AssignAttri("", false, "AV16TrGestionTableros_TipoTablero", StringUtil.LTrimStr( (decimal)(AV16TrGestionTableros_TipoTablero), 4, 0));
            }
            else
            {
               AV16TrGestionTableros_TipoTablero = (short)(context.localUtil.CToN( cgiGet( edtavTrgestiontableros_tipotablero_Internalname), ".", ","));
               AssignAttri("", false, "AV16TrGestionTableros_TipoTablero", StringUtil.LTrimStr( (decimal)(AV16TrGestionTableros_TipoTablero), 4, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTrgestiontableros_fechainicio_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Inicio"}), 1, "vTRGESTIONTABLEROS_FECHAINICIO");
               GX_FocusControl = edtavTrgestiontableros_fechainicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17TrGestionTableros_FechaInicio = DateTime.MinValue;
               AssignAttri("", false, "AV17TrGestionTableros_FechaInicio", context.localUtil.Format(AV17TrGestionTableros_FechaInicio, "99/99/9999"));
            }
            else
            {
               AV17TrGestionTableros_FechaInicio = context.localUtil.CToD( cgiGet( edtavTrgestiontableros_fechainicio_Internalname), 1);
               AssignAttri("", false, "AV17TrGestionTableros_FechaInicio", context.localUtil.Format(AV17TrGestionTableros_FechaInicio, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTrgestiontableros_fechafin_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Fin"}), 1, "vTRGESTIONTABLEROS_FECHAFIN");
               GX_FocusControl = edtavTrgestiontableros_fechafin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18TrGestionTableros_FechaFin = DateTime.MinValue;
               AssignAttri("", false, "AV18TrGestionTableros_FechaFin", context.localUtil.Format(AV18TrGestionTableros_FechaFin, "99/99/9999"));
            }
            else
            {
               AV18TrGestionTableros_FechaFin = context.localUtil.CToD( cgiGet( edtavTrgestiontableros_fechafin_Internalname), 1);
               AssignAttri("", false, "AV18TrGestionTableros_FechaFin", context.localUtil.Format(AV18TrGestionTableros_FechaFin, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTrgestiontableros_fechacreacion_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Creacion del tablero"}), 1, "vTRGESTIONTABLEROS_FECHACREACION");
               GX_FocusControl = edtavTrgestiontableros_fechacreacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV21TrGestionTableros_FechaCreacion = DateTime.MinValue;
               AssignAttri("", false, "AV21TrGestionTableros_FechaCreacion", context.localUtil.Format(AV21TrGestionTableros_FechaCreacion, "99/99/9999"));
            }
            else
            {
               AV21TrGestionTableros_FechaCreacion = context.localUtil.CToD( cgiGet( edtavTrgestiontableros_fechacreacion_Internalname), 1);
               AssignAttri("", false, "AV21TrGestionTableros_FechaCreacion", context.localUtil.Format(AV21TrGestionTableros_FechaCreacion, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTrgestiontableros_fechamodificacion_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Modificacion del tablero"}), 1, "vTRGESTIONTABLEROS_FECHAMODIFICACION");
               GX_FocusControl = edtavTrgestiontableros_fechamodificacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV24TrGestionTableros_FechaModificacion = DateTime.MinValue;
               AssignAttri("", false, "AV24TrGestionTableros_FechaModificacion", context.localUtil.Format(AV24TrGestionTableros_FechaModificacion, "99/99/9999"));
            }
            else
            {
               AV24TrGestionTableros_FechaModificacion = context.localUtil.CToD( cgiGet( edtavTrgestiontableros_fechamodificacion_Internalname), 1);
               AssignAttri("", false, "AV24TrGestionTableros_FechaModificacion", context.localUtil.Format(AV24TrGestionTableros_FechaModificacion, "99/99/9999"));
            }
            cmbavTrgestiontableros_estado.CurrentValue = cgiGet( cmbavTrgestiontableros_estado_Internalname);
            AV25TrGestionTableros_Estado = (short)(NumberUtil.Val( cgiGet( cmbavTrgestiontableros_estado_Internalname), "."));
            AssignAttri("", false, "AV25TrGestionTableros_Estado", StringUtil.LTrimStr( (decimal)(AV25TrGestionTableros_Estado), 4, 0));
            AV28ConfirmMessage = cgiGet( edtavConfirmmessage_Internalname);
            AssignAttri("", false, "AV28ConfirmMessage", AV28ConfirmMessage);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"WpActualizarTablero");
            AV21TrGestionTableros_FechaCreacion = context.localUtil.CToD( cgiGet( edtavTrgestiontableros_fechacreacion_Internalname), 1);
            AssignAttri("", false, "AV21TrGestionTableros_FechaCreacion", context.localUtil.Format(AV21TrGestionTableros_FechaCreacion, "99/99/9999"));
            forbiddenHiddens.Add("TrGestionTableros_FechaCreacion", context.localUtil.Format(AV21TrGestionTableros_FechaCreacion, "99/99/9999"));
            AV24TrGestionTableros_FechaModificacion = context.localUtil.CToD( cgiGet( edtavTrgestiontableros_fechamodificacion_Internalname), 1);
            AssignAttri("", false, "AV24TrGestionTableros_FechaModificacion", context.localUtil.Format(AV24TrGestionTableros_FechaModificacion, "99/99/9999"));
            forbiddenHiddens.Add("TrGestionTableros_FechaModificacion", context.localUtil.Format(AV24TrGestionTableros_FechaModificacion, "99/99/9999"));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("wpactualizartablero:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void S122( )
      {
         /* 'U_STARTPAGE' Routine */
         /* Using cursor H001V2 */
         pr_default.execute(0, new Object[] {AV5TrGestionTableros_ID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1TrGestionTableros_ID = (Guid)((Guid)(H001V2_A1TrGestionTableros_ID[0]));
            A2TrGestionTableros_Nombre = H001V2_A2TrGestionTableros_Nombre[0];
            n2TrGestionTableros_Nombre = H001V2_n2TrGestionTableros_Nombre[0];
            A5TrGestionTableros_Descripcion = H001V2_A5TrGestionTableros_Descripcion[0];
            n5TrGestionTableros_Descripcion = H001V2_n5TrGestionTableros_Descripcion[0];
            A6TrGestionTableros_Comentario = H001V2_A6TrGestionTableros_Comentario[0];
            n6TrGestionTableros_Comentario = H001V2_n6TrGestionTableros_Comentario[0];
            A9TrGestionTableros_TipoTablero = H001V2_A9TrGestionTableros_TipoTablero[0];
            n9TrGestionTableros_TipoTablero = H001V2_n9TrGestionTableros_TipoTablero[0];
            A3TrGestionTableros_FechaInicio = H001V2_A3TrGestionTableros_FechaInicio[0];
            n3TrGestionTableros_FechaInicio = H001V2_n3TrGestionTableros_FechaInicio[0];
            A4TrGestionTableros_FechaFin = H001V2_A4TrGestionTableros_FechaFin[0];
            n4TrGestionTableros_FechaFin = H001V2_n4TrGestionTableros_FechaFin[0];
            A7TrGestionTableros_FechaCreacion = H001V2_A7TrGestionTableros_FechaCreacion[0];
            n7TrGestionTableros_FechaCreacion = H001V2_n7TrGestionTableros_FechaCreacion[0];
            A8TrGestionTableros_FechaModificacion = H001V2_A8TrGestionTableros_FechaModificacion[0];
            n8TrGestionTableros_FechaModificacion = H001V2_n8TrGestionTableros_FechaModificacion[0];
            A10TrGestionTableros_Estado = H001V2_A10TrGestionTableros_Estado[0];
            n10TrGestionTableros_Estado = H001V2_n10TrGestionTableros_Estado[0];
            AV13TrGestionTableros_Nombre = A2TrGestionTableros_Nombre;
            AssignAttri("", false, "AV13TrGestionTableros_Nombre", AV13TrGestionTableros_Nombre);
            AV14TrGestionTableros_Descripcion = A5TrGestionTableros_Descripcion;
            AssignAttri("", false, "AV14TrGestionTableros_Descripcion", AV14TrGestionTableros_Descripcion);
            AV15TrGestionTableros_Comentario = A6TrGestionTableros_Comentario;
            AssignAttri("", false, "AV15TrGestionTableros_Comentario", AV15TrGestionTableros_Comentario);
            AV16TrGestionTableros_TipoTablero = A9TrGestionTableros_TipoTablero;
            AssignAttri("", false, "AV16TrGestionTableros_TipoTablero", StringUtil.LTrimStr( (decimal)(AV16TrGestionTableros_TipoTablero), 4, 0));
            AV17TrGestionTableros_FechaInicio = A3TrGestionTableros_FechaInicio;
            AssignAttri("", false, "AV17TrGestionTableros_FechaInicio", context.localUtil.Format(AV17TrGestionTableros_FechaInicio, "99/99/9999"));
            AV18TrGestionTableros_FechaFin = A4TrGestionTableros_FechaFin;
            AssignAttri("", false, "AV18TrGestionTableros_FechaFin", context.localUtil.Format(AV18TrGestionTableros_FechaFin, "99/99/9999"));
            AV21TrGestionTableros_FechaCreacion = A7TrGestionTableros_FechaCreacion;
            AssignAttri("", false, "AV21TrGestionTableros_FechaCreacion", context.localUtil.Format(AV21TrGestionTableros_FechaCreacion, "99/99/9999"));
            AV24TrGestionTableros_FechaModificacion = A8TrGestionTableros_FechaModificacion;
            AssignAttri("", false, "AV24TrGestionTableros_FechaModificacion", context.localUtil.Format(AV24TrGestionTableros_FechaModificacion, "99/99/9999"));
            AV25TrGestionTableros_Estado = A10TrGestionTableros_Estado;
            AssignAttri("", false, "AV25TrGestionTableros_Estado", StringUtil.LTrimStr( (decimal)(AV25TrGestionTableros_Estado), 4, 0));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
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
         E111V2 ();
         if (returnInSub) return;
      }

      protected void E111V2( )
      {
         /* Start Routine */
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         tblTableconditionalconfirm_Visible = 0;
         AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
      }

      protected void E121V2( )
      {
         /* Refresh Routine */
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         AV29ConfirmationRequired = false;
         AssignAttri("", false, "AV29ConfirmationRequired", AV29ConfirmationRequired);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavTrgestiontableros_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25TrGestionTableros_Estado), 4, 0));
         AssignProp("", false, cmbavTrgestiontableros_estado_Internalname, "Values", cmbavTrgestiontableros_estado.ToJavascriptSource(), true);
      }

      protected void E131V2( )
      {
         /* 'E_ModificarTablero' Routine */
         AV28ConfirmMessage = "Are you sure?";
         AssignAttri("", false, "AV28ConfirmMessage", AV28ConfirmMessage);
         /* Execute user subroutine: 'U_CONFIRMATIONREQUIRED(MODIFICARTABLERO)' */
         S142 ();
         if (returnInSub) return;
         if ( AV29ConfirmationRequired )
         {
            AV30ConfirmationSubId = "'U_ModificarTablero'";
            AssignAttri("", false, "AV30ConfirmationSubId", AV30ConfirmationSubId);
            tblTableconditionalconfirm_Visible = 1;
            AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
         }
         else
         {
            /* Execute user subroutine: 'U_MODIFICARTABLERO' */
            S152 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV26CrearTablero_SDT", AV26CrearTablero_SDT);
      }

      protected void S152( )
      {
         /* 'U_MODIFICARTABLERO' Routine */
         AV26CrearTablero_SDT.gxTpr_Trgestiontableros_id = (Guid)(AV5TrGestionTableros_ID);
         AV26CrearTablero_SDT.gxTpr_Trgestiontableros_nombre = AV13TrGestionTableros_Nombre;
         AV26CrearTablero_SDT.gxTpr_Trgestiontableros_descripcion = AV14TrGestionTableros_Descripcion;
         AV26CrearTablero_SDT.gxTpr_Trgestiontableros_comentario = AV15TrGestionTableros_Comentario;
         AV26CrearTablero_SDT.gxTpr_Trgestiontableros_tipotablero = AV16TrGestionTableros_TipoTablero;
         AV26CrearTablero_SDT.gxTpr_Trgestiontableros_fechainicio = AV17TrGestionTableros_FechaInicio;
         AV26CrearTablero_SDT.gxTpr_Trgestiontableros_fechafin = AV18TrGestionTableros_FechaFin;
         AV26CrearTablero_SDT.gxTpr_Trgestiontableros_fechacreacion = AV21TrGestionTableros_FechaCreacion;
         AV26CrearTablero_SDT.gxTpr_Trgestiontableros_fechamodificacion = AV24TrGestionTableros_FechaModificacion;
         AV26CrearTablero_SDT.gxTpr_Trgestiontableros_estado = AV25TrGestionTableros_Estado;
         new tpcreartablero(context ).execute(  AV26CrearTablero_SDT,  "UDP") ;
         context.DoAjaxRefresh();
      }

      protected void E141V2( )
      {
         /* 'ConfirmYes' Routine */
         tblTableconditionalconfirm_Visible = 0;
         AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV30ConfirmationSubId, "'U_ModificarTablero'") == 0 )
         {
            /* Execute user subroutine: 'U_MODIFICARTABLERO' */
            S152 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV26CrearTablero_SDT", AV26CrearTablero_SDT);
      }

      protected void S142( )
      {
         /* 'U_CONFIRMATIONREQUIRED(MODIFICARTABLERO)' Routine */
         AV29ConfirmationRequired = true;
         AssignAttri("", false, "AV29ConfirmationRequired", AV29ConfirmationRequired);
      }

      protected void nextLoad( )
      {
      }

      protected void E151V2( )
      {
         /* Load Routine */
      }

      protected void wb_table2_110_1V2( bool wbgen )
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
            wb_table3_113_1V2( true) ;
         }
         else
         {
            wb_table3_113_1V2( false) ;
         }
         return  ;
      }

      protected void wb_table3_113_1V2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_110_1V2e( true) ;
         }
         else
         {
            wb_table2_110_1V2e( false) ;
         }
      }

      protected void wb_table3_113_1V2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblSection_condconf_dialog_Internalname, tblSection_condconf_dialog_Internalname, "", "Section_CondConf_Dialog", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table4_116_1V2( true) ;
         }
         else
         {
            wb_table4_116_1V2( false) ;
         }
         return  ;
      }

      protected void wb_table4_116_1V2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_113_1V2e( true) ;
         }
         else
         {
            wb_table3_113_1V2e( false) ;
         }
      }

      protected void wb_table4_116_1V2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfirmmessage_Internalname, StringUtil.RTrim( AV28ConfirmMessage), StringUtil.RTrim( context.localUtil.Format( AV28ConfirmMessage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfirmmessage_Jsonclick, 0, "Attribute_ConditionalConfirm", "", "", "", "", 1, edtavConfirmmessage_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WpActualizarTablero.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table5_123_1V2( true) ;
         }
         else
         {
            wb_table5_123_1V2( false) ;
         }
         return  ;
      }

      protected void wb_table5_123_1V2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_116_1V2e( true) ;
         }
         else
         {
            wb_table4_116_1V2e( false) ;
         }
      }

      protected void wb_table5_123_1V2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblConfirm_hidden_actionstable_Internalname, tblConfirm_hidden_actionstable_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction_Confirm";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttI_buttonconfirmyes_Internalname, "", "Ok", bttI_buttonconfirmyes_Jsonclick, 5, "Ok", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CONFIRMYES\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpActualizarTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttI_buttonconfirmno_Internalname, "", "Cancel", bttI_buttonconfirmno_Jsonclick, 7, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e161v1_client"+"'", TempTags, "", 2, "HLP_WpActualizarTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_123_1V2e( true) ;
         }
         else
         {
            wb_table5_123_1V2e( false) ;
         }
      }

      protected void wb_table1_104_1V2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableleft_actions_Internalname, tblActionscontainertableleft_actions_Internalname, "", "K2BToolsTableActionsLeftContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttModificartablero_Internalname, "", "Modificar Tablero", bttModificartablero_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_MODIFICARTABLERO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpActualizarTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_104_1V2e( true) ;
         }
         else
         {
            wb_table1_104_1V2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5TrGestionTableros_ID = (Guid)((Guid)getParm(obj,0));
         AssignAttri("", false, "AV5TrGestionTableros_ID", AV5TrGestionTableros_ID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_ID", GetSecureSignedToken( "", AV5TrGestionTableros_ID, context));
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
         PA1V2( ) ;
         WS1V2( ) ;
         WE1V2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210202185879", true, true);
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
         context.AddJavascriptSource("wpactualizartablero.js", "?202210202185879", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavTrgestiontableros_estado.Name = "vTRGESTIONTABLEROS_ESTADO";
         cmbavTrgestiontableros_estado.WebTags = "";
         cmbavTrgestiontableros_estado.addItem("1", "Nuevo", 0);
         cmbavTrgestiontableros_estado.addItem("2", "En Progreso", 0);
         cmbavTrgestiontableros_estado.addItem("3", "Completado", 0);
         cmbavTrgestiontableros_estado.addItem("4", "Detenido", 0);
         cmbavTrgestiontableros_estado.addItem("5", "Pendiente", 0);
         if ( cmbavTrgestiontableros_estado.ItemCount > 0 )
         {
            AV25TrGestionTableros_Estado = (short)(NumberUtil.Val( cmbavTrgestiontableros_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25TrGestionTableros_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV25TrGestionTableros_Estado", StringUtil.LTrimStr( (decimal)(AV25TrGestionTableros_Estado), 4, 0));
         }
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
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtavTrgestiontableros_fechacreacion_Internalname = "vTRGESTIONTABLEROS_FECHACREACION";
         divTable_container_trgestiontableros_fechacreacion_Internalname = "TABLE_CONTAINER_TRGESTIONTABLEROS_FECHACREACION";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtavTrgestiontableros_fechamodificacion_Internalname = "vTRGESTIONTABLEROS_FECHAMODIFICACION";
         divTable_container_trgestiontableros_fechamodificacion_Internalname = "TABLE_CONTAINER_TRGESTIONTABLEROS_FECHAMODIFICACION";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         cmbavTrgestiontableros_estado_Internalname = "vTRGESTIONTABLEROS_ESTADO";
         divTable_container_trgestiontableros_estado_Internalname = "TABLE_CONTAINER_TRGESTIONTABLEROS_ESTADO";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divResponsivetable_mainattributes_attributes_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES";
         divMaingroupresponsivetable_group_Internalname = "MAINGROUPRESPONSIVETABLE_GROUP";
         grpGroup_Internalname = "GROUP";
         bttModificartablero_Internalname = "MODIFICARTABLERO";
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
         cmbavTrgestiontableros_estado_Jsonclick = "";
         cmbavTrgestiontableros_estado.Enabled = 1;
         edtavTrgestiontableros_fechamodificacion_Jsonclick = "";
         edtavTrgestiontableros_fechamodificacion_Enabled = 1;
         edtavTrgestiontableros_fechacreacion_Jsonclick = "";
         edtavTrgestiontableros_fechacreacion_Enabled = 1;
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
         Form.Caption = "Modificar tablero";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1TrGestionTableros_ID',fld:'TRGESTIONTABLEROS_ID',pic:''},{av:'A2TrGestionTableros_Nombre',fld:'TRGESTIONTABLEROS_NOMBRE',pic:''},{av:'A5TrGestionTableros_Descripcion',fld:'TRGESTIONTABLEROS_DESCRIPCION',pic:''},{av:'A6TrGestionTableros_Comentario',fld:'TRGESTIONTABLEROS_COMENTARIO',pic:''},{av:'A9TrGestionTableros_TipoTablero',fld:'TRGESTIONTABLEROS_TIPOTABLERO',pic:'ZZZ9'},{av:'A3TrGestionTableros_FechaInicio',fld:'TRGESTIONTABLEROS_FECHAINICIO',pic:''},{av:'A4TrGestionTableros_FechaFin',fld:'TRGESTIONTABLEROS_FECHAFIN',pic:''},{av:'A7TrGestionTableros_FechaCreacion',fld:'TRGESTIONTABLEROS_FECHACREACION',pic:''},{av:'A8TrGestionTableros_FechaModificacion',fld:'TRGESTIONTABLEROS_FECHAMODIFICACION',pic:''},{av:'A10TrGestionTableros_Estado',fld:'TRGESTIONTABLEROS_ESTADO',pic:'ZZZ9'},{av:'AV5TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'AV21TrGestionTableros_FechaCreacion',fld:'vTRGESTIONTABLEROS_FECHACREACION',pic:''},{av:'AV24TrGestionTableros_FechaModificacion',fld:'vTRGESTIONTABLEROS_FECHAMODIFICACION',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV29ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV13TrGestionTableros_Nombre',fld:'vTRGESTIONTABLEROS_NOMBRE',pic:''},{av:'AV14TrGestionTableros_Descripcion',fld:'vTRGESTIONTABLEROS_DESCRIPCION',pic:''},{av:'AV15TrGestionTableros_Comentario',fld:'vTRGESTIONTABLEROS_COMENTARIO',pic:''},{av:'AV16TrGestionTableros_TipoTablero',fld:'vTRGESTIONTABLEROS_TIPOTABLERO',pic:'ZZZ9'},{av:'AV17TrGestionTableros_FechaInicio',fld:'vTRGESTIONTABLEROS_FECHAINICIO',pic:''},{av:'AV18TrGestionTableros_FechaFin',fld:'vTRGESTIONTABLEROS_FECHAFIN',pic:''},{av:'AV21TrGestionTableros_FechaCreacion',fld:'vTRGESTIONTABLEROS_FECHACREACION',pic:''},{av:'AV24TrGestionTableros_FechaModificacion',fld:'vTRGESTIONTABLEROS_FECHAMODIFICACION',pic:''},{av:'cmbavTrgestiontableros_estado'},{av:'AV25TrGestionTableros_Estado',fld:'vTRGESTIONTABLEROS_ESTADO',pic:'ZZZ9'}]}");
         setEventMetadata("'E_MODIFICARTABLERO'","{handler:'E131V2',iparms:[{av:'AV29ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV5TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'AV26CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''},{av:'AV13TrGestionTableros_Nombre',fld:'vTRGESTIONTABLEROS_NOMBRE',pic:''},{av:'AV14TrGestionTableros_Descripcion',fld:'vTRGESTIONTABLEROS_DESCRIPCION',pic:''},{av:'AV15TrGestionTableros_Comentario',fld:'vTRGESTIONTABLEROS_COMENTARIO',pic:''},{av:'AV16TrGestionTableros_TipoTablero',fld:'vTRGESTIONTABLEROS_TIPOTABLERO',pic:'ZZZ9'},{av:'AV17TrGestionTableros_FechaInicio',fld:'vTRGESTIONTABLEROS_FECHAINICIO',pic:''},{av:'AV18TrGestionTableros_FechaFin',fld:'vTRGESTIONTABLEROS_FECHAFIN',pic:''},{av:'AV21TrGestionTableros_FechaCreacion',fld:'vTRGESTIONTABLEROS_FECHACREACION',pic:''},{av:'AV24TrGestionTableros_FechaModificacion',fld:'vTRGESTIONTABLEROS_FECHAMODIFICACION',pic:''},{av:'cmbavTrgestiontableros_estado'},{av:'AV25TrGestionTableros_Estado',fld:'vTRGESTIONTABLEROS_ESTADO',pic:'ZZZ9'}]");
         setEventMetadata("'E_MODIFICARTABLERO'",",oparms:[{av:'AV28ConfirmMessage',fld:'vCONFIRMMESSAGE',pic:''},{av:'AV30ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'},{av:'AV29ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV26CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''}]}");
         setEventMetadata("'CONFIRMNO'","{handler:'E161V1',iparms:[]");
         setEventMetadata("'CONFIRMNO'",",oparms:[{av:'AV30ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'}]}");
         setEventMetadata("'CONFIRMYES'","{handler:'E141V2',iparms:[{av:'AV30ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'AV5TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'AV26CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''},{av:'AV13TrGestionTableros_Nombre',fld:'vTRGESTIONTABLEROS_NOMBRE',pic:''},{av:'AV14TrGestionTableros_Descripcion',fld:'vTRGESTIONTABLEROS_DESCRIPCION',pic:''},{av:'AV15TrGestionTableros_Comentario',fld:'vTRGESTIONTABLEROS_COMENTARIO',pic:''},{av:'AV16TrGestionTableros_TipoTablero',fld:'vTRGESTIONTABLEROS_TIPOTABLERO',pic:'ZZZ9'},{av:'AV17TrGestionTableros_FechaInicio',fld:'vTRGESTIONTABLEROS_FECHAINICIO',pic:''},{av:'AV18TrGestionTableros_FechaFin',fld:'vTRGESTIONTABLEROS_FECHAFIN',pic:''},{av:'AV21TrGestionTableros_FechaCreacion',fld:'vTRGESTIONTABLEROS_FECHACREACION',pic:''},{av:'AV24TrGestionTableros_FechaModificacion',fld:'vTRGESTIONTABLEROS_FECHAMODIFICACION',pic:''},{av:'cmbavTrgestiontableros_estado'},{av:'AV25TrGestionTableros_Estado',fld:'vTRGESTIONTABLEROS_ESTADO',pic:'ZZZ9'}]");
         setEventMetadata("'CONFIRMYES'",",oparms:[{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'},{av:'AV26CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''}]}");
         setEventMetadata("VALIDV_TRGESTIONTABLEROS_FECHAINICIO","{handler:'Validv_Trgestiontableros_fechainicio',iparms:[]");
         setEventMetadata("VALIDV_TRGESTIONTABLEROS_FECHAINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_TRGESTIONTABLEROS_FECHAFIN","{handler:'Validv_Trgestiontableros_fechafin',iparms:[]");
         setEventMetadata("VALIDV_TRGESTIONTABLEROS_FECHAFIN",",oparms:[]}");
         setEventMetadata("VALIDV_TRGESTIONTABLEROS_FECHACREACION","{handler:'Validv_Trgestiontableros_fechacreacion',iparms:[]");
         setEventMetadata("VALIDV_TRGESTIONTABLEROS_FECHACREACION",",oparms:[]}");
         setEventMetadata("VALIDV_TRGESTIONTABLEROS_FECHAMODIFICACION","{handler:'Validv_Trgestiontableros_fechamodificacion',iparms:[]");
         setEventMetadata("VALIDV_TRGESTIONTABLEROS_FECHAMODIFICACION",",oparms:[]}");
         setEventMetadata("VALIDV_TRGESTIONTABLEROS_ESTADO","{handler:'Validv_Trgestiontableros_estado',iparms:[]");
         setEventMetadata("VALIDV_TRGESTIONTABLEROS_ESTADO",",oparms:[]}");
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
         wcpOAV5TrGestionTableros_ID = (Guid)(Guid.Empty);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         AV21TrGestionTableros_FechaCreacion = DateTime.MinValue;
         AV24TrGestionTableros_FechaModificacion = DateTime.MinValue;
         A1TrGestionTableros_ID = (Guid)(Guid.Empty);
         A2TrGestionTableros_Nombre = "";
         A5TrGestionTableros_Descripcion = "";
         A6TrGestionTableros_Comentario = "";
         A3TrGestionTableros_FechaInicio = DateTime.MinValue;
         A4TrGestionTableros_FechaFin = DateTime.MinValue;
         A7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         A8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         AV26CrearTablero_SDT = new SdtCrearTablero_SDT(context);
         AV30ConfirmationSubId = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblTextblock_Jsonclick = "";
         TempTags = "";
         AV13TrGestionTableros_Nombre = "";
         lblTextblock1_Jsonclick = "";
         AV14TrGestionTableros_Descripcion = "";
         lblTextblock2_Jsonclick = "";
         AV15TrGestionTableros_Comentario = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         AV17TrGestionTableros_FechaInicio = DateTime.MinValue;
         lblTextblock5_Jsonclick = "";
         AV18TrGestionTableros_FechaFin = DateTime.MinValue;
         lblTextblock8_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV28ConfirmMessage = "";
         hsh = "";
         scmdbuf = "";
         H001V2_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         H001V2_A2TrGestionTableros_Nombre = new String[] {""} ;
         H001V2_n2TrGestionTableros_Nombre = new bool[] {false} ;
         H001V2_A5TrGestionTableros_Descripcion = new String[] {""} ;
         H001V2_n5TrGestionTableros_Descripcion = new bool[] {false} ;
         H001V2_A6TrGestionTableros_Comentario = new String[] {""} ;
         H001V2_n6TrGestionTableros_Comentario = new bool[] {false} ;
         H001V2_A9TrGestionTableros_TipoTablero = new short[1] ;
         H001V2_n9TrGestionTableros_TipoTablero = new bool[] {false} ;
         H001V2_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H001V2_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         H001V2_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         H001V2_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         H001V2_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         H001V2_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         H001V2_A8TrGestionTableros_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         H001V2_n8TrGestionTableros_FechaModificacion = new bool[] {false} ;
         H001V2_A10TrGestionTableros_Estado = new short[1] ;
         H001V2_n10TrGestionTableros_Estado = new bool[] {false} ;
         sStyleString = "";
         bttI_buttonconfirmyes_Jsonclick = "";
         bttI_buttonconfirmno_Jsonclick = "";
         bttModificartablero_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpactualizartablero__default(),
            new Object[][] {
                new Object[] {
               H001V2_A1TrGestionTableros_ID, H001V2_A2TrGestionTableros_Nombre, H001V2_n2TrGestionTableros_Nombre, H001V2_A5TrGestionTableros_Descripcion, H001V2_n5TrGestionTableros_Descripcion, H001V2_A6TrGestionTableros_Comentario, H001V2_n6TrGestionTableros_Comentario, H001V2_A9TrGestionTableros_TipoTablero, H001V2_n9TrGestionTableros_TipoTablero, H001V2_A3TrGestionTableros_FechaInicio,
               H001V2_n3TrGestionTableros_FechaInicio, H001V2_A4TrGestionTableros_FechaFin, H001V2_n4TrGestionTableros_FechaFin, H001V2_A7TrGestionTableros_FechaCreacion, H001V2_n7TrGestionTableros_FechaCreacion, H001V2_A8TrGestionTableros_FechaModificacion, H001V2_n8TrGestionTableros_FechaModificacion, H001V2_A10TrGestionTableros_Estado, H001V2_n10TrGestionTableros_Estado
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavTrgestiontableros_fechacreacion_Enabled = 0;
         edtavTrgestiontableros_fechamodificacion_Enabled = 0;
         edtavConfirmmessage_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short A9TrGestionTableros_TipoTablero ;
      private short A10TrGestionTableros_Estado ;
      private short wbEnd ;
      private short wbStart ;
      private short AV16TrGestionTableros_TipoTablero ;
      private short AV25TrGestionTableros_Estado ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavTrgestiontableros_nombre_Enabled ;
      private int edtavTrgestiontableros_descripcion_Enabled ;
      private int edtavTrgestiontableros_comentario_Enabled ;
      private int edtavTrgestiontableros_tipotablero_Enabled ;
      private int edtavTrgestiontableros_fechainicio_Enabled ;
      private int edtavTrgestiontableros_fechafin_Enabled ;
      private int edtavTrgestiontableros_fechacreacion_Enabled ;
      private int edtavTrgestiontableros_fechamodificacion_Enabled ;
      private int edtavConfirmmessage_Enabled ;
      private int tblTableconditionalconfirm_Visible ;
      private int idxLst ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String A2TrGestionTableros_Nombre ;
      private String AV30ConfirmationSubId ;
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
      private String AV13TrGestionTableros_Nombre ;
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
      private String lblTextblock8_Internalname ;
      private String lblTextblock8_Jsonclick ;
      private String divTable_container_trgestiontableros_fechacreacion_Internalname ;
      private String edtavTrgestiontableros_fechacreacion_Internalname ;
      private String edtavTrgestiontableros_fechacreacion_Jsonclick ;
      private String lblTextblock7_Internalname ;
      private String lblTextblock7_Jsonclick ;
      private String divTable_container_trgestiontableros_fechamodificacion_Internalname ;
      private String edtavTrgestiontableros_fechamodificacion_Internalname ;
      private String edtavTrgestiontableros_fechamodificacion_Jsonclick ;
      private String lblTextblock6_Internalname ;
      private String lblTextblock6_Jsonclick ;
      private String divTable_container_trgestiontableros_estado_Internalname ;
      private String cmbavTrgestiontableros_estado_Internalname ;
      private String cmbavTrgestiontableros_estado_Jsonclick ;
      private String divResponsivetable_containernode_actions_Internalname ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavConfirmmessage_Internalname ;
      private String AV28ConfirmMessage ;
      private String hsh ;
      private String scmdbuf ;
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
      private String bttModificartablero_Internalname ;
      private String bttModificartablero_Jsonclick ;
      private DateTime AV21TrGestionTableros_FechaCreacion ;
      private DateTime AV24TrGestionTableros_FechaModificacion ;
      private DateTime A3TrGestionTableros_FechaInicio ;
      private DateTime A4TrGestionTableros_FechaFin ;
      private DateTime A7TrGestionTableros_FechaCreacion ;
      private DateTime A8TrGestionTableros_FechaModificacion ;
      private DateTime AV17TrGestionTableros_FechaInicio ;
      private DateTime AV18TrGestionTableros_FechaFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV29ConfirmationRequired ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n2TrGestionTableros_Nombre ;
      private bool n5TrGestionTableros_Descripcion ;
      private bool n6TrGestionTableros_Comentario ;
      private bool n9TrGestionTableros_TipoTablero ;
      private bool n3TrGestionTableros_FechaInicio ;
      private bool n4TrGestionTableros_FechaFin ;
      private bool n7TrGestionTableros_FechaCreacion ;
      private bool n8TrGestionTableros_FechaModificacion ;
      private bool n10TrGestionTableros_Estado ;
      private bool returnInSub ;
      private String A5TrGestionTableros_Descripcion ;
      private String A6TrGestionTableros_Comentario ;
      private String AV14TrGestionTableros_Descripcion ;
      private String AV15TrGestionTableros_Comentario ;
      private Guid AV5TrGestionTableros_ID ;
      private Guid wcpOAV5TrGestionTableros_ID ;
      private Guid A1TrGestionTableros_ID ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavTrgestiontableros_estado ;
      private IDataStoreProvider pr_default ;
      private Guid[] H001V2_A1TrGestionTableros_ID ;
      private String[] H001V2_A2TrGestionTableros_Nombre ;
      private bool[] H001V2_n2TrGestionTableros_Nombre ;
      private String[] H001V2_A5TrGestionTableros_Descripcion ;
      private bool[] H001V2_n5TrGestionTableros_Descripcion ;
      private String[] H001V2_A6TrGestionTableros_Comentario ;
      private bool[] H001V2_n6TrGestionTableros_Comentario ;
      private short[] H001V2_A9TrGestionTableros_TipoTablero ;
      private bool[] H001V2_n9TrGestionTableros_TipoTablero ;
      private DateTime[] H001V2_A3TrGestionTableros_FechaInicio ;
      private bool[] H001V2_n3TrGestionTableros_FechaInicio ;
      private DateTime[] H001V2_A4TrGestionTableros_FechaFin ;
      private bool[] H001V2_n4TrGestionTableros_FechaFin ;
      private DateTime[] H001V2_A7TrGestionTableros_FechaCreacion ;
      private bool[] H001V2_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] H001V2_A8TrGestionTableros_FechaModificacion ;
      private bool[] H001V2_n8TrGestionTableros_FechaModificacion ;
      private short[] H001V2_A10TrGestionTableros_Estado ;
      private bool[] H001V2_n10TrGestionTableros_Estado ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtCrearTablero_SDT AV26CrearTablero_SDT ;
   }

   public class wpactualizartablero__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH001V2 ;
          prmH001V2 = new Object[] {
          new Object[] {"@AV5TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H001V2", "SELECT [TrGestionTableros_ID], [TrGestionTableros_Nombre], [TrGestionTableros_Descripcion], [TrGestionTableros_Comentario], [TrGestionTableros_TipoTablero], [TrGestionTableros_FechaInicio], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaCreacion], [TrGestionTableros_FechaModificacion], [TrGestionTableros_Estado] FROM TABLERO.[TrGestionTableros] WHERE [TrGestionTableros_ID] = @AV5TrGestionTableros_ID ORDER BY [TrGestionTableros_ID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001V2,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[17])[0] = rslt.getShort(10) ;
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
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
       }
    }

 }

}
