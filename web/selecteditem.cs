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
   public class selecteditem : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public selecteditem( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public selecteditem( IGxContext context )
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
         chkavSelected_webpaneldesignertemplate = new GXCheckbox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               nRC_GXsfl_9 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_9_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_9_idx = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               AV9Variable_Title = GetNextPar( );
               AV8Variable_Photo = GetNextPar( );
               AV6Selected_WebPanelDesignerTemplate = StringUtil.StrToBool( GetNextPar( ));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( AV9Variable_Title, AV8Variable_Photo, AV6Selected_WebPanelDesignerTemplate) ;
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
         PA0H2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0H2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210211744398", false, true);
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
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("selecteditem.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
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
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_9", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_9), 8, 0, ".", "")));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE0H2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0H2( ) ;
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
         return formatLink("selecteditem.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "SelectedItem" ;
      }

      public override String GetPgmdesc( )
      {
         return "Selected Item" ;
      }

      protected void WB0H0( )
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
            GxWebStd.gx_div_start( context, divMaintable_webpaneldesignertemplate_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUserregion_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetIsFreestyle(true);
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"9\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "K2BT_SelectedItemsGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               GridContainer.AddObjectProperty("GridName", "Grid");
            }
            else
            {
               GridContainer.AddObjectProperty("GridName", "Grid");
               GridContainer.AddObjectProperty("Header", subGrid_Header);
               GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "K2BT_SelectedItemsGrid"));
               GridContainer.AddObjectProperty("Class", "K2BT_SelectedItemsGrid");
               GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("CmpContext", "");
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", lblInitialtextblock_Caption);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV7ShownPhoto));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV9Variable_Title));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV5Action_Remove));
               GridContainer.AddColumnProperties(GridColumn);
               GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 9 )
         {
            wbEnd = 0;
            nRC_GXsfl_9 = (int)(nGXsfl_9_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
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
            wb_table1_25_0H2( true) ;
         }
         else
         {
            wb_table1_25_0H2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_0H2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 9 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0H2( )
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
            Form.Meta.addItem("description", "Selected Item", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0H0( ) ;
      }

      protected void WS0H2( )
      {
         START0H2( ) ;
         EVT0H2( ) ;
      }

      protected void EVT0H2( )
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_9_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
                              SubsflControlProps_92( ) ;
                              AV7ShownPhoto = cgiGet( edtavShownphoto_Internalname);
                              AssignProp("", false, edtavShownphoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV7ShownPhoto)) ? AV12Shownphoto_GXI : context.convertURL( context.PathToRelativeUrl( AV7ShownPhoto))), !bGXsfl_9_Refreshing);
                              AssignProp("", false, edtavShownphoto_Internalname, "SrcSet", context.GetImageSrcSet( AV7ShownPhoto), true);
                              AV9Variable_Title = cgiGet( edtavVariable_title_Internalname);
                              AssignAttri("", false, edtavVariable_title_Internalname, AV9Variable_Title);
                              AV5Action_Remove = cgiGet( edtavAction_remove_Internalname);
                              AssignAttri("", false, edtavAction_remove_Internalname, AV5Action_Remove);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E110H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E120H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E130H2 ();
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

      protected void WE0H2( )
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

      protected void PA0H2( )
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
               GX_FocusControl = chkavSelected_webpaneldesignertemplate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_92( ) ;
         while ( nGXsfl_9_idx <= nRC_GXsfl_9 )
         {
            sendrow_92( ) ;
            nGXsfl_9_idx = ((subGrid_Islastpage==1)&&(nGXsfl_9_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( String AV9Variable_Title ,
                                       String AV8Variable_Photo ,
                                       bool AV6Selected_WebPanelDesignerTemplate )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E120H2 ();
         GRID_nCurrentRecord = 0;
         RF0H2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
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
         AV6Selected_WebPanelDesignerTemplate = StringUtil.StrToBool( StringUtil.BoolToStr( AV6Selected_WebPanelDesignerTemplate));
         AssignAttri("", false, "AV6Selected_WebPanelDesignerTemplate", AV6Selected_WebPanelDesignerTemplate);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0H2( ) ;
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

      protected void RF0H2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 9;
         /* Execute user event: Refresh */
         E120H2 ();
         nGXsfl_9_idx = 1;
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         bGXsfl_9_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "K2BT_SelectedItemsGrid"));
         GridContainer.AddObjectProperty("Class", "K2BT_SelectedItemsGrid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_92( ) ;
            /* Execute user event: Load */
            E130H2 ();
            wbEnd = 9;
            WB0H0( ) ;
         }
         bGXsfl_9_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0H2( )
      {
      }

      protected int subGrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP0H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110H2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_9 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_9"), ".", ","));
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

      protected void S112( )
      {
         /* 'DISPLAYPERSISTENTACTIONS(WEBPANELDESIGNERTEMPLATE)' Routine */
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E110H2 ();
         if (returnInSub) return;
      }

      protected void E110H2( )
      {
         /* Start Routine */
      }

      protected void E120H2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
      }

      private void E130H2( )
      {
         /* Load Routine */
         lblInitialtextblock_Caption = StringUtil.Substring( AV9Variable_Title, 1, 1);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8Variable_Photo)) )
         {
            AV7ShownPhoto = AV8Variable_Photo;
            AssignAttri("", false, edtavShownphoto_Internalname, AV7ShownPhoto);
            divPhotocontainer_Visible = 1;
            AssignProp("", false, divPhotocontainer_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPhotocontainer_Visible), 5, 0), !bGXsfl_9_Refreshing);
         }
         else
         {
            divPhotocontainer_Visible = 0;
            AssignProp("", false, divPhotocontainer_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPhotocontainer_Visible), 5, 0), !bGXsfl_9_Refreshing);
         }
         sendrow_92( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_9_Refreshing )
         {
            context.DoAjaxLoad(9, GridRow);
         }
      }

      protected void S122( )
      {
         /* 'UPDATEPAGINGCONTROLS(WEBPANELDESIGNERTEMPLATE)' Routine */
      }

      protected void S132( )
      {
         /* 'U_SEARCH(WEBPANELDESIGNERTEMPLATE)' Routine */
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE(WEBPANELDESIGNERTEMPLATE)' Routine */
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE(WEBPANELDESIGNERTEMPLATE)' Routine */
      }

      protected void S162( )
      {
         /* 'REFRESHGRIDACTIONS(WEBPANELDESIGNERTEMPLATE)' Routine */
      }

      protected void S172( )
      {
         /* 'DISPLAYMULTIPLEACTIONS(WEBPANELDESIGNERTEMPLATE)' Routine */
      }

      protected void S182( )
      {
         /* 'DISPLAYSINGLEACTIONS(WEBPANELDESIGNERTEMPLATE)' Routine */
      }

      protected void S192( )
      {
         /* 'HIDEMULTIPLEACTIONS(WEBPANELDESIGNERTEMPLATE)' Routine */
      }

      protected void S202( )
      {
         /* 'HIDESINGLEACTIONS(WEBPANELDESIGNERTEMPLATE)' Routine */
      }

      protected void S212( )
      {
         /* 'U_MULTIROWITEMSELECTED(WEBPANELDESIGNERTEMPLATE)' Routine */
      }

      protected void S222( )
      {
         /* 'U_PAGINGFIRST(WEBPANELDESIGNERTEMPLATE)' Routine */
      }

      protected void S232( )
      {
         /* 'U_PAGINGPREVIOUS(WEBPANELDESIGNERTEMPLATE)' Routine */
      }

      protected void S242( )
      {
         /* 'U_PAGINGNEXT(WEBPANELDESIGNERTEMPLATE)' Routine */
      }

      protected void S252( )
      {
         /* 'U_PAGINGLAST(WEBPANELDESIGNERTEMPLATE)' Routine */
      }

      protected void S262( )
      {
         /* 'PROCESSSELECTION(WEBPANELDESIGNERTEMPLATE)' Routine */
      }

      protected void wb_table1_25_0H2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnuseditemssection_Internalname, tblUnuseditemssection_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavSelected_webpaneldesignertemplate_Internalname, "WebPanelDesignerTemplate", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_9_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSelected_webpaneldesignertemplate_Internalname, StringUtil.BoolToStr( AV6Selected_WebPanelDesignerTemplate), "", "WebPanelDesignerTemplate", 1, chkavSelected_webpaneldesignertemplate.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(29, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,29);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+edtavVariable_photo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavVariable_photo_Internalname, "Photo", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'" + sGXsfl_9_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVariable_photo_Internalname, StringUtil.RTrim( AV8Variable_Photo), StringUtil.RTrim( context.localUtil.Format( AV8Variable_Photo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVariable_photo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavVariable_photo_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, false, "", "left", true, "", "HLP_SelectedItem.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_0H2e( true) ;
         }
         else
         {
            wb_table1_25_0H2e( false) ;
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
         PA0H2( ) ;
         WS0H2( ) ;
         WE0H2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210211744426", true, true);
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
            context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("selecteditem.js", "?202210211744426", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_92( )
      {
         lblInitialtextblock_Internalname = "INITIALTEXTBLOCK_"+sGXsfl_9_idx;
         edtavShownphoto_Internalname = "vSHOWNPHOTO_"+sGXsfl_9_idx;
         edtavVariable_title_Internalname = "vVARIABLE_TITLE_"+sGXsfl_9_idx;
         edtavAction_remove_Internalname = "vACTION_REMOVE_"+sGXsfl_9_idx;
      }

      protected void SubsflControlProps_fel_92( )
      {
         lblInitialtextblock_Internalname = "INITIALTEXTBLOCK_"+sGXsfl_9_fel_idx;
         edtavShownphoto_Internalname = "vSHOWNPHOTO_"+sGXsfl_9_fel_idx;
         edtavVariable_title_Internalname = "vVARIABLE_TITLE_"+sGXsfl_9_fel_idx;
         edtavAction_remove_Internalname = "vACTION_REMOVE_"+sGXsfl_9_fel_idx;
      }

      protected void sendrow_92( )
      {
         SubsflControlProps_92( ) ;
         WB0H0( ) ;
         GridRow = GXWebRow.GetNew(context,GridContainer);
         if ( subGrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
            {
               subGrid_Linesclass = subGrid_Class+"Odd";
            }
         }
         else if ( subGrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid_Backstyle = 0;
            subGrid_Backcolor = subGrid_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
            {
               subGrid_Linesclass = subGrid_Class+"Uniform";
            }
         }
         else if ( subGrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
            {
               subGrid_Linesclass = subGrid_Class+"Odd";
            }
            subGrid_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid_Backstyle = 1;
            if ( ((int)((nGXsfl_9_idx) % (2))) == 0 )
            {
               subGrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Even";
               }
            }
            else
            {
               subGrid_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_9_idx+"\">") ;
         }
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)divMigrate2_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"Table",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"row",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"col-xs-12",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)divSection1_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"K2BT_SelectedItemRight",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)divSection2_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"K2BToolsSection_CardListHeader",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Text block */
         GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(String)lblInitialtextblock_Internalname,(String)lblInitialtextblock_Caption,(String)"",(String)"",(String)lblInitialtextblock_Jsonclick,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"K2BToolsTextblock_InitialsCircleSmall",(short)0,(String)"",(short)1,(short)1,(short)0});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)divPhotocontainer_Internalname+"_"+sGXsfl_9_idx,(int)divPhotocontainer_Visible,(short)0,(String)"px",(short)0,(String)"px",(String)"K2BToolsSection_CardListPhotoContainer",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)" gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Attribute/Variable Label */
         GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"Photo",(String)"gx-form-item K2BToolsAttribute_CardListPhotoLabel",(short)0,(bool)true,(String)"width: 25%;"});
         /* Static Bitmap Variable */
         ClassString = "K2BToolsAttribute_CardListPhoto";
         StyleString = "";
         AV7ShownPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV7ShownPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( AV12Shownphoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV7ShownPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV7ShownPhoto)) ? AV12Shownphoto_GXI : context.PathToRelativeUrl( AV7ShownPhoto));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavShownphoto_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)1,(short)0,(String)"",(String)"",(short)0,(short)-1,(short)0,(String)"",(short)0,(String)"",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV7ShownPhoto_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)" gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Attribute/Variable Label */
         GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)edtavVariable_title_Internalname,(String)"Variable",(String)"gx-form-item K2BToolsAttribute_SmallerTitleLabel",(short)0,(bool)true,(String)"width: 25%;"});
         /* Single line edit */
         ROClassString = "K2BToolsAttribute_SmallerTitle";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavVariable_title_Internalname,StringUtil.RTrim( AV9Variable_Title),(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavVariable_title_Jsonclick,(short)0,(String)"K2BToolsAttribute_SmallerTitle",(String)"",(String)ROClassString,(String)"",(String)"",(short)1,(short)0,(short)0,(String)"text",(String)"",(short)20,(String)"chr",(short)1,(String)"row",(short)20,(short)0,(short)0,(short)9,(short)1,(short)-1,(short)-1,(bool)false,(String)"",(String)"left",(bool)true,(String)""});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)" gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Attribute/Variable Label */
         GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)edtavAction_remove_Internalname,(String)"Remove",(String)"gx-form-item AttributeLabel",(short)0,(bool)true,(String)"width: 25%;"});
         /* Single line edit */
         ROClassString = "Attribute";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavAction_remove_Internalname,StringUtil.RTrim( AV5Action_Remove),(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavAction_remove_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)1,(short)0,(short)0,(String)"text",(String)"",(short)20,(String)"chr",(short)1,(String)"row",(short)20,(short)0,(short)0,(short)9,(short)1,(short)-1,(short)-1,(bool)false,(String)"",(String)"left",(bool)true,(String)""});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         send_integrity_lvl_hashes0H2( ) ;
         /* End of Columns property logic. */
         GridContainer.AddRow(GridRow);
         nGXsfl_9_idx = ((subGrid_Islastpage==1)&&(nGXsfl_9_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         /* End function sendrow_92 */
      }

      protected void init_web_controls( )
      {
         chkavSelected_webpaneldesignertemplate.Name = "vSELECTED_WEBPANELDESIGNERTEMPLATE";
         chkavSelected_webpaneldesignertemplate.WebTags = "";
         chkavSelected_webpaneldesignertemplate.Caption = "";
         AssignProp("", false, chkavSelected_webpaneldesignertemplate_Internalname, "TitleCaption", chkavSelected_webpaneldesignertemplate.Caption, true);
         chkavSelected_webpaneldesignertemplate.CheckedValue = "false";
         AV6Selected_WebPanelDesignerTemplate = StringUtil.StrToBool( StringUtil.BoolToStr( AV6Selected_WebPanelDesignerTemplate));
         AssignAttri("", false, "AV6Selected_WebPanelDesignerTemplate", AV6Selected_WebPanelDesignerTemplate);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblInitialtextblock_Internalname = "INITIALTEXTBLOCK";
         edtavShownphoto_Internalname = "vSHOWNPHOTO";
         divPhotocontainer_Internalname = "PHOTOCONTAINER";
         divSection2_Internalname = "SECTION2";
         edtavVariable_title_Internalname = "vVARIABLE_TITLE";
         edtavAction_remove_Internalname = "vACTION_REMOVE";
         divSection1_Internalname = "SECTION1";
         divMigrate2_Internalname = "MIGRATE2";
         divUserregion_Internalname = "USERREGION";
         chkavSelected_webpaneldesignertemplate_Internalname = "vSELECTED_WEBPANELDESIGNERTEMPLATE";
         edtavVariable_photo_Internalname = "vVARIABLE_PHOTO";
         tblUnuseditemssection_Internalname = "UNUSEDITEMSSECTION";
         divMaintable_webpaneldesignertemplate_Internalname = "MAINTABLE_WEBPANELDESIGNERTEMPLATE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         chkavSelected_webpaneldesignertemplate.Caption = "WebPanelDesignerTemplate";
         edtavAction_remove_Jsonclick = "";
         edtavVariable_title_Jsonclick = "";
         divPhotocontainer_Visible = 1;
         lblInitialtextblock_Caption = "Text Block";
         subGrid_Class = "K2BT_SelectedItemsGrid";
         edtavVariable_photo_Jsonclick = "";
         edtavVariable_photo_Enabled = 1;
         chkavSelected_webpaneldesignertemplate.Enabled = 1;
         subGrid_Allowcollapsing = 0;
         lblInitialtextblock_Caption = "Text Block";
         subGrid_Backcolorstyle = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selected Item";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV9Variable_Title',fld:'vVARIABLE_TITLE',pic:''},{av:'AV8Variable_Photo',fld:'vVARIABLE_PHOTO',pic:''},{av:'AV6Selected_WebPanelDesignerTemplate',fld:'vSELECTED_WEBPANELDESIGNERTEMPLATE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV6Selected_WebPanelDesignerTemplate',fld:'vSELECTED_WEBPANELDESIGNERTEMPLATE',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Action_remove',iparms:[{av:'AV6Selected_WebPanelDesignerTemplate',fld:'vSELECTED_WEBPANELDESIGNERTEMPLATE',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV6Selected_WebPanelDesignerTemplate',fld:'vSELECTED_WEBPANELDESIGNERTEMPLATE',pic:''}]}");
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
         AV9Variable_Title = "";
         AV8Variable_Photo = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Header = "";
         GridColumn = new GXWebColumn();
         AV7ShownPhoto = "";
         AV5Action_Remove = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV12Shownphoto_GXI = "";
         GridRow = new GXWebRow();
         TempTags = "";
         ClassString = "";
         StyleString = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         lblInitialtextblock_Jsonclick = "";
         sImgUrl = "";
         ROClassString = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short GRID_nEOF ;
      private short subGrid_Backstyle ;
      private int nRC_GXsfl_9 ;
      private int nGXsfl_9_idx=1 ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int divPhotocontainer_Visible ;
      private int edtavVariable_photo_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private long GRID_nCurrentRecord ;
      private long GRID_nFirstRecordOnPage ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_9_idx="0001" ;
      private String AV9Variable_Title ;
      private String AV8Variable_Photo ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_webpaneldesignertemplate_Internalname ;
      private String divUserregion_Internalname ;
      private String sStyleString ;
      private String subGrid_Internalname ;
      private String subGrid_Header ;
      private String lblInitialtextblock_Caption ;
      private String AV5Action_Remove ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavShownphoto_Internalname ;
      private String edtavVariable_title_Internalname ;
      private String edtavAction_remove_Internalname ;
      private String chkavSelected_webpaneldesignertemplate_Internalname ;
      private String divPhotocontainer_Internalname ;
      private String tblUnuseditemssection_Internalname ;
      private String TempTags ;
      private String ClassString ;
      private String StyleString ;
      private String edtavVariable_photo_Internalname ;
      private String edtavVariable_photo_Jsonclick ;
      private String lblInitialtextblock_Internalname ;
      private String sGXsfl_9_fel_idx="0001" ;
      private String subGrid_Class ;
      private String subGrid_Linesclass ;
      private String divMigrate2_Internalname ;
      private String divSection1_Internalname ;
      private String divSection2_Internalname ;
      private String lblInitialtextblock_Jsonclick ;
      private String sImgUrl ;
      private String ROClassString ;
      private String edtavVariable_title_Jsonclick ;
      private String edtavAction_remove_Jsonclick ;
      private bool entryPointCalled ;
      private bool AV6Selected_WebPanelDesignerTemplate ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_9_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV7ShownPhoto_IsBlob ;
      private String AV12Shownphoto_GXI ;
      private String AV7ShownPhoto ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavSelected_webpaneldesignertemplate ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

}
