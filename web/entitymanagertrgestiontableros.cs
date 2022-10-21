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
   public class entitymanagertrgestiontableros : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public entitymanagertrgestiontableros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public entitymanagertrgestiontableros( IGxContext context )
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
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV6TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( GetNextPar( )));
                  AssignAttri("", false, "AV6TrGestionTableros_ID", AV6TrGestionTableros_ID.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_ID", GetSecureSignedToken( "", AV6TrGestionTableros_ID, context));
                  AV8TabCode = GetNextPar( );
                  AssignAttri("", false, "AV8TabCode", AV8TabCode);
                  GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
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
         PA1Q2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1Q2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210201141322", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("entitymanagertrgestiontableros.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV6TrGestionTableros_ID.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV8TabCode))+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vAVAILABLECOMPONENTS", GetSecureSignedToken( "", AV18AvailableComponents, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vRELATEDTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20RelatedTransactionName, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV25Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_ID", GetSecureSignedToken( "", AV6TrGestionTableros_ID, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAVAILABLECOMPONENTS", AV18AvailableComponents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAVAILABLECOMPONENTS", AV18AvailableComponents);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vAVAILABLECOMPONENTS", GetSecureSignedToken( "", AV18AvailableComponents, context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV8TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
         GxWebStd.gx_hidden_field( context, "vRELATEDTRANSACTIONNAME", StringUtil.RTrim( AV20RelatedTransactionName));
         GxWebStd.gx_hidden_field( context, "gxhash_vRELATEDTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20RelatedTransactionName, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV25Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTABLEROS_ID", AV6TrGestionTableros_ID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_ID", GetSecureSignedToken( "", AV6TrGestionTableros_ID, context));
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
         if ( ! ( WebComp_Tabstrip == null ) )
         {
            WebComp_Tabstrip.componentjscripts();
         }
         if ( ! ( WebComp_Componentwc_general == null ) )
         {
            WebComp_Componentwc_general.componentjscripts();
         }
         if ( ! ( WebComp_Componentwc_trgestiontareas == null ) )
         {
            WebComp_Componentwc_trgestiontareas.componentjscripts();
         }
         if ( ! ( WebComp_Popupcomponent == null ) )
         {
            WebComp_Popupcomponent.componentjscripts();
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
            WE1Q2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1Q2( ) ;
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
         return formatLink("entitymanagertrgestiontableros.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV6TrGestionTableros_ID.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV8TabCode)) ;
      }

      public override String GetPgmname( )
      {
         return "EntityManagerTrGestionTableros" ;
      }

      public override String GetPgmdesc( )
      {
         return "Nombre de tablero" ;
      }

      protected void WB1Q0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
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
            GxWebStd.gx_div_start( context, divSection3_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "h1");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblK2bpgmdesc_Internalname, lblK2bpgmdesc_Caption, "", "", lblK2bpgmdesc_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, "HLP_EntityManagerTrGestionTableros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "h1");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divBacktoworkwithcontainer_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divBacktoworkwithcontainertable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_BackToWorkWithContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divBacktoworkwithcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblBacktoworkwith_Internalname, lblBacktoworkwith_Caption, lblBacktoworkwith_Link, "", lblBacktoworkwith_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_BackToWorkWith", 0, "", 1, 1, 0, "HLP_EntityManagerTrGestionTableros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_EntityManagerContent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divComponentscontainer_components_Internalname, divComponentscontainer_components_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divContainercollapsiblesection_components_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divComponents_components_tabssection_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0033"+"", StringUtil.RTrim( WebComp_Tabstrip_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0033"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Tabstrip_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldTabstrip), StringUtil.Lower( WebComp_Tabstrip_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0033"+"");
                  }
                  WebComp_Tabstrip.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldTabstrip), StringUtil.Lower( WebComp_Tabstrip_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection2_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablayouts_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divComponentstabcontainer_components_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divComponentcontainer_general_Internalname, divComponentcontainer_general_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0043"+"", StringUtil.RTrim( WebComp_Componentwc_general_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0043"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldComponentwc_general), StringUtil.Lower( WebComp_Componentwc_general_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0043"+"");
                  }
                  WebComp_Componentwc_general.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldComponentwc_general), StringUtil.Lower( WebComp_Componentwc_general_Component)) != 0 )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divComponentcontainer_trgestiontareas_Internalname, divComponentcontainer_trgestiontareas_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0049"+"", StringUtil.RTrim( WebComp_Componentwc_trgestiontareas_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0049"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Componentwc_trgestiontareas_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldComponentwc_trgestiontareas), StringUtil.Lower( WebComp_Componentwc_trgestiontareas_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0049"+"");
                  }
                  WebComp_Componentwc_trgestiontareas.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldComponentwc_trgestiontareas), StringUtil.Lower( WebComp_Componentwc_trgestiontareas_Component)) != 0 )
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
            /* User Defined Control */
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, "K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_55_1Q2( true) ;
         }
         else
         {
            wb_table1_55_1Q2( false) ;
         }
         return  ;
      }

      protected void wb_table1_55_1Q2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START1Q2( )
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
            Form.Meta.addItem("description", "Nombre de tablero", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1Q0( ) ;
      }

      protected void WS1Q2( )
      {
         START1Q2( ) ;
         EVT1Q2( ) ;
      }

      protected void EVT1Q2( )
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
                              E111Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E121Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CLOSEMODAL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'CloseModal' */
                              E131Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E141Q2 ();
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
                        if ( nCmpId == 33 )
                        {
                           OldTabstrip = cgiGet( "W0033");
                           if ( ( StringUtil.Len( OldTabstrip) == 0 ) || ( StringUtil.StrCmp(OldTabstrip, WebComp_Tabstrip_Component) != 0 ) )
                           {
                              WebComp_Tabstrip = getWebComponent(GetType(), "GeneXus.Programs", OldTabstrip, new Object[] {context} );
                              WebComp_Tabstrip.ComponentInit();
                              WebComp_Tabstrip.Name = "OldTabstrip";
                              WebComp_Tabstrip_Component = OldTabstrip;
                           }
                           if ( StringUtil.Len( WebComp_Tabstrip_Component) != 0 )
                           {
                              WebComp_Tabstrip.componentprocess("W0033", "", sEvt);
                           }
                           WebComp_Tabstrip_Component = OldTabstrip;
                        }
                        else if ( nCmpId == 43 )
                        {
                           OldComponentwc_general = cgiGet( "W0043");
                           if ( ( StringUtil.Len( OldComponentwc_general) == 0 ) || ( StringUtil.StrCmp(OldComponentwc_general, WebComp_Componentwc_general_Component) != 0 ) )
                           {
                              WebComp_Componentwc_general = getWebComponent(GetType(), "GeneXus.Programs", OldComponentwc_general, new Object[] {context} );
                              WebComp_Componentwc_general.ComponentInit();
                              WebComp_Componentwc_general.Name = "OldComponentwc_general";
                              WebComp_Componentwc_general_Component = OldComponentwc_general;
                           }
                           if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
                           {
                              WebComp_Componentwc_general.componentprocess("W0043", "", sEvt);
                           }
                           WebComp_Componentwc_general_Component = OldComponentwc_general;
                        }
                        else if ( nCmpId == 49 )
                        {
                           OldComponentwc_trgestiontareas = cgiGet( "W0049");
                           if ( ( StringUtil.Len( OldComponentwc_trgestiontareas) == 0 ) || ( StringUtil.StrCmp(OldComponentwc_trgestiontareas, WebComp_Componentwc_trgestiontareas_Component) != 0 ) )
                           {
                              WebComp_Componentwc_trgestiontareas = getWebComponent(GetType(), "GeneXus.Programs", OldComponentwc_trgestiontareas, new Object[] {context} );
                              WebComp_Componentwc_trgestiontareas.ComponentInit();
                              WebComp_Componentwc_trgestiontareas.Name = "OldComponentwc_trgestiontareas";
                              WebComp_Componentwc_trgestiontareas_Component = OldComponentwc_trgestiontareas;
                           }
                           if ( StringUtil.Len( WebComp_Componentwc_trgestiontareas_Component) != 0 )
                           {
                              WebComp_Componentwc_trgestiontareas.componentprocess("W0049", "", sEvt);
                           }
                           WebComp_Componentwc_trgestiontareas_Component = OldComponentwc_trgestiontareas;
                        }
                        else if ( nCmpId == 75 )
                        {
                           OldPopupcomponent = cgiGet( "W0075");
                           if ( ( StringUtil.Len( OldPopupcomponent) == 0 ) || ( StringUtil.StrCmp(OldPopupcomponent, WebComp_Popupcomponent_Component) != 0 ) )
                           {
                              WebComp_Popupcomponent = getWebComponent(GetType(), "GeneXus.Programs", OldPopupcomponent, new Object[] {context} );
                              WebComp_Popupcomponent.ComponentInit();
                              WebComp_Popupcomponent.Name = "OldPopupcomponent";
                              WebComp_Popupcomponent_Component = OldPopupcomponent;
                           }
                           if ( StringUtil.Len( WebComp_Popupcomponent_Component) != 0 )
                           {
                              WebComp_Popupcomponent.componentprocess("W0075", "", sEvt);
                           }
                           WebComp_Popupcomponent_Component = OldPopupcomponent;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE1Q2( )
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

      protected void PA1Q2( )
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
         RF1Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV25Pgmname = "EntityManagerTrGestionTableros";
         context.Gx_err = 0;
      }

      protected void RF1Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E121Q2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Tabstrip_Component) != 0 )
               {
                  WebComp_Tabstrip.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
               {
                  WebComp_Componentwc_general.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Componentwc_trgestiontareas_Component) != 0 )
               {
                  WebComp_Componentwc_trgestiontareas.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Popupcomponent_Component) != 0 )
               {
                  WebComp_Popupcomponent.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E141Q2 ();
            WB1Q0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes1Q2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAVAILABLECOMPONENTS", AV18AvailableComponents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAVAILABLECOMPONENTS", AV18AvailableComponents);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vAVAILABLECOMPONENTS", GetSecureSignedToken( "", AV18AvailableComponents, context));
         GxWebStd.gx_hidden_field( context, "vRELATEDTRANSACTIONNAME", StringUtil.RTrim( AV20RelatedTransactionName));
         GxWebStd.gx_hidden_field( context, "gxhash_vRELATEDTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20RelatedTransactionName, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV25Pgmname, "")), context));
      }

      protected void before_start_formulas( )
      {
         AV25Pgmname = "EntityManagerTrGestionTableros";
         context.Gx_err = 0;
      }

      protected void STRUP1Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E111Q2 ();
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
         E111Q2 ();
         if (returnInSub) return;
      }

      protected void E111Q2( )
      {
         /* Start Routine */
         lblBacktoworkwith_Caption = StringUtil.Format( "%1", "Nombre de tableroes", "", "", "", "", "", "", "", "");
         AssignProp("", false, lblBacktoworkwith_Internalname, "Caption", lblBacktoworkwith_Caption, true);
         lblBacktoworkwith_Link = formatLink("wwtrgestiontableros.aspx") ;
         AssignProp("", false, lblBacktoworkwith_Internalname, "Link", lblBacktoworkwith_Link, true);
         AV24GXLvl7 = 0;
         /* Using cursor H001Q2 */
         pr_default.execute(0, new Object[] {AV6TrGestionTableros_ID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1TrGestionTableros_ID = (Guid)((Guid)(H001Q2_A1TrGestionTableros_ID[0]));
            A2TrGestionTableros_Nombre = H001Q2_A2TrGestionTableros_Nombre[0];
            n2TrGestionTableros_Nombre = H001Q2_n2TrGestionTableros_Nombre[0];
            AV24GXLvl7 = 1;
            Form.Caption = A2TrGestionTableros_Nombre;
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            lblK2bpgmdesc_Caption = StringUtil.Format( "%1 - %2", "Nombre de tablero", A2TrGestionTableros_Nombre, "", "", "", "", "", "", "");
            AssignProp("", false, lblK2bpgmdesc_Internalname, "Caption", lblK2bpgmdesc_Caption, true);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV24GXLvl7 == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               context.setWebReturnParms(new Object[] {});
               context.setWebReturnParmsMetadata(new Object[] {});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            lblK2bpgmdesc_Caption = "Nombre de tablero";
            AssignProp("", false, lblK2bpgmdesc_Internalname, "Caption", lblK2bpgmdesc_Caption, true);
         }
         new k2bsetobjectcontainername(context ).execute(  AV25Pgmname) ;
         GXt_objcol_SdtMessages_Message1 = AV16Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV16Messages = GXt_objcol_SdtMessages_Message1;
         AV26GXV1 = 1;
         while ( AV26GXV1 <= AV16Messages.Count )
         {
            AV17Message = ((SdtMessages_Message)AV16Messages.Item(AV26GXV1));
            GX_msglist.addItem(AV17Message.gxTpr_Description);
            AV26GXV1 = (int)(AV26GXV1+1);
         }
      }

      protected void E121Q2( )
      {
         /* Refresh Routine */
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         /* Execute user subroutine: 'LOADCOMPONENTGROUP_COMPONENTS' */
         S112 ();
         if (returnInSub) return;
         GXt_char2 = AV19NextComponentCode;
         new k2bgetnextcomponentcode(context ).execute(  AV18AvailableComponents,  AV8TabCode, out  GXt_char2) ;
         AV19NextComponentCode = GXt_char2;
         if ( ( StringUtil.StrCmp(AV8TabCode, "General") == 0 ) || ( StringUtil.StrCmp(AV8TabCode, "") == 0 ) )
         {
            AV20RelatedTransactionName = "TrGestionTableros";
            AssignAttri("", false, "AV20RelatedTransactionName", AV20RelatedTransactionName);
            GxWebStd.gx_hidden_field( context, "gxhash_vRELATEDTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20RelatedTransactionName, "")), context));
         }
         else if ( StringUtil.StrCmp(AV8TabCode, "TrGestionTareas") == 0 )
         {
            AV20RelatedTransactionName = "TrGestionTareas";
            AssignAttri("", false, "AV20RelatedTransactionName", AV20RelatedTransactionName);
            GxWebStd.gx_hidden_field( context, "gxhash_vRELATEDTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20RelatedTransactionName, "")), context));
         }
         new k2bgettrncontextbyname(context ).execute(  AV20RelatedTransactionName, out  AV9TrnContext) ;
         AV14CurrentUrl = AV9TrnContext.gxTpr_Callerurl;
         AV9TrnContext.gxTpr_Entitymanagername = AV25Pgmname;
         AV9TrnContext.gxTpr_Entitymanagernexttaskcode = AV19NextComponentCode;
         AV9TrnContext.gxTpr_Entitymanagernexttaskmode = "DSP";
         new k2bsettrncontextbyname(context ).execute(  AV20RelatedTransactionName,  AV9TrnContext) ;
         tblTablemodal_Visible = 0;
         AssignProp("", false, tblTablemodal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemodal_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            if ( ( StringUtil.StrCmp(AV8TabCode, "General") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( AV8TabCode)) )
            {
               lblComponenttitle_Caption = StringUtil.Format( "Update %1", "Nombre de tablero", "", "", "", "", "", "", "", "");
               AssignProp("", false, lblComponenttitle_Internalname, "Caption", lblComponenttitle_Caption, true);
               tblTablemodal_Visible = 1;
               AssignProp("", false, tblTablemodal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemodal_Visible), 5, 0), true);
               /* Object Property */
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Popupcomponent_Component), StringUtil.Lower( "TrGestionTableros")) != 0 )
               {
                  WebComp_Popupcomponent = getWebComponent(GetType(), "GeneXus.Programs", "trgestiontableros", new Object[] {context} );
                  WebComp_Popupcomponent.ComponentInit();
                  WebComp_Popupcomponent.Name = "TrGestionTableros";
                  WebComp_Popupcomponent_Component = "TrGestionTableros";
               }
               if ( StringUtil.Len( WebComp_Popupcomponent_Component) != 0 )
               {
                  WebComp_Popupcomponent.setjustcreated();
                  WebComp_Popupcomponent.componentprepare(new Object[] {(String)"W0075",(String)"",(String)"UPD",(Guid)AV6TrGestionTableros_ID});
                  WebComp_Popupcomponent.componentbind(new Object[] {(String)"",(String)""});
               }
               if ( isFullAjaxMode( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0075"+"");
                  WebComp_Popupcomponent.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            if ( ( StringUtil.StrCmp(AV8TabCode, "General") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( AV8TabCode)) )
            {
               lblComponenttitle_Caption = StringUtil.Format( "Delete %1", "Nombre de tablero", "", "", "", "", "", "", "", "");
               AssignProp("", false, lblComponenttitle_Internalname, "Caption", lblComponenttitle_Caption, true);
               tblTablemodal_Visible = 1;
               AssignProp("", false, tblTablemodal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemodal_Visible), 5, 0), true);
               /* Object Property */
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Popupcomponent_Component), StringUtil.Lower( "TrGestionTableros")) != 0 )
               {
                  WebComp_Popupcomponent = getWebComponent(GetType(), "GeneXus.Programs", "trgestiontableros", new Object[] {context} );
                  WebComp_Popupcomponent.ComponentInit();
                  WebComp_Popupcomponent.Name = "TrGestionTableros";
                  WebComp_Popupcomponent_Component = "TrGestionTableros";
               }
               if ( StringUtil.Len( WebComp_Popupcomponent_Component) != 0 )
               {
                  WebComp_Popupcomponent.setjustcreated();
                  WebComp_Popupcomponent.componentprepare(new Object[] {(String)"W0075",(String)"",(String)"DLT",(Guid)AV6TrGestionTableros_ID});
                  WebComp_Popupcomponent.componentbind(new Object[] {(String)"",(String)""});
               }
               if ( isFullAjaxMode( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0075"+"");
                  WebComp_Popupcomponent.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18AvailableComponents", AV18AvailableComponents);
      }

      protected void S112( )
      {
         /* 'LOADCOMPONENTGROUP_COMPONENTS' Routine */
         AV10Tabs = new GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>( context, "K2BTabOptionsItem", "TABLEROS_WEB");
         AV18AvailableComponents.Add("General", 0);
         AV11Tab = new SdtK2BTabOptions_K2BTabOptionsItem(context);
         AV11Tab.gxTpr_Code = "General";
         AV11Tab.gxTpr_Description = "General";
         AV11Tab.gxTpr_Link = formatLink("entitymanagertrgestiontableros.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV6TrGestionTableros_ID.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV11Tab.gxTpr_Code));
         AV11Tab.gxTpr_Componenttype = 3;
         AV11Tab.gxTpr_Relatedtransaction = "TrGestionTableros";
         AV10Tabs.Add(AV11Tab, 0);
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "TrGestionTareas",  "TrGestionTareas",  "List",  "",  "TrGestionTablerosTrGestionTareasWC") )
         {
            AV18AvailableComponents.Add("TrGestionTareas", 0);
            AV11Tab = new SdtK2BTabOptions_K2BTabOptionsItem(context);
            AV11Tab.gxTpr_Code = "TrGestionTareas";
            AV11Tab.gxTpr_Description = "Tr Gestion Tareas";
            AV11Tab.gxTpr_Link = formatLink("entitymanagertrgestiontableros.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV6TrGestionTableros_ID.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV11Tab.gxTpr_Code));
            AV11Tab.gxTpr_Componenttype = 1;
            AV11Tab.gxTpr_Relatedtransaction = "TrGestionTareas";
            AV10Tabs.Add(AV11Tab, 0);
         }
         if ( AV10Tabs.Count > 0 )
         {
            divComponentscontainer_components_Visible = 1;
            AssignProp("", false, divComponentscontainer_components_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentscontainer_components_Visible), 5, 0), true);
            /* Object Property */
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Tabstrip_Component), StringUtil.Lower( "K2BToolsTabsTitleComponent")) != 0 )
            {
               WebComp_Tabstrip = getWebComponent(GetType(), "GeneXus.Programs", "k2btoolstabstitlecomponent", new Object[] {context} );
               WebComp_Tabstrip.ComponentInit();
               WebComp_Tabstrip.Name = "K2BToolsTabsTitleComponent";
               WebComp_Tabstrip_Component = "K2BToolsTabsTitleComponent";
            }
            if ( StringUtil.Len( WebComp_Tabstrip_Component) != 0 )
            {
               WebComp_Tabstrip.setjustcreated();
               WebComp_Tabstrip.componentprepare(new Object[] {(String)"W0033",(String)"",(String)Gx_mode,(GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>)AV10Tabs,(String)AV8TabCode});
               WebComp_Tabstrip.componentbind(new Object[] {(String)"",(String)"",(String)""});
            }
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0033"+"");
               WebComp_Tabstrip.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            divComponentcontainer_general_Visible = 0;
            AssignProp("", false, divComponentcontainer_general_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_general_Visible), 5, 0), true);
            divComponentcontainer_trgestiontareas_Visible = 0;
            AssignProp("", false, divComponentcontainer_trgestiontareas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_trgestiontareas_Visible), 5, 0), true);
            if ( ( StringUtil.StrCmp(AV8TabCode, "General") == 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( AV8TabCode)) && ( StringUtil.StrCmp(((SdtK2BTabOptions_K2BTabOptionsItem)AV10Tabs.Item(1)).gxTpr_Code, "General") == 0 ) ) )
            {
               /* Execute user subroutine: 'LOADCOMPONENT_GENERAL' */
               S122 ();
               if (returnInSub) return;
            }
            else if ( ( StringUtil.StrCmp(AV8TabCode, "TrGestionTareas") == 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( AV8TabCode)) && ( StringUtil.StrCmp(((SdtK2BTabOptions_K2BTabOptionsItem)AV10Tabs.Item(1)).gxTpr_Code, "TrGestionTareas") == 0 ) ) )
            {
               /* Execute user subroutine: 'LOADCOMPONENT_TRGESTIONTAREAS' */
               S132 ();
               if (returnInSub) return;
            }
            else
            {
               /* Execute user subroutine: 'LOADCOMPONENT_GENERAL' */
               S122 ();
               if (returnInSub) return;
            }
         }
         else
         {
            divComponentscontainer_components_Visible = 0;
            AssignProp("", false, divComponentscontainer_components_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentscontainer_components_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMPONENT_GENERAL' Routine */
         divComponentcontainer_general_Visible = 0;
         AssignProp("", false, divComponentcontainer_general_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_general_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            divComponentcontainer_general_Visible = 1;
            AssignProp("", false, divComponentcontainer_general_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_general_Visible), 5, 0), true);
            /* Object Property */
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Componentwc_general_Component), StringUtil.Lower( "TrGestionTablerosGeneral")) != 0 )
            {
               WebComp_Componentwc_general = getWebComponent(GetType(), "GeneXus.Programs", "trgestiontablerosgeneral", new Object[] {context} );
               WebComp_Componentwc_general.ComponentInit();
               WebComp_Componentwc_general.Name = "TrGestionTablerosGeneral";
               WebComp_Componentwc_general_Component = "TrGestionTablerosGeneral";
            }
            if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
            {
               WebComp_Componentwc_general.setjustcreated();
               WebComp_Componentwc_general.componentprepare(new Object[] {(String)"W0043",(String)"",(String)Gx_mode,(Guid)AV6TrGestionTableros_ID,(String)AV8TabCode});
               WebComp_Componentwc_general.componentbind(new Object[] {(String)"",(String)"",(String)""});
            }
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0043"+"");
               WebComp_Componentwc_general.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            divComponentcontainer_general_Visible = 1;
            AssignProp("", false, divComponentcontainer_general_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_general_Visible), 5, 0), true);
            /* Object Property */
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Componentwc_general_Component), StringUtil.Lower( "TrGestionTablerosGeneral")) != 0 )
            {
               WebComp_Componentwc_general = getWebComponent(GetType(), "GeneXus.Programs", "trgestiontablerosgeneral", new Object[] {context} );
               WebComp_Componentwc_general.ComponentInit();
               WebComp_Componentwc_general.Name = "TrGestionTablerosGeneral";
               WebComp_Componentwc_general_Component = "TrGestionTablerosGeneral";
            }
            if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
            {
               WebComp_Componentwc_general.setjustcreated();
               WebComp_Componentwc_general.componentprepare(new Object[] {(String)"W0043",(String)"",(String)"DSP",(Guid)AV6TrGestionTableros_ID,(String)AV8TabCode});
               WebComp_Componentwc_general.componentbind(new Object[] {(String)"",(String)"",(String)""});
            }
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0043"+"");
               WebComp_Componentwc_general.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            divComponentcontainer_general_Visible = 1;
            AssignProp("", false, divComponentcontainer_general_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_general_Visible), 5, 0), true);
            /* Object Property */
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Componentwc_general_Component), StringUtil.Lower( "TrGestionTablerosGeneral")) != 0 )
            {
               WebComp_Componentwc_general = getWebComponent(GetType(), "GeneXus.Programs", "trgestiontablerosgeneral", new Object[] {context} );
               WebComp_Componentwc_general.ComponentInit();
               WebComp_Componentwc_general.Name = "TrGestionTablerosGeneral";
               WebComp_Componentwc_general_Component = "TrGestionTablerosGeneral";
            }
            if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
            {
               WebComp_Componentwc_general.setjustcreated();
               WebComp_Componentwc_general.componentprepare(new Object[] {(String)"W0043",(String)"",(String)"DSP",(Guid)AV6TrGestionTableros_ID,(String)AV8TabCode});
               WebComp_Componentwc_general.componentbind(new Object[] {(String)"",(String)"",(String)""});
            }
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0043"+"");
               WebComp_Componentwc_general.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            divComponentcontainer_general_Visible = 1;
            AssignProp("", false, divComponentcontainer_general_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_general_Visible), 5, 0), true);
            /* Object Property */
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Componentwc_general_Component), StringUtil.Lower( "TrGestionTablerosGeneral")) != 0 )
            {
               WebComp_Componentwc_general = getWebComponent(GetType(), "GeneXus.Programs", "trgestiontablerosgeneral", new Object[] {context} );
               WebComp_Componentwc_general.ComponentInit();
               WebComp_Componentwc_general.Name = "TrGestionTablerosGeneral";
               WebComp_Componentwc_general_Component = "TrGestionTablerosGeneral";
            }
            if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
            {
               WebComp_Componentwc_general.setjustcreated();
               WebComp_Componentwc_general.componentprepare(new Object[] {(String)"W0043",(String)"",(String)"DSP",(Guid)AV6TrGestionTableros_ID,(String)AV8TabCode});
               WebComp_Componentwc_general.componentbind(new Object[] {(String)"",(String)"",(String)""});
            }
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0043"+"");
               WebComp_Componentwc_general.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMPONENT_TRGESTIONTAREAS' Routine */
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "TrGestionTareas",  "TrGestionTareas",  "List",  "",  "TrGestionTablerosTrGestionTareasWC") )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               divComponentcontainer_trgestiontareas_Visible = 1;
               AssignProp("", false, divComponentcontainer_trgestiontareas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_trgestiontareas_Visible), 5, 0), true);
               /* Object Property */
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Componentwc_trgestiontareas_Component), StringUtil.Lower( "TrGestionTablerosTrGestionTareasWC")) != 0 )
               {
                  WebComp_Componentwc_trgestiontareas = getWebComponent(GetType(), "GeneXus.Programs", "trgestiontablerostrgestiontareaswc", new Object[] {context} );
                  WebComp_Componentwc_trgestiontareas.ComponentInit();
                  WebComp_Componentwc_trgestiontareas.Name = "TrGestionTablerosTrGestionTareasWC";
                  WebComp_Componentwc_trgestiontareas_Component = "TrGestionTablerosTrGestionTareasWC";
               }
               if ( StringUtil.Len( WebComp_Componentwc_trgestiontareas_Component) != 0 )
               {
                  WebComp_Componentwc_trgestiontareas.setjustcreated();
                  WebComp_Componentwc_trgestiontareas.componentprepare(new Object[] {(String)"W0049",(String)"",(Guid)AV6TrGestionTableros_ID});
                  WebComp_Componentwc_trgestiontareas.componentbind(new Object[] {(String)""});
               }
               if ( isFullAjaxMode( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0049"+"");
                  WebComp_Componentwc_trgestiontareas.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            else
            {
               divComponentcontainer_trgestiontareas_Visible = 0;
               AssignProp("", false, divComponentcontainer_trgestiontareas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_trgestiontareas_Visible), 5, 0), true);
            }
         }
         else
         {
            divComponentcontainer_trgestiontareas_Visible = 0;
            AssignProp("", false, divComponentcontainer_trgestiontareas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_trgestiontareas_Visible), 5, 0), true);
         }
      }

      protected void E131Q2( )
      {
         /* 'CloseModal' Routine */
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

      protected void E141Q2( )
      {
         /* Load Routine */
      }

      protected void wb_table1_55_1Q2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablemodal_Visible == 0 )
            {
               sStyleString = sStyleString + "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablemodal_Internalname, tblTablemodal_Internalname, "", "Table_ConditionalConfirm", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divModalcomponentwindow_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ModalWindow", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table2_61_1Q2( true) ;
         }
         else
         {
            wb_table2_61_1Q2( false) ;
         }
         return  ;
      }

      protected void wb_table2_61_1Q2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divModalcomponentwindow_inner_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ModalWindow_Inner", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0075"+"", StringUtil.RTrim( WebComp_Popupcomponent_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0075"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Popupcomponent_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldPopupcomponent), StringUtil.Lower( WebComp_Popupcomponent_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0075"+"");
                  }
                  WebComp_Popupcomponent.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldPopupcomponent), StringUtil.Lower( WebComp_Popupcomponent_Component)) != 0 )
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
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_55_1Q2e( true) ;
         }
         else
         {
            wb_table1_55_1Q2e( false) ;
         }
      }

      protected void wb_table2_61_1Q2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable5_Internalname, tblTable5_Internalname, "", "Table_Basic_Widht100Percent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblComponenttitle_Internalname, lblComponenttitle_Caption, "", "", lblComponenttitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "PopupTitle", 0, "", 1, 1, 0, "HLP_EntityManagerTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table3_66_1Q2( true) ;
         }
         else
         {
            wb_table3_66_1Q2( false) ;
         }
         return  ;
      }

      protected void wb_table3_66_1Q2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_61_1Q2e( true) ;
         }
         else
         {
            wb_table2_61_1Q2e( false) ;
         }
      }

      protected void wb_table3_66_1Q2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable6_Internalname, tblTable6_Internalname, "", "K2BToolsTable_FloatRight", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"Right\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Right;text-align:-moz-Right;text-align:-webkit-Right")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'CLOSEMODAL\\'."+"'", "", "PopupHeaderButton", 5, "", 1, 1, 0, "HLP_EntityManagerTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_66_1Q2e( true) ;
         }
         else
         {
            wb_table3_66_1Q2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (String)getParm(obj,0);
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV6TrGestionTableros_ID = (Guid)((Guid)getParm(obj,1));
         AssignAttri("", false, "AV6TrGestionTableros_ID", AV6TrGestionTableros_ID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_ID", GetSecureSignedToken( "", AV6TrGestionTableros_ID, context));
         AV8TabCode = (String)getParm(obj,2);
         AssignAttri("", false, "AV8TabCode", AV8TabCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
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
         PA1Q2( ) ;
         WS1Q2( ) ;
         WE1Q2( ) ;
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
         if ( ! ( WebComp_Tabstrip == null ) )
         {
            if ( StringUtil.Len( WebComp_Tabstrip_Component) != 0 )
            {
               WebComp_Tabstrip.componentthemes();
            }
         }
         if ( ! ( WebComp_Componentwc_general == null ) )
         {
            if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
            {
               WebComp_Componentwc_general.componentthemes();
            }
         }
         if ( ! ( WebComp_Componentwc_trgestiontareas == null ) )
         {
            if ( StringUtil.Len( WebComp_Componentwc_trgestiontareas_Component) != 0 )
            {
               WebComp_Componentwc_trgestiontareas.componentthemes();
            }
         }
         if ( ! ( WebComp_Popupcomponent == null ) )
         {
            if ( StringUtil.Len( WebComp_Popupcomponent_Component) != 0 )
            {
               WebComp_Popupcomponent.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210201141361", true, true);
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
         context.AddJavascriptSource("entitymanagertrgestiontableros.js", "?202210201141361", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblK2bpgmdesc_Internalname = "K2BPGMDESC";
         divSection3_Internalname = "SECTION3";
         divTable1_Internalname = "TABLE1";
         lblBacktoworkwith_Internalname = "BACKTOWORKWITH";
         divBacktoworkwithcell_Internalname = "BACKTOWORKWITHCELL";
         divBacktoworkwithcontainertable_Internalname = "BACKTOWORKWITHCONTAINERTABLE";
         divBacktoworkwithcontainer_Internalname = "BACKTOWORKWITHCONTAINER";
         divComponentcontainer_general_Internalname = "COMPONENTCONTAINER_GENERAL";
         divComponentcontainer_trgestiontareas_Internalname = "COMPONENTCONTAINER_TRGESTIONTAREAS";
         divComponentstabcontainer_components_Internalname = "COMPONENTSTABCONTAINER_COMPONENTS";
         divTablayouts_Internalname = "TABLAYOUTS";
         divSection2_Internalname = "SECTION2";
         divComponents_components_tabssection_Internalname = "COMPONENTS_COMPONENTS_TABSSECTION";
         divContainercollapsiblesection_components_Internalname = "CONTAINERCOLLAPSIBLESECTION_COMPONENTS";
         divComponentscontainer_components_Internalname = "COMPONENTSCONTAINER_COMPONENTS";
         divTable3_Internalname = "TABLE3";
         divTable2_Internalname = "TABLE2";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         lblComponenttitle_Internalname = "COMPONENTTITLE";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         tblTable6_Internalname = "TABLE6";
         tblTable5_Internalname = "TABLE5";
         divModalcomponentwindow_inner_Internalname = "MODALCOMPONENTWINDOW_INNER";
         divModalcomponentwindow_Internalname = "MODALCOMPONENTWINDOW";
         tblTablemodal_Internalname = "TABLEMODAL";
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
         lblComponenttitle_Caption = "Text Block";
         tblTablemodal_Visible = 1;
         divComponentcontainer_trgestiontareas_Visible = 1;
         divComponentcontainer_general_Visible = 1;
         divComponentscontainer_components_Visible = 1;
         lblBacktoworkwith_Link = "";
         lblBacktoworkwith_Caption = "";
         lblK2bpgmdesc_Caption = "Nombre de tablero";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Nombre de tablero";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV18AvailableComponents',fld:'vAVAILABLECOMPONENTS',pic:'',hsh:true},{av:'AV8TabCode',fld:'vTABCODE',pic:'',hsh:true},{av:'AV20RelatedTransactionName',fld:'vRELATEDTRANSACTIONNAME',pic:'',hsh:true},{av:'AV25Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV6TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV20RelatedTransactionName',fld:'vRELATEDTRANSACTIONNAME',pic:'',hsh:true},{av:'tblTablemodal_Visible',ctrl:'TABLEMODAL',prop:'Visible'},{av:'lblComponenttitle_Caption',ctrl:'COMPONENTTITLE',prop:'Caption'},{ctrl:'POPUPCOMPONENT'},{av:'AV18AvailableComponents',fld:'vAVAILABLECOMPONENTS',pic:'',hsh:true},{ctrl:'TABSTRIP'},{av:'divComponentcontainer_general_Visible',ctrl:'COMPONENTCONTAINER_GENERAL',prop:'Visible'},{av:'divComponentcontainer_trgestiontareas_Visible',ctrl:'COMPONENTCONTAINER_TRGESTIONTAREAS',prop:'Visible'},{av:'divComponentscontainer_components_Visible',ctrl:'COMPONENTSCONTAINER_COMPONENTS',prop:'Visible'},{ctrl:'COMPONENTWC_GENERAL'},{ctrl:'COMPONENTWC_TRGESTIONTAREAS'}]}");
         setEventMetadata("'CLOSEMODAL'","{handler:'E131Q2',iparms:[]");
         setEventMetadata("'CLOSEMODAL'",",oparms:[]}");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV18AvailableComponents = new GxSimpleCollection<String>();
         AV20RelatedTransactionName = "";
         AV25Pgmname = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblK2bpgmdesc_Jsonclick = "";
         lblBacktoworkwith_Jsonclick = "";
         WebComp_Tabstrip_Component = "";
         OldTabstrip = "";
         WebComp_Componentwc_general_Component = "";
         OldComponentwc_general = "";
         WebComp_Componentwc_trgestiontareas_Component = "";
         OldComponentwc_trgestiontareas = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         OldPopupcomponent = "";
         WebComp_Popupcomponent_Component = "";
         scmdbuf = "";
         H001Q2_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         H001Q2_A2TrGestionTableros_Nombre = new String[] {""} ;
         H001Q2_n2TrGestionTableros_Nombre = new bool[] {false} ;
         A1TrGestionTableros_ID = (Guid)(Guid.Empty);
         A2TrGestionTableros_Nombre = "";
         AV16Messages = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus");
         AV17Message = new SdtMessages_Message(context);
         AV5Context = new SdtK2BContext(context);
         AV19NextComponentCode = "";
         GXt_char2 = "";
         AV9TrnContext = new SdtK2BTrnContext(context);
         AV14CurrentUrl = "";
         AV10Tabs = new GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>( context, "K2BTabOptionsItem", "TABLEROS_WEB");
         AV11Tab = new SdtK2BTabOptions_K2BTabOptionsItem(context);
         sStyleString = "";
         lblComponenttitle_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.entitymanagertrgestiontableros__default(),
            new Object[][] {
                new Object[] {
               H001Q2_A1TrGestionTableros_ID, H001Q2_A2TrGestionTableros_Nombre, H001Q2_n2TrGestionTableros_Nombre
               }
            }
         );
         WebComp_Tabstrip = new GeneXus.Http.GXNullWebComponent();
         WebComp_Componentwc_general = new GeneXus.Http.GXNullWebComponent();
         WebComp_Componentwc_trgestiontareas = new GeneXus.Http.GXNullWebComponent();
         WebComp_Popupcomponent = new GeneXus.Http.GXNullWebComponent();
         AV25Pgmname = "EntityManagerTrGestionTableros";
         /* GeneXus formulas. */
         AV25Pgmname = "EntityManagerTrGestionTableros";
         context.Gx_err = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV24GXLvl7 ;
      private short nGXWrapped ;
      private int divComponentscontainer_components_Visible ;
      private int divComponentcontainer_general_Visible ;
      private int divComponentcontainer_trgestiontareas_Visible ;
      private int AV26GXV1 ;
      private int tblTablemodal_Visible ;
      private int idxLst ;
      private String Gx_mode ;
      private String AV8TabCode ;
      private String wcpOGx_mode ;
      private String wcpOAV8TabCode ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String AV20RelatedTransactionName ;
      private String AV25Pgmname ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divTable1_Internalname ;
      private String divSection3_Internalname ;
      private String lblK2bpgmdesc_Internalname ;
      private String lblK2bpgmdesc_Caption ;
      private String lblK2bpgmdesc_Jsonclick ;
      private String divBacktoworkwithcontainer_Internalname ;
      private String divBacktoworkwithcontainertable_Internalname ;
      private String divBacktoworkwithcell_Internalname ;
      private String lblBacktoworkwith_Internalname ;
      private String lblBacktoworkwith_Caption ;
      private String lblBacktoworkwith_Link ;
      private String lblBacktoworkwith_Jsonclick ;
      private String divTable2_Internalname ;
      private String divTable3_Internalname ;
      private String divComponentscontainer_components_Internalname ;
      private String divContainercollapsiblesection_components_Internalname ;
      private String divComponents_components_tabssection_Internalname ;
      private String WebComp_Tabstrip_Component ;
      private String OldTabstrip ;
      private String divSection2_Internalname ;
      private String divTablayouts_Internalname ;
      private String divComponentstabcontainer_components_Internalname ;
      private String divComponentcontainer_general_Internalname ;
      private String WebComp_Componentwc_general_Component ;
      private String OldComponentwc_general ;
      private String divComponentcontainer_trgestiontareas_Internalname ;
      private String WebComp_Componentwc_trgestiontareas_Component ;
      private String OldComponentwc_trgestiontareas ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String OldPopupcomponent ;
      private String WebComp_Popupcomponent_Component ;
      private String scmdbuf ;
      private String A2TrGestionTableros_Nombre ;
      private String AV19NextComponentCode ;
      private String GXt_char2 ;
      private String tblTablemodal_Internalname ;
      private String lblComponenttitle_Caption ;
      private String lblComponenttitle_Internalname ;
      private String sStyleString ;
      private String divModalcomponentwindow_Internalname ;
      private String divModalcomponentwindow_inner_Internalname ;
      private String tblTable5_Internalname ;
      private String lblComponenttitle_Jsonclick ;
      private String tblTable6_Internalname ;
      private String lblTextblock1_Internalname ;
      private String lblTextblock1_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n2TrGestionTableros_Nombre ;
      private String AV14CurrentUrl ;
      private Guid AV6TrGestionTableros_ID ;
      private Guid wcpOAV6TrGestionTableros_ID ;
      private Guid A1TrGestionTableros_ID ;
      private GXWebComponent WebComp_Tabstrip ;
      private GXWebComponent WebComp_Componentwc_general ;
      private GXWebComponent WebComp_Componentwc_trgestiontareas ;
      private GXWebComponent WebComp_Popupcomponent ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] H001Q2_A1TrGestionTableros_ID ;
      private String[] H001Q2_A2TrGestionTableros_Nombre ;
      private bool[] H001Q2_n2TrGestionTableros_Nombre ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxSimpleCollection<String> AV18AvailableComponents ;
      private GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem> AV10Tabs ;
      private GXBaseCollection<SdtMessages_Message> AV16Messages ;
      private GXBaseCollection<SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXWebForm Form ;
      private SdtK2BContext AV5Context ;
      private SdtK2BTrnContext AV9TrnContext ;
      private SdtK2BTabOptions_K2BTabOptionsItem AV11Tab ;
      private SdtMessages_Message AV17Message ;
   }

   public class entitymanagertrgestiontableros__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH001Q2 ;
          prmH001Q2 = new Object[] {
          new Object[] {"@AV6TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H001Q2", "SELECT TOP 1 [TrGestionTableros_ID], [TrGestionTableros_Nombre] FROM TABLERO.[TrGestionTableros] WHERE [TrGestionTableros_ID] = @AV6TrGestionTableros_ID ORDER BY [TrGestionTableros_ID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001Q2,1, GxCacheFrequency.OFF ,false,true )
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
