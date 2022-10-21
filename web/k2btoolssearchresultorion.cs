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
   public class k2btoolssearchresultorion : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public k2btoolssearchresultorion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2btoolssearchresultorion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( ref String aP0_SearchCriteriaIn ,
                           ref String aP1_EntityName )
      {
         this.AV6SearchCriteriaIn = aP0_SearchCriteriaIn;
         this.AV5EntityName = aP1_EntityName;
         executePrivate();
         aP0_SearchCriteriaIn=this.AV6SearchCriteriaIn;
         aP1_EntityName=this.AV5EntityName;
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
               AV6SearchCriteriaIn = gxfirstwebparm;
               AssignAttri("", false, "AV6SearchCriteriaIn", AV6SearchCriteriaIn);
               GxWebStd.gx_hidden_field( context, "gxhash_vSEARCHCRITERIAIN", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6SearchCriteriaIn, "")), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV5EntityName = GetNextPar( );
                  AssignAttri("", false, "AV5EntityName", AV5EntityName);
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
         PA0X2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0X2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210202185498", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2btoolssearchresultorion.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV6SearchCriteriaIn)) + "," + UrlEncode(StringUtil.RTrim(AV5EntityName))+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vSEARCHCRITERIAIN", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6SearchCriteriaIn, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vSEARCHCRITERIAIN", StringUtil.RTrim( AV6SearchCriteriaIn));
         GxWebStd.gx_hidden_field( context, "gxhash_vSEARCHCRITERIAIN", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6SearchCriteriaIn, "")), context));
         GxWebStd.gx_hidden_field( context, "vENTITYNAME", StringUtil.RTrim( AV5EntityName));
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
         if ( ! ( WebComp_Tabbedview == null ) )
         {
            WebComp_Tabbedview.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0X2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0X2( ) ;
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
         return formatLink("k2btoolssearchresultorion.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV6SearchCriteriaIn)) + "," + UrlEncode(StringUtil.RTrim(AV5EntityName)) ;
      }

      public override String GetPgmname( )
      {
         return "K2BToolsSearchResultOrion" ;
      }

      public override String GetPgmdesc( )
      {
         return "Search Results" ;
      }

      protected void WB0X0( )
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
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TitleContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblEd_tb_title_Internalname, lblEd_tb_title_Caption, "", "", lblEd_tb_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, "HLP_K2BToolsSearchResultOrion.htm");
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
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_EntityManagerContent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0018"+"", StringUtil.RTrim( WebComp_Tabbedview_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0018"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Tabbedview_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldTabbedview), StringUtil.Lower( WebComp_Tabbedview_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0018"+"");
                  }
                  WebComp_Tabbedview.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldTabbedview), StringUtil.Lower( WebComp_Tabbedview_Component)) != 0 )
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
         }
         wbLoad = true;
      }

      protected void START0X2( )
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
            Form.Meta.addItem("description", "Search Results", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0X0( ) ;
      }

      protected void WS0X2( )
      {
         START0X2( ) ;
         EVT0X2( ) ;
      }

      protected void EVT0X2( )
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
                              E110X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E120X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E130X2 ();
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                        if ( nCmpId == 18 )
                        {
                           OldTabbedview = cgiGet( "W0018");
                           if ( ( StringUtil.Len( OldTabbedview) == 0 ) || ( StringUtil.StrCmp(OldTabbedview, WebComp_Tabbedview_Component) != 0 ) )
                           {
                              WebComp_Tabbedview = getWebComponent(GetType(), "GeneXus.Programs", OldTabbedview, new Object[] {context} );
                              WebComp_Tabbedview.ComponentInit();
                              WebComp_Tabbedview.Name = "OldTabbedview";
                              WebComp_Tabbedview_Component = OldTabbedview;
                           }
                           if ( StringUtil.Len( WebComp_Tabbedview_Component) != 0 )
                           {
                              WebComp_Tabbedview.componentprocess("W0018", "", sEvt);
                           }
                           WebComp_Tabbedview_Component = OldTabbedview;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0X2( )
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

      protected void PA0X2( )
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
         RF0X2( ) ;
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

      protected void RF0X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E120X2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Tabbedview_Component) != 0 )
               {
                  WebComp_Tabbedview.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E130X2 ();
            WB0X0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0X2( )
      {
         GxWebStd.gx_hidden_field( context, "vSEARCHCRITERIAIN", StringUtil.RTrim( AV6SearchCriteriaIn));
         GxWebStd.gx_hidden_field( context, "gxhash_vSEARCHCRITERIAIN", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6SearchCriteriaIn, "")), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP0X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110X2 ();
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
         E110X2 ();
         if (returnInSub) return;
      }

      protected void E110X2( )
      {
         /* Start Routine */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5EntityName)) )
         {
            AV10TabCode = "All";
         }
         else
         {
            AV10TabCode = AV5EntityName;
         }
         /* Execute user subroutine: 'LOADALLTABS' */
         S112 ();
         if (returnInSub) return;
         /* Object Property */
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Tabbedview_Component), StringUtil.Lower( "K2BTabbedViewForLayoutOrionUniversalSearch")) != 0 )
         {
            WebComp_Tabbedview = getWebComponent(GetType(), "GeneXus.Programs", "k2btabbedviewforlayoutorionuniversalsearch", new Object[] {context} );
            WebComp_Tabbedview.ComponentInit();
            WebComp_Tabbedview.Name = "K2BTabbedViewForLayoutOrionUniversalSearch";
            WebComp_Tabbedview_Component = "K2BTabbedViewForLayoutOrionUniversalSearch";
         }
         if ( StringUtil.Len( WebComp_Tabbedview_Component) != 0 )
         {
            WebComp_Tabbedview.setjustcreated();
            WebComp_Tabbedview.componentprepare(new Object[] {(String)"W0018",(String)"",(String)"DSP",(GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>)AV11Tabs,(String)AV10TabCode});
            WebComp_Tabbedview.componentbind(new Object[] {(String)"",(String)"",(String)""});
         }
      }

      protected void E120X2( )
      {
         /* Refresh Routine */
         lblEd_tb_title_Caption = StringUtil.Format( "Search results for '%1'", AV6SearchCriteriaIn, "", "", "", "", "", "", "", "");
         AssignProp("", false, lblEd_tb_title_Internalname, "Caption", lblEd_tb_title_Caption, true);
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADALLTABS' Routine */
         AV11Tabs = new GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>( context, "K2BTabOptionsItem", "TABLEROS_WEB");
         AV9Tab = new SdtK2BTabOptions_K2BTabOptionsItem(context);
         AV9Tab.gxTpr_Code = "All";
         AV9Tab.gxTpr_Description = "All";
         AV9Tab.gxTpr_Webcomponent = formatLink("k2btoolssearchresultentitywcorion.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV6SearchCriteriaIn)) + "," + UrlEncode(StringUtil.RTrim(""));
         AV9Tab.gxTpr_Link = formatLink("k2btoolssearchresultorion.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV6SearchCriteriaIn)) + "," + UrlEncode(StringUtil.RTrim(""));
         AV11Tabs.Add(AV9Tab, 0);
         AV15GXV2 = 1;
         GXt_objcol_SdtSearchableTransactions_SearchableTransactionsItem1 = AV14GXV1;
         new k2bgetsearchableentities(context ).execute( out  GXt_objcol_SdtSearchableTransactions_SearchableTransactionsItem1) ;
         AV14GXV1 = GXt_objcol_SdtSearchableTransactions_SearchableTransactionsItem1;
         while ( AV15GXV2 <= AV14GXV1.Count )
         {
            AV8SearchableTransactionsItem = ((SdtSearchableTransactions_SearchableTransactionsItem)AV14GXV1.Item(AV15GXV2));
            AV9Tab = new SdtK2BTabOptions_K2BTabOptionsItem(context);
            AV9Tab.gxTpr_Code = AV8SearchableTransactionsItem.gxTpr_Searchtype;
            AV9Tab.gxTpr_Description = AV8SearchableTransactionsItem.gxTpr_Transactiondescription;
            AV9Tab.gxTpr_Webcomponent = formatLink("k2btoolssearchresultentitywcorion.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV6SearchCriteriaIn)) + "," + UrlEncode(StringUtil.RTrim(AV8SearchableTransactionsItem.gxTpr_Searchtype));
            AV9Tab.gxTpr_Link = formatLink("k2btoolssearchresultorion.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV6SearchCriteriaIn)) + "," + UrlEncode(StringUtil.RTrim(AV8SearchableTransactionsItem.gxTpr_Searchtype));
            AV11Tabs.Add(AV9Tab, 0);
            AV15GXV2 = (int)(AV15GXV2+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E130X2( )
      {
         /* Load Routine */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6SearchCriteriaIn = (String)getParm(obj,0);
         AssignAttri("", false, "AV6SearchCriteriaIn", AV6SearchCriteriaIn);
         GxWebStd.gx_hidden_field( context, "gxhash_vSEARCHCRITERIAIN", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6SearchCriteriaIn, "")), context));
         AV5EntityName = (String)getParm(obj,1);
         AssignAttri("", false, "AV5EntityName", AV5EntityName);
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
         PA0X2( ) ;
         WS0X2( ) ;
         WE0X2( ) ;
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
         if ( ! ( WebComp_Tabbedview == null ) )
         {
            if ( StringUtil.Len( WebComp_Tabbedview_Component) != 0 )
            {
               WebComp_Tabbedview.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?20221020218559", true, true);
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
         context.AddJavascriptSource("k2btoolssearchresultorion.js", "?202210202185510", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblEd_tb_title_Internalname = "ED_TB_TITLE";
         divTable3_Internalname = "TABLE3";
         divTable1_Internalname = "TABLE1";
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
         lblEd_tb_title_Caption = "Search results for:";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Search Results";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV6SearchCriteriaIn',fld:'vSEARCHCRITERIAIN',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'lblEd_tb_title_Caption',ctrl:'ED_TB_TITLE',prop:'Caption'}]}");
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
         wcpOAV6SearchCriteriaIn = "";
         wcpOAV5EntityName = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblEd_tb_title_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         WebComp_Tabbedview_Component = "";
         OldTabbedview = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV10TabCode = "";
         AV11Tabs = new GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>( context, "K2BTabOptionsItem", "TABLEROS_WEB");
         AV9Tab = new SdtK2BTabOptions_K2BTabOptionsItem(context);
         AV14GXV1 = new GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem>( context, "SearchableTransactionsItem", "TABLEROS_WEB");
         GXt_objcol_SdtSearchableTransactions_SearchableTransactionsItem1 = new GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem>( context, "SearchableTransactionsItem", "TABLEROS_WEB");
         AV8SearchableTransactionsItem = new SdtSearchableTransactions_SearchableTransactionsItem(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         WebComp_Tabbedview = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int AV15GXV2 ;
      private int idxLst ;
      private String AV6SearchCriteriaIn ;
      private String AV5EntityName ;
      private String wcpOAV6SearchCriteriaIn ;
      private String wcpOAV5EntityName ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divTable3_Internalname ;
      private String lblEd_tb_title_Internalname ;
      private String lblEd_tb_title_Caption ;
      private String lblEd_tb_title_Jsonclick ;
      private String ClassString ;
      private String StyleString ;
      private String divTable1_Internalname ;
      private String WebComp_Tabbedview_Component ;
      private String OldTabbedview ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String AV10TabCode ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GXWebComponent WebComp_Tabbedview ;
      private IGxDataStore dsDefault ;
      private String aP0_SearchCriteriaIn ;
      private String aP1_EntityName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem> AV14GXV1 ;
      private GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem> GXt_objcol_SdtSearchableTransactions_SearchableTransactionsItem1 ;
      private GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem> AV11Tabs ;
      private GXWebForm Form ;
      private SdtSearchableTransactions_SearchableTransactionsItem AV8SearchableTransactionsItem ;
      private SdtK2BTabOptions_K2BTabOptionsItem AV9Tab ;
   }

}
