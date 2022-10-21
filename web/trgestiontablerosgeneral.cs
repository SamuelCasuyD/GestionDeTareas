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
   public class trgestiontablerosgeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public trgestiontablerosgeneral( )
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

      public trgestiontablerosgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_Gx_mode ,
                           Guid aP1_TrGestionTableros_ID ,
                           String aP2_TabCode )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV6TrGestionTableros_ID = aP1_TrGestionTableros_ID;
         this.AV8TabCode = aP2_TabCode;
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
                  AV6TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( GetNextPar( )));
                  AssignAttri(sPrefix, false, "AV6TrGestionTableros_ID", AV6TrGestionTableros_ID.ToString());
                  AV8TabCode = GetNextPar( );
                  AssignAttri(sPrefix, false, "AV8TabCode", AV8TabCode);
                  setjustcreated();
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(String)Gx_mode,(Guid)AV6TrGestionTableros_ID,(String)AV8TabCode});
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
            PA1S2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS1S2( ) ;
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
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
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
            context.SendWebValue( "General") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210201141287", false, true);
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
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trgestiontablerosgeneral.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV6TrGestionTableros_ID.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV8TabCode))+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
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
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6TrGestionTableros_ID", wcpOAV6TrGestionTableros_ID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8TabCode", StringUtil.RTrim( wcpOAV8TabCode));
         GxWebStd.gx_hidden_field( context, sPrefix+"TRGESTIONTABLEROS_ID", A1TrGestionTableros_ID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vTRGESTIONTABLEROS_ID", AV6TrGestionTableros_ID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTABCODE", StringUtil.RTrim( AV8TabCode));
      }

      protected void RenderHtmlCloseForm1S2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            context.AddJavascriptSource("trgestiontablerosgeneral.js", "?202210201141288", false, true);
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
            if ( ! ( WebComp_Transactioncomponent == null ) )
            {
               WebComp_Transactioncomponent.componentjscripts();
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
         return "TrGestionTablerosGeneral" ;
      }

      public override String GetPgmdesc( )
      {
         return "General" ;
      }

      protected void WB1S0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "trgestiontablerosgeneral.aspx");
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
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_15_1S2( true) ;
         }
         else
         {
            wb_table1_15_1S2( false) ;
         }
         return  ;
      }

      protected void wb_table1_15_1S2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopBorder", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0029"+"", StringUtil.RTrim( WebComp_Transactioncomponent_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0029"+""+"\""+((WebComp_Transactioncomponent_Visible==1) ? "" : " style=\"display:none;\"")) ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Transactioncomponent_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldTransactioncomponent), StringUtil.Lower( WebComp_Transactioncomponent_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0029"+"");
                  }
                  WebComp_Transactioncomponent.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldTransactioncomponent), StringUtil.Lower( WebComp_Transactioncomponent_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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
         }
         wbLoad = true;
      }

      protected void START1S2( )
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
               Form.Meta.addItem("description", "General", 0) ;
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
               STRUP1S0( ) ;
            }
         }
      }

      protected void WS1S2( )
      {
         START1S2( ) ;
         EVT1S2( ) ;
      }

      protected void EVT1S2( )
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
                                 STRUP1S0( ) ;
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
                                 STRUP1S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E111S2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E121S2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E131S2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E141S2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E151S2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1S0( ) ;
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
                                 STRUP1S0( ) ;
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
                        if ( nCmpId == 29 )
                        {
                           OldTransactioncomponent = cgiGet( sPrefix+"W0029");
                           if ( ( StringUtil.Len( OldTransactioncomponent) == 0 ) || ( StringUtil.StrCmp(OldTransactioncomponent, WebComp_Transactioncomponent_Component) != 0 ) )
                           {
                              WebComp_Transactioncomponent = getWebComponent(GetType(), "GeneXus.Programs", OldTransactioncomponent, new Object[] {context} );
                              WebComp_Transactioncomponent.ComponentInit();
                              WebComp_Transactioncomponent.Name = "OldTransactioncomponent";
                              WebComp_Transactioncomponent_Component = OldTransactioncomponent;
                           }
                           if ( StringUtil.Len( WebComp_Transactioncomponent_Component) != 0 )
                           {
                              WebComp_Transactioncomponent.componentprocess(sPrefix+"W0029", "", sEvt);
                           }
                           WebComp_Transactioncomponent_Component = OldTransactioncomponent;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE1S2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm1S2( ) ;
            }
         }
      }

      protected void PA1S2( )
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
         RF1S2( ) ;
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

      protected void RF1S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E121S2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( WebComp_Transactioncomponent_Visible != 0 )
            {
               if ( StringUtil.Len( WebComp_Transactioncomponent_Component) != 0 )
               {
                  WebComp_Transactioncomponent.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E151S2 ();
            WB1S0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes1S2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP1S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E111S2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
            wcpOAV6TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV6TrGestionTableros_ID")));
            wcpOAV8TabCode = cgiGet( sPrefix+"wcpOAV8TabCode");
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
         E111S2 ();
         if (returnInSub) return;
      }

      protected void E111S2( )
      {
         /* Start Routine */
         imgUpdate_Tooltiptext = "";
         AssignProp(sPrefix, false, imgUpdate_Internalname, "Tooltiptext", imgUpdate_Tooltiptext, true);
         imgDelete_Tooltiptext = "";
         AssignProp(sPrefix, false, imgDelete_Internalname, "Tooltiptext", imgDelete_Tooltiptext, true);
      }

      protected void E121S2( )
      {
         /* Refresh Routine */
         AV11ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "TABLEROS_WEB");
         AV12ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV12ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Update";
         AV12ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV12ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "TrGestionTableros";
         AV12ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "TrGestionTableros";
         AV12ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "";
         AV11ActivityList.Add(AV12ActivityListItem, 0);
         AV12ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV12ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Delete";
         AV12ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV12ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "TrGestionTableros";
         AV12ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "TrGestionTableros";
         AV12ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "";
         AV11ActivityList.Add(AV12ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV11ActivityList) ;
         AV17GXLvl28 = 0;
         /* Using cursor H001S2 */
         pr_default.execute(0, new Object[] {AV6TrGestionTableros_ID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1TrGestionTableros_ID = (Guid)((Guid)(H001S2_A1TrGestionTableros_ID[0]));
            AV17GXLvl28 = 1;
            if ( ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) ) && ((SdtK2BActivityList_K2BActivityListItem)AV11ActivityList.Item(1)).gxTpr_Isauthorized )
            {
               imgUpdate_Visible = 1;
               AssignProp(sPrefix, false, imgUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgUpdate_Visible), 5, 0), true);
            }
            else
            {
               imgUpdate_Visible = 0;
               AssignProp(sPrefix, false, imgUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgUpdate_Visible), 5, 0), true);
            }
            if ( ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) ) && ((SdtK2BActivityList_K2BActivityListItem)AV11ActivityList.Item(2)).gxTpr_Isauthorized )
            {
               imgDelete_Visible = 1;
               AssignProp(sPrefix, false, imgDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgDelete_Visible), 5, 0), true);
            }
            else
            {
               imgDelete_Visible = 0;
               AssignProp(sPrefix, false, imgDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgDelete_Visible), 5, 0), true);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV17GXLvl28 == 0 )
         {
            imgUpdate_Visible = 0;
            AssignProp(sPrefix, false, imgUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgUpdate_Visible), 5, 0), true);
            imgDelete_Visible = 0;
            AssignProp(sPrefix, false, imgDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgDelete_Visible), 5, 0), true);
         }
         WebComp_Transactioncomponent_Visible = 1;
         AssignProp(sPrefix, false, sPrefix+"gxHTMLWrpW0029"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Transactioncomponent_Visible), 5, 0), true);
         /* Object Property */
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Transactioncomponent_Component), StringUtil.Lower( "TrGestionTableros")) != 0 )
         {
            WebComp_Transactioncomponent = getWebComponent(GetType(), "GeneXus.Programs", "trgestiontableros", new Object[] {context} );
            WebComp_Transactioncomponent.ComponentInit();
            WebComp_Transactioncomponent.Name = "TrGestionTableros";
            WebComp_Transactioncomponent_Component = "TrGestionTableros";
         }
         if ( StringUtil.Len( WebComp_Transactioncomponent_Component) != 0 )
         {
            WebComp_Transactioncomponent.setjustcreated();
            WebComp_Transactioncomponent.componentprepare(new Object[] {(String)sPrefix+"W0029",(String)"",(String)Gx_mode,(Guid)AV6TrGestionTableros_ID});
            WebComp_Transactioncomponent.componentbind(new Object[] {(String)"",(String)""});
         }
         if ( isFullAjaxMode( ) )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0029"+"");
            WebComp_Transactioncomponent.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E131S2( )
      {
         /* 'DoUpdate' Routine */
         new k2bgettrncontextbyname(context ).execute(  "TrGestionTableros", out  AV10TrnContext) ;
         GXt_char1 = "";
         new k2bgetcallerurl(context ).execute( out  GXt_char1) ;
         AV10TrnContext.gxTpr_Callerurl = GXt_char1;
         AV10TrnContext.gxTpr_Returnmode = "value 0";
         new k2bsettrncontextbyname(context ).execute(  "TrGestionTableros",  AV10TrnContext) ;
         CallWebObject(formatLink("entitymanagertrgestiontableros.aspx") + "?" + UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(AV6TrGestionTableros_ID.ToString()) + "," + UrlEncode(StringUtil.RTrim("General")));
         context.wjLocDisableFrm = 1;
      }

      protected void E141S2( )
      {
         /* 'DoDelete' Routine */
         new k2bgettrncontextbyname(context ).execute(  "TrGestionTableros", out  AV10TrnContext) ;
         GXt_char1 = "";
         new k2bgetcallerurl(context ).execute( out  GXt_char1) ;
         AV10TrnContext.gxTpr_Callerurl = GXt_char1;
         AV10TrnContext.gxTpr_Returnmode = "value 0";
         new k2bsettrncontextbyname(context ).execute(  "TrGestionTableros",  AV10TrnContext) ;
         CallWebObject(formatLink("entitymanagertrgestiontableros.aspx") + "?" + UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(AV6TrGestionTableros_ID.ToString()) + "," + UrlEncode(StringUtil.RTrim("General")));
         context.wjLocDisableFrm = 1;
      }

      protected void nextLoad( )
      {
      }

      protected void E151S2( )
      {
         /* Load Routine */
      }

      protected void wb_table1_15_1S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable4_Internalname, tblTable4_Internalname, "", "K2BTableActionsRightContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='Section_Basic_TextAlign_Right'>") ;
            wb_table2_18_1S2( true) ;
         }
         else
         {
            wb_table2_18_1S2( false) ;
         }
         return  ;
      }

      protected void wb_table2_18_1S2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_15_1S2e( true) ;
         }
         else
         {
            wb_table1_15_1S2e( false) ;
         }
      }

      protected void wb_table2_18_1S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btableactionsrightcontainer_Internalname, tblK2btableactionsrightcontainer_Internalname, "", "K2BToolsTable_FloatRight", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgUpdate_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgUpdate_Visible, 1, "K2BT_UpdateAction", imgUpdate_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 5, imgUpdate_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TrGestionTablerosGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgDelete_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgDelete_Visible, 1, "K2BT_DeleteAction", imgDelete_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 5, imgDelete_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TrGestionTablerosGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_18_1S2e( true) ;
         }
         else
         {
            wb_table2_18_1S2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (String)getParm(obj,0);
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         AV6TrGestionTableros_ID = (Guid)((Guid)getParm(obj,1));
         AssignAttri(sPrefix, false, "AV6TrGestionTableros_ID", AV6TrGestionTableros_ID.ToString());
         AV8TabCode = (String)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV8TabCode", AV8TabCode);
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
         PA1S2( ) ;
         WS1S2( ) ;
         WE1S2( ) ;
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
         sCtrlAV6TrGestionTableros_ID = (String)((String)getParm(obj,1));
         sCtrlAV8TabCode = (String)((String)getParm(obj,2));
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA1S2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (String)getParm(obj,0);
         sSFPrefix = (String)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "trgestiontablerosgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA1S2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (String)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV6TrGestionTableros_ID = (Guid)((Guid)getParm(obj,3));
            AssignAttri(sPrefix, false, "AV6TrGestionTableros_ID", AV6TrGestionTableros_ID.ToString());
            AV8TabCode = (String)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV8TabCode", AV8TabCode);
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV6TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV6TrGestionTableros_ID")));
         wcpOAV8TabCode = cgiGet( sPrefix+"wcpOAV8TabCode");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV6TrGestionTableros_ID != wcpOAV6TrGestionTableros_ID ) || ( StringUtil.StrCmp(AV8TabCode, wcpOAV8TabCode) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV6TrGestionTableros_ID = (Guid)(AV6TrGestionTableros_ID);
         wcpOAV8TabCode = AV8TabCode;
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
         sCtrlAV6TrGestionTableros_ID = cgiGet( sPrefix+"AV6TrGestionTableros_ID_CTRL");
         if ( StringUtil.Len( sCtrlAV6TrGestionTableros_ID) > 0 )
         {
            AV6TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( cgiGet( sCtrlAV6TrGestionTableros_ID)));
            AssignAttri(sPrefix, false, "AV6TrGestionTableros_ID", AV6TrGestionTableros_ID.ToString());
         }
         else
         {
            AV6TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( cgiGet( sPrefix+"AV6TrGestionTableros_ID_PARM")));
         }
         sCtrlAV8TabCode = cgiGet( sPrefix+"AV8TabCode_CTRL");
         if ( StringUtil.Len( sCtrlAV8TabCode) > 0 )
         {
            AV8TabCode = cgiGet( sCtrlAV8TabCode);
            AssignAttri(sPrefix, false, "AV8TabCode", AV8TabCode);
         }
         else
         {
            AV8TabCode = cgiGet( sPrefix+"AV8TabCode_PARM");
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
         PA1S2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS1S2( ) ;
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
         WS1S2( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6TrGestionTableros_ID_PARM", AV6TrGestionTableros_ID.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6TrGestionTableros_ID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6TrGestionTableros_ID_CTRL", StringUtil.RTrim( sCtrlAV6TrGestionTableros_ID));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8TabCode_PARM", StringUtil.RTrim( AV8TabCode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8TabCode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8TabCode_CTRL", StringUtil.RTrim( sCtrlAV8TabCode));
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
         WE1S2( ) ;
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
         if ( ! ( WebComp_Transactioncomponent == null ) )
         {
            WebComp_Transactioncomponent.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Transactioncomponent == null ) )
         {
            if ( StringUtil.Len( WebComp_Transactioncomponent_Component) != 0 )
            {
               WebComp_Transactioncomponent.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?20221020114136", true, true);
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
         context.AddJavascriptSource("trgestiontablerosgeneral.js", "?20221020114136", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgUpdate_Internalname = sPrefix+"UPDATE";
         imgDelete_Internalname = sPrefix+"DELETE";
         tblK2btableactionsrightcontainer_Internalname = sPrefix+"K2BTABLEACTIONSRIGHTCONTAINER";
         tblTable4_Internalname = sPrefix+"TABLE4";
         divTable2_Internalname = sPrefix+"TABLE2";
         divTable3_Internalname = sPrefix+"TABLE3";
         divTable1_Internalname = sPrefix+"TABLE1";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
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
         imgDelete_Visible = 1;
         imgUpdate_Visible = 1;
         imgDelete_Tooltiptext = "";
         imgUpdate_Tooltiptext = "";
         WebComp_Transactioncomponent_Visible = 1;
         AssignProp(sPrefix, false, sPrefix+"gxHTMLWrpW0029"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Transactioncomponent_Visible), 5, 0), true);
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1TrGestionTableros_ID',fld:'TRGESTIONTABLEROS_ID',pic:''},{av:'AV6TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'imgUpdate_Visible',ctrl:'UPDATE',prop:'Visible'},{av:'imgDelete_Visible',ctrl:'DELETE',prop:'Visible'},{ctrl:'TRANSACTIONCOMPONENT',prop:'Visible'},{ctrl:'TRANSACTIONCOMPONENT'}]}");
         setEventMetadata("'DOUPDATE'","{handler:'E131S2',iparms:[{av:'AV6TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:''}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E141S2',iparms:[{av:'AV6TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:''}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
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
         wcpOGx_mode = "";
         wcpOAV6TrGestionTableros_ID = (Guid)(Guid.Empty);
         wcpOAV8TabCode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         A1TrGestionTableros_ID = (Guid)(Guid.Empty);
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         WebComp_Transactioncomponent_Component = "";
         OldTransactioncomponent = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV11ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "TABLEROS_WEB");
         AV12ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         scmdbuf = "";
         H001S2_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         AV10TrnContext = new SdtK2BTrnContext(context);
         GXt_char1 = "";
         sStyleString = "";
         TempTags = "";
         sImgUrl = "";
         imgUpdate_Jsonclick = "";
         imgDelete_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlGx_mode = "";
         sCtrlAV6TrGestionTableros_ID = "";
         sCtrlAV8TabCode = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trgestiontablerosgeneral__default(),
            new Object[][] {
                new Object[] {
               H001S2_A1TrGestionTableros_ID
               }
            }
         );
         WebComp_Transactioncomponent = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV17GXLvl28 ;
      private short nGXWrapped ;
      private int WebComp_Transactioncomponent_Visible ;
      private int imgUpdate_Visible ;
      private int imgDelete_Visible ;
      private int idxLst ;
      private String Gx_mode ;
      private String AV8TabCode ;
      private String wcpOGx_mode ;
      private String wcpOAV8TabCode ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sPrefix ;
      private String sCompPrefix ;
      private String sSFPrefix ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String divMaintable_Internalname ;
      private String divTable1_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String divTable2_Internalname ;
      private String divTable3_Internalname ;
      private String WebComp_Transactioncomponent_Component ;
      private String OldTransactioncomponent ;
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String imgUpdate_Tooltiptext ;
      private String imgUpdate_Internalname ;
      private String imgDelete_Tooltiptext ;
      private String imgDelete_Internalname ;
      private String scmdbuf ;
      private String GXt_char1 ;
      private String sStyleString ;
      private String tblTable4_Internalname ;
      private String tblK2btableactionsrightcontainer_Internalname ;
      private String TempTags ;
      private String sImgUrl ;
      private String imgUpdate_Jsonclick ;
      private String imgDelete_Jsonclick ;
      private String sCtrlGx_mode ;
      private String sCtrlAV6TrGestionTableros_ID ;
      private String sCtrlAV8TabCode ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private Guid AV6TrGestionTableros_ID ;
      private Guid wcpOAV6TrGestionTableros_ID ;
      private Guid A1TrGestionTableros_ID ;
      private GXWebComponent WebComp_Transactioncomponent ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] H001S2_A1TrGestionTableros_ID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV11ActivityList ;
      private SdtK2BTrnContext AV10TrnContext ;
      private SdtK2BActivityList_K2BActivityListItem AV12ActivityListItem ;
   }

   public class trgestiontablerosgeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH001S2 ;
          prmH001S2 = new Object[] {
          new Object[] {"@AV6TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H001S2", "SELECT [TrGestionTableros_ID] FROM TABLERO.[TrGestionTableros] WHERE [TrGestionTableros_ID] = @AV6TrGestionTableros_ID ORDER BY [TrGestionTableros_ID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001S2,1, GxCacheFrequency.OFF ,false,true )
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
