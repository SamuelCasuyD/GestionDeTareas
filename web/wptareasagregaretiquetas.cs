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
   public class wptareasagregaretiquetas : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wptareasagregaretiquetas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public wptareasagregaretiquetas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_TrGestionTareas_ID )
      {
         this.AV13TrGestionTareas_ID = aP0_TrGestionTareas_ID;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavGestiontareas_etiquetaid = new GXCombobox();
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
               AV13TrGestionTareas_ID = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV13TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(AV13TrGestionTareas_ID), 13, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
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

      public override short ExecuteStartEvent( )
      {
         PA262( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START262( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210211745060", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wptareasagregaretiquetas.aspx") + "?" + UrlEncode("" +AV13TrGestionTareas_ID)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTAREAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13TrGestionTareas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGESTIONETIQUETAS_SDT", AV16GestionEtiquetas_SDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGESTIONETIQUETAS_SDT", AV16GestionEtiquetas_SDT);
         }
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
            WE262( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT262( ) ;
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
         return formatLink("wptareasagregaretiquetas.aspx") + "?" + UrlEncode("" +AV13TrGestionTareas_ID) ;
      }

      public override String GetPgmname( )
      {
         return "WpTareasAgregarEtiquetas" ;
      }

      public override String GetPgmdesc( )
      {
         return "Agregar Etiquetas" ;
      }

      protected void WB260( )
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
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", divTable1_Height, "px", "K2BToolsTable_TitleContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection2_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "h1");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Etiquetas", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "font-size:"+StringUtil.Str( (decimal)(lblTitle_Fontsize), 3, 0)+"pt;", "TextBlock_Title", 0, "", 1, 1, 0, "HLP_WpTareasAgregarEtiquetas.htm");
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
            GxWebStd.gx_group_start( context, grpGroup_Internalname, "Seleccionar etiqueta", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_WpTareasAgregarEtiquetas.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_group_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_gestiontareas_ide_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavGestiontareas_ide_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavGestiontareas_ide_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGestiontareas_ide_Internalname, "Tareas Etiquetas_ID", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGestiontareas_ide_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14GestionTareas_IDe), 13, 0, ".", "")), ((edtavGestiontareas_ide_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV14GestionTareas_IDe), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV14GestionTareas_IDe), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGestiontareas_ide_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavGestiontareas_ide_Visible, edtavGestiontareas_ide_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpTareasAgregarEtiquetas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_gestiontareas_etiquetaid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_gestiontareas_etiquetaidfieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGestiontareas_etiquetaid_var_lefttext_Internalname, "Etiqueta : ", "", "", lblGestiontareas_etiquetaid_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpTareasAgregarEtiquetas.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavGestiontareas_etiquetaid, dynavGestiontareas_etiquetaid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV15GestionTareas_EtiquetaID), 13, 0)), 1, dynavGestiontareas_etiquetaid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavGestiontareas_etiquetaid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, "HLP_WpTareasAgregarEtiquetas.htm");
            dynavGestiontareas_etiquetaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV15GestionTareas_EtiquetaID), 13, 0));
            AssignProp("", false, dynavGestiontareas_etiquetaid_Internalname, "Values", (String)(dynavGestiontareas_etiquetaid.ToJavascriptSource()), true);
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
            wb_table1_45_262( true) ;
         }
         else
         {
            wb_table1_45_262( false) ;
         }
         return  ;
      }

      protected void wb_table1_45_262e( bool wbgen )
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
            /* User Defined Control */
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, "K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START262( )
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
            Form.Meta.addItem("description", "Agregar Etiquetas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP260( ) ;
      }

      protected void WS262( )
      {
         START262( ) ;
         EVT262( ) ;
      }

      protected void EVT262( )
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
                              E11262 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E12262 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_AGREGARETIQUETA'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_AgregarEtiqueta' */
                              E13262 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E14262 ();
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

      protected void WE262( )
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

      protected void PA262( )
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
               GX_FocusControl = edtavGestiontareas_ide_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvGESTIONTAREAS_ETIQUETAID261( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvGESTIONTAREAS_ETIQUETAID_data261( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((String)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((String)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvGESTIONTAREAS_ETIQUETAID_html261( )
      {
         long gxdynajaxvalue ;
         GXDLVvGESTIONTAREAS_ETIQUETAID_data261( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavGestiontareas_etiquetaid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(NumberUtil.Val( ((String)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavGestiontareas_etiquetaid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 13, 0)), ((String)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvGESTIONTAREAS_ETIQUETAID_data261( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00262 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00262_A41TrEtiquetas_ID[0]), 13, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00262_A42TrEtiquetas_Nombre[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynavGestiontareas_etiquetaid.Name = "vGESTIONTAREAS_ETIQUETAID";
            dynavGestiontareas_etiquetaid.WebTags = "";
            dynavGestiontareas_etiquetaid.removeAllItems();
            /* Using cursor H00263 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               dynavGestiontareas_etiquetaid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00263_A41TrEtiquetas_ID[0]), 13, 0)), H00263_A42TrEtiquetas_Nombre[0], 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( dynavGestiontareas_etiquetaid.ItemCount > 0 )
            {
               AV15GestionTareas_EtiquetaID = (long)(NumberUtil.Val( dynavGestiontareas_etiquetaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV15GestionTareas_EtiquetaID), 13, 0))), "."));
               AssignAttri("", false, "AV15GestionTareas_EtiquetaID", StringUtil.LTrimStr( (decimal)(AV15GestionTareas_EtiquetaID), 13, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavGestiontareas_etiquetaid.ItemCount > 0 )
         {
            AV15GestionTareas_EtiquetaID = (long)(NumberUtil.Val( dynavGestiontareas_etiquetaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV15GestionTareas_EtiquetaID), 13, 0))), "."));
            AssignAttri("", false, "AV15GestionTareas_EtiquetaID", StringUtil.LTrimStr( (decimal)(AV15GestionTareas_EtiquetaID), 13, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavGestiontareas_etiquetaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV15GestionTareas_EtiquetaID), 13, 0));
            AssignProp("", false, dynavGestiontareas_etiquetaid_Internalname, "Values", dynavGestiontareas_etiquetaid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF262( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF262( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E12262 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E14262 ();
            WB260( ) ;
         }
      }

      protected void send_integrity_lvl_hashes262( )
      {
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTAREAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13TrGestionTareas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP260( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11262 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGestiontareas_ide_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGestiontareas_ide_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGESTIONTAREAS_IDE");
               GX_FocusControl = edtavGestiontareas_ide_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14GestionTareas_IDe = 0;
               AssignAttri("", false, "AV14GestionTareas_IDe", StringUtil.LTrimStr( (decimal)(AV14GestionTareas_IDe), 13, 0));
            }
            else
            {
               AV14GestionTareas_IDe = (long)(context.localUtil.CToN( cgiGet( edtavGestiontareas_ide_Internalname), ".", ","));
               AssignAttri("", false, "AV14GestionTareas_IDe", StringUtil.LTrimStr( (decimal)(AV14GestionTareas_IDe), 13, 0));
            }
            dynavGestiontareas_etiquetaid.CurrentValue = cgiGet( dynavGestiontareas_etiquetaid_Internalname);
            AV15GestionTareas_EtiquetaID = (long)(NumberUtil.Val( cgiGet( dynavGestiontareas_etiquetaid_Internalname), "."));
            AssignAttri("", false, "AV15GestionTareas_EtiquetaID", StringUtil.LTrimStr( (decimal)(AV15GestionTareas_EtiquetaID), 13, 0));
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
         divTable1_Height = 60;
         AssignProp("", false, divTable1_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTable1_Height), 9, 0), true);
         lblTitle_Fontsize = 18;
         AssignProp("", false, lblTitle_Internalname, "Fontsize", StringUtil.LTrimStr( (decimal)(lblTitle_Fontsize), 9, 0), true);
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
         E11262 ();
         if (returnInSub) return;
      }

      protected void E11262( )
      {
         /* Start Routine */
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E12262( )
      {
         /* Refresh Routine */
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         edtavGestiontareas_ide_Visible = 0;
         AssignProp("", false, edtavGestiontareas_ide_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGestiontareas_ide_Visible), 5, 0), true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E13262( )
      {
         /* 'E_AgregarEtiqueta' Routine */
         /* Execute user subroutine: 'U_AGREGARETIQUETA' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16GestionEtiquetas_SDT", AV16GestionEtiquetas_SDT);
      }

      protected void S142( )
      {
         /* 'U_AGREGARETIQUETA' Routine */
         AV16GestionEtiquetas_SDT.gxTpr_Tretiquetas_idtarea = AV13TrGestionTareas_ID;
         AV16GestionEtiquetas_SDT.gxTpr_Tretiquetas_id = AV15GestionTareas_EtiquetaID;
         new prgestionaretiquetas(context ).execute(  AV16GestionEtiquetas_SDT,  "EIN") ;
         context.DoAjaxRefresh();
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void nextLoad( )
      {
      }

      protected void E14262( )
      {
         /* Load Routine */
      }

      protected void wb_table1_45_262( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableleft_actions_Internalname, tblActionscontainertableleft_actions_Internalname, "", "K2BToolsTableActionsLeftContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAgregaretiqueta_Internalname, "", "Agregar Etiqueta", bttAgregaretiqueta_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_AGREGARETIQUETA\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpTareasAgregarEtiquetas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_45_262e( true) ;
         }
         else
         {
            wb_table1_45_262e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13TrGestionTareas_ID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(AV13TrGestionTareas_ID), 13, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
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
         PA262( ) ;
         WS262( ) ;
         WE262( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210211745089", true, true);
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
         context.AddJavascriptSource("wptareasagregaretiquetas.js", "?202210211745089", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynavGestiontareas_etiquetaid.Name = "vGESTIONTAREAS_ETIQUETAID";
         dynavGestiontareas_etiquetaid.WebTags = "";
         dynavGestiontareas_etiquetaid.removeAllItems();
         /* Using cursor H00264 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            dynavGestiontareas_etiquetaid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00264_A41TrEtiquetas_ID[0]), 13, 0)), H00264_A42TrEtiquetas_Nombre[0], 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( dynavGestiontareas_etiquetaid.ItemCount > 0 )
         {
            AV15GestionTareas_EtiquetaID = (long)(NumberUtil.Val( dynavGestiontareas_etiquetaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV15GestionTareas_EtiquetaID), 13, 0))), "."));
            AssignAttri("", false, "AV15GestionTareas_EtiquetaID", StringUtil.LTrimStr( (decimal)(AV15GestionTareas_EtiquetaID), 13, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divSection2_Internalname = "SECTION2";
         divTable1_Internalname = "TABLE1";
         edtavGestiontareas_ide_Internalname = "vGESTIONTAREAS_IDE";
         divTable_container_gestiontareas_ide_Internalname = "TABLE_CONTAINER_GESTIONTAREAS_IDE";
         lblGestiontareas_etiquetaid_var_lefttext_Internalname = "GESTIONTAREAS_ETIQUETAID_VAR_LEFTTEXT";
         dynavGestiontareas_etiquetaid_Internalname = "vGESTIONTAREAS_ETIQUETAID";
         divTable_container_gestiontareas_etiquetaidfieldcontainer_Internalname = "TABLE_CONTAINER_GESTIONTAREAS_ETIQUETAIDFIELDCONTAINER";
         divTable_container_gestiontareas_etiquetaid_Internalname = "TABLE_CONTAINER_GESTIONTAREAS_ETIQUETAID";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divResponsivetable_mainattributes_attributes_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES";
         divMaingroupresponsivetable_group_Internalname = "MAINGROUPRESPONSIVETABLE_GROUP";
         grpGroup_Internalname = "GROUP";
         bttAgregaretiqueta_Internalname = "AGREGARETIQUETA";
         tblActionscontainertableleft_actions_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divContenttable_Internalname = "CONTENTTABLE";
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
         dynavGestiontareas_etiquetaid_Jsonclick = "";
         dynavGestiontareas_etiquetaid.Enabled = 1;
         edtavGestiontareas_ide_Jsonclick = "";
         edtavGestiontareas_ide_Enabled = 1;
         edtavGestiontareas_ide_Visible = 1;
         lblTitle_Fontsize = (int)(24.0m);
         divTable1_Height = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Agregar Etiquetas";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV13TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'dynavGestiontareas_etiquetaid'},{av:'AV15GestionTareas_EtiquetaID',fld:'vGESTIONTAREAS_ETIQUETAID',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'edtavGestiontareas_ide_Visible',ctrl:'vGESTIONTAREAS_IDE',prop:'Visible'},{av:'divTable1_Height',ctrl:'TABLE1',prop:'Height'},{av:'lblTitle_Fontsize',ctrl:'TITLE',prop:'Fontsize'},{av:'dynavGestiontareas_etiquetaid'},{av:'AV15GestionTareas_EtiquetaID',fld:'vGESTIONTAREAS_ETIQUETAID',pic:'ZZZZZZZZZZZZ9'}]}");
         setEventMetadata("'E_AGREGARETIQUETA'","{handler:'E13262',iparms:[{av:'AV13TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV16GestionEtiquetas_SDT',fld:'vGESTIONETIQUETAS_SDT',pic:''},{av:'dynavGestiontareas_etiquetaid'},{av:'AV15GestionTareas_EtiquetaID',fld:'vGESTIONTAREAS_ETIQUETAID',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("'E_AGREGARETIQUETA'",",oparms:[{av:'AV16GestionEtiquetas_SDT',fld:'vGESTIONETIQUETAS_SDT',pic:''},{av:'dynavGestiontareas_etiquetaid'},{av:'AV15GestionTareas_EtiquetaID',fld:'vGESTIONTAREAS_ETIQUETAID',pic:'ZZZZZZZZZZZZ9'}]}");
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
         GXKey = "";
         AV16GestionEtiquetas_SDT = new SdtGestionEtiquetas_SDT(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         lblGestiontareas_etiquetaid_var_lefttext_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H00262_A41TrEtiquetas_ID = new long[1] ;
         H00262_A42TrEtiquetas_Nombre = new String[] {""} ;
         H00262_n42TrEtiquetas_Nombre = new bool[] {false} ;
         H00263_A41TrEtiquetas_ID = new long[1] ;
         H00263_A42TrEtiquetas_Nombre = new String[] {""} ;
         H00263_n42TrEtiquetas_Nombre = new bool[] {false} ;
         sStyleString = "";
         bttAgregaretiqueta_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         H00264_A41TrEtiquetas_ID = new long[1] ;
         H00264_A42TrEtiquetas_Nombre = new String[] {""} ;
         H00264_n42TrEtiquetas_Nombre = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wptareasagregaretiquetas__default(),
            new Object[][] {
                new Object[] {
               H00262_A41TrEtiquetas_ID, H00262_A42TrEtiquetas_Nombre, H00262_n42TrEtiquetas_Nombre
               }
               , new Object[] {
               H00263_A41TrEtiquetas_ID, H00263_A42TrEtiquetas_Nombre, H00263_n42TrEtiquetas_Nombre
               }
               , new Object[] {
               H00264_A41TrEtiquetas_ID, H00264_A42TrEtiquetas_Nombre, H00264_n42TrEtiquetas_Nombre
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int divTable1_Height ;
      private int lblTitle_Fontsize ;
      private int edtavGestiontareas_ide_Visible ;
      private int edtavGestiontareas_ide_Enabled ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private long AV13TrGestionTareas_ID ;
      private long wcpOAV13TrGestionTareas_ID ;
      private long AV14GestionTareas_IDe ;
      private long AV15GestionTareas_EtiquetaID ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
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
      private String divTable_container_gestiontareas_ide_Internalname ;
      private String edtavGestiontareas_ide_Internalname ;
      private String TempTags ;
      private String edtavGestiontareas_ide_Jsonclick ;
      private String divTable_container_gestiontareas_etiquetaid_Internalname ;
      private String divTable_container_gestiontareas_etiquetaidfieldcontainer_Internalname ;
      private String lblGestiontareas_etiquetaid_var_lefttext_Internalname ;
      private String lblGestiontareas_etiquetaid_var_lefttext_Jsonclick ;
      private String dynavGestiontareas_etiquetaid_Internalname ;
      private String dynavGestiontareas_etiquetaid_Jsonclick ;
      private String divResponsivetable_containernode_actions_Internalname ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String gxwrpcisep ;
      private String scmdbuf ;
      private String sStyleString ;
      private String tblActionscontainertableleft_actions_Internalname ;
      private String bttAgregaretiqueta_Internalname ;
      private String bttAgregaretiqueta_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavGestiontareas_etiquetaid ;
      private IDataStoreProvider pr_default ;
      private long[] H00262_A41TrEtiquetas_ID ;
      private String[] H00262_A42TrEtiquetas_Nombre ;
      private bool[] H00262_n42TrEtiquetas_Nombre ;
      private long[] H00263_A41TrEtiquetas_ID ;
      private String[] H00263_A42TrEtiquetas_Nombre ;
      private bool[] H00263_n42TrEtiquetas_Nombre ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] H00264_A41TrEtiquetas_ID ;
      private String[] H00264_A42TrEtiquetas_Nombre ;
      private bool[] H00264_n42TrEtiquetas_Nombre ;
      private GXWebForm Form ;
      private SdtGestionEtiquetas_SDT AV16GestionEtiquetas_SDT ;
   }

   public class wptareasagregaretiquetas__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00262 ;
          prmH00262 = new Object[] {
          } ;
          Object[] prmH00263 ;
          prmH00263 = new Object[] {
          } ;
          Object[] prmH00264 ;
          prmH00264 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("H00262", "SELECT [TrEtiquetas_ID], [TrEtiquetas_Nombre] FROM TABLERO.[TrEtiquetas] ORDER BY [TrEtiquetas_Nombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00262,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00263", "SELECT [TrEtiquetas_ID], [TrEtiquetas_Nombre] FROM TABLERO.[TrEtiquetas] ORDER BY [TrEtiquetas_Nombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00263,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00264", "SELECT [TrEtiquetas_ID], [TrEtiquetas_Nombre] FROM TABLERO.[TrEtiquetas] ORDER BY [TrEtiquetas_Nombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00264,0, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 256) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 256) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
       }
    }

 }

}
