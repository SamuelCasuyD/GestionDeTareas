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
   public class k2btabbedviewforlayoutorion : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public k2btabbedviewforlayoutorion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (String)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("K2BOrion");
         }
      }

      public k2btabbedviewforlayoutorion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_Gx_mode ,
                           GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem> aP1_Tabs ,
                           String aP2_TabCode )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV18Tabs = aP1_Tabs;
         this.AV15TabCode = aP2_TabCode;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( String sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (String)(sPrefix)) == 0 )
         {
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetNextPar( );
                  sSFPrefix = GetNextPar( );
                  Gx_mode = GetNextPar( );
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV18Tabs);
                  AV15TabCode = GetNextPar( );
                  AssignAttri(sPrefix, false, "AV15TabCode", AV15TabCode);
                  setjustcreated();
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(String)Gx_mode,(GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>)AV18Tabs,(String)AV15TabCode});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA0N2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS0N2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, false);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "K2 BTabbed View For Layout Orion") ;
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
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 947160), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202210211743863", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("k2btabbedviewforlayoutorion.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV15TabCode))+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( ) ;
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV5FirstTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV11LastTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV13SelectedTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vINDEX", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8Index), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTAB", GetSecureSignedToken( sPrefix, AV14Tab, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABSMARKUP", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV19TabsMarkup, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABTEMPLATE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV20TabTemplate, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV15TabCode", StringUtil.RTrim( wcpOAV15TabCode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFIRSTTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5FirstTab), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV5FirstTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vLASTTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11LastTab), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV11LastTab), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTABS", AV18Tabs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTABS", AV18Tabs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTABCODE", StringUtil.RTrim( AV15TabCode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSELECTEDTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13SelectedTab), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV13SelectedTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINDEX", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Index), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vINDEX", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8Index), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTAB", AV14Tab);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTAB", AV14Tab);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTAB", GetSecureSignedToken( sPrefix, AV14Tab, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTABSMARKUP", StringUtil.RTrim( AV19TabsMarkup));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABSMARKUP", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV19TabsMarkup, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTABTEMPLATE", StringUtil.RTrim( AV20TabTemplate));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABTEMPLATE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV20TabTemplate, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm0N2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            context.AddJavascriptSource("k2btabbedviewforlayoutorion.js", "?202210211743867", false, true);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            if ( ! ( WebComp_Component == null ) )
            {
               WebComp_Component.componentjscripts();
            }
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override String GetPgmname( )
      {
         return "K2BTabbedViewForLayoutOrion" ;
      }

      public override String GetPgmdesc( )
      {
         return "K2 BTabbed View For Layout Orion" ;
      }

      protected void WB0N0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "k2btabbedviewforlayoutorion.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsSection_TabContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabs_Internalname, lblTabs_Caption, "", "", lblTabs_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 1, "HLP_K2BTabbedViewForLayoutOrion.htm");
            /* Static images/pictures */
            ClassString = "ImageTabPaging";
            StyleString = "";
            sImgUrl = "(none)";
            GxWebStd.gx_bitmap( context, imgTabprevious_Internalname, sImgUrl, imgTabprevious_Link, "", "", context.GetTheme( ), imgTabprevious_Visible, 1, "", "Previous Tab", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BTabbedViewForLayoutOrion.htm");
            /* Static images/pictures */
            ClassString = "ImageTabPaging";
            StyleString = "";
            sImgUrl = "(none)";
            GxWebStd.gx_bitmap( context, imgTabnext_Internalname, sImgUrl, imgTabnext_Link, "", "", context.GetTheme( ), imgTabnext_Visible, 1, "", "Next Tab", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BTabbedViewForLayoutOrion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsSection_TabbedView", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection1_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0008"+"", StringUtil.RTrim( WebComp_Component_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0008"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Component_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldComponent), StringUtil.Lower( WebComp_Component_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0008"+"");
                  }
                  WebComp_Component.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldComponent), StringUtil.Lower( WebComp_Component_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0N2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus C# 16_0_10-142546", 0) ;
               }
               Form.Meta.addItem("description", "K2 BTabbed View For Layout Orion", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP0N0( ) ;
            }
         }
      }

      protected void WS0N2( )
      {
         START0N2( ) ;
         EVT0N2( ) ;
      }

      protected void EVT0N2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E110N2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E120N2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E130N2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                        if ( nCmpId == 8 )
                        {
                           OldComponent = cgiGet( sPrefix+"W0008");
                           if ( ( StringUtil.Len( OldComponent) == 0 ) || ( StringUtil.StrCmp(OldComponent, WebComp_Component_Component) != 0 ) )
                           {
                              WebComp_Component = getWebComponent(GetType(), "GeneXus.Programs", OldComponent, new Object[] {context} );
                              WebComp_Component.ComponentInit();
                              WebComp_Component.Name = "OldComponent";
                              WebComp_Component_Component = OldComponent;
                           }
                           if ( StringUtil.Len( WebComp_Component_Component) != 0 )
                           {
                              WebComp_Component.componentprocess(sPrefix+"W0008", "", sEvt);
                           }
                           WebComp_Component_Component = OldComponent;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0N2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0N2( ) ;
            }
         }
      }

      protected void PA0N2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
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
         RF0N2( ) ;
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

      protected void RF0N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E120N2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Component_Component) != 0 )
               {
                  WebComp_Component.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E130N2 ();
            WB0N0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0N2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vFIRSTTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5FirstTab), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV5FirstTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vLASTTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11LastTab), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV11LastTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSELECTEDTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13SelectedTab), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV13SelectedTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINDEX", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Index), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vINDEX", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8Index), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTAB", AV14Tab);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTAB", AV14Tab);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTAB", GetSecureSignedToken( sPrefix, AV14Tab, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTABSMARKUP", StringUtil.RTrim( AV19TabsMarkup));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABSMARKUP", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV19TabsMarkup, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTABTEMPLATE", StringUtil.RTrim( AV20TabTemplate));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABTEMPLATE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV20TabTemplate, "")), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP0N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110N2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
            wcpOAV15TabCode = cgiGet( sPrefix+"wcpOAV15TabCode");
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
         E110N2 ();
         if (returnInSub) return;
      }

      protected void E110N2( )
      {
         /* Start Routine */
         /* Execute user subroutine: 'INIT' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E120N2( )
      {
         /* Refresh Routine */
         /* Execute user subroutine: 'FINDTABINDEX' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SCROLLTABS' */
         S132 ();
         if (returnInSub) return;
         AV9IsFirstTab = true;
         AV19TabsMarkup = "";
         AssignAttri(sPrefix, false, "AV19TabsMarkup", AV19TabsMarkup);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABSMARKUP", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV19TabsMarkup, "")), context));
         AV8Index = AV5FirstTab;
         AssignAttri(sPrefix, false, "AV8Index", StringUtil.LTrimStr( (decimal)(AV8Index), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vINDEX", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8Index), "ZZZ9"), context));
         while ( AV8Index <= AV11LastTab )
         {
            AV14Tab = ((SdtK2BTabOptions_K2BTabOptionsItem)AV18Tabs.Item(AV8Index));
            /* Execute user subroutine: 'LOADITEM' */
            S142 ();
            if (returnInSub) return;
            AV9IsFirstTab = false;
            AV8Index = (short)(AV8Index+1);
            AssignAttri(sPrefix, false, "AV8Index", StringUtil.LTrimStr( (decimal)(AV8Index), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vINDEX", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8Index), "ZZZ9"), context));
         }
         lblTabs_Caption = StringUtil.Format( "<ul class=\"Tabs\">%1</ul>", AV19TabsMarkup, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, lblTabs_Internalname, "Caption", lblTabs_Caption, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV14Tab", AV14Tab);
      }

      protected void S112( )
      {
         /* 'INIT' Routine */
         AV20TabTemplate = "<li class=\"%1\">";
         AssignAttri(sPrefix, false, "AV20TabTemplate", AV20TabTemplate);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABTEMPLATE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV20TabTemplate, "")), context));
         AV20TabTemplate = AV20TabTemplate + "<a id=\"%2Tab\" %3%7 class=\"%4\">";
         AssignAttri(sPrefix, false, "AV20TabTemplate", AV20TabTemplate);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABTEMPLATE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV20TabTemplate, "")), context));
         AV20TabTemplate = AV20TabTemplate + "<span class=\"%5\">";
         AssignAttri(sPrefix, false, "AV20TabTemplate", AV20TabTemplate);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABTEMPLATE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV20TabTemplate, "")), context));
         AV20TabTemplate = AV20TabTemplate + "<span class=\"TabBackground\">";
         AssignAttri(sPrefix, false, "AV20TabTemplate", AV20TabTemplate);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABTEMPLATE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV20TabTemplate, "")), context));
         AV20TabTemplate = AV20TabTemplate + "<span class=\"TabText\">%6</span>";
         AssignAttri(sPrefix, false, "AV20TabTemplate", AV20TabTemplate);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABTEMPLATE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV20TabTemplate, "")), context));
         AV20TabTemplate = AV20TabTemplate + "</span>";
         AssignAttri(sPrefix, false, "AV20TabTemplate", AV20TabTemplate);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABTEMPLATE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV20TabTemplate, "")), context));
         AV20TabTemplate = AV20TabTemplate + "</span>";
         AssignAttri(sPrefix, false, "AV20TabTemplate", AV20TabTemplate);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABTEMPLATE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV20TabTemplate, "")), context));
         AV20TabTemplate = AV20TabTemplate + "</a>";
         AssignAttri(sPrefix, false, "AV20TabTemplate", AV20TabTemplate);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABTEMPLATE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV20TabTemplate, "")), context));
         AV20TabTemplate = AV20TabTemplate + "</li>";
         AssignAttri(sPrefix, false, "AV20TabTemplate", AV20TabTemplate);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABTEMPLATE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV20TabTemplate, "")), context));
      }

      protected void S122( )
      {
         /* 'FINDTABINDEX' Routine */
         AV6Found = false;
         AV8Index = 1;
         AssignAttri(sPrefix, false, "AV8Index", StringUtil.LTrimStr( (decimal)(AV8Index), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vINDEX", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8Index), "ZZZ9"), context));
         while ( AV8Index <= AV18Tabs.Count )
         {
            if ( StringUtil.StrCmp(((SdtK2BTabOptions_K2BTabOptionsItem)AV18Tabs.Item(AV8Index)).gxTpr_Code, AV15TabCode) == 0 )
            {
               AV13SelectedTab = AV8Index;
               AssignAttri(sPrefix, false, "AV13SelectedTab", StringUtil.LTrimStr( (decimal)(AV13SelectedTab), 4, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV13SelectedTab), "ZZZ9"), context));
               AV6Found = true;
               if (true) break;
            }
            AV8Index = (short)(AV8Index+1);
            AssignAttri(sPrefix, false, "AV8Index", StringUtil.LTrimStr( (decimal)(AV8Index), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vINDEX", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8Index), "ZZZ9"), context));
         }
         if ( ! AV6Found && ( AV18Tabs.Count > 0 ) )
         {
            AV13SelectedTab = 1;
            AssignAttri(sPrefix, false, "AV13SelectedTab", StringUtil.LTrimStr( (decimal)(AV13SelectedTab), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV13SelectedTab), "ZZZ9"), context));
         }
      }

      protected void S132( )
      {
         /* 'SCROLLTABS' Routine */
         AV24TotalTabs = 8;
         AV23CurrentPage = (short)((AV13SelectedTab-1)/ (decimal)(AV24TotalTabs));
         AV5FirstTab = (short)(AV23CurrentPage*AV24TotalTabs+1);
         AssignAttri(sPrefix, false, "AV5FirstTab", StringUtil.LTrimStr( (decimal)(AV5FirstTab), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV5FirstTab), "ZZZ9"), context));
         AV11LastTab = (short)(AV5FirstTab+AV24TotalTabs-1);
         AssignAttri(sPrefix, false, "AV11LastTab", StringUtil.LTrimStr( (decimal)(AV11LastTab), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV11LastTab), "ZZZ9"), context));
         if ( AV11LastTab > AV18Tabs.Count )
         {
            AV11LastTab = (short)(AV18Tabs.Count);
            AssignAttri(sPrefix, false, "AV11LastTab", StringUtil.LTrimStr( (decimal)(AV11LastTab), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV11LastTab), "ZZZ9"), context));
         }
         if ( AV5FirstTab <= AV24TotalTabs )
         {
            imgTabprevious_Visible = 0;
            AssignProp(sPrefix, false, imgTabprevious_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgTabprevious_Visible), 5, 0), true);
         }
         else
         {
            imgTabprevious_Link = formatLink(((SdtK2BTabOptions_K2BTabOptionsItem)AV18Tabs.Item(AV5FirstTab-AV24TotalTabs)).gxTpr_Link) ;
            AssignProp(sPrefix, false, imgTabprevious_Internalname, "Link", imgTabprevious_Link, true);
         }
         if ( AV11LastTab >= AV18Tabs.Count )
         {
            imgTabnext_Visible = 0;
            AssignProp(sPrefix, false, imgTabnext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgTabnext_Visible), 5, 0), true);
         }
         else
         {
            imgTabnext_Link = formatLink(((SdtK2BTabOptions_K2BTabOptionsItem)AV18Tabs.Item(AV5FirstTab+AV24TotalTabs)).gxTpr_Link) ;
            AssignProp(sPrefix, false, imgTabnext_Internalname, "Link", imgTabnext_Link, true);
         }
      }

      protected void S142( )
      {
         /* 'LOADITEM' Routine */
         AV16TabLeftCls = "TabLeft";
         if ( AV8Index == AV5FirstTab )
         {
            AV16TabLeftCls = "TabFirst";
         }
         AV17TabRightCls = "TabRight";
         if ( AV8Index == AV11LastTab )
         {
            AV17TabRightCls = "TabLast";
         }
         if ( AV8Index == AV13SelectedTab )
         {
            AV19TabsMarkup = AV19TabsMarkup + StringUtil.Format( AV20TabTemplate, "Tab TabSelected", AV14Tab.gxTpr_Code, "", AV16TabLeftCls, AV17TabRightCls, AV14Tab.gxTpr_Description, "", "", "");
            AssignAttri(sPrefix, false, "AV19TabsMarkup", AV19TabsMarkup);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABSMARKUP", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV19TabsMarkup, "")), context));
            AV22WebComponentUrl = AV14Tab.gxTpr_Webcomponent;
            /* Object Property */
            gxDynCompUrl = AV22WebComponentUrl;
            if ( ! IsSameComponent( WebComp_Component_Component, gxDynCompUrl) )
            {
               WebComp_Component = getWebComponent(GetType(), "GeneXus.Programs", gxDynCompUrl, new Object[] {context} );
               WebComp_Component.ComponentInit();
               WebComp_Component.Name = "gxDynCompUrl";
               WebComp_Component_Component = gxDynCompUrl;
            }
            else
            {
               WebComp_Component.setparmsfromurl(gxDynCompUrl);
            }
            if ( StringUtil.Len( WebComp_Component_Component) != 0 )
            {
               WebComp_Component.setjustcreated();
               WebComp_Component.componentprepare(new Object[] {(String)sPrefix+"W0008",(String)""});
               WebComp_Component.componentbind(new Object[] {});
            }
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0008"+"");
               WebComp_Component.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 )
            {
               AV19TabsMarkup = AV19TabsMarkup + StringUtil.Format( AV20TabTemplate, "Tab TabDisabled", AV14Tab.gxTpr_Code, "", AV16TabLeftCls, AV17TabRightCls, AV14Tab.gxTpr_Description, "", "", "");
               AssignAttri(sPrefix, false, "AV19TabsMarkup", AV19TabsMarkup);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABSMARKUP", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV19TabsMarkup, "")), context));
            }
            else
            {
               AV12OnClickTemplate = "";
               AV19TabsMarkup = AV19TabsMarkup + StringUtil.Format( AV20TabTemplate, "Tab", AV14Tab.gxTpr_Code, StringUtil.Format( "href=\"%1\"", AV14Tab.gxTpr_Link, "", "", "", "", "", "", "", ""), AV16TabLeftCls, AV17TabRightCls, AV14Tab.gxTpr_Description, StringUtil.Format( AV12OnClickTemplate, AV14Tab.gxTpr_Code, "", "", "", "", "", "", "", ""), "", "");
               AssignAttri(sPrefix, false, "AV19TabsMarkup", AV19TabsMarkup);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTABSMARKUP", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV19TabsMarkup, "")), context));
            }
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E130N2( )
      {
         /* Load Routine */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (String)getParm(obj,0);
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         AV18Tabs = (GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>)getParm(obj,1);
         AV15TabCode = (String)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV15TabCode", AV15TabCode);
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
         PA0N2( ) ;
         WS0N2( ) ;
         WE0N2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( String sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (String)((String)getParm(obj,0));
         sCtrlAV18Tabs = (String)((String)getParm(obj,1));
         sCtrlAV15TabCode = (String)((String)getParm(obj,2));
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0N2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (String)getParm(obj,0);
         sSFPrefix = (String)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "k2btabbedviewforlayoutorion", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0N2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (String)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV18Tabs = (GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>)getParm(obj,3);
            AV15TabCode = (String)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV15TabCode", AV15TabCode);
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV15TabCode = cgiGet( sPrefix+"wcpOAV15TabCode");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( StringUtil.StrCmp(AV15TabCode, wcpOAV15TabCode) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV15TabCode = AV15TabCode;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlGx_mode = cgiGet( sPrefix+"Gx_mode_CTRL");
         if ( StringUtil.Len( sCtrlGx_mode) > 0 )
         {
            Gx_mode = cgiGet( sCtrlGx_mode);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = cgiGet( sPrefix+"Gx_mode_PARM");
         }
         sCtrlAV18Tabs = cgiGet( sPrefix+"AV18Tabs_CTRL");
         if ( StringUtil.Len( sCtrlAV18Tabs) > 0 )
         {
            AV18Tabs = new GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>();
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV18Tabs_PARM"), AV18Tabs);
         }
         sCtrlAV15TabCode = cgiGet( sPrefix+"AV15TabCode_CTRL");
         if ( StringUtil.Len( sCtrlAV15TabCode) > 0 )
         {
            AV15TabCode = cgiGet( sCtrlAV15TabCode);
            AssignAttri(sPrefix, false, "AV15TabCode", AV15TabCode);
         }
         else
         {
            AV15TabCode = cgiGet( sPrefix+"AV15TabCode_PARM");
         }
      }

      public override void componentprocess( String sPPrefix ,
                                             String sPSFPrefix ,
                                             String sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA0N2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS0N2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_PARM", StringUtil.RTrim( Gx_mode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlGx_mode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_CTRL", StringUtil.RTrim( sCtrlGx_mode));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV18Tabs_PARM", AV18Tabs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV18Tabs_PARM", AV18Tabs);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV18Tabs)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV18Tabs_CTRL", StringUtil.RTrim( sCtrlAV18Tabs));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV15TabCode_PARM", StringUtil.RTrim( AV15TabCode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV15TabCode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV15TabCode_CTRL", StringUtil.RTrim( sCtrlAV15TabCode));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE0N2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override String getstring( String sGXControl )
      {
         String sCtrlName ;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
         if ( ! ( WebComp_Component == null ) )
         {
            WebComp_Component.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Component == null ) )
         {
            if ( StringUtil.Len( WebComp_Component_Component) != 0 )
            {
               WebComp_Component.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210211743890", true, true);
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
         context.AddJavascriptSource("k2btabbedviewforlayoutorion.js", "?202210211743890", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTabs_Internalname = sPrefix+"TABS";
         imgTabprevious_Internalname = sPrefix+"TABPREVIOUS";
         imgTabnext_Internalname = sPrefix+"TABNEXT";
         divTabcontainer_Internalname = sPrefix+"TABCONTAINER";
         divSection1_Internalname = sPrefix+"SECTION1";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("K2BOrion");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         imgTabnext_Visible = 1;
         imgTabnext_Link = "";
         imgTabprevious_Visible = 1;
         imgTabprevious_Link = "";
         lblTabs_Jsonclick = "";
         lblTabs_Caption = "Tabs";
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV18Tabs',fld:'vTABS',pic:''},{av:'AV15TabCode',fld:'vTABCODE',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV5FirstTab',fld:'vFIRSTTAB',pic:'ZZZ9',hsh:true},{av:'AV11LastTab',fld:'vLASTTAB',pic:'ZZZ9',hsh:true},{av:'AV13SelectedTab',fld:'vSELECTEDTAB',pic:'ZZZ9',hsh:true},{av:'AV8Index',fld:'vINDEX',pic:'ZZZ9',hsh:true},{av:'AV14Tab',fld:'vTAB',pic:'',hsh:true},{av:'AV19TabsMarkup',fld:'vTABSMARKUP',pic:'',hsh:true},{av:'AV20TabTemplate',fld:'vTABTEMPLATE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV19TabsMarkup',fld:'vTABSMARKUP',pic:'',hsh:true},{av:'AV8Index',fld:'vINDEX',pic:'ZZZ9',hsh:true},{av:'AV14Tab',fld:'vTAB',pic:'',hsh:true},{av:'lblTabs_Caption',ctrl:'TABS',prop:'Caption'},{av:'AV13SelectedTab',fld:'vSELECTEDTAB',pic:'ZZZ9',hsh:true},{av:'AV5FirstTab',fld:'vFIRSTTAB',pic:'ZZZ9',hsh:true},{av:'AV11LastTab',fld:'vLASTTAB',pic:'ZZZ9',hsh:true},{av:'imgTabprevious_Visible',ctrl:'TABPREVIOUS',prop:'Visible'},{av:'imgTabprevious_Link',ctrl:'TABPREVIOUS',prop:'Link'},{av:'imgTabnext_Visible',ctrl:'TABNEXT',prop:'Visible'},{av:'imgTabnext_Link',ctrl:'TABNEXT',prop:'Link'},{ctrl:'COMPONENT'}]}");
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
         AV18Tabs = new GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>( context, "K2BTabOptionsItem", "TABLEROS_WEB");
         wcpOGx_mode = "";
         wcpOAV15TabCode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV14Tab = new SdtK2BTabOptions_K2BTabOptionsItem(context);
         AV19TabsMarkup = "";
         AV20TabTemplate = "";
         GXKey = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         WebComp_Component_Component = "";
         gxDynCompUrl = "";
         OldComponent = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV16TabLeftCls = "";
         AV17TabRightCls = "";
         AV22WebComponentUrl = "";
         AV12OnClickTemplate = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlGx_mode = "";
         sCtrlAV18Tabs = "";
         sCtrlAV15TabCode = "";
         WebComp_Component = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short AV5FirstTab ;
      private short AV11LastTab ;
      private short AV13SelectedTab ;
      private short AV8Index ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV24TotalTabs ;
      private short AV23CurrentPage ;
      private short nGXWrapped ;
      private int imgTabprevious_Visible ;
      private int imgTabnext_Visible ;
      private int idxLst ;
      private String Gx_mode ;
      private String AV15TabCode ;
      private String wcpOGx_mode ;
      private String wcpOAV15TabCode ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sPrefix ;
      private String sCompPrefix ;
      private String sSFPrefix ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String AV19TabsMarkup ;
      private String AV20TabTemplate ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String divTabcontainer_Internalname ;
      private String lblTabs_Internalname ;
      private String lblTabs_Caption ;
      private String lblTabs_Jsonclick ;
      private String ClassString ;
      private String StyleString ;
      private String sImgUrl ;
      private String imgTabprevious_Internalname ;
      private String imgTabprevious_Link ;
      private String imgTabnext_Internalname ;
      private String imgTabnext_Link ;
      private String divSection1_Internalname ;
      private String WebComp_Component_Component ;
      private String gxDynCompUrl ;
      private String OldComponent ;
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String AV16TabLeftCls ;
      private String AV17TabRightCls ;
      private String AV12OnClickTemplate ;
      private String sCtrlGx_mode ;
      private String sCtrlAV18Tabs ;
      private String sCtrlAV15TabCode ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV9IsFirstTab ;
      private bool AV6Found ;
      private String AV22WebComponentUrl ;
      private GXWebComponent WebComp_Component ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem> AV18Tabs ;
      private SdtK2BTabOptions_K2BTabOptionsItem AV14Tab ;
   }

}
