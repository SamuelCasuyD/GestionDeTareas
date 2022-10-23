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
   public class wpcrearactividadtarea : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpcrearactividadtarea( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public wpcrearactividadtarea( IGxContext context )
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
         this.AV21TrGestionTareas_ID = aP0_TrGestionTareas_ID;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavTractividades_estado = new GXCombobox();
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
               AV21TrGestionTareas_ID = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV21TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(AV21TrGestionTareas_ID), 13, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV21TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
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
         PA2B2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2B2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210211857718", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpcrearactividadtarea.aspx") + "?" + UrlEncode("" +AV21TrGestionTareas_ID)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV46Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV21TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV46Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV46Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTAREAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21TrGestionTareas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV21TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGESTIONACTIVIDADES_SDT", AV43GestionActividades_SDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGESTIONACTIVIDADES_SDT", AV43GestionActividades_SDT);
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
            WE2B2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2B2( ) ;
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
         return formatLink("wpcrearactividadtarea.aspx") + "?" + UrlEncode("" +AV21TrGestionTareas_ID) ;
      }

      public override String GetPgmname( )
      {
         return "WpCrearActividadTarea" ;
      }

      public override String GetPgmdesc( )
      {
         return "Crear actividad de tarea" ;
      }

      protected void WB2B0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Actividad", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, "HLP_WpCrearActividadTarea.htm");
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
            GxWebStd.gx_group_start( context, grpGroup_Internalname, "Ingrese los datos solicitados", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_WpCrearActividadTarea.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_tractividades_id_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTractividades_id_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38TrActividades_ID), 13, 0, ".", "")), ((edtavTractividades_id_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV38TrActividades_ID), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV38TrActividades_ID), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTractividades_id_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavTractividades_id_Visible, edtavTractividades_id_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpCrearActividadTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Nímero de tarea : ", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpCrearActividadTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tractividades_idtarea_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTractividades_idtarea_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39TrActividades_IDTarea), 13, 0, ".", "")), ((edtavTractividades_idtarea_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV39TrActividades_IDTarea), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV39TrActividades_IDTarea), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTractividades_idtarea_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTractividades_idtarea_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpCrearActividadTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_Internalname, "Nombre de la actividad : ", "", "", lblTextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpCrearActividadTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tractividades_nombre_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTractividades_nombre_Internalname, StringUtil.RTrim( AV34TrActividades_Nombre), StringUtil.RTrim( context.localUtil.Format( AV34TrActividades_Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTractividades_nombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTractividades_nombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WpCrearActividadTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Descripción", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpCrearActividadTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tractividades_descripcion_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = "";
            ClassString = "Attribute_Trn";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavTractividades_descripcion_Internalname, AV37TrActividades_Descripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", 0, 1, edtavTractividades_descripcion_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WpCrearActividadTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tractividades_fechainicio_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tractividades_fechainiciofieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTractividades_fechainicio_var_lefttext_Internalname, "Fecha de Inicio : ", "", "", lblTractividades_fechainicio_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpCrearActividadTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTractividades_fechainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTractividades_fechainicio_Internalname, context.localUtil.Format(AV40TrActividades_FechaInicio, "99/99/9999"), context.localUtil.Format( AV40TrActividades_FechaInicio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTractividades_fechainicio_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTractividades_fechainicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpCrearActividadTarea.htm");
            GxWebStd.gx_bitmap( context, edtavTractividades_fechainicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTractividades_fechainicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpCrearActividadTarea.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTractividades_fechafin_var_lefttext_Internalname, "Fecha de fin : ", "", "", lblTractividades_fechafin_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpCrearActividadTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTractividades_fechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTractividades_fechafin_Internalname, context.localUtil.Format(AV41TrActividades_FechaFin, "99/99/9999"), context.localUtil.Format( AV41TrActividades_FechaFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTractividades_fechafin_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTractividades_fechafin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpCrearActividadTarea.htm");
            GxWebStd.gx_bitmap( context, edtavTractividades_fechafin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTractividades_fechafin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpCrearActividadTarea.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Estado de la actividad : ", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpCrearActividadTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tractividades_estado_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTractividades_estado, cmbavTractividades_estado_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV42TrActividades_Estado), 4, 0)), 1, cmbavTractividades_estado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavTractividades_estado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, "HLP_WpCrearActividadTarea.htm");
            cmbavTractividades_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42TrActividades_Estado), 4, 0));
            AssignProp("", false, cmbavTractividades_estado_Internalname, "Values", (String)(cmbavTractividades_estado.ToJavascriptSource()), true);
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
            wb_table1_79_2B2( true) ;
         }
         else
         {
            wb_table1_79_2B2( false) ;
         }
         return  ;
      }

      protected void wb_table1_79_2B2e( bool wbgen )
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

      protected void START2B2( )
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
            Form.Meta.addItem("description", "Crear actividad de tarea", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2B0( ) ;
      }

      protected void WS2B2( )
      {
         START2B2( ) ;
         EVT2B2( ) ;
      }

      protected void EVT2B2( )
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
                              E112B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E122B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_CREARACTIVIDAD'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_CrearActividad' */
                              E132B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E142B2 ();
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

      protected void WE2B2( )
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

      protected void PA2B2( )
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
               GX_FocusControl = edtavTractividades_id_Internalname;
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
         if ( cmbavTractividades_estado.ItemCount > 0 )
         {
            AV42TrActividades_Estado = (short)(NumberUtil.Val( cmbavTractividades_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV42TrActividades_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV42TrActividades_Estado", StringUtil.LTrimStr( (decimal)(AV42TrActividades_Estado), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTractividades_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42TrActividades_Estado), 4, 0));
            AssignProp("", false, cmbavTractividades_estado_Internalname, "Values", cmbavTractividades_estado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV46Pgmname = "WpCrearActividadTarea";
         context.Gx_err = 0;
         edtavTractividades_idtarea_Enabled = 0;
         AssignProp("", false, edtavTractividades_idtarea_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTractividades_idtarea_Enabled), 5, 0), true);
      }

      protected void RF2B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E122B2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E142B2 ();
            WB2B0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2B2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV46Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV46Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTAREAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21TrGestionTareas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV21TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         AV46Pgmname = "WpCrearActividadTarea";
         context.Gx_err = 0;
         edtavTractividades_idtarea_Enabled = 0;
         AssignProp("", false, edtavTractividades_idtarea_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTractividades_idtarea_Enabled), 5, 0), true);
      }

      protected void STRUP2B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112B2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTractividades_id_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTractividades_id_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTRACTIVIDADES_ID");
               GX_FocusControl = edtavTractividades_id_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV38TrActividades_ID = 0;
               AssignAttri("", false, "AV38TrActividades_ID", StringUtil.LTrimStr( (decimal)(AV38TrActividades_ID), 13, 0));
            }
            else
            {
               AV38TrActividades_ID = (long)(context.localUtil.CToN( cgiGet( edtavTractividades_id_Internalname), ".", ","));
               AssignAttri("", false, "AV38TrActividades_ID", StringUtil.LTrimStr( (decimal)(AV38TrActividades_ID), 13, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTractividades_idtarea_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTractividades_idtarea_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTRACTIVIDADES_IDTAREA");
               GX_FocusControl = edtavTractividades_idtarea_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV39TrActividades_IDTarea = 0;
               AssignAttri("", false, "AV39TrActividades_IDTarea", StringUtil.LTrimStr( (decimal)(AV39TrActividades_IDTarea), 13, 0));
            }
            else
            {
               AV39TrActividades_IDTarea = (long)(context.localUtil.CToN( cgiGet( edtavTractividades_idtarea_Internalname), ".", ","));
               AssignAttri("", false, "AV39TrActividades_IDTarea", StringUtil.LTrimStr( (decimal)(AV39TrActividades_IDTarea), 13, 0));
            }
            AV34TrActividades_Nombre = cgiGet( edtavTractividades_nombre_Internalname);
            AssignAttri("", false, "AV34TrActividades_Nombre", AV34TrActividades_Nombre);
            AV37TrActividades_Descripcion = cgiGet( edtavTractividades_descripcion_Internalname);
            AssignAttri("", false, "AV37TrActividades_Descripcion", AV37TrActividades_Descripcion);
            if ( context.localUtil.VCDate( cgiGet( edtavTractividades_fechainicio_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Actividades_Fecha Inicio"}), 1, "vTRACTIVIDADES_FECHAINICIO");
               GX_FocusControl = edtavTractividades_fechainicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV40TrActividades_FechaInicio = DateTime.MinValue;
               AssignAttri("", false, "AV40TrActividades_FechaInicio", context.localUtil.Format(AV40TrActividades_FechaInicio, "99/99/9999"));
            }
            else
            {
               AV40TrActividades_FechaInicio = context.localUtil.CToD( cgiGet( edtavTractividades_fechainicio_Internalname), 2);
               AssignAttri("", false, "AV40TrActividades_FechaInicio", context.localUtil.Format(AV40TrActividades_FechaInicio, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTractividades_fechafin_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Actividades_Fecha Fin"}), 1, "vTRACTIVIDADES_FECHAFIN");
               GX_FocusControl = edtavTractividades_fechafin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV41TrActividades_FechaFin = DateTime.MinValue;
               AssignAttri("", false, "AV41TrActividades_FechaFin", context.localUtil.Format(AV41TrActividades_FechaFin, "99/99/9999"));
            }
            else
            {
               AV41TrActividades_FechaFin = context.localUtil.CToD( cgiGet( edtavTractividades_fechafin_Internalname), 2);
               AssignAttri("", false, "AV41TrActividades_FechaFin", context.localUtil.Format(AV41TrActividades_FechaFin, "99/99/9999"));
            }
            cmbavTractividades_estado.CurrentValue = cgiGet( cmbavTractividades_estado_Internalname);
            AV42TrActividades_Estado = (short)(NumberUtil.Val( cgiGet( cmbavTractividades_estado_Internalname), "."));
            AssignAttri("", false, "AV42TrActividades_Estado", StringUtil.LTrimStr( (decimal)(AV42TrActividades_Estado), 4, 0));
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
         AV39TrActividades_IDTarea = AV21TrGestionTareas_ID;
         AssignAttri("", false, "AV39TrActividades_IDTarea", StringUtil.LTrimStr( (decimal)(AV39TrActividades_IDTarea), 13, 0));
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
         E112B2 ();
         if (returnInSub) return;
      }

      protected void E112B2( )
      {
         /* Start Routine */
         if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "",  "TrActividades",  "None",  "",  AV46Pgmname) )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim("TrActividades")) + "," + UrlEncode(StringUtil.RTrim("None")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(AV46Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            /* Execute user subroutine: 'U_OPENPAGE' */
            S112 ();
            if (returnInSub) return;
         }
      }

      protected void E122B2( )
      {
         /* Refresh Routine */
         if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "",  "TrActividades",  "None",  "",  AV46Pgmname) )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim("TrActividades")) + "," + UrlEncode(StringUtil.RTrim("None")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(AV46Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            /* Execute user subroutine: 'U_STARTPAGE' */
            S122 ();
            if (returnInSub) return;
            edtavTractividades_id_Visible = 0;
            AssignProp("", false, edtavTractividades_id_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTractividades_id_Visible), 5, 0), true);
            /* Execute user subroutine: 'U_REFRESHPAGE' */
            S132 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E132B2( )
      {
         /* 'E_CrearActividad' Routine */
         /* Execute user subroutine: 'U_CREARACTIVIDAD' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43GestionActividades_SDT", AV43GestionActividades_SDT);
      }

      protected void S142( )
      {
         /* 'U_CREARACTIVIDAD' Routine */
         AV43GestionActividades_SDT.gxTpr_Tractividades_idtarea = AV21TrGestionTareas_ID;
         AV43GestionActividades_SDT.gxTpr_Tractividades_nombre = AV34TrActividades_Nombre;
         AV43GestionActividades_SDT.gxTpr_Tractividades_descripcion = AV37TrActividades_Descripcion;
         AV43GestionActividades_SDT.gxTpr_Tractividades_fechafin = AV41TrActividades_FechaFin;
         AV43GestionActividades_SDT.gxTpr_Tractividades_fechainicio = AV40TrActividades_FechaInicio;
         AV43GestionActividades_SDT.gxTpr_Tractividades_estado = AV42TrActividades_Estado;
         new prgestionaractividades(context ).execute(  AV43GestionActividades_SDT,  "INS") ;
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

      protected void E142B2( )
      {
         /* Load Routine */
      }

      protected void wb_table1_79_2B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableleft_actions_Internalname, tblActionscontainertableleft_actions_Internalname, "", "K2BToolsTableActionsLeftContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCrearactividad_Internalname, "", "Crear Actividad", bttCrearactividad_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_CREARACTIVIDAD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpCrearActividadTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_79_2B2e( true) ;
         }
         else
         {
            wb_table1_79_2B2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV21TrGestionTareas_ID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV21TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(AV21TrGestionTareas_ID), 13, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV21TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
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
         PA2B2( ) ;
         WS2B2( ) ;
         WE2B2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210211857747", true, true);
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
         context.AddJavascriptSource("wpcrearactividadtarea.js", "?202210211857747", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavTractividades_estado.Name = "vTRACTIVIDADES_ESTADO";
         cmbavTractividades_estado.WebTags = "";
         cmbavTractividades_estado.addItem("1", "Nuevo", 0);
         cmbavTractividades_estado.addItem("2", "En Progreso", 0);
         cmbavTractividades_estado.addItem("3", "Completado", 0);
         cmbavTractividades_estado.addItem("4", "Detenido", 0);
         cmbavTractividades_estado.addItem("5", "Pendiente", 0);
         if ( cmbavTractividades_estado.ItemCount > 0 )
         {
            AV42TrActividades_Estado = (short)(NumberUtil.Val( cmbavTractividades_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV42TrActividades_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV42TrActividades_Estado", StringUtil.LTrimStr( (decimal)(AV42TrActividades_Estado), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divSection2_Internalname = "SECTION2";
         divTable1_Internalname = "TABLE1";
         edtavTractividades_id_Internalname = "vTRACTIVIDADES_ID";
         divTable_container_tractividades_id_Internalname = "TABLE_CONTAINER_TRACTIVIDADES_ID";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtavTractividades_idtarea_Internalname = "vTRACTIVIDADES_IDTAREA";
         divTable_container_tractividades_idtarea_Internalname = "TABLE_CONTAINER_TRACTIVIDADES_IDTAREA";
         lblTextblock_Internalname = "TEXTBLOCK";
         edtavTractividades_nombre_Internalname = "vTRACTIVIDADES_NOMBRE";
         divTable_container_tractividades_nombre_Internalname = "TABLE_CONTAINER_TRACTIVIDADES_NOMBRE";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtavTractividades_descripcion_Internalname = "vTRACTIVIDADES_DESCRIPCION";
         divTable_container_tractividades_descripcion_Internalname = "TABLE_CONTAINER_TRACTIVIDADES_DESCRIPCION";
         lblTractividades_fechainicio_var_lefttext_Internalname = "TRACTIVIDADES_FECHAINICIO_VAR_LEFTTEXT";
         edtavTractividades_fechainicio_Internalname = "vTRACTIVIDADES_FECHAINICIO";
         lblTractividades_fechafin_var_lefttext_Internalname = "TRACTIVIDADES_FECHAFIN_VAR_LEFTTEXT";
         edtavTractividades_fechafin_Internalname = "vTRACTIVIDADES_FECHAFIN";
         divTable_container_tractividades_fechainiciofieldcontainer_Internalname = "TABLE_CONTAINER_TRACTIVIDADES_FECHAINICIOFIELDCONTAINER";
         divTable_container_tractividades_fechainicio_Internalname = "TABLE_CONTAINER_TRACTIVIDADES_FECHAINICIO";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         cmbavTractividades_estado_Internalname = "vTRACTIVIDADES_ESTADO";
         divTable_container_tractividades_estado_Internalname = "TABLE_CONTAINER_TRACTIVIDADES_ESTADO";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divResponsivetable_mainattributes_attributes_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES";
         divMaingroupresponsivetable_group_Internalname = "MAINGROUPRESPONSIVETABLE_GROUP";
         grpGroup_Internalname = "GROUP";
         bttCrearactividad_Internalname = "CREARACTIVIDAD";
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
         cmbavTractividades_estado_Jsonclick = "";
         cmbavTractividades_estado.Enabled = 1;
         edtavTractividades_fechafin_Jsonclick = "";
         edtavTractividades_fechafin_Enabled = 1;
         edtavTractividades_fechainicio_Jsonclick = "";
         edtavTractividades_fechainicio_Enabled = 1;
         edtavTractividades_descripcion_Enabled = 1;
         edtavTractividades_nombre_Jsonclick = "";
         edtavTractividades_nombre_Enabled = 1;
         edtavTractividades_idtarea_Jsonclick = "";
         edtavTractividades_idtarea_Enabled = 1;
         edtavTractividades_id_Jsonclick = "";
         edtavTractividades_id_Enabled = 1;
         edtavTractividades_id_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Crear actividad de tarea";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'edtavTractividades_id_Visible',ctrl:'vTRACTIVIDADES_ID',prop:'Visible'},{av:'AV39TrActividades_IDTarea',fld:'vTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'}]}");
         setEventMetadata("'E_CREARACTIVIDAD'","{handler:'E132B2',iparms:[{av:'AV21TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV43GestionActividades_SDT',fld:'vGESTIONACTIVIDADES_SDT',pic:''},{av:'AV34TrActividades_Nombre',fld:'vTRACTIVIDADES_NOMBRE',pic:''},{av:'AV37TrActividades_Descripcion',fld:'vTRACTIVIDADES_DESCRIPCION',pic:''},{av:'AV41TrActividades_FechaFin',fld:'vTRACTIVIDADES_FECHAFIN',pic:''},{av:'AV40TrActividades_FechaInicio',fld:'vTRACTIVIDADES_FECHAINICIO',pic:''},{av:'cmbavTractividades_estado'},{av:'AV42TrActividades_Estado',fld:'vTRACTIVIDADES_ESTADO',pic:'ZZZ9'}]");
         setEventMetadata("'E_CREARACTIVIDAD'",",oparms:[{av:'AV43GestionActividades_SDT',fld:'vGESTIONACTIVIDADES_SDT',pic:''}]}");
         setEventMetadata("VALIDV_TRACTIVIDADES_FECHAINICIO","{handler:'Validv_Tractividades_fechainicio',iparms:[]");
         setEventMetadata("VALIDV_TRACTIVIDADES_FECHAINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_TRACTIVIDADES_FECHAFIN","{handler:'Validv_Tractividades_fechafin',iparms:[]");
         setEventMetadata("VALIDV_TRACTIVIDADES_FECHAFIN",",oparms:[]}");
         setEventMetadata("VALIDV_TRACTIVIDADES_ESTADO","{handler:'Validv_Tractividades_estado',iparms:[]");
         setEventMetadata("VALIDV_TRACTIVIDADES_ESTADO",",oparms:[]}");
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
         AV46Pgmname = "";
         GXKey = "";
         AV43GestionActividades_SDT = new SdtGestionActividades_SDT(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock_Jsonclick = "";
         AV34TrActividades_Nombre = "";
         lblTextblock1_Jsonclick = "";
         AV37TrActividades_Descripcion = "";
         lblTractividades_fechainicio_var_lefttext_Jsonclick = "";
         AV40TrActividades_FechaInicio = DateTime.MinValue;
         lblTractividades_fechafin_var_lefttext_Jsonclick = "";
         AV41TrActividades_FechaFin = DateTime.MinValue;
         lblTextblock3_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         sStyleString = "";
         bttCrearactividad_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         AV46Pgmname = "WpCrearActividadTarea";
         /* GeneXus formulas. */
         AV46Pgmname = "WpCrearActividadTarea";
         context.Gx_err = 0;
         edtavTractividades_idtarea_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV42TrActividades_Estado ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavTractividades_id_Enabled ;
      private int edtavTractividades_id_Visible ;
      private int edtavTractividades_idtarea_Enabled ;
      private int edtavTractividades_nombre_Enabled ;
      private int edtavTractividades_descripcion_Enabled ;
      private int edtavTractividades_fechainicio_Enabled ;
      private int edtavTractividades_fechafin_Enabled ;
      private int idxLst ;
      private long AV21TrGestionTareas_ID ;
      private long wcpOAV21TrGestionTareas_ID ;
      private long AV38TrActividades_ID ;
      private long AV39TrActividades_IDTarea ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String AV46Pgmname ;
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
      private String divTable_container_tractividades_id_Internalname ;
      private String TempTags ;
      private String edtavTractividades_id_Internalname ;
      private String edtavTractividades_id_Jsonclick ;
      private String lblTextblock2_Internalname ;
      private String lblTextblock2_Jsonclick ;
      private String divTable_container_tractividades_idtarea_Internalname ;
      private String edtavTractividades_idtarea_Internalname ;
      private String edtavTractividades_idtarea_Jsonclick ;
      private String lblTextblock_Internalname ;
      private String lblTextblock_Jsonclick ;
      private String divTable_container_tractividades_nombre_Internalname ;
      private String edtavTractividades_nombre_Internalname ;
      private String AV34TrActividades_Nombre ;
      private String edtavTractividades_nombre_Jsonclick ;
      private String lblTextblock1_Internalname ;
      private String lblTextblock1_Jsonclick ;
      private String divTable_container_tractividades_descripcion_Internalname ;
      private String edtavTractividades_descripcion_Internalname ;
      private String divTable_container_tractividades_fechainicio_Internalname ;
      private String divTable_container_tractividades_fechainiciofieldcontainer_Internalname ;
      private String lblTractividades_fechainicio_var_lefttext_Internalname ;
      private String lblTractividades_fechainicio_var_lefttext_Jsonclick ;
      private String edtavTractividades_fechainicio_Internalname ;
      private String edtavTractividades_fechainicio_Jsonclick ;
      private String lblTractividades_fechafin_var_lefttext_Internalname ;
      private String lblTractividades_fechafin_var_lefttext_Jsonclick ;
      private String edtavTractividades_fechafin_Internalname ;
      private String edtavTractividades_fechafin_Jsonclick ;
      private String lblTextblock3_Internalname ;
      private String lblTextblock3_Jsonclick ;
      private String divTable_container_tractividades_estado_Internalname ;
      private String cmbavTractividades_estado_Internalname ;
      private String cmbavTractividades_estado_Jsonclick ;
      private String divResponsivetable_containernode_actions_Internalname ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String sStyleString ;
      private String tblActionscontainertableleft_actions_Internalname ;
      private String bttCrearactividad_Internalname ;
      private String bttCrearactividad_Jsonclick ;
      private DateTime AV40TrActividades_FechaInicio ;
      private DateTime AV41TrActividades_FechaFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private String AV37TrActividades_Descripcion ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavTractividades_estado ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtGestionActividades_SDT AV43GestionActividades_SDT ;
   }

}
