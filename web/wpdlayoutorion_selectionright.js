gx.evt.autoSkip=!1;gx.define("wpdlayoutorion_selectionright",!1,function(){var n,i,t;this.ServerClass="wpdlayoutorion_selectionright";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e17151_client=function(){return this.clearMessages(),gx.fn.getCtrlProperty("DOWNLOADACTIONSTABLE","Visible")==!1?gx.fn.setCtrlProperty("DOWNLOADACTIONSTABLE","Visible",!0):gx.fn.setCtrlProperty("DOWNLOADACTIONSTABLE","Visible",!1),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("DOWNLOADACTIONSTABLE","Visible")',ctrl:"DOWNLOADACTIONSTABLE",prop:"Visible"}]),gx.$.Deferred().resolve()};this.e11152_client=function(){return this.executeServerEvent("FILTERTOGGLE_COMBINED.CLICK",!0,null,!1,!0)};this.e12152_client=function(){return this.executeServerEvent("FILTERCLOSE_COMBINED.CLICK",!0,null,!1,!0)};this.e13152_client=function(){return this.executeServerEvent("FILTERTOGGLE_ONLYDETAILED.CLICK",!0,null,!1,!0)};this.e14152_client=function(){return this.executeServerEvent("FILTERCLOSE_ONLYDETAILED.CLICK",!0,null,!1,!0)};this.e18152_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e19152_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,41,43,45,46,47,48,49,50,51,52,53,54,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,77,78,79,80,81,82,83,84,85,86,87,88,89,90,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,115,116,117,119,120,121,122,125,126,127,128,129,130,133,134,135,138,139,140,141,142,143,144,145,146,147,148,149,150,151,152,153,154,155,156,157,158,159,160,161,162,163,164,165,166];this.GXLastCtrlId=166;this.GridcontentContainer=new gx.grid.grid(this,2,"WbpLvl2",118,"Gridcontent","Gridcontent","GridcontentContainer",this.CmpContext,this.IsMasterPage,"wpdlayoutorion_selectionright",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","New row",!1,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridcontentContainer;this.GridcontentContainer.emptyText="";this.setGrid(i);this.K2BCONTROLBEAUTIFY1Container=gx.uc.getNew(this,167,67,"K2BControlBeautify","K2BCONTROLBEAUTIFY1Container","K2bcontrolbeautify1","K2BCONTROLBEAUTIFY1");t=this.K2BCONTROLBEAUTIFY1Container;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("UpdateCheckboxes","Updatecheckboxes",!0,"bool");t.setProp("UpdateSelects","Updateselects",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLE1",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"CONTENTTABLE",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"GLOBALGRIDTABLE",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"TABLE2",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"LEFTACTIONS",format:0,grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"TOPACTIONS",format:0,grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"TABLE6",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"GRID_INNER",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"TABLE10",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"TABLE7",grid:0};n[41]={id:41,fld:"GRIDSETTINGSCONTAINER",format:0,grid:0};n[43]={id:43,fld:"RUNTIMECOLUMNMANAGEMENT",format:0,grid:0};n[45]={id:45,fld:"DOWNLOADSACTIONSSECTIONCONTAINER",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"DOWNLOADSACTIONTOGGLE",grid:0,evt:"e17151_client"};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"DOWNLOADACTIONSTABLE",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"DOWNLOADSACTIONSSECTION",format:0,grid:0};n[56]={id:56,fld:"RIGHTACTIONS",format:0,grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"FILTERGLOBALCONTAINER",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"COMBINEDFILTERLAYOUT",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"SECTION4",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vK2BTOOLSGENERICSEARCHFIELD",gxz:"ZV5K2BToolsGenericSearchField",gxold:"OV5K2BToolsGenericSearchField",gxvar:"AV5K2BToolsGenericSearchField",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5K2BToolsGenericSearchField=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5K2BToolsGenericSearchField=n)},v2c:function(){gx.fn.setControlValue("vK2BTOOLSGENERICSEARCHFIELD",gx.O.AV5K2BToolsGenericSearchField,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV5K2BToolsGenericSearchField=this.val())},val:function(){return gx.fn.getControlValue("vK2BTOOLSGENERICSEARCHFIELD")},nac:gx.falseFn};n[68]={id:68,fld:"FILTERTOGGLE_COMBINED",grid:0,evt:"e11152_client"};n[69]={id:69,fld:"FILTERSUMMARY_COMBINED",format:0,grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"FILTERCOLLAPSIBLESECTION_COMBINED",grid:0};n[73]={id:73,fld:"FILTERCLOSE_COMBINED",grid:0,evt:"e12152_client"};n[74]={id:74,fld:"FILTERSCONTAINER_COMBINED",grid:0};n[77]={id:77,fld:"FILTERS",format:0,grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"ONLYDETAILEDFILTERLAYOUT",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"SECTION5",grid:0};n[84]={id:84,fld:"FILTERTOGGLE_ONLYDETAILED",grid:0,evt:"e13152_client"};n[85]={id:85,fld:"FILTERSUMMARY_ONLYDETAILED",format:0,grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"",grid:0};n[88]={id:88,fld:"FILTERCOLLAPSIBLESECTION_ONLYDETAILED",grid:0};n[89]={id:89,fld:"FILTERCLOSE_ONLYDETAILED",grid:0,evt:"e14152_client"};n[90]={id:90,fld:"FILTERSCONTAINER_ONLYDETAILED",grid:0};n[93]={id:93,fld:"TEXTBLOCK4",format:0,grid:0};n[94]={id:94,fld:"",grid:0};n[95]={id:95,fld:"",grid:0};n[96]={id:96,fld:"ONLYGENERICFILTERLAYOUT",grid:0};n[97]={id:97,fld:"",grid:0};n[98]={id:98,fld:"",grid:0};n[99]={id:99,fld:"SECTION6",grid:0};n[100]={id:100,fld:"",grid:0};n[101]={id:101,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vK2BTOOLSGENERICSEARCHFIELD",gxz:"ZV5K2BToolsGenericSearchField",gxold:"OV5K2BToolsGenericSearchField",gxvar:"AV5K2BToolsGenericSearchField",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5K2BToolsGenericSearchField=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5K2BToolsGenericSearchField=n)},v2c:function(){gx.fn.setControlValue("vK2BTOOLSGENERICSEARCHFIELD",gx.O.AV5K2BToolsGenericSearchField,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV5K2BToolsGenericSearchField=this.val())},val:function(){return gx.fn.getControlValue("vK2BTOOLSGENERICSEARCHFIELD")},nac:gx.falseFn};n[102]={id:102,fld:"",grid:0};n[103]={id:103,fld:"",grid:0};n[104]={id:104,fld:"TABLE3",grid:0};n[105]={id:105,fld:"",grid:0};n[106]={id:106,fld:"",grid:0};n[107]={id:107,fld:"TABLE5",grid:0};n[108]={id:108,fld:"",grid:0};n[109]={id:109,fld:"",grid:0};n[110]={id:110,fld:"GRIDACTIONSLEFT",format:0,grid:0};n[111]={id:111,fld:"",grid:0};n[112]={id:112,fld:"TABLE11",grid:0};n[115]={id:115,fld:"GRIDACTIONSRIGHT",format:0,grid:0};n[116]={id:116,fld:"",grid:0};n[117]={id:117,fld:"",grid:0};n[119]={id:119,fld:"",grid:0};n[120]={id:120,fld:"",grid:0};n[121]={id:121,fld:"",grid:0};n[122]={id:122,fld:"SUMMARYCONTAINER",grid:0};n[125]={id:125,fld:"TEXTBLOCK2",format:0,grid:0};n[126]={id:126,fld:"",grid:0};n[127]={id:127,fld:"",grid:0};n[128]={id:128,fld:"GRIDRECORDCOUNT",format:0,grid:0};n[129]={id:129,fld:"",grid:0};n[130]={id:130,fld:"ORDERBYCONTAINER",grid:0};n[133]={id:133,fld:"ORDERBY",format:0,grid:0};n[134]={id:134,fld:"",grid:0};n[135]={id:135,fld:"PAGINGCONTAINER",grid:0};n[138]={id:138,fld:"TEXTBLOCK1",format:0,grid:0};n[139]={id:139,fld:"",grid:0};n[140]={id:140,fld:"",grid:0};n[141]={id:141,fld:"BOTTOMACTIONS",format:0,grid:0};n[142]={id:142,fld:"",grid:0};n[143]={id:143,fld:"TABLE4",grid:0};n[144]={id:144,fld:"",grid:0};n[145]={id:145,fld:"",grid:0};n[146]={id:146,fld:"SELECTIONSUMMARYSELECTEDITEMSTEXTBLOCK",format:0,grid:0};n[147]={id:147,fld:"",grid:0};n[148]={id:148,fld:"",grid:0};n[149]={id:149,fld:"SELECTIONSUMMARY",format:0,grid:0};n[150]={id:150,fld:"",grid:0};n[151]={id:151,fld:"",grid:0};n[152]={id:152,fld:"SELECTIONSUMMARYNOITEMSTABLE",grid:0};n[153]={id:153,fld:"",grid:0};n[154]={id:154,fld:"",grid:0};n[155]={id:155,fld:"IMAGE1",grid:0};n[156]={id:156,fld:"",grid:0};n[157]={id:157,fld:"",grid:0};n[158]={id:158,fld:"SELECTIONSUMMARYNOITEMSTEXTBLOCK",format:0,grid:0};n[159]={id:159,fld:"",grid:0};n[160]={id:160,fld:"",grid:0};n[161]={id:161,fld:"HIDDENITEMS",format:0,grid:0};n[162]={id:162,fld:"",grid:0};n[163]={id:163,fld:"",grid:0};n[164]={id:164,fld:"CONDITIONALCONFIRM",format:0,grid:0};n[165]={id:165,fld:"",grid:0};n[166]={id:166,fld:"",grid:0};this.AV5K2BToolsGenericSearchField="";this.ZV5K2BToolsGenericSearchField="";this.OV5K2BToolsGenericSearchField="";this.AV5K2BToolsGenericSearchField="";this.Events={e11152_client:["FILTERTOGGLE_COMBINED.CLICK",!0],e12152_client:["FILTERCLOSE_COMBINED.CLICK",!0],e13152_client:["FILTERTOGGLE_ONLYDETAILED.CLICK",!0],e14152_client:["FILTERCLOSE_ONLYDETAILED.CLICK",!0],e18152_client:["ENTER",!0],e19152_client:["CANCEL",!0],e17151_client:["DOWNLOADSACTIONTOGGLE.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRIDCONTENT_nFirstRecordOnPage"},{av:"GRIDCONTENT_nEOF"}],[]];this.EvtParms.START=[[],[{av:'gx.fn.getCtrlProperty("FILTERCOLLAPSIBLESECTION_COMBINED","Visible")',ctrl:"FILTERCOLLAPSIBLESECTION_COMBINED",prop:"Visible"},{av:'gx.fn.getCtrlProperty("FILTERCOLLAPSIBLESECTION_ONLYDETAILED","Visible")',ctrl:"FILTERCOLLAPSIBLESECTION_ONLYDETAILED",prop:"Visible"},{av:'gx.fn.getCtrlProperty("DOWNLOADACTIONSTABLE","Visible")',ctrl:"DOWNLOADACTIONSTABLE",prop:"Visible"}]];this.EvtParms["FILTERTOGGLE_COMBINED.CLICK"]=[[{av:'gx.fn.getCtrlProperty("FILTERCOLLAPSIBLESECTION_COMBINED","Visible")',ctrl:"FILTERCOLLAPSIBLESECTION_COMBINED",prop:"Visible"}],[{av:'gx.fn.getCtrlProperty("FILTERCOLLAPSIBLESECTION_COMBINED","Visible")',ctrl:"FILTERCOLLAPSIBLESECTION_COMBINED",prop:"Visible"}]];this.EvtParms["FILTERCLOSE_COMBINED.CLICK"]=[[],[{av:'gx.fn.getCtrlProperty("FILTERCOLLAPSIBLESECTION_COMBINED","Visible")',ctrl:"FILTERCOLLAPSIBLESECTION_COMBINED",prop:"Visible"}]];this.EvtParms["FILTERTOGGLE_ONLYDETAILED.CLICK"]=[[{av:'gx.fn.getCtrlProperty("FILTERCOLLAPSIBLESECTION_ONLYDETAILED","Visible")',ctrl:"FILTERCOLLAPSIBLESECTION_ONLYDETAILED",prop:"Visible"}],[{av:'gx.fn.getCtrlProperty("FILTERCOLLAPSIBLESECTION_ONLYDETAILED","Visible")',ctrl:"FILTERCOLLAPSIBLESECTION_ONLYDETAILED",prop:"Visible"}]];this.EvtParms["FILTERCLOSE_ONLYDETAILED.CLICK"]=[[],[{av:'gx.fn.getCtrlProperty("FILTERCOLLAPSIBLESECTION_ONLYDETAILED","Visible")',ctrl:"FILTERCOLLAPSIBLESECTION_ONLYDETAILED",prop:"Visible"}]];this.EvtParms["DOWNLOADSACTIONTOGGLE.CLICK"]=[[{av:'gx.fn.getCtrlProperty("DOWNLOADACTIONSTABLE","Visible")',ctrl:"DOWNLOADACTIONSTABLE",prop:"Visible"}],[{av:'gx.fn.getCtrlProperty("DOWNLOADACTIONSTABLE","Visible")',ctrl:"DOWNLOADACTIONSTABLE",prop:"Visible"}]];this.Initialize()});gx.wi(function(){gx.createParentObj(wpdlayoutorion_selectionright)})