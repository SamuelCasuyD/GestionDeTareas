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
   public class masterpage : GXMasterPage, System.Web.SessionState.IRequiresSessionState
   {
      public masterpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public masterpage( IGxContext context )
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
            PA092( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS092( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE092( ) ;
               }
            }
         }
         this.cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlHeaders();
         }
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlOpenForm();
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
      }

      protected void RenderHtmlCloseForm092( )
      {
         SendCloseFormHiddens( ) ;
         SendSecurityToken((String)(sPrefix));
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlCloseForm();
         }
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.AddJavascriptSource("masterpage.js", "?202210211744329", false, true);
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override String GetPgmname( )
      {
         return "MasterPage" ;
      }

      public override String GetPgmdesc( )
      {
         return "Master Page" ;
      }

      protected void WB090( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            if ( ! ShowMPWhenPopUp( ) && context.isPopUpObject( ) )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               /* Content placeholder */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gx-content-placeholder");
               context.WriteHtmlText( ">") ;
               if ( ! isFullAjaxMode( ) )
               {
                  getDataAreaObject().RenderHtmlContent();
               }
               context.WriteHtmlText( "</div>") ;
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
               wbLoad = true;
               return  ;
            }
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtscrip1_Internalname, lblTxtscrip1_Caption, "", "", lblTxtscrip1_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlock", 0, "", 1, 1, 2, "HLP_MasterPage.htm");
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            /* Content placeholder */
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-content-placeholder");
            context.WriteHtmlText( ">") ;
            if ( ! isFullAjaxMode( ) )
            {
               getDataAreaObject().RenderHtmlContent();
            }
            context.WriteHtmlText( "</div>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtscript2_Internalname, lblTxtscript2_Caption, "", "", lblTxtscript2_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlock", 0, "", 1, 1, 2, "HLP_MasterPage.htm");
         }
         wbLoad = true;
      }

      protected void START092( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP090( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( getDataAreaObject().ExecuteStartEvent() != 0 )
            {
               setAjaxCallMode();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void WS092( )
      {
         START092( ) ;
         EVT092( ) ;
      }

      protected void EVT092( )
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
                        if ( StringUtil.StrCmp(sEvt, "RFR_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11092 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E12092 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER_MPAGE") == 0 )
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
                  if ( context.wbHandled == 0 )
                  {
                     getDataAreaObject().DispatchEvents();
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WE092( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm092( ) ;
            }
         }
      }

      protected void PA092( )
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
         RF092( ) ;
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

      protected void RF092( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ShowMPWhenPopUp( ) || ! context.isPopUpObject( ) )
         {
            gxdyncontrolsrefreshing = true;
            fix_multi_value_controls( ) ;
            gxdyncontrolsrefreshing = false;
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E12092 ();
            WB090( ) ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
      }

      protected void send_integrity_lvl_hashes092( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP090( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11092 ();
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
         E11092 ();
         if (returnInSub) return;
      }

      protected void E11092( )
      {
         /* Start Routine */
         AV6vRuta = AV5HttpRequest.BaseURL;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = "<meta content=\"width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no\" name=\"viewport\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV6vRuta+"Librerias/bower_components/font-awesome/css/font-awesome.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV6vRuta+"Librerias/bower_components/Ionicons/css/ionicons.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV6vRuta+"Librerias/dist/css/AdminLTE.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV6vRuta+"Librerias/dist/css/skins/_all-skins.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV6vRuta+"Librerias/bower_components/morris.js/morris.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV6vRuta+"Librerias/bower_components/jvectormap/jquery-jvectormap.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV6vRuta+"Librerias/bower_components/bootstrap-daterangepicker/daterangepicker.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV6vRuta+"Librerias/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\"https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic\">"+StringUtil.NewLine( )+"<script>window.onload = function(){document.body.className = \"form-horizontal Form form-horizontal-fx hold-transition skin-blue sidebar-mini\";}</script>";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV6vRuta+"Librerias/bower_components/jquery/dist/jquery.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV6vRuta+"Librerias/bower_components/jquery-ui/jquery-ui.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV6vRuta+"Librerias/bower_components/raphael/raphael.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV6vRuta+"Librerias/bower_components/jquery-sparkline/dist/jquery.sparkline.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV6vRuta+"Librerias/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV6vRuta+"Librerias/plugins/jvectormap/jquery-jvectormap-world-mill-en.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV6vRuta+"Librerias/bower_components/jquery-knob/dist/jquery.knob.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV6vRuta+"Librerias/bower_components/moment/min/moment.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV6vRuta+"Librerias/bower_components/bootstrap-daterangepicker/daterangepicker.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV6vRuta+"Librerias/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV6vRuta+"Librerias/bower_components/jquery-slimscroll/jquery.slimscroll.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV6vRuta+"Librerias/bower_components/fastclick/lib/fastclick.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV6vRuta+"Librerias/dist/js/adminlte.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV6vRuta+"Librerias/dist/js/demo.js") ;
         AV7vScript = "<div class=\"wrapper\">" + StringUtil.NewLine( ) + "<header class=\"main-header\">" + StringUtil.NewLine( ) + "<a href=\"#\" class=\"logo\">" + StringUtil.NewLine( ) + "<span class=\"logo-mini\"><b>D</L>S</span>" + StringUtil.NewLine( ) + "<span class=\"logo-lg\"><b>DLS</b>ystem</span>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "<nav class=\"navbar navbar-static-top\">" + StringUtil.NewLine( ) + "<a href=\"#\" class=\"sidebar-toggle\" data-toggle=\"push-menu\" role=\"button\">" + StringUtil.NewLine( ) + " <span class=\"sr-only\"></span>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "<div class=\"navbar-custom-menu\">" + StringUtil.NewLine( ) + "<ul class=\"nav navbar-nav\">" + StringUtil.NewLine( ) + "<li class=\"dropdown notifications-menu\">" + StringUtil.NewLine( ) + "<a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">" + StringUtil.NewLine( ) + "<i class=\"fa fa-bell-o\"></i>" + StringUtil.NewLine( ) + "<span class=\"label label-warning\">5</span>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "<ul class=\"dropdown-menu\">" + StringUtil.NewLine( ) + "<li class=\"header\">Tienes 5 Notificaciones</li>" + StringUtil.NewLine( ) + "<li>" + StringUtil.NewLine( ) + "<ul class=\"menu\">" + StringUtil.NewLine( ) + "<li>" + StringUtil.NewLine( ) + "<a href=\"#\">" + StringUtil.NewLine( ) + "<i class=\"fa fa-users text-aqua\"></i> 5 new members joined today" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "</li>" + StringUtil.NewLine( ) + "</ul>" + StringUtil.NewLine( ) + "</li>" + StringUtil.NewLine( ) + "<li class=\"footer\"><a href=\"#\">Ver Todo</a></li>" + StringUtil.NewLine( ) + "</ul>" + StringUtil.NewLine( ) + "</li>" + StringUtil.NewLine( ) + "</ul>" + StringUtil.NewLine( ) + "</div>" + StringUtil.NewLine( ) + "</nav>" + StringUtil.NewLine( ) + "</header>" + StringUtil.NewLine( ) + "<aside class=\"main-sidebar\" style=\"max-height: 100%;\">" + StringUtil.NewLine( ) + "<section class=\"sidebar\">" + StringUtil.NewLine( ) + "<div class=\"user-panel\">" + StringUtil.NewLine( ) + "<div class=\"pull-left image\">" + StringUtil.NewLine( ) + "</div>" + StringUtil.NewLine( ) + "<div class=\"pull-left info\">" + StringUtil.NewLine( ) + "</div>" + StringUtil.NewLine( ) + "</div>" + StringUtil.NewLine( ) + "<ul class=\"sidebar-menu\" data-widget=\"tree\">" + StringUtil.NewLine( ) + "<li class=\"header\">SOFTWARE</li>";
         /* Using cursor H00092 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A23MenXEst = H00092_A23MenXEst[0];
            n23MenXEst = H00092_n23MenXEst[0];
            A20MenuXDesc = H00092_A20MenuXDesc[0];
            n20MenuXDesc = H00092_n20MenuXDesc[0];
            A22MenXUrl = H00092_A22MenXUrl[0];
            n22MenXUrl = H00092_n22MenXUrl[0];
            AV9vScript11 = AV9vScript11 + "<li class=\"active treeview\">" + StringUtil.NewLine( ) + "<a href=\"" + AV6vRuta + StringUtil.Trim( A22MenXUrl) + "\">" + StringUtil.NewLine( ) + "<i class=\"fa fa-dashboard\"></i> <span>" + StringUtil.Trim( A20MenuXDesc) + "</span>" + StringUtil.NewLine( ) + "<span class=\"pull-right-container\">" + StringUtil.NewLine( ) + "<i class=\"fa fa-angle-left pull-right\"></i>" + StringUtil.NewLine( ) + "</span>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "</li>";
            AssignAttri("", true, "AV9vScript11", AV9vScript11);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV7vScript = AV7vScript + AV9vScript11 + "</ul>" + StringUtil.NewLine( ) + "</section>" + StringUtil.NewLine( ) + "</aside>" + StringUtil.NewLine( ) + "<div class=\"content-wrapper\" >" + StringUtil.NewLine( ) + "<section class=\"content-header\">" + StringUtil.NewLine( ) + "<ol class=\"breadcrumb\" style=\"position:static;\">" + StringUtil.NewLine( ) + "<li><a href=\"#\"><i class=\"fa fa-dashboard\"></i> Position</a></li>" + StringUtil.NewLine( ) + "<li class=\"active\">" + (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption + "</li>" + StringUtil.NewLine( ) + "</ol>" + StringUtil.NewLine( ) + "</section>" + StringUtil.NewLine( ) + "<section class=\"content\" >";
         AV8vScript2 = "  </section></div></div>";
         lblTxtscrip1_Caption = AV7vScript;
         AssignProp("", true, lblTxtscrip1_Internalname, "Caption", lblTxtscrip1_Caption, true);
         lblTxtscript2_Caption = AV8vScript2;
         AssignProp("", true, lblTxtscript2_Internalname, "Caption", lblTxtscript2_Caption, true);
      }

      protected void nextLoad( )
      {
      }

      protected void E12092( )
      {
         /* Load Routine */
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
         PA092( ) ;
         WS092( ) ;
         WE092( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( String sGXDynURL )
      {
      }

      public override void master_styles( )
      {
         define_styles( ) ;
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
         while ( idxLst <= (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)(getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Item(idxLst))), "?202210211744342", true, true);
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
            context.AddJavascriptSource("masterpage.js", "?202210211744343", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTxtscrip1_Internalname = "TXTSCRIP1_MPAGE";
         lblTxtscript2_Internalname = "TXTSCRIPT2_MPAGE";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Internalname = "FORM_MPAGE";
      }

      public override void initialize_properties( )
      {
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         lblTxtscript2_Caption = "Script2";
         lblTxtscrip1_Caption = "Script1";
         Contholder1.setDataArea(getDataAreaObject());
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
         setEventMetadata("REFRESH_MPAGE","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH_MPAGE",",oparms:[]}");
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
         Contholder1 = new GXDataAreaControl();
         GXKey = "";
         sPrefix = "";
         lblTxtscrip1_Jsonclick = "";
         lblTxtscript2_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV6vRuta = "";
         AV5HttpRequest = new GxHttpRequest( context);
         AV7vScript = "";
         scmdbuf = "";
         H00092_A19MenuXid = new short[1] ;
         H00092_A23MenXEst = new String[] {""} ;
         H00092_n23MenXEst = new bool[] {false} ;
         H00092_A20MenuXDesc = new String[] {""} ;
         H00092_n20MenuXDesc = new bool[] {false} ;
         H00092_A22MenXUrl = new String[] {""} ;
         H00092_n22MenXUrl = new bool[] {false} ;
         A23MenXEst = "";
         A20MenuXDesc = "";
         A22MenXUrl = "";
         AV9vScript11 = "";
         AV8vScript2 = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sDynURL = "";
         Form = new GXWebForm();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.masterpage__default(),
            new Object[][] {
                new Object[] {
               H00092_A19MenuXid, H00092_A23MenXEst, H00092_n23MenXEst, H00092_A20MenuXDesc, H00092_n20MenuXDesc, H00092_A22MenXUrl, H00092_n22MenXUrl
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short initialized ;
      private short GxWebError ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGotPars ;
      private short nGXWrapped ;
      private int idxLst ;
      private String GXKey ;
      private String sPrefix ;
      private String lblTxtscrip1_Internalname ;
      private String lblTxtscrip1_Caption ;
      private String lblTxtscrip1_Jsonclick ;
      private String lblTxtscript2_Internalname ;
      private String lblTxtscript2_Caption ;
      private String lblTxtscript2_Jsonclick ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String scmdbuf ;
      private String A23MenXEst ;
      private String sDynURL ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool toggleJsOutput ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n23MenXEst ;
      private bool n20MenuXDesc ;
      private bool n22MenXUrl ;
      private String AV7vScript ;
      private String AV9vScript11 ;
      private String AV8vScript2 ;
      private String AV6vRuta ;
      private String A20MenuXDesc ;
      private String A22MenXUrl ;
      private IGxDataStore dsDefault ;
      private GXDataAreaControl Contholder1 ;
      private IDataStoreProvider pr_default ;
      private short[] H00092_A19MenuXid ;
      private String[] H00092_A23MenXEst ;
      private bool[] H00092_n23MenXEst ;
      private String[] H00092_A20MenuXDesc ;
      private bool[] H00092_n20MenuXDesc ;
      private String[] H00092_A22MenXUrl ;
      private bool[] H00092_n22MenXUrl ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV5HttpRequest ;
      private GXWebForm Form ;
   }

   public class masterpage__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00092 ;
          prmH00092 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("H00092", "SELECT [MenuXid], [MenXEst], [MenuXDesc], [MenXUrl] FROM TABLERO.[Menu] WHERE [MenXEst] = 'A' ORDER BY [MenuXid] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00092,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 1) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getVarchar(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getVarchar(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
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
