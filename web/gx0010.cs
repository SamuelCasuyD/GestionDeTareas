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
   public class gx0010 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0010( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public gx0010( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( out Guid aP0_pTrGestionTableros_ID )
      {
         this.AV9pTrGestionTableros_ID = Guid.Empty ;
         executePrivate();
         aP0_pTrGestionTableros_ID=this.AV9pTrGestionTableros_ID;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_84 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_84_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_84_idx = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid1_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               subGrid1_Rows = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV6cTrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( GetNextPar( )));
               AV15cTrGestionTableros_Nombre = GetNextPar( );
               AV7cTrGestionTableros_FechaInicio = context.localUtil.ParseDateParm( GetNextPar( ));
               AV8cTrGestionTableros_FechaFin = context.localUtil.ParseDateParm( GetNextPar( ));
               AV11cTrGestionTableros_FechaCreacion = context.localUtil.ParseDateParm( GetNextPar( ));
               AV12cTrGestionTableros_FechaModificacion = context.localUtil.ParseDateParm( GetNextPar( ));
               AV13cTrGestionTableros_TipoTablero = (short)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cTrGestionTableros_ID, AV15cTrGestionTableros_Nombre, AV7cTrGestionTableros_FechaInicio, AV8cTrGestionTableros_FechaFin, AV11cTrGestionTableros_FechaCreacion, AV12cTrGestionTableros_FechaModificacion, AV13cTrGestionTableros_TipoTablero) ;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV9pTrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( gxfirstwebparm));
               AssignAttri("", false, "AV9pTrGestionTableros_ID", AV9pTrGestionTableros_ID.ToString());
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdpromptmasterpage", "GeneXus.Programs.rwdpromptmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,true);
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
         PA072( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START072( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210211745150", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0010.aspx") + "?" + UrlEncode(AV9pTrGestionTableros_ID.ToString())+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCTRGESTIONTABLEROS_ID", AV6cTrGestionTableros_ID.ToString());
         GxWebStd.gx_hidden_field( context, "GXH_vCTRGESTIONTABLEROS_NOMBRE", StringUtil.RTrim( AV15cTrGestionTableros_Nombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRGESTIONTABLEROS_FECHAINICIO", context.localUtil.Format(AV7cTrGestionTableros_FechaInicio, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRGESTIONTABLEROS_FECHAFIN", context.localUtil.Format(AV8cTrGestionTableros_FechaFin, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRGESTIONTABLEROS_FECHACREACION", context.localUtil.Format(AV11cTrGestionTableros_FechaCreacion, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRGESTIONTABLEROS_FECHAMODIFICACION", context.localUtil.Format(AV12cTrGestionTableros_FechaModificacion, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRGESTIONTABLEROS_TIPOTABLERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cTrGestionTableros_TipoTablero), 4, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPTRGESTIONTABLEROS_ID", AV9pTrGestionTableros_ID.ToString());
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_IDFILTERCONTAINER_Class", StringUtil.RTrim( divTrgestiontableros_idfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_NOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divTrgestiontableros_nombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_FECHAINICIOFILTERCONTAINER_Class", StringUtil.RTrim( divTrgestiontableros_fechainiciofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_FECHAFINFILTERCONTAINER_Class", StringUtil.RTrim( divTrgestiontableros_fechafinfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_FECHACREACIONFILTERCONTAINER_Class", StringUtil.RTrim( divTrgestiontableros_fechacreacionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_FECHAMODIFICACIONFILTERCONTAINER_Class", StringUtil.RTrim( divTrgestiontableros_fechamodificacionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_TIPOTABLEROFILTERCONTAINER_Class", StringUtil.RTrim( divTrgestiontableros_tipotablerofiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
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
            WE072( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT072( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("gx0010.aspx") + "?" + UrlEncode(AV9pTrGestionTableros_ID.ToString()) ;
      }

      public override String GetPgmname( )
      {
         return "Gx0010" ;
      }

      public override String GetPgmdesc( )
      {
         return "Selection List Tr Gestion Tableros" ;
      }

      protected void WB070( )
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
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTrgestiontableros_idfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrgestiontableros_idfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrgestiontableros_idfilter_Internalname, "ID gesti?n tablero", "", "", lblLbltrgestiontableros_idfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11071_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrgestiontableros_id_Internalname, "ID gesti?n tablero", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtrgestiontableros_id_Internalname, AV6cTrGestionTableros_ID.ToString(), AV6cTrGestionTableros_ID.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrgestiontableros_id_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtrgestiontableros_id_Visible, edtavCtrgestiontableros_id_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 1, 0, 0, true, "", "", false, "", "HLP_Gx0010.htm");
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
            GxWebStd.gx_div_start( context, divTrgestiontableros_nombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrgestiontableros_nombrefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrgestiontableros_nombrefilter_Internalname, "Nombre del tablero", "", "", lblLbltrgestiontableros_nombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12071_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrgestiontableros_nombre_Internalname, "Nombre del tablero", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtrgestiontableros_nombre_Internalname, StringUtil.RTrim( AV15cTrGestionTableros_Nombre), StringUtil.RTrim( context.localUtil.Format( AV15cTrGestionTableros_Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrgestiontableros_nombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtrgestiontableros_nombre_Visible, edtavCtrgestiontableros_nombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx0010.htm");
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
            GxWebStd.gx_div_start( context, divTrgestiontableros_fechainiciofiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrgestiontableros_fechainiciofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrgestiontableros_fechainiciofilter_Internalname, "Fecha Inicio", "", "", lblLbltrgestiontableros_fechainiciofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13071_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrgestiontableros_fechainicio_Internalname, "Fecha Inicio", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtrgestiontableros_fechainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtrgestiontableros_fechainicio_Internalname, context.localUtil.Format(AV7cTrGestionTableros_FechaInicio, "99/99/9999"), context.localUtil.Format( AV7cTrGestionTableros_FechaInicio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrgestiontableros_fechainicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtrgestiontableros_fechainicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0010.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divTrgestiontableros_fechafinfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrgestiontableros_fechafinfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrgestiontableros_fechafinfilter_Internalname, "Fecha Fin", "", "", lblLbltrgestiontableros_fechafinfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14071_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrgestiontableros_fechafin_Internalname, "Fecha Fin", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtrgestiontableros_fechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtrgestiontableros_fechafin_Internalname, context.localUtil.Format(AV8cTrGestionTableros_FechaFin, "99/99/9999"), context.localUtil.Format( AV8cTrGestionTableros_FechaFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrgestiontableros_fechafin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtrgestiontableros_fechafin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0010.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divTrgestiontableros_fechacreacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrgestiontableros_fechacreacionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrgestiontableros_fechacreacionfilter_Internalname, "Fecha Creacion del tablero", "", "", lblLbltrgestiontableros_fechacreacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15071_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrgestiontableros_fechacreacion_Internalname, "Fecha Creacion del tablero", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtrgestiontableros_fechacreacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtrgestiontableros_fechacreacion_Internalname, context.localUtil.Format(AV11cTrGestionTableros_FechaCreacion, "99/99/9999"), context.localUtil.Format( AV11cTrGestionTableros_FechaCreacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrgestiontableros_fechacreacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtrgestiontableros_fechacreacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0010.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divTrgestiontableros_fechamodificacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrgestiontableros_fechamodificacionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrgestiontableros_fechamodificacionfilter_Internalname, "Fecha Modificacion del tablero", "", "", lblLbltrgestiontableros_fechamodificacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16071_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrgestiontableros_fechamodificacion_Internalname, "Fecha Modificacion del tablero", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtrgestiontableros_fechamodificacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtrgestiontableros_fechamodificacion_Internalname, context.localUtil.Format(AV12cTrGestionTableros_FechaModificacion, "99/99/9999"), context.localUtil.Format( AV12cTrGestionTableros_FechaModificacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrgestiontableros_fechamodificacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtrgestiontableros_fechamodificacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0010.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divTrgestiontableros_tipotablerofiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrgestiontableros_tipotablerofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrgestiontableros_tipotablerofilter_Internalname, "Tipo de tablero", "", "", lblLbltrgestiontableros_tipotablerofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17071_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrgestiontableros_tipotablero_Internalname, "Tipo de tablero", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtrgestiontableros_tipotablero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cTrGestionTableros_TipoTablero), 4, 0, ".", "")), ((edtavCtrgestiontableros_tipotablero_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV13cTrGestionTableros_TipoTablero), "ZZZ9")) : context.localUtil.Format( (decimal)(AV13cTrGestionTableros_TipoTablero), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrgestiontableros_tipotablero_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtrgestiontableros_tipotablero_Visible, edtavCtrgestiontableros_tipotablero_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18071_client"+"'", TempTags, "", 2, "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid1_Backcolorstyle == 0 )
               {
                  subGrid1_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
               else
               {
                  subGrid1_Titlebackstyle = 1;
                  if ( subGrid1_Backcolorstyle == 1 )
                  {
                     subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "gesti?n tablero") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Inicio") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fin") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "del tablero") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "del tablero") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid1Container.AddObjectProperty("GridName", "Grid1");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid1Container = new GXWebGrid( context);
               }
               else
               {
                  Grid1Container.Clear();
               }
               Grid1Container.SetWrapped(nGXWrapped);
               Grid1Container.AddObjectProperty("GridName", "Grid1");
               Grid1Container.AddObjectProperty("Header", subGrid1_Header);
               Grid1Container.AddObjectProperty("Class", "PromptGrid");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", "");
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", A1TrGestionTableros_ID.ToString());
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A8TrGestionTableros_FechaModificacion, "99/99/9999"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START072( )
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
            Form.Meta.addItem("description", "Selection List Tr Gestion Tableros", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP070( ) ;
      }

      protected void WS072( )
      {
         START072( ) ;
         EVT072( ) ;
      }

      protected void EVT072( )
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_84_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV18Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A1TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( cgiGet( edtTrGestionTableros_ID_Internalname)));
                              A3TrGestionTableros_FechaInicio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrGestionTableros_FechaInicio_Internalname), 0));
                              n3TrGestionTableros_FechaInicio = false;
                              A4TrGestionTableros_FechaFin = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrGestionTableros_FechaFin_Internalname), 0));
                              n4TrGestionTableros_FechaFin = false;
                              A7TrGestionTableros_FechaCreacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrGestionTableros_FechaCreacion_Internalname), 0));
                              n7TrGestionTableros_FechaCreacion = false;
                              A8TrGestionTableros_FechaModificacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrGestionTableros_FechaModificacion_Internalname), 0));
                              n8TrGestionTableros_FechaModificacion = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19072 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20072 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ctrgestiontableros_id Changed */
                                       if ( StringUtil.StrToGuid( cgiGet( "GXH_vCTRGESTIONTABLEROS_ID")) != AV6cTrGestionTableros_ID )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrgestiontableros_nombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCTRGESTIONTABLEROS_NOMBRE"), AV15cTrGestionTableros_Nombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrgestiontableros_fechainicio Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTRGESTIONTABLEROS_FECHAINICIO"), 0) != AV7cTrGestionTableros_FechaInicio )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrgestiontableros_fechafin Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTRGESTIONTABLEROS_FECHAFIN"), 0) != AV8cTrGestionTableros_FechaFin )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrgestiontableros_fechacreacion Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTRGESTIONTABLEROS_FECHACREACION"), 0) != AV11cTrGestionTableros_FechaCreacion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrgestiontableros_fechamodificacion Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTRGESTIONTABLEROS_FECHAMODIFICACION"), 0) != AV12cTrGestionTableros_FechaModificacion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrgestiontableros_tipotablero Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRGESTIONTABLEROS_TIPOTABLERO"), ".", ",") != Convert.ToDecimal( AV13cTrGestionTableros_TipoTablero )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21072 ();
                                       }
                                       dynload_actions( ) ;
                                    }
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

      protected void WE072( )
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

      protected void PA072( )
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
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        Guid AV6cTrGestionTableros_ID ,
                                        String AV15cTrGestionTableros_Nombre ,
                                        DateTime AV7cTrGestionTableros_FechaInicio ,
                                        DateTime AV8cTrGestionTableros_FechaFin ,
                                        DateTime AV11cTrGestionTableros_FechaCreacion ,
                                        DateTime AV12cTrGestionTableros_FechaModificacion ,
                                        short AV13cTrGestionTableros_TipoTablero )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF072( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TRGESTIONTABLEROS_ID", GetSecureSignedToken( "", A1TrGestionTableros_ID, context));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_ID", A1TrGestionTableros_ID.ToString());
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
         RF072( ) ;
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

      protected void RF072( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV15cTrGestionTableros_Nombre ,
                                                 AV7cTrGestionTableros_FechaInicio ,
                                                 AV8cTrGestionTableros_FechaFin ,
                                                 AV11cTrGestionTableros_FechaCreacion ,
                                                 AV12cTrGestionTableros_FechaModificacion ,
                                                 AV13cTrGestionTableros_TipoTablero ,
                                                 A2TrGestionTableros_Nombre ,
                                                 A3TrGestionTableros_FechaInicio ,
                                                 A4TrGestionTableros_FechaFin ,
                                                 A7TrGestionTableros_FechaCreacion ,
                                                 A8TrGestionTableros_FechaModificacion ,
                                                 A9TrGestionTableros_TipoTablero ,
                                                 AV6cTrGestionTableros_ID } ,
                                                 new int[]{
                                                 TypeConstants.STRING, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.STRING, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                                 TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            } ) ;
            lV15cTrGestionTableros_Nombre = StringUtil.PadR( StringUtil.RTrim( AV15cTrGestionTableros_Nombre), 100, "%");
            /* Using cursor H00072 */
            pr_default.execute(0, new Object[] {AV6cTrGestionTableros_ID, lV15cTrGestionTableros_Nombre, AV7cTrGestionTableros_FechaInicio, AV8cTrGestionTableros_FechaFin, AV11cTrGestionTableros_FechaCreacion, AV12cTrGestionTableros_FechaModificacion, AV13cTrGestionTableros_TipoTablero, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A9TrGestionTableros_TipoTablero = H00072_A9TrGestionTableros_TipoTablero[0];
               n9TrGestionTableros_TipoTablero = H00072_n9TrGestionTableros_TipoTablero[0];
               A2TrGestionTableros_Nombre = H00072_A2TrGestionTableros_Nombre[0];
               n2TrGestionTableros_Nombre = H00072_n2TrGestionTableros_Nombre[0];
               A8TrGestionTableros_FechaModificacion = H00072_A8TrGestionTableros_FechaModificacion[0];
               n8TrGestionTableros_FechaModificacion = H00072_n8TrGestionTableros_FechaModificacion[0];
               A7TrGestionTableros_FechaCreacion = H00072_A7TrGestionTableros_FechaCreacion[0];
               n7TrGestionTableros_FechaCreacion = H00072_n7TrGestionTableros_FechaCreacion[0];
               A4TrGestionTableros_FechaFin = H00072_A4TrGestionTableros_FechaFin[0];
               n4TrGestionTableros_FechaFin = H00072_n4TrGestionTableros_FechaFin[0];
               A3TrGestionTableros_FechaInicio = H00072_A3TrGestionTableros_FechaInicio[0];
               n3TrGestionTableros_FechaInicio = H00072_n3TrGestionTableros_FechaInicio[0];
               A1TrGestionTableros_ID = (Guid)((Guid)(H00072_A1TrGestionTableros_ID[0]));
               /* Execute user event: Load */
               E20072 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB070( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes072( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TRGESTIONTABLEROS_ID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, A1TrGestionTableros_ID, context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV15cTrGestionTableros_Nombre ,
                                              AV7cTrGestionTableros_FechaInicio ,
                                              AV8cTrGestionTableros_FechaFin ,
                                              AV11cTrGestionTableros_FechaCreacion ,
                                              AV12cTrGestionTableros_FechaModificacion ,
                                              AV13cTrGestionTableros_TipoTablero ,
                                              A2TrGestionTableros_Nombre ,
                                              A3TrGestionTableros_FechaInicio ,
                                              A4TrGestionTableros_FechaFin ,
                                              A7TrGestionTableros_FechaCreacion ,
                                              A8TrGestionTableros_FechaModificacion ,
                                              A9TrGestionTableros_TipoTablero ,
                                              AV6cTrGestionTableros_ID } ,
                                              new int[]{
                                              TypeConstants.STRING, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.STRING, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         } ) ;
         lV15cTrGestionTableros_Nombre = StringUtil.PadR( StringUtil.RTrim( AV15cTrGestionTableros_Nombre), 100, "%");
         /* Using cursor H00073 */
         pr_default.execute(1, new Object[] {AV6cTrGestionTableros_ID, lV15cTrGestionTableros_Nombre, AV7cTrGestionTableros_FechaInicio, AV8cTrGestionTableros_FechaFin, AV11cTrGestionTableros_FechaCreacion, AV12cTrGestionTableros_FechaModificacion, AV13cTrGestionTableros_TipoTablero});
         GRID1_nRecordCount = H00073_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrGestionTableros_ID, AV15cTrGestionTableros_Nombre, AV7cTrGestionTableros_FechaInicio, AV8cTrGestionTableros_FechaFin, AV11cTrGestionTableros_FechaCreacion, AV12cTrGestionTableros_FechaModificacion, AV13cTrGestionTableros_TipoTablero) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrGestionTableros_ID, AV15cTrGestionTableros_Nombre, AV7cTrGestionTableros_FechaInicio, AV8cTrGestionTableros_FechaFin, AV11cTrGestionTableros_FechaCreacion, AV12cTrGestionTableros_FechaModificacion, AV13cTrGestionTableros_TipoTablero) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrGestionTableros_ID, AV15cTrGestionTableros_Nombre, AV7cTrGestionTableros_FechaInicio, AV8cTrGestionTableros_FechaFin, AV11cTrGestionTableros_FechaCreacion, AV12cTrGestionTableros_FechaModificacion, AV13cTrGestionTableros_TipoTablero) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrGestionTableros_ID, AV15cTrGestionTableros_Nombre, AV7cTrGestionTableros_FechaInicio, AV8cTrGestionTableros_FechaFin, AV11cTrGestionTableros_FechaCreacion, AV12cTrGestionTableros_FechaModificacion, AV13cTrGestionTableros_TipoTablero) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrGestionTableros_ID, AV15cTrGestionTableros_Nombre, AV7cTrGestionTableros_FechaInicio, AV8cTrGestionTableros_FechaFin, AV11cTrGestionTableros_FechaCreacion, AV12cTrGestionTableros_FechaModificacion, AV13cTrGestionTableros_TipoTablero) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP070( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19072 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ".", ","));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","));
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtavCtrgestiontableros_id_Internalname), "") == 0 )
            {
               AV6cTrGestionTableros_ID = (Guid)(Guid.Empty);
               AssignAttri("", false, "AV6cTrGestionTableros_ID", AV6cTrGestionTableros_ID.ToString());
            }
            else
            {
               try
               {
                  AV6cTrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( cgiGet( edtavCtrgestiontableros_id_Internalname)));
                  AssignAttri("", false, "AV6cTrGestionTableros_ID", AV6cTrGestionTableros_ID.ToString());
               }
               catch ( Exception e )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vCTRGESTIONTABLEROS_ID");
                  GX_FocusControl = edtavCtrgestiontableros_id_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV15cTrGestionTableros_Nombre = cgiGet( edtavCtrgestiontableros_nombre_Internalname);
            AssignAttri("", false, "AV15cTrGestionTableros_Nombre", AV15cTrGestionTableros_Nombre);
            if ( context.localUtil.VCDate( cgiGet( edtavCtrgestiontableros_fechainicio_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Inicio"}), 1, "vCTRGESTIONTABLEROS_FECHAINICIO");
               GX_FocusControl = edtavCtrgestiontableros_fechainicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cTrGestionTableros_FechaInicio = DateTime.MinValue;
               AssignAttri("", false, "AV7cTrGestionTableros_FechaInicio", context.localUtil.Format(AV7cTrGestionTableros_FechaInicio, "99/99/9999"));
            }
            else
            {
               AV7cTrGestionTableros_FechaInicio = context.localUtil.CToD( cgiGet( edtavCtrgestiontableros_fechainicio_Internalname), 2);
               AssignAttri("", false, "AV7cTrGestionTableros_FechaInicio", context.localUtil.Format(AV7cTrGestionTableros_FechaInicio, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtrgestiontableros_fechafin_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Fin"}), 1, "vCTRGESTIONTABLEROS_FECHAFIN");
               GX_FocusControl = edtavCtrgestiontableros_fechafin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cTrGestionTableros_FechaFin = DateTime.MinValue;
               AssignAttri("", false, "AV8cTrGestionTableros_FechaFin", context.localUtil.Format(AV8cTrGestionTableros_FechaFin, "99/99/9999"));
            }
            else
            {
               AV8cTrGestionTableros_FechaFin = context.localUtil.CToD( cgiGet( edtavCtrgestiontableros_fechafin_Internalname), 2);
               AssignAttri("", false, "AV8cTrGestionTableros_FechaFin", context.localUtil.Format(AV8cTrGestionTableros_FechaFin, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtrgestiontableros_fechacreacion_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Creacion del tablero"}), 1, "vCTRGESTIONTABLEROS_FECHACREACION");
               GX_FocusControl = edtavCtrgestiontableros_fechacreacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cTrGestionTableros_FechaCreacion = DateTime.MinValue;
               AssignAttri("", false, "AV11cTrGestionTableros_FechaCreacion", context.localUtil.Format(AV11cTrGestionTableros_FechaCreacion, "99/99/9999"));
            }
            else
            {
               AV11cTrGestionTableros_FechaCreacion = context.localUtil.CToD( cgiGet( edtavCtrgestiontableros_fechacreacion_Internalname), 2);
               AssignAttri("", false, "AV11cTrGestionTableros_FechaCreacion", context.localUtil.Format(AV11cTrGestionTableros_FechaCreacion, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtrgestiontableros_fechamodificacion_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Modificacion del tablero"}), 1, "vCTRGESTIONTABLEROS_FECHAMODIFICACION");
               GX_FocusControl = edtavCtrgestiontableros_fechamodificacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cTrGestionTableros_FechaModificacion = DateTime.MinValue;
               AssignAttri("", false, "AV12cTrGestionTableros_FechaModificacion", context.localUtil.Format(AV12cTrGestionTableros_FechaModificacion, "99/99/9999"));
            }
            else
            {
               AV12cTrGestionTableros_FechaModificacion = context.localUtil.CToD( cgiGet( edtavCtrgestiontableros_fechamodificacion_Internalname), 2);
               AssignAttri("", false, "AV12cTrGestionTableros_FechaModificacion", context.localUtil.Format(AV12cTrGestionTableros_FechaModificacion, "99/99/9999"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtrgestiontableros_tipotablero_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtrgestiontableros_tipotablero_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTRGESTIONTABLEROS_TIPOTABLERO");
               GX_FocusControl = edtavCtrgestiontableros_tipotablero_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13cTrGestionTableros_TipoTablero = 0;
               AssignAttri("", false, "AV13cTrGestionTableros_TipoTablero", StringUtil.LTrimStr( (decimal)(AV13cTrGestionTableros_TipoTablero), 4, 0));
            }
            else
            {
               AV13cTrGestionTableros_TipoTablero = (short)(context.localUtil.CToN( cgiGet( edtavCtrgestiontableros_tipotablero_Internalname), ".", ","));
               AssignAttri("", false, "AV13cTrGestionTableros_TipoTablero", StringUtil.LTrimStr( (decimal)(AV13cTrGestionTableros_TipoTablero), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrToGuid( cgiGet( "GXH_vCTRGESTIONTABLEROS_ID")) != AV6cTrGestionTableros_ID )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCTRGESTIONTABLEROS_NOMBRE"), AV15cTrGestionTableros_Nombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCTRGESTIONTABLEROS_FECHAINICIO"), 2) != AV7cTrGestionTableros_FechaInicio )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCTRGESTIONTABLEROS_FECHAFIN"), 2) != AV8cTrGestionTableros_FechaFin )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCTRGESTIONTABLEROS_FECHACREACION"), 2) != AV11cTrGestionTableros_FechaCreacion )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCTRGESTIONTABLEROS_FECHAMODIFICACION"), 2) != AV12cTrGestionTableros_FechaModificacion )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRGESTIONTABLEROS_TIPOTABLERO"), ".", ",") != Convert.ToDecimal( AV13cTrGestionTableros_TipoTablero )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E19072 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19072( )
      {
         /* Start Routine */
         Form.Caption = StringUtil.Format( "Lista de Selecci?n %1", "Tr Gestion Tableros", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV10ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E20072( )
      {
         /* Load Routine */
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV18Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            context.DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E21072 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21072( )
      {
         /* Enter Routine */
         AV9pTrGestionTableros_ID = (Guid)(A1TrGestionTableros_ID);
         AssignAttri("", false, "AV9pTrGestionTableros_ID", AV9pTrGestionTableros_ID.ToString());
         context.setWebReturnParms(new Object[] {(Guid)AV9pTrGestionTableros_ID});
         context.setWebReturnParmsMetadata(new Object[] {"AV9pTrGestionTableros_ID"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV9pTrGestionTableros_ID = (Guid)((Guid)getParm(obj,0));
         AssignAttri("", false, "AV9pTrGestionTableros_ID", AV9pTrGestionTableros_ID.ToString());
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
         PA072( ) ;
         WS072( ) ;
         WE072( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210211745213", true, true);
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
         context.AddJavascriptSource("gx0010.js", "?202210211745213", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtTrGestionTableros_ID_Internalname = "TRGESTIONTABLEROS_ID_"+sGXsfl_84_idx;
         edtTrGestionTableros_FechaInicio_Internalname = "TRGESTIONTABLEROS_FECHAINICIO_"+sGXsfl_84_idx;
         edtTrGestionTableros_FechaFin_Internalname = "TRGESTIONTABLEROS_FECHAFIN_"+sGXsfl_84_idx;
         edtTrGestionTableros_FechaCreacion_Internalname = "TRGESTIONTABLEROS_FECHACREACION_"+sGXsfl_84_idx;
         edtTrGestionTableros_FechaModificacion_Internalname = "TRGESTIONTABLEROS_FECHAMODIFICACION_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtTrGestionTableros_ID_Internalname = "TRGESTIONTABLEROS_ID_"+sGXsfl_84_fel_idx;
         edtTrGestionTableros_FechaInicio_Internalname = "TRGESTIONTABLEROS_FECHAINICIO_"+sGXsfl_84_fel_idx;
         edtTrGestionTableros_FechaFin_Internalname = "TRGESTIONTABLEROS_FECHAFIN_"+sGXsfl_84_fel_idx;
         edtTrGestionTableros_FechaCreacion_Internalname = "TRGESTIONTABLEROS_FECHACREACION_"+sGXsfl_84_fel_idx;
         edtTrGestionTableros_FechaModificacion_Internalname = "TRGESTIONTABLEROS_FECHAMODIFICACION_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB070( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( A1TrGestionTableros_ID.ToString())+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV18Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV18Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavLinkselection_Internalname,(String)sImgUrl,(String)edtavLinkselection_Link,(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"",(String)"",(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"WWActionColumn",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTableros_ID_Internalname,A1TrGestionTableros_ID.ToString(),A1TrGestionTableros_ID.ToString(),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTableros_ID_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)36,(short)0,(short)0,(short)84,(short)1,(short)0,(short)0,(bool)true,(String)"",(String)"",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTableros_FechaInicio_Internalname,context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"),context.localUtil.Format( A3TrGestionTableros_FechaInicio, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTableros_FechaInicio_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTableros_FechaFin_Internalname,context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"),context.localUtil.Format( A4TrGestionTableros_FechaFin, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTableros_FechaFin_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTableros_FechaCreacion_Internalname,context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"),context.localUtil.Format( A7TrGestionTableros_FechaCreacion, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTableros_FechaCreacion_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTableros_FechaModificacion_Internalname,context.localUtil.Format(A8TrGestionTableros_FechaModificacion, "99/99/9999"),context.localUtil.Format( A8TrGestionTableros_FechaModificacion, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTableros_FechaModificacion_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            send_integrity_lvl_hashes072( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLbltrgestiontableros_idfilter_Internalname = "LBLTRGESTIONTABLEROS_IDFILTER";
         edtavCtrgestiontableros_id_Internalname = "vCTRGESTIONTABLEROS_ID";
         divTrgestiontableros_idfiltercontainer_Internalname = "TRGESTIONTABLEROS_IDFILTERCONTAINER";
         lblLbltrgestiontableros_nombrefilter_Internalname = "LBLTRGESTIONTABLEROS_NOMBREFILTER";
         edtavCtrgestiontableros_nombre_Internalname = "vCTRGESTIONTABLEROS_NOMBRE";
         divTrgestiontableros_nombrefiltercontainer_Internalname = "TRGESTIONTABLEROS_NOMBREFILTERCONTAINER";
         lblLbltrgestiontableros_fechainiciofilter_Internalname = "LBLTRGESTIONTABLEROS_FECHAINICIOFILTER";
         edtavCtrgestiontableros_fechainicio_Internalname = "vCTRGESTIONTABLEROS_FECHAINICIO";
         divTrgestiontableros_fechainiciofiltercontainer_Internalname = "TRGESTIONTABLEROS_FECHAINICIOFILTERCONTAINER";
         lblLbltrgestiontableros_fechafinfilter_Internalname = "LBLTRGESTIONTABLEROS_FECHAFINFILTER";
         edtavCtrgestiontableros_fechafin_Internalname = "vCTRGESTIONTABLEROS_FECHAFIN";
         divTrgestiontableros_fechafinfiltercontainer_Internalname = "TRGESTIONTABLEROS_FECHAFINFILTERCONTAINER";
         lblLbltrgestiontableros_fechacreacionfilter_Internalname = "LBLTRGESTIONTABLEROS_FECHACREACIONFILTER";
         edtavCtrgestiontableros_fechacreacion_Internalname = "vCTRGESTIONTABLEROS_FECHACREACION";
         divTrgestiontableros_fechacreacionfiltercontainer_Internalname = "TRGESTIONTABLEROS_FECHACREACIONFILTERCONTAINER";
         lblLbltrgestiontableros_fechamodificacionfilter_Internalname = "LBLTRGESTIONTABLEROS_FECHAMODIFICACIONFILTER";
         edtavCtrgestiontableros_fechamodificacion_Internalname = "vCTRGESTIONTABLEROS_FECHAMODIFICACION";
         divTrgestiontableros_fechamodificacionfiltercontainer_Internalname = "TRGESTIONTABLEROS_FECHAMODIFICACIONFILTERCONTAINER";
         lblLbltrgestiontableros_tipotablerofilter_Internalname = "LBLTRGESTIONTABLEROS_TIPOTABLEROFILTER";
         edtavCtrgestiontableros_tipotablero_Internalname = "vCTRGESTIONTABLEROS_TIPOTABLERO";
         divTrgestiontableros_tipotablerofiltercontainer_Internalname = "TRGESTIONTABLEROS_TIPOTABLEROFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtTrGestionTableros_ID_Internalname = "TRGESTIONTABLEROS_ID";
         edtTrGestionTableros_FechaInicio_Internalname = "TRGESTIONTABLEROS_FECHAINICIO";
         edtTrGestionTableros_FechaFin_Internalname = "TRGESTIONTABLEROS_FECHAFIN";
         edtTrGestionTableros_FechaCreacion_Internalname = "TRGESTIONTABLEROS_FECHACREACION";
         edtTrGestionTableros_FechaModificacion_Internalname = "TRGESTIONTABLEROS_FECHAMODIFICACION";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtTrGestionTableros_FechaModificacion_Jsonclick = "";
         edtTrGestionTableros_FechaCreacion_Jsonclick = "";
         edtTrGestionTableros_FechaFin_Jsonclick = "";
         edtTrGestionTableros_FechaInicio_Jsonclick = "";
         edtTrGestionTableros_ID_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCtrgestiontableros_tipotablero_Jsonclick = "";
         edtavCtrgestiontableros_tipotablero_Enabled = 1;
         edtavCtrgestiontableros_tipotablero_Visible = 1;
         edtavCtrgestiontableros_fechamodificacion_Jsonclick = "";
         edtavCtrgestiontableros_fechamodificacion_Enabled = 1;
         edtavCtrgestiontableros_fechacreacion_Jsonclick = "";
         edtavCtrgestiontableros_fechacreacion_Enabled = 1;
         edtavCtrgestiontableros_fechafin_Jsonclick = "";
         edtavCtrgestiontableros_fechafin_Enabled = 1;
         edtavCtrgestiontableros_fechainicio_Jsonclick = "";
         edtavCtrgestiontableros_fechainicio_Enabled = 1;
         edtavCtrgestiontableros_nombre_Jsonclick = "";
         edtavCtrgestiontableros_nombre_Enabled = 1;
         edtavCtrgestiontableros_nombre_Visible = 1;
         edtavCtrgestiontableros_id_Jsonclick = "";
         edtavCtrgestiontableros_id_Enabled = 1;
         edtavCtrgestiontableros_id_Visible = 1;
         divTrgestiontableros_tipotablerofiltercontainer_Class = "AdvancedContainerItem";
         divTrgestiontableros_fechamodificacionfiltercontainer_Class = "AdvancedContainerItem";
         divTrgestiontableros_fechacreacionfiltercontainer_Class = "AdvancedContainerItem";
         divTrgestiontableros_fechafinfiltercontainer_Class = "AdvancedContainerItem";
         divTrgestiontableros_fechainiciofiltercontainer_Class = "AdvancedContainerItem";
         divTrgestiontableros_nombrefiltercontainer_Class = "AdvancedContainerItem";
         divTrgestiontableros_idfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Tr Gestion Tableros";
         subGrid1_Rows = 10;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrGestionTableros_ID',fld:'vCTRGESTIONTABLEROS_ID',pic:''},{av:'AV15cTrGestionTableros_Nombre',fld:'vCTRGESTIONTABLEROS_NOMBRE',pic:''},{av:'AV7cTrGestionTableros_FechaInicio',fld:'vCTRGESTIONTABLEROS_FECHAINICIO',pic:''},{av:'AV8cTrGestionTableros_FechaFin',fld:'vCTRGESTIONTABLEROS_FECHAFIN',pic:''},{av:'AV11cTrGestionTableros_FechaCreacion',fld:'vCTRGESTIONTABLEROS_FECHACREACION',pic:''},{av:'AV12cTrGestionTableros_FechaModificacion',fld:'vCTRGESTIONTABLEROS_FECHAMODIFICACION',pic:''},{av:'AV13cTrGestionTableros_TipoTablero',fld:'vCTRGESTIONTABLEROS_TIPOTABLERO',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E18071',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLTRGESTIONTABLEROS_IDFILTER.CLICK","{handler:'E11071',iparms:[{av:'divTrgestiontableros_idfiltercontainer_Class',ctrl:'TRGESTIONTABLEROS_IDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRGESTIONTABLEROS_IDFILTER.CLICK",",oparms:[{av:'divTrgestiontableros_idfiltercontainer_Class',ctrl:'TRGESTIONTABLEROS_IDFILTERCONTAINER',prop:'Class'},{av:'edtavCtrgestiontableros_id_Visible',ctrl:'vCTRGESTIONTABLEROS_ID',prop:'Visible'}]}");
         setEventMetadata("LBLTRGESTIONTABLEROS_NOMBREFILTER.CLICK","{handler:'E12071',iparms:[{av:'divTrgestiontableros_nombrefiltercontainer_Class',ctrl:'TRGESTIONTABLEROS_NOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRGESTIONTABLEROS_NOMBREFILTER.CLICK",",oparms:[{av:'divTrgestiontableros_nombrefiltercontainer_Class',ctrl:'TRGESTIONTABLEROS_NOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCtrgestiontableros_nombre_Visible',ctrl:'vCTRGESTIONTABLEROS_NOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLTRGESTIONTABLEROS_FECHAINICIOFILTER.CLICK","{handler:'E13071',iparms:[{av:'divTrgestiontableros_fechainiciofiltercontainer_Class',ctrl:'TRGESTIONTABLEROS_FECHAINICIOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRGESTIONTABLEROS_FECHAINICIOFILTER.CLICK",",oparms:[{av:'divTrgestiontableros_fechainiciofiltercontainer_Class',ctrl:'TRGESTIONTABLEROS_FECHAINICIOFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLTRGESTIONTABLEROS_FECHAFINFILTER.CLICK","{handler:'E14071',iparms:[{av:'divTrgestiontableros_fechafinfiltercontainer_Class',ctrl:'TRGESTIONTABLEROS_FECHAFINFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRGESTIONTABLEROS_FECHAFINFILTER.CLICK",",oparms:[{av:'divTrgestiontableros_fechafinfiltercontainer_Class',ctrl:'TRGESTIONTABLEROS_FECHAFINFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLTRGESTIONTABLEROS_FECHACREACIONFILTER.CLICK","{handler:'E15071',iparms:[{av:'divTrgestiontableros_fechacreacionfiltercontainer_Class',ctrl:'TRGESTIONTABLEROS_FECHACREACIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRGESTIONTABLEROS_FECHACREACIONFILTER.CLICK",",oparms:[{av:'divTrgestiontableros_fechacreacionfiltercontainer_Class',ctrl:'TRGESTIONTABLEROS_FECHACREACIONFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLTRGESTIONTABLEROS_FECHAMODIFICACIONFILTER.CLICK","{handler:'E16071',iparms:[{av:'divTrgestiontableros_fechamodificacionfiltercontainer_Class',ctrl:'TRGESTIONTABLEROS_FECHAMODIFICACIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRGESTIONTABLEROS_FECHAMODIFICACIONFILTER.CLICK",",oparms:[{av:'divTrgestiontableros_fechamodificacionfiltercontainer_Class',ctrl:'TRGESTIONTABLEROS_FECHAMODIFICACIONFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLTRGESTIONTABLEROS_TIPOTABLEROFILTER.CLICK","{handler:'E17071',iparms:[{av:'divTrgestiontableros_tipotablerofiltercontainer_Class',ctrl:'TRGESTIONTABLEROS_TIPOTABLEROFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRGESTIONTABLEROS_TIPOTABLEROFILTER.CLICK",",oparms:[{av:'divTrgestiontableros_tipotablerofiltercontainer_Class',ctrl:'TRGESTIONTABLEROS_TIPOTABLEROFILTERCONTAINER',prop:'Class'},{av:'edtavCtrgestiontableros_tipotablero_Visible',ctrl:'vCTRGESTIONTABLEROS_TIPOTABLERO',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E21072',iparms:[{av:'A1TrGestionTableros_ID',fld:'TRGESTIONTABLEROS_ID',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV9pTrGestionTableros_ID',fld:'vPTRGESTIONTABLEROS_ID',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrGestionTableros_ID',fld:'vCTRGESTIONTABLEROS_ID',pic:''},{av:'AV15cTrGestionTableros_Nombre',fld:'vCTRGESTIONTABLEROS_NOMBRE',pic:''},{av:'AV7cTrGestionTableros_FechaInicio',fld:'vCTRGESTIONTABLEROS_FECHAINICIO',pic:''},{av:'AV8cTrGestionTableros_FechaFin',fld:'vCTRGESTIONTABLEROS_FECHAFIN',pic:''},{av:'AV11cTrGestionTableros_FechaCreacion',fld:'vCTRGESTIONTABLEROS_FECHACREACION',pic:''},{av:'AV12cTrGestionTableros_FechaModificacion',fld:'vCTRGESTIONTABLEROS_FECHAMODIFICACION',pic:''},{av:'AV13cTrGestionTableros_TipoTablero',fld:'vCTRGESTIONTABLEROS_TIPOTABLERO',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrGestionTableros_ID',fld:'vCTRGESTIONTABLEROS_ID',pic:''},{av:'AV15cTrGestionTableros_Nombre',fld:'vCTRGESTIONTABLEROS_NOMBRE',pic:''},{av:'AV7cTrGestionTableros_FechaInicio',fld:'vCTRGESTIONTABLEROS_FECHAINICIO',pic:''},{av:'AV8cTrGestionTableros_FechaFin',fld:'vCTRGESTIONTABLEROS_FECHAFIN',pic:''},{av:'AV11cTrGestionTableros_FechaCreacion',fld:'vCTRGESTIONTABLEROS_FECHACREACION',pic:''},{av:'AV12cTrGestionTableros_FechaModificacion',fld:'vCTRGESTIONTABLEROS_FECHAMODIFICACION',pic:''},{av:'AV13cTrGestionTableros_TipoTablero',fld:'vCTRGESTIONTABLEROS_TIPOTABLERO',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrGestionTableros_ID',fld:'vCTRGESTIONTABLEROS_ID',pic:''},{av:'AV15cTrGestionTableros_Nombre',fld:'vCTRGESTIONTABLEROS_NOMBRE',pic:''},{av:'AV7cTrGestionTableros_FechaInicio',fld:'vCTRGESTIONTABLEROS_FECHAINICIO',pic:''},{av:'AV8cTrGestionTableros_FechaFin',fld:'vCTRGESTIONTABLEROS_FECHAFIN',pic:''},{av:'AV11cTrGestionTableros_FechaCreacion',fld:'vCTRGESTIONTABLEROS_FECHACREACION',pic:''},{av:'AV12cTrGestionTableros_FechaModificacion',fld:'vCTRGESTIONTABLEROS_FECHAMODIFICACION',pic:''},{av:'AV13cTrGestionTableros_TipoTablero',fld:'vCTRGESTIONTABLEROS_TIPOTABLERO',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrGestionTableros_ID',fld:'vCTRGESTIONTABLEROS_ID',pic:''},{av:'AV15cTrGestionTableros_Nombre',fld:'vCTRGESTIONTABLEROS_NOMBRE',pic:''},{av:'AV7cTrGestionTableros_FechaInicio',fld:'vCTRGESTIONTABLEROS_FECHAINICIO',pic:''},{av:'AV8cTrGestionTableros_FechaFin',fld:'vCTRGESTIONTABLEROS_FECHAFIN',pic:''},{av:'AV11cTrGestionTableros_FechaCreacion',fld:'vCTRGESTIONTABLEROS_FECHACREACION',pic:''},{av:'AV12cTrGestionTableros_FechaModificacion',fld:'vCTRGESTIONTABLEROS_FECHAMODIFICACION',pic:''},{av:'AV13cTrGestionTableros_TipoTablero',fld:'vCTRGESTIONTABLEROS_TIPOTABLERO',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CTRGESTIONTABLEROS_ID","{handler:'Validv_Ctrgestiontableros_id',iparms:[]");
         setEventMetadata("VALIDV_CTRGESTIONTABLEROS_ID",",oparms:[]}");
         setEventMetadata("VALIDV_CTRGESTIONTABLEROS_FECHAINICIO","{handler:'Validv_Ctrgestiontableros_fechainicio',iparms:[]");
         setEventMetadata("VALIDV_CTRGESTIONTABLEROS_FECHAINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_CTRGESTIONTABLEROS_FECHAFIN","{handler:'Validv_Ctrgestiontableros_fechafin',iparms:[]");
         setEventMetadata("VALIDV_CTRGESTIONTABLEROS_FECHAFIN",",oparms:[]}");
         setEventMetadata("VALIDV_CTRGESTIONTABLEROS_FECHACREACION","{handler:'Validv_Ctrgestiontableros_fechacreacion',iparms:[]");
         setEventMetadata("VALIDV_CTRGESTIONTABLEROS_FECHACREACION",",oparms:[]}");
         setEventMetadata("VALIDV_CTRGESTIONTABLEROS_FECHAMODIFICACION","{handler:'Validv_Ctrgestiontableros_fechamodificacion',iparms:[]");
         setEventMetadata("VALIDV_CTRGESTIONTABLEROS_FECHAMODIFICACION",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Trgestiontableros_fechamodificacion',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         AV6cTrGestionTableros_ID = (Guid)(Guid.Empty);
         AV15cTrGestionTableros_Nombre = "";
         AV7cTrGestionTableros_FechaInicio = DateTime.MinValue;
         AV8cTrGestionTableros_FechaFin = DateTime.MinValue;
         AV11cTrGestionTableros_FechaCreacion = DateTime.MinValue;
         AV12cTrGestionTableros_FechaModificacion = DateTime.MinValue;
         AV9pTrGestionTableros_ID = (Guid)(Guid.Empty);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLbltrgestiontableros_idfilter_Jsonclick = "";
         TempTags = "";
         lblLbltrgestiontableros_nombrefilter_Jsonclick = "";
         lblLbltrgestiontableros_fechainiciofilter_Jsonclick = "";
         lblLbltrgestiontableros_fechafinfilter_Jsonclick = "";
         lblLbltrgestiontableros_fechacreacionfilter_Jsonclick = "";
         lblLbltrgestiontableros_fechamodificacionfilter_Jsonclick = "";
         lblLbltrgestiontableros_tipotablerofilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A1TrGestionTableros_ID = (Guid)(Guid.Empty);
         A3TrGestionTableros_FechaInicio = DateTime.MinValue;
         A4TrGestionTableros_FechaFin = DateTime.MinValue;
         A7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         A8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV18Linkselection_GXI = "";
         scmdbuf = "";
         lV15cTrGestionTableros_Nombre = "";
         A2TrGestionTableros_Nombre = "";
         H00072_A9TrGestionTableros_TipoTablero = new short[1] ;
         H00072_n9TrGestionTableros_TipoTablero = new bool[] {false} ;
         H00072_A2TrGestionTableros_Nombre = new String[] {""} ;
         H00072_n2TrGestionTableros_Nombre = new bool[] {false} ;
         H00072_A8TrGestionTableros_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         H00072_n8TrGestionTableros_FechaModificacion = new bool[] {false} ;
         H00072_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         H00072_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         H00072_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         H00072_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         H00072_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H00072_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         H00072_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         H00073_AGRID1_nRecordCount = new long[1] ;
         AV10ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0010__default(),
            new Object[][] {
                new Object[] {
               H00072_A9TrGestionTableros_TipoTablero, H00072_n9TrGestionTableros_TipoTablero, H00072_A2TrGestionTableros_Nombre, H00072_n2TrGestionTableros_Nombre, H00072_A8TrGestionTableros_FechaModificacion, H00072_n8TrGestionTableros_FechaModificacion, H00072_A7TrGestionTableros_FechaCreacion, H00072_n7TrGestionTableros_FechaCreacion, H00072_A4TrGestionTableros_FechaFin, H00072_n4TrGestionTableros_FechaFin,
               H00072_A3TrGestionTableros_FechaInicio, H00072_n3TrGestionTableros_FechaInicio, H00072_A1TrGestionTableros_ID
               }
               , new Object[] {
               H00073_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13cTrGestionTableros_TipoTablero ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A9TrGestionTableros_TipoTablero ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_84 ;
      private int nGXsfl_84_idx=1 ;
      private int subGrid1_Rows ;
      private int edtavCtrgestiontableros_id_Visible ;
      private int edtavCtrgestiontableros_id_Enabled ;
      private int edtavCtrgestiontableros_nombre_Visible ;
      private int edtavCtrgestiontableros_nombre_Enabled ;
      private int edtavCtrgestiontableros_fechainicio_Enabled ;
      private int edtavCtrgestiontableros_fechafin_Enabled ;
      private int edtavCtrgestiontableros_fechacreacion_Enabled ;
      private int edtavCtrgestiontableros_fechamodificacion_Enabled ;
      private int edtavCtrgestiontableros_tipotablero_Enabled ;
      private int edtavCtrgestiontableros_tipotablero_Visible ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private String divAdvancedcontainer_Class ;
      private String bttBtntoggle_Class ;
      private String divTrgestiontableros_idfiltercontainer_Class ;
      private String divTrgestiontableros_nombrefiltercontainer_Class ;
      private String divTrgestiontableros_fechainiciofiltercontainer_Class ;
      private String divTrgestiontableros_fechafinfiltercontainer_Class ;
      private String divTrgestiontableros_fechacreacionfiltercontainer_Class ;
      private String divTrgestiontableros_fechamodificacionfiltercontainer_Class ;
      private String divTrgestiontableros_tipotablerofiltercontainer_Class ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_84_idx="0001" ;
      private String AV15cTrGestionTableros_Nombre ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMain_Internalname ;
      private String divAdvancedcontainer_Internalname ;
      private String divTrgestiontableros_idfiltercontainer_Internalname ;
      private String lblLbltrgestiontableros_idfilter_Internalname ;
      private String lblLbltrgestiontableros_idfilter_Jsonclick ;
      private String edtavCtrgestiontableros_id_Internalname ;
      private String TempTags ;
      private String edtavCtrgestiontableros_id_Jsonclick ;
      private String divTrgestiontableros_nombrefiltercontainer_Internalname ;
      private String lblLbltrgestiontableros_nombrefilter_Internalname ;
      private String lblLbltrgestiontableros_nombrefilter_Jsonclick ;
      private String edtavCtrgestiontableros_nombre_Internalname ;
      private String edtavCtrgestiontableros_nombre_Jsonclick ;
      private String divTrgestiontableros_fechainiciofiltercontainer_Internalname ;
      private String lblLbltrgestiontableros_fechainiciofilter_Internalname ;
      private String lblLbltrgestiontableros_fechainiciofilter_Jsonclick ;
      private String edtavCtrgestiontableros_fechainicio_Internalname ;
      private String edtavCtrgestiontableros_fechainicio_Jsonclick ;
      private String divTrgestiontableros_fechafinfiltercontainer_Internalname ;
      private String lblLbltrgestiontableros_fechafinfilter_Internalname ;
      private String lblLbltrgestiontableros_fechafinfilter_Jsonclick ;
      private String edtavCtrgestiontableros_fechafin_Internalname ;
      private String edtavCtrgestiontableros_fechafin_Jsonclick ;
      private String divTrgestiontableros_fechacreacionfiltercontainer_Internalname ;
      private String lblLbltrgestiontableros_fechacreacionfilter_Internalname ;
      private String lblLbltrgestiontableros_fechacreacionfilter_Jsonclick ;
      private String edtavCtrgestiontableros_fechacreacion_Internalname ;
      private String edtavCtrgestiontableros_fechacreacion_Jsonclick ;
      private String divTrgestiontableros_fechamodificacionfiltercontainer_Internalname ;
      private String lblLbltrgestiontableros_fechamodificacionfilter_Internalname ;
      private String lblLbltrgestiontableros_fechamodificacionfilter_Jsonclick ;
      private String edtavCtrgestiontableros_fechamodificacion_Internalname ;
      private String edtavCtrgestiontableros_fechamodificacion_Jsonclick ;
      private String divTrgestiontableros_tipotablerofiltercontainer_Internalname ;
      private String lblLbltrgestiontableros_tipotablerofilter_Internalname ;
      private String lblLbltrgestiontableros_tipotablerofilter_Jsonclick ;
      private String edtavCtrgestiontableros_tipotablero_Internalname ;
      private String edtavCtrgestiontableros_tipotablero_Jsonclick ;
      private String divGridtable_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String bttBtntoggle_Internalname ;
      private String bttBtntoggle_Jsonclick ;
      private String sStyleString ;
      private String subGrid1_Internalname ;
      private String subGrid1_Class ;
      private String subGrid1_Linesclass ;
      private String subGrid1_Header ;
      private String edtavLinkselection_Link ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavLinkselection_Internalname ;
      private String edtTrGestionTableros_ID_Internalname ;
      private String edtTrGestionTableros_FechaInicio_Internalname ;
      private String edtTrGestionTableros_FechaFin_Internalname ;
      private String edtTrGestionTableros_FechaCreacion_Internalname ;
      private String edtTrGestionTableros_FechaModificacion_Internalname ;
      private String scmdbuf ;
      private String lV15cTrGestionTableros_Nombre ;
      private String A2TrGestionTableros_Nombre ;
      private String AV10ADVANCED_LABEL_TEMPLATE ;
      private String sGXsfl_84_fel_idx="0001" ;
      private String sImgUrl ;
      private String ROClassString ;
      private String edtTrGestionTableros_ID_Jsonclick ;
      private String edtTrGestionTableros_FechaInicio_Jsonclick ;
      private String edtTrGestionTableros_FechaFin_Jsonclick ;
      private String edtTrGestionTableros_FechaCreacion_Jsonclick ;
      private String edtTrGestionTableros_FechaModificacion_Jsonclick ;
      private DateTime AV7cTrGestionTableros_FechaInicio ;
      private DateTime AV8cTrGestionTableros_FechaFin ;
      private DateTime AV11cTrGestionTableros_FechaCreacion ;
      private DateTime AV12cTrGestionTableros_FechaModificacion ;
      private DateTime A3TrGestionTableros_FechaInicio ;
      private DateTime A4TrGestionTableros_FechaFin ;
      private DateTime A7TrGestionTableros_FechaCreacion ;
      private DateTime A8TrGestionTableros_FechaModificacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n3TrGestionTableros_FechaInicio ;
      private bool n4TrGestionTableros_FechaFin ;
      private bool n7TrGestionTableros_FechaCreacion ;
      private bool n8TrGestionTableros_FechaModificacion ;
      private bool gxdyncontrolsrefreshing ;
      private bool n9TrGestionTableros_TipoTablero ;
      private bool n2TrGestionTableros_Nombre ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private String AV18Linkselection_GXI ;
      private String AV5LinkSelection ;
      private Guid AV6cTrGestionTableros_ID ;
      private Guid AV9pTrGestionTableros_ID ;
      private Guid A1TrGestionTableros_ID ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H00072_A9TrGestionTableros_TipoTablero ;
      private bool[] H00072_n9TrGestionTableros_TipoTablero ;
      private String[] H00072_A2TrGestionTableros_Nombre ;
      private bool[] H00072_n2TrGestionTableros_Nombre ;
      private DateTime[] H00072_A8TrGestionTableros_FechaModificacion ;
      private bool[] H00072_n8TrGestionTableros_FechaModificacion ;
      private DateTime[] H00072_A7TrGestionTableros_FechaCreacion ;
      private bool[] H00072_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] H00072_A4TrGestionTableros_FechaFin ;
      private bool[] H00072_n4TrGestionTableros_FechaFin ;
      private DateTime[] H00072_A3TrGestionTableros_FechaInicio ;
      private bool[] H00072_n3TrGestionTableros_FechaInicio ;
      private Guid[] H00072_A1TrGestionTableros_ID ;
      private long[] H00073_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid aP0_pTrGestionTableros_ID ;
      private GXWebForm Form ;
   }

   public class gx0010__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00072( IGxContext context ,
                                             String AV15cTrGestionTableros_Nombre ,
                                             DateTime AV7cTrGestionTableros_FechaInicio ,
                                             DateTime AV8cTrGestionTableros_FechaFin ,
                                             DateTime AV11cTrGestionTableros_FechaCreacion ,
                                             DateTime AV12cTrGestionTableros_FechaModificacion ,
                                             short AV13cTrGestionTableros_TipoTablero ,
                                             String A2TrGestionTableros_Nombre ,
                                             DateTime A3TrGestionTableros_FechaInicio ,
                                             DateTime A4TrGestionTableros_FechaFin ,
                                             DateTime A7TrGestionTableros_FechaCreacion ,
                                             DateTime A8TrGestionTableros_FechaModificacion ,
                                             short A9TrGestionTableros_TipoTablero ,
                                             Guid AV6cTrGestionTableros_ID )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int1 ;
         GXv_int1 = new short [10] ;
         Object[] GXv_Object2 ;
         GXv_Object2 = new Object [2] ;
         String sSelectString ;
         String sFromString ;
         String sOrderString ;
         sSelectString = " [TrGestionTableros_TipoTablero], [TrGestionTableros_Nombre], [TrGestionTableros_FechaModificacion], [TrGestionTableros_FechaCreacion], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaInicio], [TrGestionTableros_ID]";
         sFromString = " FROM TABLERO.[TrGestionTableros]";
         sOrderString = "";
         sWhereString = sWhereString + " WHERE ([TrGestionTableros_ID] >= @AV6cTrGestionTableros_ID)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15cTrGestionTableros_Nombre)) )
         {
            sWhereString = sWhereString + " and ([TrGestionTableros_Nombre] like @lV15cTrGestionTableros_Nombre)";
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV7cTrGestionTableros_FechaInicio) )
         {
            sWhereString = sWhereString + " and ([TrGestionTableros_FechaInicio] >= @AV7cTrGestionTableros_FechaInicio)";
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cTrGestionTableros_FechaFin) )
         {
            sWhereString = sWhereString + " and ([TrGestionTableros_FechaFin] >= @AV8cTrGestionTableros_FechaFin)";
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cTrGestionTableros_FechaCreacion) )
         {
            sWhereString = sWhereString + " and ([TrGestionTableros_FechaCreacion] >= @AV11cTrGestionTableros_FechaCreacion)";
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cTrGestionTableros_FechaModificacion) )
         {
            sWhereString = sWhereString + " and ([TrGestionTableros_FechaModificacion] >= @AV12cTrGestionTableros_FechaModificacion)";
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV13cTrGestionTableros_TipoTablero) )
         {
            sWhereString = sWhereString + " and ([TrGestionTableros_TipoTablero] >= @AV13cTrGestionTableros_TipoTablero)";
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString = sOrderString + " ORDER BY [TrGestionTableros_ID]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00073( IGxContext context ,
                                             String AV15cTrGestionTableros_Nombre ,
                                             DateTime AV7cTrGestionTableros_FechaInicio ,
                                             DateTime AV8cTrGestionTableros_FechaFin ,
                                             DateTime AV11cTrGestionTableros_FechaCreacion ,
                                             DateTime AV12cTrGestionTableros_FechaModificacion ,
                                             short AV13cTrGestionTableros_TipoTablero ,
                                             String A2TrGestionTableros_Nombre ,
                                             DateTime A3TrGestionTableros_FechaInicio ,
                                             DateTime A4TrGestionTableros_FechaFin ,
                                             DateTime A7TrGestionTableros_FechaCreacion ,
                                             DateTime A8TrGestionTableros_FechaModificacion ,
                                             short A9TrGestionTableros_TipoTablero ,
                                             Guid AV6cTrGestionTableros_ID )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int3 ;
         GXv_int3 = new short [7] ;
         Object[] GXv_Object4 ;
         GXv_Object4 = new Object [2] ;
         scmdbuf = "SELECT COUNT(*) FROM TABLERO.[TrGestionTableros]";
         scmdbuf = scmdbuf + " WHERE ([TrGestionTableros_ID] >= @AV6cTrGestionTableros_ID)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15cTrGestionTableros_Nombre)) )
         {
            sWhereString = sWhereString + " and ([TrGestionTableros_Nombre] like @lV15cTrGestionTableros_Nombre)";
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV7cTrGestionTableros_FechaInicio) )
         {
            sWhereString = sWhereString + " and ([TrGestionTableros_FechaInicio] >= @AV7cTrGestionTableros_FechaInicio)";
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cTrGestionTableros_FechaFin) )
         {
            sWhereString = sWhereString + " and ([TrGestionTableros_FechaFin] >= @AV8cTrGestionTableros_FechaFin)";
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cTrGestionTableros_FechaCreacion) )
         {
            sWhereString = sWhereString + " and ([TrGestionTableros_FechaCreacion] >= @AV11cTrGestionTableros_FechaCreacion)";
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cTrGestionTableros_FechaModificacion) )
         {
            sWhereString = sWhereString + " and ([TrGestionTableros_FechaModificacion] >= @AV12cTrGestionTableros_FechaModificacion)";
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV13cTrGestionTableros_TipoTablero) )
         {
            sWhereString = sWhereString + " and ([TrGestionTableros_TipoTablero] >= @AV13cTrGestionTableros_TipoTablero)";
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf = scmdbuf + sWhereString;
         scmdbuf = scmdbuf + "";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00072(context, (String)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (short)dynConstraints[5] , (String)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (Guid)dynConstraints[12] );
               case 1 :
                     return conditional_H00073(context, (String)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (short)dynConstraints[5] , (String)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (Guid)dynConstraints[12] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00072 ;
          prmH00072 = new Object[] {
          new Object[] {"@AV6cTrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0} ,
          new Object[] {"@lV15cTrGestionTableros_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@AV7cTrGestionTableros_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV8cTrGestionTableros_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV11cTrGestionTableros_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV12cTrGestionTableros_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV13cTrGestionTableros_TipoTablero",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@GXPagingFrom2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0}
          } ;
          Object[] prmH00073 ;
          prmH00073 = new Object[] {
          new Object[] {"@AV6cTrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0} ,
          new Object[] {"@lV15cTrGestionTableros_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@AV7cTrGestionTableros_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV8cTrGestionTableros_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV11cTrGestionTableros_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV12cTrGestionTableros_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV13cTrGestionTableros_TipoTablero",SqlDbType.SmallInt,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00072", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00072,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00073", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00073,1, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((String[]) buf[2])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((Guid[]) buf[12])[0] = rslt.getGuid(7) ;
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       short sIdx ;
       switch ( cursor )
       {
             case 0 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (Guid)parms[10]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[11]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[12]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[13]);
                }
                if ( (short)parms[4] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[14]);
                }
                if ( (short)parms[5] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[15]);
                }
                if ( (short)parms[6] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (short)parms[16]);
                }
                if ( (short)parms[7] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[17]);
                }
                if ( (short)parms[8] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[18]);
                }
                if ( (short)parms[9] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[19]);
                }
                return;
             case 1 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (Guid)parms[7]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[8]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[9]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[10]);
                }
                if ( (short)parms[4] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[11]);
                }
                if ( (short)parms[5] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[12]);
                }
                if ( (short)parms[6] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (short)parms[13]);
                }
                return;
       }
    }

 }

}
