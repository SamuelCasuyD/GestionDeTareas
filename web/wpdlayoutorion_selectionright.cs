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
   public class wpdlayoutorion_selectionright : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpdlayoutorion_selectionright( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public wpdlayoutorion_selectionright( IGxContext context )
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
               nRC_GXsfl_118 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_118_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_118_idx = GetNextPar( );
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
         PA152( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START152( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210211744739", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpdlayoutorion_selectionright.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_118", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_118), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERCOLLAPSIBLESECTION_COMBINED_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERCOLLAPSIBLESECTION_ONLYDETAILED_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divFiltercollapsiblesection_onlydetailed_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOWNLOADACTIONSTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divDownloadactionstable_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERCOLLAPSIBLESECTION_COMBINED_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERCOLLAPSIBLESECTION_ONLYDETAILED_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divFiltercollapsiblesection_onlydetailed_Visible), 5, 0, ".", "")));
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
            WE152( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT152( ) ;
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
         return formatLink("wpdlayoutorion_selectionright.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "WPDLayoutOrion_SelectionRight" ;
      }

      public override String GetPgmdesc( )
      {
         return "Grid with selection on the right" ;
      }

      protected void WB150( )
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Title placeholder", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLeftactions_Internalname, "LeftActions", "", "", lblLeftactions_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTopactions_Internalname, "TopActions", "", "", lblTopactions_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
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
            GxWebStd.gx_div_start( context, divTable6_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
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
            wb_table1_38_152( true) ;
         }
         else
         {
            wb_table1_38_152( false) ;
         }
         return  ;
      }

      protected void wb_table1_38_152e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFilterglobalcontainer_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCombinedfilterlayout_Internalname, 1, 0, "px", 0, "px", "ControlBeautify_ParentCollapsableTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection4_Internalname, 1, 0, "px", 0, "px", "K2BToolsSection_CombinedFilters", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV5K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV5K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPDLayoutOrion_SelectionRight.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgFiltertoggle_combined_Bitmap;
            GxWebStd.gx_bitmap( context, imgFiltertoggle_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFiltertoggle_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERTOGGLE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPDLayoutOrion_SelectionRight.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFiltersummary_combined_Internalname, "Filter Summary", "", "", lblFiltersummary_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_FilterSummary", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFiltercollapsiblesection_combined_Internalname, divFiltercollapsiblesection_combined_Visible, 0, "px", 0, "px", "K2BToolsTable_FilterCollapsibleTable ControlBeautify_CollapsableTable", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "9aecb836-6551-428a-b43d-2dcaf78773a5", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgFilterclose_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFilterclose_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERCLOSE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPDLayoutOrion_SelectionRight.htm");
            wb_table2_74_152( true) ;
         }
         else
         {
            wb_table2_74_152( false) ;
         }
         return  ;
      }

      protected void wb_table2_74_152e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_div_start( context, divOnlydetailedfilterlayout_Internalname, 1, 0, "px", 0, "px", "ControlBeautify_ParentCollapsableTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection5_Internalname, 1, 0, "px", 0, "px", "K2BToolsSection_OnlyDetailedFilters", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgFiltertoggle_onlydetailed_Bitmap;
            GxWebStd.gx_bitmap( context, imgFiltertoggle_onlydetailed_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFiltertoggle_onlydetailed_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERTOGGLE_ONLYDETAILED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPDLayoutOrion_SelectionRight.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFiltersummary_onlydetailed_Internalname, "Filter Summary", "", "", lblFiltersummary_onlydetailed_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_FilterSummary", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFiltercollapsiblesection_onlydetailed_Internalname, divFiltercollapsiblesection_onlydetailed_Visible, 0, "px", 0, "px", "K2BToolsTable_FilterCollapsibleTable ControlBeautify_CollapsableTable", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "9aecb836-6551-428a-b43d-2dcaf78773a5", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgFilterclose_onlydetailed_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFilterclose_onlydetailed_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERCLOSE_ONLYDETAILED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPDLayoutOrion_SelectionRight.htm");
            wb_table3_90_152( true) ;
         }
         else
         {
            wb_table3_90_152( false) ;
         }
         return  ;
      }

      protected void wb_table3_90_152e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_div_start( context, divOnlygenericfilterlayout_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection6_Internalname, 1, 0, "px", 0, "px", "K2BToolsSection_OnlyGenericFilter", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV5K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV5K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPDLayoutOrion_SelectionRight.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable5_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridactionsleft_Internalname, "GridActionsLeft", "", "", lblGridactionsleft_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            wb_table4_112_152( true) ;
         }
         else
         {
            wb_table4_112_152( false) ;
         }
         return  ;
      }

      protected void wb_table4_112_152e( bool wbgen )
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
            /*  Grid Control  */
            GridcontentContainer.SetWrapped(nGXWrapped);
            if ( GridcontentContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridcontentContainer"+"DivS\" data-gxgridid=\"118\">") ;
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
         if ( wbEnd == 118 )
         {
            wbEnd = 0;
            nRC_GXsfl_118 = (int)(nGXsfl_118_idx-1);
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
            wb_table5_122_152( true) ;
         }
         else
         {
            wb_table5_122_152( false) ;
         }
         return  ;
      }

      protected void wb_table5_122_152e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridrecordcount_Internalname, "Record count", "", "", lblGridrecordcount_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            wb_table6_130_152( true) ;
         }
         else
         {
            wb_table6_130_152( false) ;
         }
         return  ;
      }

      protected void wb_table6_130_152e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            wb_table7_135_152( true) ;
         }
         else
         {
            wb_table7_135_152( false) ;
         }
         return  ;
      }

      protected void wb_table7_135_152e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblBottomactions_Internalname, "BottomActions", "", "", lblBottomactions_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 K2BT_SelectedItemsCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable4_Internalname, 1, 0, "px", 0, "px", "K2BT_SelectedItems", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSelectionsummaryselecteditemstextblock_Internalname, "Selected Items", "", "", lblSelectionsummaryselecteditemstextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextblock_SmallTitle", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSelectionsummary_Internalname, "Selection Summary", "", "", lblSelectionsummary_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSelectionsummarynoitemstable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_NoResultsFound", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "K2BT_NoSelectedItemsImage";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "98da6132-a7a6-4d48-b25f-7111db311c1b", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPDLayoutOrion_SelectionRight.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSelectionsummarynoitemstextblock_Internalname, "Text Block", "", "", lblSelectionsummarynoitemstextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BT_NoItemsSelectedTextblock", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblHiddenitems_Internalname, "HiddenItems", "", "", lblHiddenitems_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblConditionalconfirm_Internalname, "ConditionalConfirm", "", "", lblConditionalconfirm_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
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
         if ( wbEnd == 118 )
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

      protected void START152( )
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
            Form.Meta.addItem("description", "Grid with selection on the right", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP150( ) ;
      }

      protected void WS152( )
      {
         START152( ) ;
         EVT152( ) ;
      }

      protected void EVT152( )
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
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTOGGLE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E11152 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERCLOSE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12152 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTOGGLE_ONLYDETAILED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E13152 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERCLOSE_ONLYDETAILED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E14152 ();
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
                              nGXsfl_118_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
                              SubsflControlProps_1182( ) ;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E15152 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E16152 ();
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

      protected void WE152( )
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

      protected void PA152( )
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
               GX_FocusControl = edtavK2btoolsgenericsearchfield_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_1182( ) ;
         while ( nGXsfl_118_idx <= nRC_GXsfl_118 )
         {
            sendrow_1182( ) ;
            nGXsfl_118_idx = ((subGridcontent_Islastpage==1)&&(nGXsfl_118_idx+1>subGridcontent_fnc_Recordsperpage( )) ? 1 : nGXsfl_118_idx+1);
            sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
            SubsflControlProps_1182( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridcontentContainer)) ;
         /* End function gxnrGridcontent_newrow */
      }

      protected void gxgrGridcontent_refresh( )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDCONTENT_nCurrentRecord = 0;
         RF152( ) ;
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
         RF152( ) ;
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

      protected void RF152( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridcontentContainer.ClearRows();
         }
         wbStart = 118;
         nGXsfl_118_idx = 1;
         sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
         SubsflControlProps_1182( ) ;
         bGXsfl_118_Refreshing = true;
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
            SubsflControlProps_1182( ) ;
            /* Execute user event: Load */
            E16152 ();
            wbEnd = 118;
            WB150( ) ;
         }
         bGXsfl_118_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes152( )
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

      protected void STRUP150( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E15152 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_118 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_118"), ".", ","));
            divFiltercollapsiblesection_combined_Visible = (int)(context.localUtil.CToN( cgiGet( "FILTERCOLLAPSIBLESECTION_COMBINED_Visible"), ".", ","));
            divFiltercollapsiblesection_onlydetailed_Visible = (int)(context.localUtil.CToN( cgiGet( "FILTERCOLLAPSIBLESECTION_ONLYDETAILED_Visible"), ".", ","));
            /* Read variables values. */
            AV5K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri("", false, "AV5K2BToolsGenericSearchField", AV5K2BToolsGenericSearchField);
            AV5K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri("", false, "AV5K2BToolsGenericSearchField", AV5K2BToolsGenericSearchField);
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
         E15152 ();
         if (returnInSub) return;
      }

      protected void E15152( )
      {
         /* Start Routine */
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         divFiltercollapsiblesection_onlydetailed_Visible = 0;
         AssignProp("", false, divFiltercollapsiblesection_onlydetailed_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_onlydetailed_Visible), 5, 0), true);
         divDownloadactionstable_Visible = 0;
         AssignProp("", false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
      }

      protected void E11152( )
      {
         /* Filtertoggle_combined_Click Routine */
         if ( divFiltercollapsiblesection_combined_Visible != 0 )
         {
            divFiltercollapsiblesection_combined_Visible = 0;
            AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
            imgFiltertoggle_combined_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
            AssignProp("", false, imgFiltertoggle_combined_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgFiltertoggle_combined_Bitmap)), true);
            AssignProp("", false, imgFiltertoggle_combined_Internalname, "SrcSet", context.GetImageSrcSet( imgFiltertoggle_combined_Bitmap), true);
         }
         else
         {
            divFiltercollapsiblesection_combined_Visible = 1;
            AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
            imgFiltertoggle_combined_Bitmap = context.GetImagePath( "0f563368-53de-4c84-a145-c3119aedd1ee", "", context.GetTheme( ));
            AssignProp("", false, imgFiltertoggle_combined_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgFiltertoggle_combined_Bitmap)), true);
            AssignProp("", false, imgFiltertoggle_combined_Internalname, "SrcSet", context.GetImageSrcSet( imgFiltertoggle_combined_Bitmap), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E12152( )
      {
         /* Filterclose_combined_Click Routine */
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         imgFiltertoggle_combined_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
         AssignProp("", false, imgFiltertoggle_combined_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgFiltertoggle_combined_Bitmap)), true);
         AssignProp("", false, imgFiltertoggle_combined_Internalname, "SrcSet", context.GetImageSrcSet( imgFiltertoggle_combined_Bitmap), true);
         /*  Sending Event outputs  */
      }

      protected void E13152( )
      {
         /* Filtertoggle_onlydetailed_Click Routine */
         if ( divFiltercollapsiblesection_onlydetailed_Visible != 0 )
         {
            divFiltercollapsiblesection_onlydetailed_Visible = 0;
            AssignProp("", false, divFiltercollapsiblesection_onlydetailed_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_onlydetailed_Visible), 5, 0), true);
            imgFiltertoggle_onlydetailed_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
            AssignProp("", false, imgFiltertoggle_onlydetailed_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgFiltertoggle_onlydetailed_Bitmap)), true);
            AssignProp("", false, imgFiltertoggle_onlydetailed_Internalname, "SrcSet", context.GetImageSrcSet( imgFiltertoggle_onlydetailed_Bitmap), true);
         }
         else
         {
            divFiltercollapsiblesection_onlydetailed_Visible = 1;
            AssignProp("", false, divFiltercollapsiblesection_onlydetailed_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_onlydetailed_Visible), 5, 0), true);
            imgFiltertoggle_onlydetailed_Bitmap = context.GetImagePath( "0f563368-53de-4c84-a145-c3119aedd1ee", "", context.GetTheme( ));
            AssignProp("", false, imgFiltertoggle_onlydetailed_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgFiltertoggle_onlydetailed_Bitmap)), true);
            AssignProp("", false, imgFiltertoggle_onlydetailed_Internalname, "SrcSet", context.GetImageSrcSet( imgFiltertoggle_onlydetailed_Bitmap), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E14152( )
      {
         /* Filterclose_onlydetailed_Click Routine */
         divFiltercollapsiblesection_onlydetailed_Visible = 0;
         AssignProp("", false, divFiltercollapsiblesection_onlydetailed_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_onlydetailed_Visible), 5, 0), true);
         imgFiltertoggle_onlydetailed_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
         AssignProp("", false, imgFiltertoggle_onlydetailed_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgFiltertoggle_onlydetailed_Bitmap)), true);
         AssignProp("", false, imgFiltertoggle_onlydetailed_Internalname, "SrcSet", context.GetImageSrcSet( imgFiltertoggle_onlydetailed_Bitmap), true);
         /*  Sending Event outputs  */
      }

      private void E16152( )
      {
         /* Load Routine */
      }

      protected void wb_table7_135_152( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblPagingcontainer_Internalname, tblPagingcontainer_Internalname, "", "K2BToolsTable_FloatRight", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Paging", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_135_152e( true) ;
         }
         else
         {
            wb_table7_135_152e( false) ;
         }
      }

      protected void wb_table6_130_152( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblOrderbycontainer_Internalname, tblOrderbycontainer_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblOrderby_Internalname, "OrderedBy", "", "", lblOrderby_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_130_152e( true) ;
         }
         else
         {
            wb_table6_130_152e( false) ;
         }
      }

      protected void wb_table5_122_152( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblSummarycontainer_Internalname, tblSummarycontainer_Internalname, "", "K2BToolsTable_FloatRight", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Summary", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_122_152e( true) ;
         }
         else
         {
            wb_table5_122_152e( false) ;
         }
      }

      protected void wb_table4_112_152( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable11_Internalname, tblTable11_Internalname, "", "K2BToolsTable_FloatRight", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridactionsright_Internalname, "GridActionsRight", "", "", lblGridactionsright_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_112_152e( true) ;
         }
         else
         {
            wb_table4_112_152e( false) ;
         }
      }

      protected void wb_table3_90_152( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblFilterscontainer_onlydetailed_Internalname, tblFilterscontainer_onlydetailed_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Filters", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_90_152e( true) ;
         }
         else
         {
            wb_table3_90_152e( false) ;
         }
      }

      protected void wb_table2_74_152( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblFilterscontainer_combined_Internalname, tblFilterscontainer_combined_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFilters_Internalname, "Filters", "", "", lblFilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_74_152e( true) ;
         }
         else
         {
            wb_table2_74_152e( false) ;
         }
      }

      protected void wb_table1_38_152( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable7_Internalname, tblTable7_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettingscontainer_Internalname, "GridSettingsContainer", "", "", lblGridsettingscontainer_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnmanagement_Internalname, "RuntimeColumnManagement", "", "", lblRuntimecolumnmanagement_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divDownloadsactionssectioncontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_DownloadActionsContainer ControlBeautify_ParentCollapsableTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgDownloadsactiontoggle_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgDownloadsactiontoggle_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17151_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPDLayoutOrion_SelectionRight.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDownloadsactionssection_Internalname, "DownloadsActionsSection", "", "", lblDownloadsactionssection_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblRightactions_Internalname, "RightActions", "", "", lblRightactions_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WPDLayoutOrion_SelectionRight.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_38_152e( true) ;
         }
         else
         {
            wb_table1_38_152e( false) ;
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
         PA152( ) ;
         WS152( ) ;
         WE152( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210211744872", true, true);
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
         context.AddJavascriptSource("wpdlayoutorion_selectionright.js", "?202210211744872", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1182( )
      {
      }

      protected void SubsflControlProps_fel_1182( )
      {
      }

      protected void sendrow_1182( )
      {
         SubsflControlProps_1182( ) ;
         WB150( ) ;
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
            if ( ((int)((nGXsfl_118_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " gxrow=\""+sGXsfl_118_idx+"\">") ;
         }
         send_integrity_lvl_hashes152( ) ;
         GridcontentContainer.AddRow(GridcontentRow);
         nGXsfl_118_idx = ((subGridcontent_Islastpage==1)&&(nGXsfl_118_idx+1>subGridcontent_fnc_Recordsperpage( )) ? 1 : nGXsfl_118_idx+1);
         sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
         SubsflControlProps_1182( ) ;
         /* End function sendrow_1182 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
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
         edtavK2btoolsgenericsearchfield_Internalname = "vK2BTOOLSGENERICSEARCHFIELD";
         imgFiltertoggle_combined_Internalname = "FILTERTOGGLE_COMBINED";
         lblFiltersummary_combined_Internalname = "FILTERSUMMARY_COMBINED";
         divSection4_Internalname = "SECTION4";
         imgFilterclose_combined_Internalname = "FILTERCLOSE_COMBINED";
         lblFilters_Internalname = "FILTERS";
         tblFilterscontainer_combined_Internalname = "FILTERSCONTAINER_COMBINED";
         divFiltercollapsiblesection_combined_Internalname = "FILTERCOLLAPSIBLESECTION_COMBINED";
         divCombinedfilterlayout_Internalname = "COMBINEDFILTERLAYOUT";
         imgFiltertoggle_onlydetailed_Internalname = "FILTERTOGGLE_ONLYDETAILED";
         lblFiltersummary_onlydetailed_Internalname = "FILTERSUMMARY_ONLYDETAILED";
         divSection5_Internalname = "SECTION5";
         imgFilterclose_onlydetailed_Internalname = "FILTERCLOSE_ONLYDETAILED";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         tblFilterscontainer_onlydetailed_Internalname = "FILTERSCONTAINER_ONLYDETAILED";
         divFiltercollapsiblesection_onlydetailed_Internalname = "FILTERCOLLAPSIBLESECTION_ONLYDETAILED";
         divOnlydetailedfilterlayout_Internalname = "ONLYDETAILEDFILTERLAYOUT";
         edtavK2btoolsgenericsearchfield_Internalname = "vK2BTOOLSGENERICSEARCHFIELD";
         divSection6_Internalname = "SECTION6";
         divOnlygenericfilterlayout_Internalname = "ONLYGENERICFILTERLAYOUT";
         divFilterglobalcontainer_Internalname = "FILTERGLOBALCONTAINER";
         divTable10_Internalname = "TABLE10";
         lblGridactionsleft_Internalname = "GRIDACTIONSLEFT";
         lblGridactionsright_Internalname = "GRIDACTIONSRIGHT";
         tblTable11_Internalname = "TABLE11";
         divTable5_Internalname = "TABLE5";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         tblSummarycontainer_Internalname = "SUMMARYCONTAINER";
         lblGridrecordcount_Internalname = "GRIDRECORDCOUNT";
         lblOrderby_Internalname = "ORDERBY";
         tblOrderbycontainer_Internalname = "ORDERBYCONTAINER";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         tblPagingcontainer_Internalname = "PAGINGCONTAINER";
         lblBottomactions_Internalname = "BOTTOMACTIONS";
         divTable3_Internalname = "TABLE3";
         divGrid_inner_Internalname = "GRID_INNER";
         lblSelectionsummaryselecteditemstextblock_Internalname = "SELECTIONSUMMARYSELECTEDITEMSTEXTBLOCK";
         lblSelectionsummary_Internalname = "SELECTIONSUMMARY";
         imgImage1_Internalname = "IMAGE1";
         lblSelectionsummarynoitemstextblock_Internalname = "SELECTIONSUMMARYNOITEMSTEXTBLOCK";
         divSelectionsummarynoitemstable_Internalname = "SELECTIONSUMMARYNOITEMSTABLE";
         divTable4_Internalname = "TABLE4";
         divTable6_Internalname = "TABLE6";
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
         lblFilters_Jsonclick = "";
         subGridcontent_Allowcollapsing = 0;
         subGridcontent_Allowselection = 0;
         subGridcontent_Header = "";
         subGridcontent_Class = "Grid";
         subGridcontent_Backcolorstyle = 0;
         divFiltercollapsiblesection_onlydetailed_Visible = 1;
         imgFiltertoggle_onlydetailed_Bitmap = (String)(context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( )));
         divFiltercollapsiblesection_combined_Visible = 1;
         imgFiltertoggle_combined_Bitmap = (String)(context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( )));
         edtavK2btoolsgenericsearchfield_Jsonclick = "";
         edtavK2btoolsgenericsearchfield_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Grid with selection on the right";
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
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK","{handler:'E11152',iparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'}]");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'}]}");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK","{handler:'E12152',iparms:[]");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'}]}");
         setEventMetadata("FILTERTOGGLE_ONLYDETAILED.CLICK","{handler:'E13152',iparms:[{av:'divFiltercollapsiblesection_onlydetailed_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_ONLYDETAILED',prop:'Visible'}]");
         setEventMetadata("FILTERTOGGLE_ONLYDETAILED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_onlydetailed_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_ONLYDETAILED',prop:'Visible'}]}");
         setEventMetadata("FILTERCLOSE_ONLYDETAILED.CLICK","{handler:'E14152',iparms:[]");
         setEventMetadata("FILTERCLOSE_ONLYDETAILED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_onlydetailed_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_ONLYDETAILED',prop:'Visible'}]}");
         setEventMetadata("DOWNLOADSACTIONTOGGLE.CLICK","{handler:'E17151',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'}]");
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
         TempTags = "";
         AV5K2BToolsGenericSearchField = "";
         sImgUrl = "";
         imgFiltertoggle_combined_Jsonclick = "";
         lblFiltersummary_combined_Jsonclick = "";
         imgFilterclose_combined_Jsonclick = "";
         imgFiltertoggle_onlydetailed_Jsonclick = "";
         lblFiltersummary_onlydetailed_Jsonclick = "";
         imgFilterclose_onlydetailed_Jsonclick = "";
         lblGridactionsleft_Jsonclick = "";
         GridcontentContainer = new GXWebGrid( context);
         sStyleString = "";
         subGridcontent_Linesclass = "";
         lblGridrecordcount_Jsonclick = "";
         lblBottomactions_Jsonclick = "";
         lblSelectionsummaryselecteditemstextblock_Jsonclick = "";
         lblSelectionsummary_Jsonclick = "";
         lblSelectionsummarynoitemstextblock_Jsonclick = "";
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
         lblGridactionsright_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         lblGridsettingscontainer_Jsonclick = "";
         lblRuntimecolumnmanagement_Jsonclick = "";
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
      private int divFiltercollapsiblesection_combined_Visible ;
      private int divFiltercollapsiblesection_onlydetailed_Visible ;
      private int divDownloadactionstable_Visible ;
      private int nRC_GXsfl_118 ;
      private int nGXsfl_118_idx=1 ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
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
      private String sGXsfl_118_idx="0001" ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divTable1_Internalname ;
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
      private String divTable6_Internalname ;
      private String divGrid_inner_Internalname ;
      private String divTable10_Internalname ;
      private String divFilterglobalcontainer_Internalname ;
      private String divCombinedfilterlayout_Internalname ;
      private String divSection4_Internalname ;
      private String TempTags ;
      private String edtavK2btoolsgenericsearchfield_Internalname ;
      private String AV5K2BToolsGenericSearchField ;
      private String edtavK2btoolsgenericsearchfield_Jsonclick ;
      private String sImgUrl ;
      private String imgFiltertoggle_combined_Internalname ;
      private String imgFiltertoggle_combined_Jsonclick ;
      private String lblFiltersummary_combined_Internalname ;
      private String lblFiltersummary_combined_Jsonclick ;
      private String divFiltercollapsiblesection_combined_Internalname ;
      private String imgFilterclose_combined_Internalname ;
      private String imgFilterclose_combined_Jsonclick ;
      private String divOnlydetailedfilterlayout_Internalname ;
      private String divSection5_Internalname ;
      private String imgFiltertoggle_onlydetailed_Internalname ;
      private String imgFiltertoggle_onlydetailed_Jsonclick ;
      private String lblFiltersummary_onlydetailed_Internalname ;
      private String lblFiltersummary_onlydetailed_Jsonclick ;
      private String divFiltercollapsiblesection_onlydetailed_Internalname ;
      private String imgFilterclose_onlydetailed_Internalname ;
      private String imgFilterclose_onlydetailed_Jsonclick ;
      private String divOnlygenericfilterlayout_Internalname ;
      private String divSection6_Internalname ;
      private String divTable3_Internalname ;
      private String divTable5_Internalname ;
      private String lblGridactionsleft_Internalname ;
      private String lblGridactionsleft_Jsonclick ;
      private String sStyleString ;
      private String subGridcontent_Internalname ;
      private String subGridcontent_Class ;
      private String subGridcontent_Linesclass ;
      private String subGridcontent_Header ;
      private String lblGridrecordcount_Internalname ;
      private String lblGridrecordcount_Jsonclick ;
      private String lblBottomactions_Internalname ;
      private String lblBottomactions_Jsonclick ;
      private String divTable4_Internalname ;
      private String lblSelectionsummaryselecteditemstextblock_Internalname ;
      private String lblSelectionsummaryselecteditemstextblock_Jsonclick ;
      private String lblSelectionsummary_Internalname ;
      private String lblSelectionsummary_Jsonclick ;
      private String divSelectionsummarynoitemstable_Internalname ;
      private String imgImage1_Internalname ;
      private String lblSelectionsummarynoitemstextblock_Internalname ;
      private String lblSelectionsummarynoitemstextblock_Jsonclick ;
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
      private String tblTable11_Internalname ;
      private String lblGridactionsright_Internalname ;
      private String lblGridactionsright_Jsonclick ;
      private String tblFilterscontainer_onlydetailed_Internalname ;
      private String lblTextblock4_Internalname ;
      private String lblTextblock4_Jsonclick ;
      private String tblFilterscontainer_combined_Internalname ;
      private String lblFilters_Internalname ;
      private String lblFilters_Jsonclick ;
      private String tblTable7_Internalname ;
      private String lblGridsettingscontainer_Internalname ;
      private String lblGridsettingscontainer_Jsonclick ;
      private String lblRuntimecolumnmanagement_Internalname ;
      private String lblRuntimecolumnmanagement_Jsonclick ;
      private String divDownloadsactionssectioncontainer_Internalname ;
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
      private bool bGXsfl_118_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private String imgFiltertoggle_combined_Bitmap ;
      private String imgFiltertoggle_onlydetailed_Bitmap ;
      private GXWebGrid GridcontentContainer ;
      private GXWebRow GridcontentRow ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

}
