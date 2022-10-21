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
   public class webpaneldesignerlayoutorionalwaysvisiblefilters : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public webpaneldesignerlayoutorionalwaysvisiblefilters( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public webpaneldesignerlayoutorionalwaysvisiblefilters( IGxContext context )
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridcontent") == 0 )
            {
               nRC_GXsfl_76 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_76_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_76_idx = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGridcontent_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridcontent") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGridcontent_refresh( ) ;
               AddString( context.getJSONResponse( )) ;
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
         PA192( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START192( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210202185636", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("webpaneldesignerlayoutorionalwaysvisiblefilters.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_76", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_76), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOWNLOADACTIONSTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divDownloadactionstable_Visible), 5, 0, ".", "")));
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
            WE192( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT192( ) ;
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
         return formatLink("webpaneldesignerlayoutorionalwaysvisiblefilters.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "WebPanelDesignerLayoutOrionAlwaysVisibleFilters" ;
      }

      public override String GetPgmdesc( )
      {
         return "Web Panel Designer Layout Orion Always Visible Filters" ;
      }

      protected void WB190( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Title placeholder", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, "HLP_WebPanelDesignerLayoutOrionAlwaysVisibleFilters.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divGlobalgridtable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer K2BToolsTable_WebPanelDesignerGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLeftactions_Internalname, "LeftActions", "", "", lblLeftactions_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WebPanelDesignerLayoutOrionAlwaysVisibleFilters.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTopactions_Internalname, "TopActions", "", "", lblTopactions_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WebPanelDesignerLayoutOrionAlwaysVisibleFilters.htm");
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
            GxWebStd.gx_div_start( context, divGrid_inner_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable10_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_BeforeGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_36_192( true) ;
         }
         else
         {
            wb_table1_36_192( false) ;
         }
         return  ;
      }

      protected void wb_table1_36_192e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_div_start( context, divFilterglobalcontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_OnlyDetailedFiltersContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFilterscontainer_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Filters", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WebPanelDesignerLayoutOrionAlwaysVisibleFilters.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection1_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection7_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FloatLeft", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridactionsleft_Internalname, "GridActionsLeft", "", "", lblGridactionsleft_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WebPanelDesignerLayoutOrionAlwaysVisibleFilters.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection3_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FloatRight", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridactionsright_Internalname, "GridActionsRight", "", "", lblGridactionsright_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WebPanelDesignerLayoutOrionAlwaysVisibleFilters.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridcontentContainer.SetWrapped(nGXWrapped);
            if ( GridcontentContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridcontentContainer"+"DivS\" data-gxgridid=\"76\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGridcontent_Internalname, subGridcontent_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGridcontent_Backcolorstyle == 0 )
               {
                  subGridcontent_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGridcontent_Class) > 0 )
                  {
                     subGridcontent_Linesclass = subGridcontent_Class+"Title";
                  }
               }
               else
               {
                  subGridcontent_Titlebackstyle = 1;
                  if ( subGridcontent_Backcolorstyle == 1 )
                  {
                     subGridcontent_Titlebackcolor = subGridcontent_Allbackcolor;
                     if ( StringUtil.Len( subGridcontent_Class) > 0 )
                     {
                        subGridcontent_Linesclass = subGridcontent_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGridcontent_Class) > 0 )
                     {
                        subGridcontent_Linesclass = subGridcontent_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlTextNl( "</tr>") ;
               GridcontentContainer.AddObjectProperty("GridName", "Gridcontent");
            }
            else
            {
               GridcontentContainer.AddObjectProperty("GridName", "Gridcontent");
               GridcontentContainer.AddObjectProperty("Header", subGridcontent_Header);
               GridcontentContainer.AddObjectProperty("Class", "Grid");
               GridcontentContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridcontentContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridcontentContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcontent_Backcolorstyle), 1, 0, ".", "")));
               GridcontentContainer.AddObjectProperty("CmpContext", "");
               GridcontentContainer.AddObjectProperty("InMasterPage", "false");
               GridcontentContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcontent_Selectedindex), 4, 0, ".", "")));
               GridcontentContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcontent_Allowselection), 1, 0, ".", "")));
               GridcontentContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcontent_Selectioncolor), 9, 0, ".", "")));
               GridcontentContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcontent_Allowhovering), 1, 0, ".", "")));
               GridcontentContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcontent_Hoveringcolor), 9, 0, ".", "")));
               GridcontentContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcontent_Allowcollapsing), 1, 0, ".", "")));
               GridcontentContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcontent_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 76 )
         {
            wbEnd = 0;
            nRC_GXsfl_76 = (int)(nGXsfl_76_idx-1);
            if ( GridcontentContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridcontentContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridcontent", GridcontentContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridcontentContainerData", GridcontentContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridcontentContainerData"+"V", GridcontentContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridcontentContainerData"+"V"+"\" value='"+GridcontentContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            wb_table2_80_192( true) ;
         }
         else
         {
            wb_table2_80_192( false) ;
         }
         return  ;
      }

      protected void wb_table2_80_192e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            wb_table3_86_192( true) ;
         }
         else
         {
            wb_table3_86_192( false) ;
         }
         return  ;
      }

      protected void wb_table3_86_192e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection8_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            wb_table4_92_192( true) ;
         }
         else
         {
            wb_table4_92_192( false) ;
         }
         return  ;
      }

      protected void wb_table4_92_192e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridrecordcount_Internalname, "Record count", "", "", lblGridrecordcount_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BT_RecordCount", 0, "", 1, 1, 0, "HLP_WebPanelDesignerLayoutOrionAlwaysVisibleFilters.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblBottomactions_Internalname, "BottomActions", "", "", lblBottomactions_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WebPanelDesignerLayoutOrionAlwaysVisibleFilters.htm");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblHiddenitems_Internalname, "HiddenItems", "", "", lblHiddenitems_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WebPanelDesignerLayoutOrionAlwaysVisibleFilters.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblConditionalconfirm_Internalname, "ConditionalConfirm", "", "", lblConditionalconfirm_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WebPanelDesignerLayoutOrionAlwaysVisibleFilters.htm");
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
         if ( wbEnd == 76 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridcontentContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridcontentContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridcontent", GridcontentContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridcontentContainerData", GridcontentContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridcontentContainerData"+"V", GridcontentContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridcontentContainerData"+"V"+"\" value='"+GridcontentContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START192( )
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
            Form.Meta.addItem("description", "Web Panel Designer Layout Orion Always Visible Filters", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP190( ) ;
      }

      protected void WS192( )
      {
         START192( ) ;
         EVT192( ) ;
      }

      protected void EVT192( )
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
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_76_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
                              SubsflControlProps_762( ) ;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11192 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12192 ();
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
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE192( )
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

      protected void PA192( )
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridcontent_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_762( ) ;
         while ( nGXsfl_76_idx <= nRC_GXsfl_76 )
         {
            sendrow_762( ) ;
            nGXsfl_76_idx = ((subGridcontent_Islastpage==1)&&(nGXsfl_76_idx+1>subGridcontent_fnc_Recordsperpage( )) ? 1 : nGXsfl_76_idx+1);
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
            SubsflControlProps_762( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridcontentContainer)) ;
         /* End function gxnrGridcontent_newrow */
      }

      protected void gxgrGridcontent_refresh( )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDCONTENT_nCurrentRecord = 0;
         RF192( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridcontent_refresh */
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
         RF192( ) ;
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

      protected void RF192( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridcontentContainer.ClearRows();
         }
         wbStart = 76;
         nGXsfl_76_idx = 1;
         sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
         SubsflControlProps_762( ) ;
         bGXsfl_76_Refreshing = true;
         GridcontentContainer.AddObjectProperty("GridName", "Gridcontent");
         GridcontentContainer.AddObjectProperty("CmpContext", "");
         GridcontentContainer.AddObjectProperty("InMasterPage", "false");
         GridcontentContainer.AddObjectProperty("Class", "Grid");
         GridcontentContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridcontentContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridcontentContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcontent_Backcolorstyle), 1, 0, ".", "")));
         GridcontentContainer.PageSize = subGridcontent_fnc_Recordsperpage( );
         if ( subGridcontent_Islastpage != 0 )
         {
            GRIDCONTENT_nFirstRecordOnPage = (long)(subGridcontent_fnc_Recordcount( )-subGridcontent_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRIDCONTENT_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDCONTENT_nFirstRecordOnPage), 15, 0, ".", "")));
            GridcontentContainer.AddObjectProperty("GRIDCONTENT_nFirstRecordOnPage", GRIDCONTENT_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_762( ) ;
            /* Execute user event: Load */
            E12192 ();
            wbEnd = 76;
            WB190( ) ;
         }
         bGXsfl_76_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes192( )
      {
      }

      protected int subGridcontent_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridcontent_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridcontent_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridcontent_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP190( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11192 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_76 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_76"), ".", ","));
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11192 ();
         if (returnInSub) return;
      }

      protected void E11192( )
      {
         /* Start Routine */
         divDownloadactionstable_Visible = 0;
         AssignProp("", false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
      }

      private void E12192( )
      {
         /* Load Routine */
      }

      protected void wb_table4_92_192( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblPagingcontainer_Internalname, tblPagingcontainer_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Paging", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WebPanelDesignerLayoutOrionAlwaysVisibleFilters.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_92_192e( true) ;
         }
         else
         {
            wb_table4_92_192e( false) ;
         }
      }

      protected void wb_table3_86_192( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblOrderbycontainer_Internalname, tblOrderbycontainer_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblOrderby_Internalname, "OrderedBy", "", "", lblOrderby_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WebPanelDesignerLayoutOrionAlwaysVisibleFilters.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_86_192e( true) ;
         }
         else
         {
            wb_table3_86_192e( false) ;
         }
      }

      protected void wb_table2_80_192( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblSummarycontainer_Internalname, tblSummarycontainer_Internalname, "", "K2BToolsTable_FloatRight", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Summary", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WebPanelDesignerLayoutOrionAlwaysVisibleFilters.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_80_192e( true) ;
         }
         else
         {
            wb_table2_80_192e( false) ;
         }
      }

      protected void wb_table1_36_192( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable7_Internalname, tblTable7_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettingscontainer_Internalname, "GridSettingsContainer", "", "", lblGridsettingscontainer_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WebPanelDesignerLayoutOrionAlwaysVisibleFilters.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnmanagement_Internalname, "RuntimeColumnManagement", "", "", lblRuntimecolumnmanagement_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WebPanelDesignerLayoutOrionAlwaysVisibleFilters.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divDownloadsactionssectioncontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_DownloadActionsContainer ControlBeautify_ParentCollapsableTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgDownloadsactiontoggle_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgDownloadsactiontoggle_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13191_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WebPanelDesignerLayoutOrionAlwaysVisibleFilters.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDownloadactionstable_Internalname, divDownloadactionstable_Visible, 0, "px", 0, "px", "K2BToolsDownloadActionsTable ControlBeautify_CollapsableTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDownloadsactionssection_Internalname, "DownloadsActionsSection", "", "", lblDownloadsactionssection_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WebPanelDesignerLayoutOrionAlwaysVisibleFilters.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblRightactions_Internalname, "RightActions", "", "", lblRightactions_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WebPanelDesignerLayoutOrionAlwaysVisibleFilters.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_36_192e( true) ;
         }
         else
         {
            wb_table1_36_192e( false) ;
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
         PA192( ) ;
         WS192( ) ;
         WE192( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210202185693", true, true);
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
         context.AddJavascriptSource("webpaneldesignerlayoutorionalwaysvisiblefilters.js", "?202210202185693", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_762( )
      {
      }

      protected void SubsflControlProps_fel_762( )
      {
      }

      protected void sendrow_762( )
      {
         SubsflControlProps_762( ) ;
         WB190( ) ;
         GridcontentRow = GXWebRow.GetNew(context,GridcontentContainer);
         if ( subGridcontent_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridcontent_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridcontent_Class, "") != 0 )
            {
               subGridcontent_Linesclass = subGridcontent_Class+"Odd";
            }
         }
         else if ( subGridcontent_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridcontent_Backstyle = 0;
            subGridcontent_Backcolor = subGridcontent_Allbackcolor;
            if ( StringUtil.StrCmp(subGridcontent_Class, "") != 0 )
            {
               subGridcontent_Linesclass = subGridcontent_Class+"Uniform";
            }
         }
         else if ( subGridcontent_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridcontent_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridcontent_Class, "") != 0 )
            {
               subGridcontent_Linesclass = subGridcontent_Class+"Odd";
            }
            subGridcontent_Backcolor = (int)(0x0);
         }
         else if ( subGridcontent_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridcontent_Backstyle = 1;
            if ( ((int)((nGXsfl_76_idx) % (2))) == 0 )
            {
               subGridcontent_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridcontent_Class, "") != 0 )
               {
                  subGridcontent_Linesclass = subGridcontent_Class+"Even";
               }
            }
            else
            {
               subGridcontent_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridcontent_Class, "") != 0 )
               {
                  subGridcontent_Linesclass = subGridcontent_Class+"Odd";
               }
            }
         }
         if ( GridcontentContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"Grid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_76_idx+"\">") ;
         }
         send_integrity_lvl_hashes192( ) ;
         GridcontentContainer.AddRow(GridcontentRow);
         nGXsfl_76_idx = ((subGridcontent_Islastpage==1)&&(nGXsfl_76_idx+1>subGridcontent_fnc_Recordsperpage( )) ? 1 : nGXsfl_76_idx+1);
         sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
         SubsflControlProps_762( ) ;
         /* End function sendrow_762 */
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
         lblLeftactions_Internalname = "LEFTACTIONS";
         lblTopactions_Internalname = "TOPACTIONS";
         divTable2_Internalname = "TABLE2";
         lblGridsettingscontainer_Internalname = "GRIDSETTINGSCONTAINER";
         lblRuntimecolumnmanagement_Internalname = "RUNTIMECOLUMNMANAGEMENT";
         imgDownloadsactiontoggle_Internalname = "DOWNLOADSACTIONTOGGLE";
         lblDownloadsactionssection_Internalname = "DOWNLOADSACTIONSSECTION";
         divDownloadactionstable_Internalname = "DOWNLOADACTIONSTABLE";
         divDownloadsactionssectioncontainer_Internalname = "DOWNLOADSACTIONSSECTIONCONTAINER";
         lblRightactions_Internalname = "RIGHTACTIONS";
         tblTable7_Internalname = "TABLE7";
         divTable10_Internalname = "TABLE10";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         divFilterscontainer_Internalname = "FILTERSCONTAINER";
         divFilterglobalcontainer_Internalname = "FILTERGLOBALCONTAINER";
         lblGridactionsleft_Internalname = "GRIDACTIONSLEFT";
         divSection7_Internalname = "SECTION7";
         lblGridactionsright_Internalname = "GRIDACTIONSRIGHT";
         divSection3_Internalname = "SECTION3";
         divSection1_Internalname = "SECTION1";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         tblSummarycontainer_Internalname = "SUMMARYCONTAINER";
         lblOrderby_Internalname = "ORDERBY";
         tblOrderbycontainer_Internalname = "ORDERBYCONTAINER";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         tblPagingcontainer_Internalname = "PAGINGCONTAINER";
         lblGridrecordcount_Internalname = "GRIDRECORDCOUNT";
         divSection8_Internalname = "SECTION8";
         lblBottomactions_Internalname = "BOTTOMACTIONS";
         divTable3_Internalname = "TABLE3";
         divGrid_inner_Internalname = "GRID_INNER";
         divGlobalgridtable_Internalname = "GLOBALGRIDTABLE";
         divContenttable_Internalname = "CONTENTTABLE";
         lblHiddenitems_Internalname = "HIDDENITEMS";
         lblConditionalconfirm_Internalname = "CONDITIONALCONFIRM";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridcontent_Internalname = "GRIDCONTENT";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         divDownloadactionstable_Visible = 1;
         subGridcontent_Allowcollapsing = 0;
         subGridcontent_Allowselection = 0;
         subGridcontent_Header = "";
         subGridcontent_Class = "Grid";
         subGridcontent_Backcolorstyle = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Web Panel Designer Layout Orion Always Visible Filters";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDCONTENT_nFirstRecordOnPage'},{av:'GRIDCONTENT_nEOF'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("DOWNLOADSACTIONTOGGLE.CLICK","{handler:'E13191',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'}]");
         setEventMetadata("DOWNLOADSACTIONTOGGLE.CLICK",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'}]}");
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
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblLeftactions_Jsonclick = "";
         lblTopactions_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         lblGridactionsleft_Jsonclick = "";
         lblGridactionsright_Jsonclick = "";
         GridcontentContainer = new GXWebGrid( context);
         sStyleString = "";
         subGridcontent_Linesclass = "";
         lblGridrecordcount_Jsonclick = "";
         lblBottomactions_Jsonclick = "";
         lblHiddenitems_Jsonclick = "";
         lblConditionalconfirm_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         lblTextblock1_Jsonclick = "";
         lblOrderby_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         lblGridsettingscontainer_Jsonclick = "";
         lblRuntimecolumnmanagement_Jsonclick = "";
         TempTags = "";
         sImgUrl = "";
         imgDownloadsactiontoggle_Jsonclick = "";
         lblDownloadsactionssection_Jsonclick = "";
         lblRightactions_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         GridcontentRow = new GXWebRow();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGridcontent_Backcolorstyle ;
      private short subGridcontent_Titlebackstyle ;
      private short subGridcontent_Allowselection ;
      private short subGridcontent_Allowhovering ;
      private short subGridcontent_Allowcollapsing ;
      private short subGridcontent_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGridcontent_Backstyle ;
      private short GRIDCONTENT_nEOF ;
      private int divDownloadactionstable_Visible ;
      private int nRC_GXsfl_76 ;
      private int nGXsfl_76_idx=1 ;
      private int subGridcontent_Titlebackcolor ;
      private int subGridcontent_Allbackcolor ;
      private int subGridcontent_Selectedindex ;
      private int subGridcontent_Selectioncolor ;
      private int subGridcontent_Hoveringcolor ;
      private int subGridcontent_Islastpage ;
      private int idxLst ;
      private int subGridcontent_Backcolor ;
      private long GRIDCONTENT_nCurrentRecord ;
      private long GRIDCONTENT_nFirstRecordOnPage ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_76_idx="0001" ;
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
      private String divGlobalgridtable_Internalname ;
      private String divTable2_Internalname ;
      private String lblLeftactions_Internalname ;
      private String lblLeftactions_Jsonclick ;
      private String lblTopactions_Internalname ;
      private String lblTopactions_Jsonclick ;
      private String divGrid_inner_Internalname ;
      private String divTable10_Internalname ;
      private String divFilterglobalcontainer_Internalname ;
      private String divFilterscontainer_Internalname ;
      private String lblTextblock4_Internalname ;
      private String lblTextblock4_Jsonclick ;
      private String divTable3_Internalname ;
      private String divSection1_Internalname ;
      private String divSection7_Internalname ;
      private String lblGridactionsleft_Internalname ;
      private String lblGridactionsleft_Jsonclick ;
      private String divSection3_Internalname ;
      private String lblGridactionsright_Internalname ;
      private String lblGridactionsright_Jsonclick ;
      private String sStyleString ;
      private String subGridcontent_Internalname ;
      private String subGridcontent_Class ;
      private String subGridcontent_Linesclass ;
      private String subGridcontent_Header ;
      private String divSection8_Internalname ;
      private String lblGridrecordcount_Internalname ;
      private String lblGridrecordcount_Jsonclick ;
      private String lblBottomactions_Internalname ;
      private String lblBottomactions_Jsonclick ;
      private String lblHiddenitems_Internalname ;
      private String lblHiddenitems_Jsonclick ;
      private String lblConditionalconfirm_Internalname ;
      private String lblConditionalconfirm_Jsonclick ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String divDownloadactionstable_Internalname ;
      private String tblPagingcontainer_Internalname ;
      private String lblTextblock1_Internalname ;
      private String lblTextblock1_Jsonclick ;
      private String tblOrderbycontainer_Internalname ;
      private String lblOrderby_Internalname ;
      private String lblOrderby_Jsonclick ;
      private String tblSummarycontainer_Internalname ;
      private String lblTextblock2_Internalname ;
      private String lblTextblock2_Jsonclick ;
      private String tblTable7_Internalname ;
      private String lblGridsettingscontainer_Internalname ;
      private String lblGridsettingscontainer_Jsonclick ;
      private String lblRuntimecolumnmanagement_Internalname ;
      private String lblRuntimecolumnmanagement_Jsonclick ;
      private String divDownloadsactionssectioncontainer_Internalname ;
      private String TempTags ;
      private String sImgUrl ;
      private String imgDownloadsactiontoggle_Internalname ;
      private String imgDownloadsactiontoggle_Jsonclick ;
      private String lblDownloadsactionssection_Internalname ;
      private String lblDownloadsactionssection_Jsonclick ;
      private String lblRightactions_Internalname ;
      private String lblRightactions_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_76_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GXWebGrid GridcontentContainer ;
      private GXWebRow GridcontentRow ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

}
