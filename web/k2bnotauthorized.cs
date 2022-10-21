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
   public class k2bnotauthorized : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
   {
      public k2bnotauthorized( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bnotauthorized( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_EntityName ,
                           String aP1_TransactionName ,
                           String aP2_StandardActivityType ,
                           String aP3_UserActivityType ,
                           String aP4_ProgramName )
      {
         this.AV5EntityName = aP0_EntityName;
         this.AV8TransactionName = aP1_TransactionName;
         this.AV7StandardActivityType = aP2_StandardActivityType;
         this.AV9UserActivityType = aP3_UserActivityType;
         this.AV6ProgramName = aP4_ProgramName;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV5EntityName = gxfirstwebparm;
               AssignAttri("", false, "AV5EntityName", AV5EntityName);
               GxWebStd.gx_hidden_field( context, "gxhash_vENTITYNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5EntityName, "")), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV8TransactionName = GetNextPar( );
                  AssignAttri("", false, "AV8TransactionName", AV8TransactionName);
                  GxWebStd.gx_hidden_field( context, "gxhash_vTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TransactionName, "")), context));
                  AV7StandardActivityType = GetNextPar( );
                  AssignAttri("", false, "AV7StandardActivityType", AV7StandardActivityType);
                  GxWebStd.gx_hidden_field( context, "gxhash_vSTANDARDACTIVITYTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7StandardActivityType, "")), context));
                  AV9UserActivityType = GetNextPar( );
                  AssignAttri("", false, "AV9UserActivityType", AV9UserActivityType);
                  GxWebStd.gx_hidden_field( context, "gxhash_vUSERACTIVITYTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9UserActivityType, "")), context));
                  AV6ProgramName = GetNextPar( );
                  AssignAttri("", false, "AV6ProgramName", AV6ProgramName);
                  GxWebStd.gx_hidden_field( context, "gxhash_vPROGRAMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6ProgramName, "")), context));
               }
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
            ValidateSpaRequest();
            PA0B2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS0B2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE0B2( ) ;
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
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "K2B Not Authorized") ;
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
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 947160), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202210202185399", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "";
         if ( nGXWrapped == 0 )
         {
            bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
         }
         context.WriteHtmlText( " "+"class=\"Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("k2bnotauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV5EntityName)) + "," + UrlEncode(StringUtil.RTrim(AV8TransactionName)) + "," + UrlEncode(StringUtil.RTrim(AV7StandardActivityType)) + "," + UrlEncode(StringUtil.RTrim(AV9UserActivityType)) + "," + UrlEncode(StringUtil.RTrim(AV6ProgramName))+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vENTITYNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5EntityName, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TransactionName, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vSTANDARDACTIVITYTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7StandardActivityType, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERACTIVITYTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9UserActivityType, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROGRAMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6ProgramName, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vENTITYNAME", AV5EntityName);
         GxWebStd.gx_hidden_field( context, "gxhash_vENTITYNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5EntityName, "")), context));
         GxWebStd.gx_hidden_field( context, "vTRANSACTIONNAME", AV8TransactionName);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TransactionName, "")), context));
         GxWebStd.gx_hidden_field( context, "vSTANDARDACTIVITYTYPE", StringUtil.RTrim( AV7StandardActivityType));
         GxWebStd.gx_hidden_field( context, "gxhash_vSTANDARDACTIVITYTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7StandardActivityType, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERACTIVITYTYPE", AV9UserActivityType);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERACTIVITYTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9UserActivityType, "")), context));
         GxWebStd.gx_hidden_field( context, "vPROGRAMNAME", AV6ProgramName);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROGRAMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6ProgramName, "")), context));
      }

      protected void RenderHtmlCloseForm0B2( )
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override String GetPgmname( )
      {
         return "K2BNotAuthorized" ;
      }

      public override String GetPgmdesc( )
      {
         return "K2B Not Authorized" ;
      }

      protected void WB0B0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            wb_table1_2_0B2( true) ;
         }
         else
         {
            wb_table1_2_0B2( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_0B2e( bool wbgen )
      {
         if ( wbgen )
         {
         }
         wbLoad = true;
      }

      protected void START0B2( )
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
            Form.Meta.addItem("description", "K2B Not Authorized", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0B0( ) ;
      }

      protected void WS0B2( )
      {
         START0B2( ) ;
         EVT0B2( ) ;
      }

      protected void EVT0B2( )
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
                           E110B2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E120B2 ();
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

      protected void WE0B2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0B2( ) ;
            }
         }
      }

      protected void PA0B2( )
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
         RF0B2( ) ;
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

      protected void RF0B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E120B2 ();
            WB0B0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0B2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP0B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110B2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
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
         E110B2 ();
         if (returnInSub) return;
      }

      protected void E110B2( )
      {
         /* Start Routine */
         GX_msglist.addItem("You are not authorized to do activity");
         GX_msglist.addItem("EntityName:"+AV5EntityName);
         GX_msglist.addItem("TransactionName:"+AV8TransactionName);
         if ( StringUtil.StrCmp(AV7StandardActivityType, "None") == 0 )
         {
            GX_msglist.addItem("ActivityType : "+AV9UserActivityType);
         }
         else
         {
            GX_msglist.addItem("ActivityType: "+AV7StandardActivityType);
         }
         GX_msglist.addItem("PgmName :"+AV6ProgramName);
      }

      protected void nextLoad( )
      {
      }

      protected void E120B2( )
      {
         /* Load Routine */
      }

      protected void wb_table1_2_0B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            sStyleString = sStyleString + " height: " + StringUtil.LTrimStr( (decimal)(150), 10, 0) + "px" + ";";
            sStyleString = sStyleString + " width: " + StringUtil.LTrimStr( (decimal)(100), 10, 0) + "%" + ";";
            GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "MainComponentTable", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            ClassString = "K2BError";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_0B2e( true) ;
         }
         else
         {
            wb_table1_2_0B2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5EntityName = (String)getParm(obj,0);
         AssignAttri("", false, "AV5EntityName", AV5EntityName);
         GxWebStd.gx_hidden_field( context, "gxhash_vENTITYNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5EntityName, "")), context));
         AV8TransactionName = (String)getParm(obj,1);
         AssignAttri("", false, "AV8TransactionName", AV8TransactionName);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TransactionName, "")), context));
         AV7StandardActivityType = (String)getParm(obj,2);
         AssignAttri("", false, "AV7StandardActivityType", AV7StandardActivityType);
         GxWebStd.gx_hidden_field( context, "gxhash_vSTANDARDACTIVITYTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7StandardActivityType, "")), context));
         AV9UserActivityType = (String)getParm(obj,3);
         AssignAttri("", false, "AV9UserActivityType", AV9UserActivityType);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERACTIVITYTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9UserActivityType, "")), context));
         AV6ProgramName = (String)getParm(obj,4);
         AssignAttri("", false, "AV6ProgramName", AV6ProgramName);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROGRAMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6ProgramName, "")), context));
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
         PA0B2( ) ;
         WS0B2( ) ;
         WE0B2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?20221020218546", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("k2bnotauthorized.js", "?20221020218546", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         tblTable1_Internalname = "TABLE1";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV5EntityName',fld:'vENTITYNAME',pic:'',hsh:true},{av:'AV8TransactionName',fld:'vTRANSACTIONNAME',pic:'',hsh:true},{av:'AV7StandardActivityType',fld:'vSTANDARDACTIVITYTYPE',pic:'',hsh:true},{av:'AV9UserActivityType',fld:'vUSERACTIVITYTYPE',pic:'',hsh:true},{av:'AV6ProgramName',fld:'vPROGRAMNAME',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
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
         wcpOAV5EntityName = "";
         wcpOAV8TransactionName = "";
         wcpOAV7StandardActivityType = "";
         wcpOAV9UserActivityType = "";
         wcpOAV6ProgramName = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         sPrefix = "";
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         sStyleString = "";
         ClassString = "";
         StyleString = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private int idxLst ;
      private String AV7StandardActivityType ;
      private String wcpOAV7StandardActivityType ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String sStyleString ;
      private String tblTable1_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private String AV5EntityName ;
      private String AV8TransactionName ;
      private String AV9UserActivityType ;
      private String AV6ProgramName ;
      private String wcpOAV5EntityName ;
      private String wcpOAV8TransactionName ;
      private String wcpOAV9UserActivityType ;
      private String wcpOAV6ProgramName ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
