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
   public class gx0091 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0091( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public gx0091( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_pTrActividades_ID ,
                           out Guid aP1_pTrListaActividad_ID )
      {
         this.AV12pTrActividades_ID = aP0_pTrActividades_ID;
         this.AV13pTrListaActividad_ID = Guid.Empty ;
         executePrivate();
         aP1_pTrListaActividad_ID=this.AV13pTrListaActividad_ID;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCtrlistaactividad_estado = new GXCombobox();
         cmbTrListaActividad_Estado = new GXCombobox();
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
               nRC_GXsfl_74 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_74_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_74_idx = GetNextPar( );
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
               AV6cTrListaActividad_ID = (Guid)(StringUtil.StrToGuid( GetNextPar( )));
               AV7cTrListaActividad_FechaInicio = context.localUtil.ParseDateParm( GetNextPar( ));
               AV8cTrListaActividad_FechaFin = context.localUtil.ParseDateParm( GetNextPar( ));
               AV9cTrListaActividad_FechaCreacion = context.localUtil.ParseDateParm( GetNextPar( ));
               AV10cTrListaActividad_FechaModificacion = context.localUtil.ParseDateParm( GetNextPar( ));
               AV11cTrListaActividad_Estado = (short)(NumberUtil.Val( GetNextPar( ), "."));
               AV12pTrActividades_ID = (long)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cTrListaActividad_ID, AV7cTrListaActividad_FechaInicio, AV8cTrListaActividad_FechaFin, AV9cTrListaActividad_FechaCreacion, AV10cTrListaActividad_FechaModificacion, AV11cTrListaActividad_Estado, AV12pTrActividades_ID) ;
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
               AV12pTrActividades_ID = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV12pTrActividades_ID", StringUtil.LTrimStr( (decimal)(AV12pTrActividades_ID), 13, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13pTrListaActividad_ID = (Guid)(StringUtil.StrToGuid( GetNextPar( )));
                  AssignAttri("", false, "AV13pTrListaActividad_ID", AV13pTrListaActividad_ID.ToString());
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
         PA2A2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2A2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210211745415", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0091.aspx") + "?" + UrlEncode("" +AV12pTrActividades_ID) + "," + UrlEncode(AV13pTrListaActividad_ID.ToString())+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCTRLISTAACTIVIDAD_ID", AV6cTrListaActividad_ID.ToString());
         GxWebStd.gx_hidden_field( context, "GXH_vCTRLISTAACTIVIDAD_FECHAINICIO", context.localUtil.Format(AV7cTrListaActividad_FechaInicio, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRLISTAACTIVIDAD_FECHAFIN", context.localUtil.Format(AV8cTrListaActividad_FechaFin, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRLISTAACTIVIDAD_FECHACREACION", context.localUtil.Format(AV9cTrListaActividad_FechaCreacion, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRLISTAACTIVIDAD_FECHAMODIFICACION", context.localUtil.Format(AV10cTrListaActividad_FechaModificacion, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRLISTAACTIVIDAD_ESTADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cTrListaActividad_Estado), 4, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPTRACTIVIDADES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pTrActividades_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPTRLISTAACTIVIDAD_ID", AV13pTrListaActividad_ID.ToString());
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_IDFILTERCONTAINER_Class", StringUtil.RTrim( divTrlistaactividad_idfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_FECHAINICIOFILTERCONTAINER_Class", StringUtil.RTrim( divTrlistaactividad_fechainiciofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_FECHAFINFILTERCONTAINER_Class", StringUtil.RTrim( divTrlistaactividad_fechafinfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_FECHACREACIONFILTERCONTAINER_Class", StringUtil.RTrim( divTrlistaactividad_fechacreacionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_FECHAMODIFICACIONFILTERCONTAINER_Class", StringUtil.RTrim( divTrlistaactividad_fechamodificacionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_ESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divTrlistaactividad_estadofiltercontainer_Class));
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
            WE2A2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2A2( ) ;
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
         return formatLink("gx0091.aspx") + "?" + UrlEncode("" +AV12pTrActividades_ID) + "," + UrlEncode(AV13pTrListaActividad_ID.ToString()) ;
      }

      public override String GetPgmname( )
      {
         return "Gx0091" ;
      }

      public override String GetPgmdesc( )
      {
         return "Selection List Level1" ;
      }

      protected void WB2A0( )
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
            GxWebStd.gx_div_start( context, divTrlistaactividad_idfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrlistaactividad_idfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrlistaactividad_idfilter_Internalname, "Tr Lista Actividad_ID", "", "", lblLbltrlistaactividad_idfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e112a1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0091.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrlistaactividad_id_Internalname, "Tr Lista Actividad_ID", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtrlistaactividad_id_Internalname, AV6cTrListaActividad_ID.ToString(), AV6cTrListaActividad_ID.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrlistaactividad_id_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtrlistaactividad_id_Visible, edtavCtrlistaactividad_id_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 1, 0, 0, true, "", "", false, "", "HLP_Gx0091.htm");
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
            GxWebStd.gx_div_start( context, divTrlistaactividad_fechainiciofiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrlistaactividad_fechainiciofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrlistaactividad_fechainiciofilter_Internalname, "Tr Lista Actividad_Fecha Inicio", "", "", lblLbltrlistaactividad_fechainiciofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e122a1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0091.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrlistaactividad_fechainicio_Internalname, "Tr Lista Actividad_Fecha Inicio", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtrlistaactividad_fechainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtrlistaactividad_fechainicio_Internalname, context.localUtil.Format(AV7cTrListaActividad_FechaInicio, "99/99/9999"), context.localUtil.Format( AV7cTrListaActividad_FechaInicio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrlistaactividad_fechainicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtrlistaactividad_fechainicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0091.htm");
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
            GxWebStd.gx_div_start( context, divTrlistaactividad_fechafinfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrlistaactividad_fechafinfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrlistaactividad_fechafinfilter_Internalname, "Tr Lista Actividad_Fecha Fin", "", "", lblLbltrlistaactividad_fechafinfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e132a1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0091.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrlistaactividad_fechafin_Internalname, "Tr Lista Actividad_Fecha Fin", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtrlistaactividad_fechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtrlistaactividad_fechafin_Internalname, context.localUtil.Format(AV8cTrListaActividad_FechaFin, "99/99/9999"), context.localUtil.Format( AV8cTrListaActividad_FechaFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrlistaactividad_fechafin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtrlistaactividad_fechafin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0091.htm");
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
            GxWebStd.gx_div_start( context, divTrlistaactividad_fechacreacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrlistaactividad_fechacreacionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrlistaactividad_fechacreacionfilter_Internalname, "Tr Lista Actividad_Fecha Creacion", "", "", lblLbltrlistaactividad_fechacreacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e142a1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0091.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrlistaactividad_fechacreacion_Internalname, "Tr Lista Actividad_Fecha Creacion", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtrlistaactividad_fechacreacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtrlistaactividad_fechacreacion_Internalname, context.localUtil.Format(AV9cTrListaActividad_FechaCreacion, "99/99/9999"), context.localUtil.Format( AV9cTrListaActividad_FechaCreacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrlistaactividad_fechacreacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtrlistaactividad_fechacreacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0091.htm");
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
            GxWebStd.gx_div_start( context, divTrlistaactividad_fechamodificacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrlistaactividad_fechamodificacionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrlistaactividad_fechamodificacionfilter_Internalname, "Tr Lista Actividad_Fecha Modificacion", "", "", lblLbltrlistaactividad_fechamodificacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e152a1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0091.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrlistaactividad_fechamodificacion_Internalname, "Tr Lista Actividad_Fecha Modificacion", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtrlistaactividad_fechamodificacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtrlistaactividad_fechamodificacion_Internalname, context.localUtil.Format(AV10cTrListaActividad_FechaModificacion, "99/99/9999"), context.localUtil.Format( AV10cTrListaActividad_FechaModificacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrlistaactividad_fechamodificacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtrlistaactividad_fechamodificacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0091.htm");
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
            GxWebStd.gx_div_start( context, divTrlistaactividad_estadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrlistaactividad_estadofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrlistaactividad_estadofilter_Internalname, "Tr Lista Actividad_Estado", "", "", lblLbltrlistaactividad_estadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e162a1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0091.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCtrlistaactividad_estado_Internalname, "Tr Lista Actividad_Estado", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCtrlistaactividad_estado, cmbavCtrlistaactividad_estado_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV11cTrListaActividad_Estado), 4, 0)), 1, cmbavCtrlistaactividad_estado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavCtrlistaactividad_estado.Visible, cmbavCtrlistaactividad_estado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "", true, "HLP_Gx0091.htm");
            cmbavCtrlistaactividad_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11cTrListaActividad_Estado), 4, 0));
            AssignProp("", false, cmbavCtrlistaactividad_estado_Internalname, "Values", (String)(cmbavCtrlistaactividad_estado.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e172a1_client"+"'", TempTags, "", 2, "HLP_Gx0091.htm");
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
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"74\">") ;
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
               context.SendWebValue( "Lista Actividad_ID") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Actividad_Fecha Inicio") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Actividad_Fecha Fin") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Lista Actividad_Estado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Tr Actividades_ID") ;
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
               Grid1Column.AddObjectProperty("Value", A55TrListaActividad_ID.ToString());
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A58TrListaActividad_FechaInicio, "99/99/9999"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A59TrListaActividad_FechaFin, "99/99/9999"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A62TrListaActividad_Estado), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26TrActividades_ID), 13, 0, ".", "")));
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
         if ( wbEnd == 74 )
         {
            wbEnd = 0;
            nRC_GXsfl_74 = (int)(nGXsfl_74_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0091.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 74 )
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

      protected void START2A2( )
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
            Form.Meta.addItem("description", "Selection List Level1", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2A0( ) ;
      }

      protected void WS2A2( )
      {
         START2A2( ) ;
         EVT2A2( ) ;
      }

      protected void EVT2A2( )
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
                              nGXsfl_74_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
                              SubsflControlProps_742( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A55TrListaActividad_ID = (Guid)(StringUtil.StrToGuid( cgiGet( edtTrListaActividad_ID_Internalname)));
                              A58TrListaActividad_FechaInicio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrListaActividad_FechaInicio_Internalname), 0));
                              n58TrListaActividad_FechaInicio = false;
                              A59TrListaActividad_FechaFin = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrListaActividad_FechaFin_Internalname), 0));
                              n59TrListaActividad_FechaFin = false;
                              cmbTrListaActividad_Estado.Name = cmbTrListaActividad_Estado_Internalname;
                              cmbTrListaActividad_Estado.CurrentValue = cgiGet( cmbTrListaActividad_Estado_Internalname);
                              A62TrListaActividad_Estado = (short)(NumberUtil.Val( cgiGet( cmbTrListaActividad_Estado_Internalname), "."));
                              n62TrListaActividad_Estado = false;
                              A26TrActividades_ID = (long)(context.localUtil.CToN( cgiGet( edtTrActividades_ID_Internalname), ".", ","));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E182A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E192A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ctrlistaactividad_id Changed */
                                       if ( StringUtil.StrToGuid( cgiGet( "GXH_vCTRLISTAACTIVIDAD_ID")) != AV6cTrListaActividad_ID )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrlistaactividad_fechainicio Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTRLISTAACTIVIDAD_FECHAINICIO"), 0) != AV7cTrListaActividad_FechaInicio )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrlistaactividad_fechafin Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTRLISTAACTIVIDAD_FECHAFIN"), 0) != AV8cTrListaActividad_FechaFin )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrlistaactividad_fechacreacion Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTRLISTAACTIVIDAD_FECHACREACION"), 0) != AV9cTrListaActividad_FechaCreacion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrlistaactividad_fechamodificacion Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTRLISTAACTIVIDAD_FECHAMODIFICACION"), 0) != AV10cTrListaActividad_FechaModificacion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrlistaactividad_estado Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRLISTAACTIVIDAD_ESTADO"), ".", ",") != Convert.ToDecimal( AV11cTrListaActividad_Estado )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E202A2 ();
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

      protected void WE2A2( )
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

      protected void PA2A2( )
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
         SubsflControlProps_742( ) ;
         while ( nGXsfl_74_idx <= nRC_GXsfl_74 )
         {
            sendrow_742( ) ;
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        Guid AV6cTrListaActividad_ID ,
                                        DateTime AV7cTrListaActividad_FechaInicio ,
                                        DateTime AV8cTrListaActividad_FechaFin ,
                                        DateTime AV9cTrListaActividad_FechaCreacion ,
                                        DateTime AV10cTrListaActividad_FechaModificacion ,
                                        short AV11cTrListaActividad_Estado ,
                                        long AV12pTrActividades_ID )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF2A2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TRLISTAACTIVIDAD_ID", GetSecureSignedToken( "", A55TrListaActividad_ID, context));
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_ID", A55TrListaActividad_ID.ToString());
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
         if ( cmbavCtrlistaactividad_estado.ItemCount > 0 )
         {
            AV11cTrListaActividad_Estado = (short)(NumberUtil.Val( cmbavCtrlistaactividad_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11cTrListaActividad_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV11cTrListaActividad_Estado", StringUtil.LTrimStr( (decimal)(AV11cTrListaActividad_Estado), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCtrlistaactividad_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11cTrListaActividad_Estado), 4, 0));
            AssignProp("", false, cmbavCtrlistaactividad_estado_Internalname, "Values", cmbavCtrlistaactividad_estado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2A2( ) ;
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

      protected void RF2A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 74;
         nGXsfl_74_idx = 1;
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         bGXsfl_74_Refreshing = true;
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
            SubsflControlProps_742( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cTrListaActividad_FechaInicio ,
                                                 AV8cTrListaActividad_FechaFin ,
                                                 AV9cTrListaActividad_FechaCreacion ,
                                                 AV10cTrListaActividad_FechaModificacion ,
                                                 AV11cTrListaActividad_Estado ,
                                                 A58TrListaActividad_FechaInicio ,
                                                 A59TrListaActividad_FechaFin ,
                                                 A60TrListaActividad_FechaCreacion ,
                                                 A61TrListaActividad_FechaModificacion ,
                                                 A62TrListaActividad_Estado ,
                                                 AV12pTrActividades_ID ,
                                                 AV6cTrListaActividad_ID ,
                                                 A26TrActividades_ID } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                                 TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            } ) ;
            /* Using cursor H002A2 */
            pr_default.execute(0, new Object[] {AV12pTrActividades_ID, AV6cTrListaActividad_ID, AV7cTrListaActividad_FechaInicio, AV8cTrListaActividad_FechaFin, AV9cTrListaActividad_FechaCreacion, AV10cTrListaActividad_FechaModificacion, AV11cTrListaActividad_Estado, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A61TrListaActividad_FechaModificacion = H002A2_A61TrListaActividad_FechaModificacion[0];
               n61TrListaActividad_FechaModificacion = H002A2_n61TrListaActividad_FechaModificacion[0];
               A60TrListaActividad_FechaCreacion = H002A2_A60TrListaActividad_FechaCreacion[0];
               n60TrListaActividad_FechaCreacion = H002A2_n60TrListaActividad_FechaCreacion[0];
               A26TrActividades_ID = H002A2_A26TrActividades_ID[0];
               A62TrListaActividad_Estado = H002A2_A62TrListaActividad_Estado[0];
               n62TrListaActividad_Estado = H002A2_n62TrListaActividad_Estado[0];
               A59TrListaActividad_FechaFin = H002A2_A59TrListaActividad_FechaFin[0];
               n59TrListaActividad_FechaFin = H002A2_n59TrListaActividad_FechaFin[0];
               A58TrListaActividad_FechaInicio = H002A2_A58TrListaActividad_FechaInicio[0];
               n58TrListaActividad_FechaInicio = H002A2_n58TrListaActividad_FechaInicio[0];
               A55TrListaActividad_ID = (Guid)((Guid)(H002A2_A55TrListaActividad_ID[0]));
               /* Execute user event: Load */
               E192A2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WB2A0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2A2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TRLISTAACTIVIDAD_ID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, A55TrListaActividad_ID, context));
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
                                              AV7cTrListaActividad_FechaInicio ,
                                              AV8cTrListaActividad_FechaFin ,
                                              AV9cTrListaActividad_FechaCreacion ,
                                              AV10cTrListaActividad_FechaModificacion ,
                                              AV11cTrListaActividad_Estado ,
                                              A58TrListaActividad_FechaInicio ,
                                              A59TrListaActividad_FechaFin ,
                                              A60TrListaActividad_FechaCreacion ,
                                              A61TrListaActividad_FechaModificacion ,
                                              A62TrListaActividad_Estado ,
                                              AV12pTrActividades_ID ,
                                              AV6cTrListaActividad_ID ,
                                              A26TrActividades_ID } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         } ) ;
         /* Using cursor H002A3 */
         pr_default.execute(1, new Object[] {AV12pTrActividades_ID, AV6cTrListaActividad_ID, AV7cTrListaActividad_FechaInicio, AV8cTrListaActividad_FechaFin, AV9cTrListaActividad_FechaCreacion, AV10cTrListaActividad_FechaModificacion, AV11cTrListaActividad_Estado});
         GRID1_nRecordCount = H002A3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrListaActividad_ID, AV7cTrListaActividad_FechaInicio, AV8cTrListaActividad_FechaFin, AV9cTrListaActividad_FechaCreacion, AV10cTrListaActividad_FechaModificacion, AV11cTrListaActividad_Estado, AV12pTrActividades_ID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrListaActividad_ID, AV7cTrListaActividad_FechaInicio, AV8cTrListaActividad_FechaFin, AV9cTrListaActividad_FechaCreacion, AV10cTrListaActividad_FechaModificacion, AV11cTrListaActividad_Estado, AV12pTrActividades_ID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrListaActividad_ID, AV7cTrListaActividad_FechaInicio, AV8cTrListaActividad_FechaFin, AV9cTrListaActividad_FechaCreacion, AV10cTrListaActividad_FechaModificacion, AV11cTrListaActividad_Estado, AV12pTrActividades_ID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrListaActividad_ID, AV7cTrListaActividad_FechaInicio, AV8cTrListaActividad_FechaFin, AV9cTrListaActividad_FechaCreacion, AV10cTrListaActividad_FechaModificacion, AV11cTrListaActividad_Estado, AV12pTrActividades_ID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrListaActividad_ID, AV7cTrListaActividad_FechaInicio, AV8cTrListaActividad_FechaFin, AV9cTrListaActividad_FechaCreacion, AV10cTrListaActividad_FechaModificacion, AV11cTrListaActividad_Estado, AV12pTrActividades_ID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP2A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E182A2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_74 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_74"), ".", ","));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","));
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtavCtrlistaactividad_id_Internalname), "") == 0 )
            {
               AV6cTrListaActividad_ID = (Guid)(Guid.Empty);
               AssignAttri("", false, "AV6cTrListaActividad_ID", AV6cTrListaActividad_ID.ToString());
            }
            else
            {
               try
               {
                  AV6cTrListaActividad_ID = (Guid)(StringUtil.StrToGuid( cgiGet( edtavCtrlistaactividad_id_Internalname)));
                  AssignAttri("", false, "AV6cTrListaActividad_ID", AV6cTrListaActividad_ID.ToString());
               }
               catch ( Exception e )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vCTRLISTAACTIVIDAD_ID");
                  GX_FocusControl = edtavCtrlistaactividad_id_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtrlistaactividad_fechainicio_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Lista Actividad_Fecha Inicio"}), 1, "vCTRLISTAACTIVIDAD_FECHAINICIO");
               GX_FocusControl = edtavCtrlistaactividad_fechainicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cTrListaActividad_FechaInicio = DateTime.MinValue;
               AssignAttri("", false, "AV7cTrListaActividad_FechaInicio", context.localUtil.Format(AV7cTrListaActividad_FechaInicio, "99/99/9999"));
            }
            else
            {
               AV7cTrListaActividad_FechaInicio = context.localUtil.CToD( cgiGet( edtavCtrlistaactividad_fechainicio_Internalname), 2);
               AssignAttri("", false, "AV7cTrListaActividad_FechaInicio", context.localUtil.Format(AV7cTrListaActividad_FechaInicio, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtrlistaactividad_fechafin_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Lista Actividad_Fecha Fin"}), 1, "vCTRLISTAACTIVIDAD_FECHAFIN");
               GX_FocusControl = edtavCtrlistaactividad_fechafin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cTrListaActividad_FechaFin = DateTime.MinValue;
               AssignAttri("", false, "AV8cTrListaActividad_FechaFin", context.localUtil.Format(AV8cTrListaActividad_FechaFin, "99/99/9999"));
            }
            else
            {
               AV8cTrListaActividad_FechaFin = context.localUtil.CToD( cgiGet( edtavCtrlistaactividad_fechafin_Internalname), 2);
               AssignAttri("", false, "AV8cTrListaActividad_FechaFin", context.localUtil.Format(AV8cTrListaActividad_FechaFin, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtrlistaactividad_fechacreacion_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Lista Actividad_Fecha Creacion"}), 1, "vCTRLISTAACTIVIDAD_FECHACREACION");
               GX_FocusControl = edtavCtrlistaactividad_fechacreacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cTrListaActividad_FechaCreacion = DateTime.MinValue;
               AssignAttri("", false, "AV9cTrListaActividad_FechaCreacion", context.localUtil.Format(AV9cTrListaActividad_FechaCreacion, "99/99/9999"));
            }
            else
            {
               AV9cTrListaActividad_FechaCreacion = context.localUtil.CToD( cgiGet( edtavCtrlistaactividad_fechacreacion_Internalname), 2);
               AssignAttri("", false, "AV9cTrListaActividad_FechaCreacion", context.localUtil.Format(AV9cTrListaActividad_FechaCreacion, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtrlistaactividad_fechamodificacion_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Lista Actividad_Fecha Modificacion"}), 1, "vCTRLISTAACTIVIDAD_FECHAMODIFICACION");
               GX_FocusControl = edtavCtrlistaactividad_fechamodificacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cTrListaActividad_FechaModificacion = DateTime.MinValue;
               AssignAttri("", false, "AV10cTrListaActividad_FechaModificacion", context.localUtil.Format(AV10cTrListaActividad_FechaModificacion, "99/99/9999"));
            }
            else
            {
               AV10cTrListaActividad_FechaModificacion = context.localUtil.CToD( cgiGet( edtavCtrlistaactividad_fechamodificacion_Internalname), 2);
               AssignAttri("", false, "AV10cTrListaActividad_FechaModificacion", context.localUtil.Format(AV10cTrListaActividad_FechaModificacion, "99/99/9999"));
            }
            cmbavCtrlistaactividad_estado.Name = cmbavCtrlistaactividad_estado_Internalname;
            cmbavCtrlistaactividad_estado.CurrentValue = cgiGet( cmbavCtrlistaactividad_estado_Internalname);
            AV11cTrListaActividad_Estado = (short)(NumberUtil.Val( cgiGet( cmbavCtrlistaactividad_estado_Internalname), "."));
            AssignAttri("", false, "AV11cTrListaActividad_Estado", StringUtil.LTrimStr( (decimal)(AV11cTrListaActividad_Estado), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrToGuid( cgiGet( "GXH_vCTRLISTAACTIVIDAD_ID")) != AV6cTrListaActividad_ID )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCTRLISTAACTIVIDAD_FECHAINICIO"), 2) != AV7cTrListaActividad_FechaInicio )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCTRLISTAACTIVIDAD_FECHAFIN"), 2) != AV8cTrListaActividad_FechaFin )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCTRLISTAACTIVIDAD_FECHACREACION"), 2) != AV9cTrListaActividad_FechaCreacion )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCTRLISTAACTIVIDAD_FECHAMODIFICACION"), 2) != AV10cTrListaActividad_FechaModificacion )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRLISTAACTIVIDAD_ESTADO"), ".", ",") != Convert.ToDecimal( AV11cTrListaActividad_Estado )) )
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
         E182A2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E182A2( )
      {
         /* Start Routine */
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "Level1", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E192A2( )
      {
         /* Load Routine */
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV17Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_742( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_74_Refreshing )
         {
            context.DoAjaxLoad(74, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E202A2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E202A2( )
      {
         /* Enter Routine */
         AV13pTrListaActividad_ID = (Guid)(A55TrListaActividad_ID);
         AssignAttri("", false, "AV13pTrListaActividad_ID", AV13pTrListaActividad_ID.ToString());
         context.setWebReturnParms(new Object[] {(Guid)AV13pTrListaActividad_ID});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pTrListaActividad_ID"});
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
         AV12pTrActividades_ID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV12pTrActividades_ID", StringUtil.LTrimStr( (decimal)(AV12pTrActividades_ID), 13, 0));
         AV13pTrListaActividad_ID = (Guid)((Guid)getParm(obj,1));
         AssignAttri("", false, "AV13pTrListaActividad_ID", AV13pTrListaActividad_ID.ToString());
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
         PA2A2( ) ;
         WS2A2( ) ;
         WE2A2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210211745474", true, true);
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
         context.AddJavascriptSource("gx0091.js", "?202210211745474", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtTrListaActividad_ID_Internalname = "TRLISTAACTIVIDAD_ID_"+sGXsfl_74_idx;
         edtTrListaActividad_FechaInicio_Internalname = "TRLISTAACTIVIDAD_FECHAINICIO_"+sGXsfl_74_idx;
         edtTrListaActividad_FechaFin_Internalname = "TRLISTAACTIVIDAD_FECHAFIN_"+sGXsfl_74_idx;
         cmbTrListaActividad_Estado_Internalname = "TRLISTAACTIVIDAD_ESTADO_"+sGXsfl_74_idx;
         edtTrActividades_ID_Internalname = "TRACTIVIDADES_ID_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtTrListaActividad_ID_Internalname = "TRLISTAACTIVIDAD_ID_"+sGXsfl_74_fel_idx;
         edtTrListaActividad_FechaInicio_Internalname = "TRLISTAACTIVIDAD_FECHAINICIO_"+sGXsfl_74_fel_idx;
         edtTrListaActividad_FechaFin_Internalname = "TRLISTAACTIVIDAD_FECHAFIN_"+sGXsfl_74_fel_idx;
         cmbTrListaActividad_Estado_Internalname = "TRLISTAACTIVIDAD_ESTADO_"+sGXsfl_74_fel_idx;
         edtTrActividades_ID_Internalname = "TRACTIVIDADES_ID_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         SubsflControlProps_742( ) ;
         WB2A0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_74_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_74_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_74_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( A55TrListaActividad_ID.ToString())+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV17Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavLinkselection_Internalname,(String)sImgUrl,(String)edtavLinkselection_Link,(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"",(String)"",(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"WWActionColumn",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrListaActividad_ID_Internalname,A55TrListaActividad_ID.ToString(),A55TrListaActividad_ID.ToString(),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrListaActividad_ID_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)36,(short)0,(short)0,(short)74,(short)1,(short)0,(short)0,(bool)true,(String)"",(String)"",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrListaActividad_FechaInicio_Internalname,context.localUtil.Format(A58TrListaActividad_FechaInicio, "99/99/9999"),context.localUtil.Format( A58TrListaActividad_FechaInicio, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrListaActividad_FechaInicio_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrListaActividad_FechaFin_Internalname,context.localUtil.Format(A59TrListaActividad_FechaFin, "99/99/9999"),context.localUtil.Format( A59TrListaActividad_FechaFin, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrListaActividad_FechaFin_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbTrListaActividad_Estado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TRLISTAACTIVIDAD_ESTADO_" + sGXsfl_74_idx;
               cmbTrListaActividad_Estado.Name = GXCCtl;
               cmbTrListaActividad_Estado.WebTags = "";
               cmbTrListaActividad_Estado.addItem("1", "Nuevo", 0);
               cmbTrListaActividad_Estado.addItem("2", "En Progreso", 0);
               cmbTrListaActividad_Estado.addItem("3", "Completado", 0);
               cmbTrListaActividad_Estado.addItem("4", "Detenido", 0);
               cmbTrListaActividad_Estado.addItem("5", "Pendiente", 0);
               if ( cmbTrListaActividad_Estado.ItemCount > 0 )
               {
                  A62TrListaActividad_Estado = (short)(NumberUtil.Val( cmbTrListaActividad_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A62TrListaActividad_Estado), 4, 0))), "."));
                  n62TrListaActividad_Estado = false;
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTrListaActividad_Estado,(String)cmbTrListaActividad_Estado_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A62TrListaActividad_Estado), 4, 0)),(short)1,(String)cmbTrListaActividad_Estado_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"WWColumn OptionalColumn",(String)"",(String)"",(String)"",(bool)true});
            cmbTrListaActividad_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A62TrListaActividad_Estado), 4, 0));
            AssignProp("", false, cmbTrListaActividad_Estado_Internalname, "Values", (String)(cmbTrListaActividad_Estado.ToJavascriptSource()), !bGXsfl_74_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrActividades_ID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A26TrActividades_ID), 13, 0, ".", "")),context.localUtil.Format( (decimal)(A26TrActividades_ID), "ZZZZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrActividades_ID_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)0,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            send_integrity_lvl_hashes2A2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         cmbavCtrlistaactividad_estado.Name = "vCTRLISTAACTIVIDAD_ESTADO";
         cmbavCtrlistaactividad_estado.WebTags = "";
         cmbavCtrlistaactividad_estado.addItem("1", "Nuevo", 0);
         cmbavCtrlistaactividad_estado.addItem("2", "En Progreso", 0);
         cmbavCtrlistaactividad_estado.addItem("3", "Completado", 0);
         cmbavCtrlistaactividad_estado.addItem("4", "Detenido", 0);
         cmbavCtrlistaactividad_estado.addItem("5", "Pendiente", 0);
         if ( cmbavCtrlistaactividad_estado.ItemCount > 0 )
         {
            AV11cTrListaActividad_Estado = (short)(NumberUtil.Val( cmbavCtrlistaactividad_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11cTrListaActividad_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV11cTrListaActividad_Estado", StringUtil.LTrimStr( (decimal)(AV11cTrListaActividad_Estado), 4, 0));
         }
         GXCCtl = "TRLISTAACTIVIDAD_ESTADO_" + sGXsfl_74_idx;
         cmbTrListaActividad_Estado.Name = GXCCtl;
         cmbTrListaActividad_Estado.WebTags = "";
         cmbTrListaActividad_Estado.addItem("1", "Nuevo", 0);
         cmbTrListaActividad_Estado.addItem("2", "En Progreso", 0);
         cmbTrListaActividad_Estado.addItem("3", "Completado", 0);
         cmbTrListaActividad_Estado.addItem("4", "Detenido", 0);
         cmbTrListaActividad_Estado.addItem("5", "Pendiente", 0);
         if ( cmbTrListaActividad_Estado.ItemCount > 0 )
         {
            A62TrListaActividad_Estado = (short)(NumberUtil.Val( cmbTrListaActividad_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A62TrListaActividad_Estado), 4, 0))), "."));
            n62TrListaActividad_Estado = false;
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLbltrlistaactividad_idfilter_Internalname = "LBLTRLISTAACTIVIDAD_IDFILTER";
         edtavCtrlistaactividad_id_Internalname = "vCTRLISTAACTIVIDAD_ID";
         divTrlistaactividad_idfiltercontainer_Internalname = "TRLISTAACTIVIDAD_IDFILTERCONTAINER";
         lblLbltrlistaactividad_fechainiciofilter_Internalname = "LBLTRLISTAACTIVIDAD_FECHAINICIOFILTER";
         edtavCtrlistaactividad_fechainicio_Internalname = "vCTRLISTAACTIVIDAD_FECHAINICIO";
         divTrlistaactividad_fechainiciofiltercontainer_Internalname = "TRLISTAACTIVIDAD_FECHAINICIOFILTERCONTAINER";
         lblLbltrlistaactividad_fechafinfilter_Internalname = "LBLTRLISTAACTIVIDAD_FECHAFINFILTER";
         edtavCtrlistaactividad_fechafin_Internalname = "vCTRLISTAACTIVIDAD_FECHAFIN";
         divTrlistaactividad_fechafinfiltercontainer_Internalname = "TRLISTAACTIVIDAD_FECHAFINFILTERCONTAINER";
         lblLbltrlistaactividad_fechacreacionfilter_Internalname = "LBLTRLISTAACTIVIDAD_FECHACREACIONFILTER";
         edtavCtrlistaactividad_fechacreacion_Internalname = "vCTRLISTAACTIVIDAD_FECHACREACION";
         divTrlistaactividad_fechacreacionfiltercontainer_Internalname = "TRLISTAACTIVIDAD_FECHACREACIONFILTERCONTAINER";
         lblLbltrlistaactividad_fechamodificacionfilter_Internalname = "LBLTRLISTAACTIVIDAD_FECHAMODIFICACIONFILTER";
         edtavCtrlistaactividad_fechamodificacion_Internalname = "vCTRLISTAACTIVIDAD_FECHAMODIFICACION";
         divTrlistaactividad_fechamodificacionfiltercontainer_Internalname = "TRLISTAACTIVIDAD_FECHAMODIFICACIONFILTERCONTAINER";
         lblLbltrlistaactividad_estadofilter_Internalname = "LBLTRLISTAACTIVIDAD_ESTADOFILTER";
         cmbavCtrlistaactividad_estado_Internalname = "vCTRLISTAACTIVIDAD_ESTADO";
         divTrlistaactividad_estadofiltercontainer_Internalname = "TRLISTAACTIVIDAD_ESTADOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtTrListaActividad_ID_Internalname = "TRLISTAACTIVIDAD_ID";
         edtTrListaActividad_FechaInicio_Internalname = "TRLISTAACTIVIDAD_FECHAINICIO";
         edtTrListaActividad_FechaFin_Internalname = "TRLISTAACTIVIDAD_FECHAFIN";
         cmbTrListaActividad_Estado_Internalname = "TRLISTAACTIVIDAD_ESTADO";
         edtTrActividades_ID_Internalname = "TRACTIVIDADES_ID";
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
         edtTrActividades_ID_Jsonclick = "";
         cmbTrListaActividad_Estado_Jsonclick = "";
         edtTrListaActividad_FechaFin_Jsonclick = "";
         edtTrListaActividad_FechaInicio_Jsonclick = "";
         edtTrListaActividad_ID_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         cmbavCtrlistaactividad_estado_Jsonclick = "";
         cmbavCtrlistaactividad_estado.Enabled = 1;
         cmbavCtrlistaactividad_estado.Visible = 1;
         edtavCtrlistaactividad_fechamodificacion_Jsonclick = "";
         edtavCtrlistaactividad_fechamodificacion_Enabled = 1;
         edtavCtrlistaactividad_fechacreacion_Jsonclick = "";
         edtavCtrlistaactividad_fechacreacion_Enabled = 1;
         edtavCtrlistaactividad_fechafin_Jsonclick = "";
         edtavCtrlistaactividad_fechafin_Enabled = 1;
         edtavCtrlistaactividad_fechainicio_Jsonclick = "";
         edtavCtrlistaactividad_fechainicio_Enabled = 1;
         edtavCtrlistaactividad_id_Jsonclick = "";
         edtavCtrlistaactividad_id_Enabled = 1;
         edtavCtrlistaactividad_id_Visible = 1;
         divTrlistaactividad_estadofiltercontainer_Class = "AdvancedContainerItem";
         divTrlistaactividad_fechamodificacionfiltercontainer_Class = "AdvancedContainerItem";
         divTrlistaactividad_fechacreacionfiltercontainer_Class = "AdvancedContainerItem";
         divTrlistaactividad_fechafinfiltercontainer_Class = "AdvancedContainerItem";
         divTrlistaactividad_fechainiciofiltercontainer_Class = "AdvancedContainerItem";
         divTrlistaactividad_idfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Level1";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrListaActividad_ID',fld:'vCTRLISTAACTIVIDAD_ID',pic:''},{av:'AV7cTrListaActividad_FechaInicio',fld:'vCTRLISTAACTIVIDAD_FECHAINICIO',pic:''},{av:'AV8cTrListaActividad_FechaFin',fld:'vCTRLISTAACTIVIDAD_FECHAFIN',pic:''},{av:'AV9cTrListaActividad_FechaCreacion',fld:'vCTRLISTAACTIVIDAD_FECHACREACION',pic:''},{av:'AV10cTrListaActividad_FechaModificacion',fld:'vCTRLISTAACTIVIDAD_FECHAMODIFICACION',pic:''},{av:'cmbavCtrlistaactividad_estado'},{av:'AV11cTrListaActividad_Estado',fld:'vCTRLISTAACTIVIDAD_ESTADO',pic:'ZZZ9'},{av:'AV12pTrActividades_ID',fld:'vPTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E172A1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLTRLISTAACTIVIDAD_IDFILTER.CLICK","{handler:'E112A1',iparms:[{av:'divTrlistaactividad_idfiltercontainer_Class',ctrl:'TRLISTAACTIVIDAD_IDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRLISTAACTIVIDAD_IDFILTER.CLICK",",oparms:[{av:'divTrlistaactividad_idfiltercontainer_Class',ctrl:'TRLISTAACTIVIDAD_IDFILTERCONTAINER',prop:'Class'},{av:'edtavCtrlistaactividad_id_Visible',ctrl:'vCTRLISTAACTIVIDAD_ID',prop:'Visible'}]}");
         setEventMetadata("LBLTRLISTAACTIVIDAD_FECHAINICIOFILTER.CLICK","{handler:'E122A1',iparms:[{av:'divTrlistaactividad_fechainiciofiltercontainer_Class',ctrl:'TRLISTAACTIVIDAD_FECHAINICIOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRLISTAACTIVIDAD_FECHAINICIOFILTER.CLICK",",oparms:[{av:'divTrlistaactividad_fechainiciofiltercontainer_Class',ctrl:'TRLISTAACTIVIDAD_FECHAINICIOFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLTRLISTAACTIVIDAD_FECHAFINFILTER.CLICK","{handler:'E132A1',iparms:[{av:'divTrlistaactividad_fechafinfiltercontainer_Class',ctrl:'TRLISTAACTIVIDAD_FECHAFINFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRLISTAACTIVIDAD_FECHAFINFILTER.CLICK",",oparms:[{av:'divTrlistaactividad_fechafinfiltercontainer_Class',ctrl:'TRLISTAACTIVIDAD_FECHAFINFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLTRLISTAACTIVIDAD_FECHACREACIONFILTER.CLICK","{handler:'E142A1',iparms:[{av:'divTrlistaactividad_fechacreacionfiltercontainer_Class',ctrl:'TRLISTAACTIVIDAD_FECHACREACIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRLISTAACTIVIDAD_FECHACREACIONFILTER.CLICK",",oparms:[{av:'divTrlistaactividad_fechacreacionfiltercontainer_Class',ctrl:'TRLISTAACTIVIDAD_FECHACREACIONFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLTRLISTAACTIVIDAD_FECHAMODIFICACIONFILTER.CLICK","{handler:'E152A1',iparms:[{av:'divTrlistaactividad_fechamodificacionfiltercontainer_Class',ctrl:'TRLISTAACTIVIDAD_FECHAMODIFICACIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRLISTAACTIVIDAD_FECHAMODIFICACIONFILTER.CLICK",",oparms:[{av:'divTrlistaactividad_fechamodificacionfiltercontainer_Class',ctrl:'TRLISTAACTIVIDAD_FECHAMODIFICACIONFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLTRLISTAACTIVIDAD_ESTADOFILTER.CLICK","{handler:'E162A1',iparms:[{av:'divTrlistaactividad_estadofiltercontainer_Class',ctrl:'TRLISTAACTIVIDAD_ESTADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRLISTAACTIVIDAD_ESTADOFILTER.CLICK",",oparms:[{av:'divTrlistaactividad_estadofiltercontainer_Class',ctrl:'TRLISTAACTIVIDAD_ESTADOFILTERCONTAINER',prop:'Class'},{av:'cmbavCtrlistaactividad_estado'}]}");
         setEventMetadata("ENTER","{handler:'E202A2',iparms:[{av:'A55TrListaActividad_ID',fld:'TRLISTAACTIVIDAD_ID',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pTrListaActividad_ID',fld:'vPTRLISTAACTIVIDAD_ID',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrListaActividad_ID',fld:'vCTRLISTAACTIVIDAD_ID',pic:''},{av:'AV7cTrListaActividad_FechaInicio',fld:'vCTRLISTAACTIVIDAD_FECHAINICIO',pic:''},{av:'AV8cTrListaActividad_FechaFin',fld:'vCTRLISTAACTIVIDAD_FECHAFIN',pic:''},{av:'AV9cTrListaActividad_FechaCreacion',fld:'vCTRLISTAACTIVIDAD_FECHACREACION',pic:''},{av:'AV10cTrListaActividad_FechaModificacion',fld:'vCTRLISTAACTIVIDAD_FECHAMODIFICACION',pic:''},{av:'cmbavCtrlistaactividad_estado'},{av:'AV11cTrListaActividad_Estado',fld:'vCTRLISTAACTIVIDAD_ESTADO',pic:'ZZZ9'},{av:'AV12pTrActividades_ID',fld:'vPTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrListaActividad_ID',fld:'vCTRLISTAACTIVIDAD_ID',pic:''},{av:'AV7cTrListaActividad_FechaInicio',fld:'vCTRLISTAACTIVIDAD_FECHAINICIO',pic:''},{av:'AV8cTrListaActividad_FechaFin',fld:'vCTRLISTAACTIVIDAD_FECHAFIN',pic:''},{av:'AV9cTrListaActividad_FechaCreacion',fld:'vCTRLISTAACTIVIDAD_FECHACREACION',pic:''},{av:'AV10cTrListaActividad_FechaModificacion',fld:'vCTRLISTAACTIVIDAD_FECHAMODIFICACION',pic:''},{av:'cmbavCtrlistaactividad_estado'},{av:'AV11cTrListaActividad_Estado',fld:'vCTRLISTAACTIVIDAD_ESTADO',pic:'ZZZ9'},{av:'AV12pTrActividades_ID',fld:'vPTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrListaActividad_ID',fld:'vCTRLISTAACTIVIDAD_ID',pic:''},{av:'AV7cTrListaActividad_FechaInicio',fld:'vCTRLISTAACTIVIDAD_FECHAINICIO',pic:''},{av:'AV8cTrListaActividad_FechaFin',fld:'vCTRLISTAACTIVIDAD_FECHAFIN',pic:''},{av:'AV9cTrListaActividad_FechaCreacion',fld:'vCTRLISTAACTIVIDAD_FECHACREACION',pic:''},{av:'AV10cTrListaActividad_FechaModificacion',fld:'vCTRLISTAACTIVIDAD_FECHAMODIFICACION',pic:''},{av:'cmbavCtrlistaactividad_estado'},{av:'AV11cTrListaActividad_Estado',fld:'vCTRLISTAACTIVIDAD_ESTADO',pic:'ZZZ9'},{av:'AV12pTrActividades_ID',fld:'vPTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrListaActividad_ID',fld:'vCTRLISTAACTIVIDAD_ID',pic:''},{av:'AV7cTrListaActividad_FechaInicio',fld:'vCTRLISTAACTIVIDAD_FECHAINICIO',pic:''},{av:'AV8cTrListaActividad_FechaFin',fld:'vCTRLISTAACTIVIDAD_FECHAFIN',pic:''},{av:'AV9cTrListaActividad_FechaCreacion',fld:'vCTRLISTAACTIVIDAD_FECHACREACION',pic:''},{av:'AV10cTrListaActividad_FechaModificacion',fld:'vCTRLISTAACTIVIDAD_FECHAMODIFICACION',pic:''},{av:'cmbavCtrlistaactividad_estado'},{av:'AV11cTrListaActividad_Estado',fld:'vCTRLISTAACTIVIDAD_ESTADO',pic:'ZZZ9'},{av:'AV12pTrActividades_ID',fld:'vPTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CTRLISTAACTIVIDAD_ID","{handler:'Validv_Ctrlistaactividad_id',iparms:[]");
         setEventMetadata("VALIDV_CTRLISTAACTIVIDAD_ID",",oparms:[]}");
         setEventMetadata("VALIDV_CTRLISTAACTIVIDAD_FECHAINICIO","{handler:'Validv_Ctrlistaactividad_fechainicio',iparms:[]");
         setEventMetadata("VALIDV_CTRLISTAACTIVIDAD_FECHAINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_CTRLISTAACTIVIDAD_FECHAFIN","{handler:'Validv_Ctrlistaactividad_fechafin',iparms:[]");
         setEventMetadata("VALIDV_CTRLISTAACTIVIDAD_FECHAFIN",",oparms:[]}");
         setEventMetadata("VALIDV_CTRLISTAACTIVIDAD_FECHACREACION","{handler:'Validv_Ctrlistaactividad_fechacreacion',iparms:[]");
         setEventMetadata("VALIDV_CTRLISTAACTIVIDAD_FECHACREACION",",oparms:[]}");
         setEventMetadata("VALIDV_CTRLISTAACTIVIDAD_FECHAMODIFICACION","{handler:'Validv_Ctrlistaactividad_fechamodificacion',iparms:[]");
         setEventMetadata("VALIDV_CTRLISTAACTIVIDAD_FECHAMODIFICACION",",oparms:[]}");
         setEventMetadata("VALIDV_CTRLISTAACTIVIDAD_ESTADO","{handler:'Validv_Ctrlistaactividad_estado',iparms:[]");
         setEventMetadata("VALIDV_CTRLISTAACTIVIDAD_ESTADO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Tractividades_id',iparms:[]");
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
         AV6cTrListaActividad_ID = (Guid)(Guid.Empty);
         AV7cTrListaActividad_FechaInicio = DateTime.MinValue;
         AV8cTrListaActividad_FechaFin = DateTime.MinValue;
         AV9cTrListaActividad_FechaCreacion = DateTime.MinValue;
         AV10cTrListaActividad_FechaModificacion = DateTime.MinValue;
         AV13pTrListaActividad_ID = (Guid)(Guid.Empty);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLbltrlistaactividad_idfilter_Jsonclick = "";
         TempTags = "";
         lblLbltrlistaactividad_fechainiciofilter_Jsonclick = "";
         lblLbltrlistaactividad_fechafinfilter_Jsonclick = "";
         lblLbltrlistaactividad_fechacreacionfilter_Jsonclick = "";
         lblLbltrlistaactividad_fechamodificacionfilter_Jsonclick = "";
         lblLbltrlistaactividad_estadofilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A55TrListaActividad_ID = (Guid)(Guid.Empty);
         A58TrListaActividad_FechaInicio = DateTime.MinValue;
         A59TrListaActividad_FechaFin = DateTime.MinValue;
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV17Linkselection_GXI = "";
         scmdbuf = "";
         A60TrListaActividad_FechaCreacion = DateTime.MinValue;
         A61TrListaActividad_FechaModificacion = DateTime.MinValue;
         H002A2_A61TrListaActividad_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         H002A2_n61TrListaActividad_FechaModificacion = new bool[] {false} ;
         H002A2_A60TrListaActividad_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         H002A2_n60TrListaActividad_FechaCreacion = new bool[] {false} ;
         H002A2_A26TrActividades_ID = new long[1] ;
         H002A2_A62TrListaActividad_Estado = new short[1] ;
         H002A2_n62TrListaActividad_Estado = new bool[] {false} ;
         H002A2_A59TrListaActividad_FechaFin = new DateTime[] {DateTime.MinValue} ;
         H002A2_n59TrListaActividad_FechaFin = new bool[] {false} ;
         H002A2_A58TrListaActividad_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H002A2_n58TrListaActividad_FechaInicio = new bool[] {false} ;
         H002A2_A55TrListaActividad_ID = new Guid[] {Guid.Empty} ;
         H002A3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0091__default(),
            new Object[][] {
                new Object[] {
               H002A2_A61TrListaActividad_FechaModificacion, H002A2_n61TrListaActividad_FechaModificacion, H002A2_A60TrListaActividad_FechaCreacion, H002A2_n60TrListaActividad_FechaCreacion, H002A2_A26TrActividades_ID, H002A2_A62TrListaActividad_Estado, H002A2_n62TrListaActividad_Estado, H002A2_A59TrListaActividad_FechaFin, H002A2_n59TrListaActividad_FechaFin, H002A2_A58TrListaActividad_FechaInicio,
               H002A2_n58TrListaActividad_FechaInicio, H002A2_A55TrListaActividad_ID
               }
               , new Object[] {
               H002A3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV11cTrListaActividad_Estado ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short A62TrListaActividad_Estado ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_74 ;
      private int nGXsfl_74_idx=1 ;
      private int subGrid1_Rows ;
      private int edtavCtrlistaactividad_id_Visible ;
      private int edtavCtrlistaactividad_id_Enabled ;
      private int edtavCtrlistaactividad_fechainicio_Enabled ;
      private int edtavCtrlistaactividad_fechafin_Enabled ;
      private int edtavCtrlistaactividad_fechacreacion_Enabled ;
      private int edtavCtrlistaactividad_fechamodificacion_Enabled ;
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
      private long AV12pTrActividades_ID ;
      private long wcpOAV12pTrActividades_ID ;
      private long GRID1_nFirstRecordOnPage ;
      private long A26TrActividades_ID ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private String divAdvancedcontainer_Class ;
      private String bttBtntoggle_Class ;
      private String divTrlistaactividad_idfiltercontainer_Class ;
      private String divTrlistaactividad_fechainiciofiltercontainer_Class ;
      private String divTrlistaactividad_fechafinfiltercontainer_Class ;
      private String divTrlistaactividad_fechacreacionfiltercontainer_Class ;
      private String divTrlistaactividad_fechamodificacionfiltercontainer_Class ;
      private String divTrlistaactividad_estadofiltercontainer_Class ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_74_idx="0001" ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMain_Internalname ;
      private String divAdvancedcontainer_Internalname ;
      private String divTrlistaactividad_idfiltercontainer_Internalname ;
      private String lblLbltrlistaactividad_idfilter_Internalname ;
      private String lblLbltrlistaactividad_idfilter_Jsonclick ;
      private String edtavCtrlistaactividad_id_Internalname ;
      private String TempTags ;
      private String edtavCtrlistaactividad_id_Jsonclick ;
      private String divTrlistaactividad_fechainiciofiltercontainer_Internalname ;
      private String lblLbltrlistaactividad_fechainiciofilter_Internalname ;
      private String lblLbltrlistaactividad_fechainiciofilter_Jsonclick ;
      private String edtavCtrlistaactividad_fechainicio_Internalname ;
      private String edtavCtrlistaactividad_fechainicio_Jsonclick ;
      private String divTrlistaactividad_fechafinfiltercontainer_Internalname ;
      private String lblLbltrlistaactividad_fechafinfilter_Internalname ;
      private String lblLbltrlistaactividad_fechafinfilter_Jsonclick ;
      private String edtavCtrlistaactividad_fechafin_Internalname ;
      private String edtavCtrlistaactividad_fechafin_Jsonclick ;
      private String divTrlistaactividad_fechacreacionfiltercontainer_Internalname ;
      private String lblLbltrlistaactividad_fechacreacionfilter_Internalname ;
      private String lblLbltrlistaactividad_fechacreacionfilter_Jsonclick ;
      private String edtavCtrlistaactividad_fechacreacion_Internalname ;
      private String edtavCtrlistaactividad_fechacreacion_Jsonclick ;
      private String divTrlistaactividad_fechamodificacionfiltercontainer_Internalname ;
      private String lblLbltrlistaactividad_fechamodificacionfilter_Internalname ;
      private String lblLbltrlistaactividad_fechamodificacionfilter_Jsonclick ;
      private String edtavCtrlistaactividad_fechamodificacion_Internalname ;
      private String edtavCtrlistaactividad_fechamodificacion_Jsonclick ;
      private String divTrlistaactividad_estadofiltercontainer_Internalname ;
      private String lblLbltrlistaactividad_estadofilter_Internalname ;
      private String lblLbltrlistaactividad_estadofilter_Jsonclick ;
      private String cmbavCtrlistaactividad_estado_Internalname ;
      private String cmbavCtrlistaactividad_estado_Jsonclick ;
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
      private String edtTrListaActividad_ID_Internalname ;
      private String edtTrListaActividad_FechaInicio_Internalname ;
      private String edtTrListaActividad_FechaFin_Internalname ;
      private String cmbTrListaActividad_Estado_Internalname ;
      private String edtTrActividades_ID_Internalname ;
      private String scmdbuf ;
      private String AV14ADVANCED_LABEL_TEMPLATE ;
      private String sGXsfl_74_fel_idx="0001" ;
      private String sImgUrl ;
      private String ROClassString ;
      private String edtTrListaActividad_ID_Jsonclick ;
      private String edtTrListaActividad_FechaInicio_Jsonclick ;
      private String edtTrListaActividad_FechaFin_Jsonclick ;
      private String GXCCtl ;
      private String cmbTrListaActividad_Estado_Jsonclick ;
      private String edtTrActividades_ID_Jsonclick ;
      private DateTime AV7cTrListaActividad_FechaInicio ;
      private DateTime AV8cTrListaActividad_FechaFin ;
      private DateTime AV9cTrListaActividad_FechaCreacion ;
      private DateTime AV10cTrListaActividad_FechaModificacion ;
      private DateTime A58TrListaActividad_FechaInicio ;
      private DateTime A59TrListaActividad_FechaFin ;
      private DateTime A60TrListaActividad_FechaCreacion ;
      private DateTime A61TrListaActividad_FechaModificacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool n58TrListaActividad_FechaInicio ;
      private bool n59TrListaActividad_FechaFin ;
      private bool n62TrListaActividad_Estado ;
      private bool gxdyncontrolsrefreshing ;
      private bool n61TrListaActividad_FechaModificacion ;
      private bool n60TrListaActividad_FechaCreacion ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private String AV17Linkselection_GXI ;
      private String AV5LinkSelection ;
      private Guid AV6cTrListaActividad_ID ;
      private Guid AV13pTrListaActividad_ID ;
      private Guid A55TrListaActividad_ID ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCtrlistaactividad_estado ;
      private GXCombobox cmbTrListaActividad_Estado ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H002A2_A61TrListaActividad_FechaModificacion ;
      private bool[] H002A2_n61TrListaActividad_FechaModificacion ;
      private DateTime[] H002A2_A60TrListaActividad_FechaCreacion ;
      private bool[] H002A2_n60TrListaActividad_FechaCreacion ;
      private long[] H002A2_A26TrActividades_ID ;
      private short[] H002A2_A62TrListaActividad_Estado ;
      private bool[] H002A2_n62TrListaActividad_Estado ;
      private DateTime[] H002A2_A59TrListaActividad_FechaFin ;
      private bool[] H002A2_n59TrListaActividad_FechaFin ;
      private DateTime[] H002A2_A58TrListaActividad_FechaInicio ;
      private bool[] H002A2_n58TrListaActividad_FechaInicio ;
      private Guid[] H002A2_A55TrListaActividad_ID ;
      private long[] H002A3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid aP1_pTrListaActividad_ID ;
      private GXWebForm Form ;
   }

   public class gx0091__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002A2( IGxContext context ,
                                             DateTime AV7cTrListaActividad_FechaInicio ,
                                             DateTime AV8cTrListaActividad_FechaFin ,
                                             DateTime AV9cTrListaActividad_FechaCreacion ,
                                             DateTime AV10cTrListaActividad_FechaModificacion ,
                                             short AV11cTrListaActividad_Estado ,
                                             DateTime A58TrListaActividad_FechaInicio ,
                                             DateTime A59TrListaActividad_FechaFin ,
                                             DateTime A60TrListaActividad_FechaCreacion ,
                                             DateTime A61TrListaActividad_FechaModificacion ,
                                             short A62TrListaActividad_Estado ,
                                             long AV12pTrActividades_ID ,
                                             Guid AV6cTrListaActividad_ID ,
                                             long A26TrActividades_ID )
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
         sSelectString = " [TrListaActividad_FechaModificacion], [TrListaActividad_FechaCreacion], [TrActividades_ID], [TrListaActividad_Estado], [TrListaActividad_FechaFin], [TrListaActividad_FechaInicio], [TrListaActividad_ID]";
         sFromString = " FROM TABLERO.[TrActividadesLevel1]";
         sOrderString = "";
         sWhereString = sWhereString + " WHERE ([TrActividades_ID] = @AV12pTrActividades_ID and [TrListaActividad_ID] >= @AV6cTrListaActividad_ID)";
         if ( ! (DateTime.MinValue==AV7cTrListaActividad_FechaInicio) )
         {
            sWhereString = sWhereString + " and ([TrListaActividad_FechaInicio] >= @AV7cTrListaActividad_FechaInicio)";
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cTrListaActividad_FechaFin) )
         {
            sWhereString = sWhereString + " and ([TrListaActividad_FechaFin] >= @AV8cTrListaActividad_FechaFin)";
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cTrListaActividad_FechaCreacion) )
         {
            sWhereString = sWhereString + " and ([TrListaActividad_FechaCreacion] >= @AV9cTrListaActividad_FechaCreacion)";
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cTrListaActividad_FechaModificacion) )
         {
            sWhereString = sWhereString + " and ([TrListaActividad_FechaModificacion] >= @AV10cTrListaActividad_FechaModificacion)";
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV11cTrListaActividad_Estado) )
         {
            sWhereString = sWhereString + " and ([TrListaActividad_Estado] >= @AV11cTrListaActividad_Estado)";
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString = sOrderString + " ORDER BY [TrActividades_ID], [TrListaActividad_ID]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H002A3( IGxContext context ,
                                             DateTime AV7cTrListaActividad_FechaInicio ,
                                             DateTime AV8cTrListaActividad_FechaFin ,
                                             DateTime AV9cTrListaActividad_FechaCreacion ,
                                             DateTime AV10cTrListaActividad_FechaModificacion ,
                                             short AV11cTrListaActividad_Estado ,
                                             DateTime A58TrListaActividad_FechaInicio ,
                                             DateTime A59TrListaActividad_FechaFin ,
                                             DateTime A60TrListaActividad_FechaCreacion ,
                                             DateTime A61TrListaActividad_FechaModificacion ,
                                             short A62TrListaActividad_Estado ,
                                             long AV12pTrActividades_ID ,
                                             Guid AV6cTrListaActividad_ID ,
                                             long A26TrActividades_ID )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int3 ;
         GXv_int3 = new short [7] ;
         Object[] GXv_Object4 ;
         GXv_Object4 = new Object [2] ;
         scmdbuf = "SELECT COUNT(*) FROM TABLERO.[TrActividadesLevel1]";
         scmdbuf = scmdbuf + " WHERE ([TrActividades_ID] = @AV12pTrActividades_ID and [TrListaActividad_ID] >= @AV6cTrListaActividad_ID)";
         if ( ! (DateTime.MinValue==AV7cTrListaActividad_FechaInicio) )
         {
            sWhereString = sWhereString + " and ([TrListaActividad_FechaInicio] >= @AV7cTrListaActividad_FechaInicio)";
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cTrListaActividad_FechaFin) )
         {
            sWhereString = sWhereString + " and ([TrListaActividad_FechaFin] >= @AV8cTrListaActividad_FechaFin)";
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cTrListaActividad_FechaCreacion) )
         {
            sWhereString = sWhereString + " and ([TrListaActividad_FechaCreacion] >= @AV9cTrListaActividad_FechaCreacion)";
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cTrListaActividad_FechaModificacion) )
         {
            sWhereString = sWhereString + " and ([TrListaActividad_FechaModificacion] >= @AV10cTrListaActividad_FechaModificacion)";
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV11cTrListaActividad_Estado) )
         {
            sWhereString = sWhereString + " and ([TrListaActividad_Estado] >= @AV11cTrListaActividad_Estado)";
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
                     return conditional_H002A2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (short)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (long)dynConstraints[10] , (Guid)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H002A3(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (short)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (long)dynConstraints[10] , (Guid)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH002A2 ;
          prmH002A2 = new Object[] {
          new Object[] {"@AV12pTrActividades_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV6cTrListaActividad_ID",SqlDbType.UniqueIdentifier,13,0} ,
          new Object[] {"@AV7cTrListaActividad_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV8cTrListaActividad_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV9cTrListaActividad_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV10cTrListaActividad_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV11cTrListaActividad_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@GXPagingFrom2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0}
          } ;
          Object[] prmH002A3 ;
          prmH002A3 = new Object[] {
          new Object[] {"@AV12pTrActividades_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV6cTrListaActividad_ID",SqlDbType.UniqueIdentifier,13,0} ,
          new Object[] {"@AV7cTrListaActividad_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV8cTrListaActividad_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV9cTrListaActividad_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV10cTrListaActividad_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV11cTrListaActividad_Estado",SqlDbType.SmallInt,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H002A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002A2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H002A3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002A3,1, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3) ;
                ((short[]) buf[5])[0] = rslt.getShort(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((Guid[]) buf[11])[0] = rslt.getGuid(7) ;
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
                   stmt.SetParameter(sIdx, (long)parms[10]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (Guid)parms[11]);
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
                   stmt.SetParameter(sIdx, (long)parms[7]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (Guid)parms[8]);
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
