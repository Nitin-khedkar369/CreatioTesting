define("TranslationStatusPage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "MainHeader",
				"values": {
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"visible": true,
					"borderRadius": "none",
					"gap": "small"
				}
			},
			{
				"operation": "move",
				"name": "MainHeader",
				"parentName": "GridContainer_4q0zww4",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "merge",
				"name": "PageTitle",
				"values": {
					"caption": "#MacrosTemplateString(#ResourceString(PageTitle_caption)#)#",
					"visible": true,
					"headingLevel": "label"
				}
			},
			{
				"operation": "remove",
				"name": "AddButton"
			},
			{
				"operation": "remove",
				"name": "DataImportButton"
			},
			{
				"operation": "remove",
				"name": "MenuItem_ImportFromExcel"
			},
			{
				"operation": "remove",
				"name": "OpenLandingDesigner"
			},
			{
				"operation": "remove",
				"name": "MainContainer",
				"properties": [
					"stretch"
				]
			},
			{
				"operation": "merge",
				"name": "MainContainer",
				"values": {
					"fitContent": true,
					"color": "transparent",
					"visible": true,
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"wrap": "nowrap"
				}
			},
			{
				"operation": "move",
				"name": "MainFilterContainer",
				"parentName": "GridContainer_4q0zww4",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "merge",
				"name": "MainFilterContainer",
				"values": {
					"visible": true,
					"alignItems": "stretch",
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 1,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "merge",
				"name": "LeftFilterContainer",
				"values": {
					"alignItems": "center",
					"visible": true
				}
			},
			{
				"operation": "remove",
				"name": "FolderTreeActions"
			},
			{
				"operation": "remove",
				"name": "LookupQuickFilterByTag"
			},
			{
				"operation": "merge",
				"name": "RightFilterContainer",
				"values": {
					"alignItems": "center",
					"visible": true
				}
			},
			{
				"operation": "merge",
				"name": "ContentContainer",
				"values": {
					"gap": "small",
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "small",
						"right": "small",
						"bottom": "small",
						"left": "small"
					},
					"alignItems": "stretch",
					"justifyContent": "start"
				}
			},
			{
				"operation": "remove",
				"name": "ContentContainer",
				"properties": [
					"stretch"
				]
			},
			{
				"operation": "remove",
				"name": "FolderTree"
			},
			{
				"operation": "remove",
				"name": "SectionContentWrapper",
				"properties": [
					"stretch"
				]
			},
			{
				"operation": "merge",
				"name": "SectionContentWrapper",
				"values": {
					"visible": true,
					"borderRadius": "medium",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap"
				}
			},
			{
				"operation": "merge",
				"name": "DataTable",
				"values": {
					"columns": [
						{
							"id": "08abf836-5701-4ae7-31bb-b2f9f9f94558",
							"code": "PDS_TranslationKey",
							"caption": "#ResourceString(PDS_TranslationKey)#",
							"dataValueType": 28
						},
						{
							"id": "5d491eec-5875-6a3f-9395-388133b44e8f",
							"code": "PDS_SysCulture",
							"caption": "#ResourceString(PDS_SysCulture)#",
							"dataValueType": 10
						},
						{
							"id": "eac0a8b4-ad43-fcdc-17b2-a6b8604e1fa1",
							"code": "PDS_ExpectedLocalizationValue",
							"caption": "#ResourceString(PDS_ExpectedLocalizationValue)#",
							"dataValueType": 29
						},
						{
							"id": "eb71d3f8-ed18-b984-e28c-f48f4baad886",
							"code": "PDS_ActualLocalizationValue",
							"caption": "#ResourceString(PDS_ActualLocalizationValue)#",
							"dataValueType": 29
						},
						{
							"id": "66f8aaa2-f09c-9a15-c2d0-ca50e53de90c",
							"code": "PDS_StaticContentValue",
							"caption": "#ResourceString(PDS_StaticContentValue)#",
							"dataValueType": 29
						}
					],
					"placeholder": false,
					"features": {
						"rows": {
							"selection": {
								"enable": true,
								"multiple": true
							}
						},
						"editable": {
							"enable": false,
							"itemsCreation": false,
							"floatingEditPanel": false
						}
					},
					"selectionState": "$DataTable_SelectionState",
					"_selectionOptions": {
						"attribute": "DataTable_SelectionState"
					},
					"bulkActions": [],
					"visible": true,
					"fitContent": true
				}
			},
			{
				"operation": "remove",
				"name": "DataTable",
				"properties": [
					"layoutConfig"
				]
			},
			{
				"operation": "insert",
				"name": "GridContainer_4q0zww4",
				"values": {
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "primary",
					"borderRadius": "none",
					"padding": {
						"top": "large",
						"right": "large",
						"bottom": "small",
						"left": "large"
					},
					"alignItems": "stretch"
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Button_Back",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(Button_Back_caption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-icon",
					"visible": true,
					"icon": "back-button-icon",
					"clicked": {
						"request": "crt.ClosePageRequest"
					},
					"clickMode": "default"
				},
				"parentName": "TitleContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "MenuItem_OpenTranslationSection",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(MenuItem_OpenTranslationSection_caption)#",
					"visible": true,
					"clicked": {
						"request": "crt.OpenPageRequest",
						"params": {
							"schemaName": "TranslationSection"
						}
					},
					"icon": "translate-icon"
				},
				"parentName": "ActionButton",
				"propertyName": "menuItems",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "QuickFilter_yt46o13",
				"values": {
					"type": "crt.QuickFilter",
					"config": {
						"caption": "#ResourceString(QuickFilter_yt46o13_config_caption)#",
						"hint": "",
						"icon": "filter-column-icon",
						"iconPosition": "left-icon",
						"defaultValue": [],
						"entitySchemaName": "SysCulture",
						"recordsFilter": null
					},
					"_filterOptions": {
						"expose": [
							{
								"attribute": "QuickFilter_yt46o13_Items",
								"converters": [
									{
										"converter": "crt.QuickFilterAttributeConverter",
										"args": [
											{
												"target": {
													"viewAttributeName": "Items",
													"filterColumn": "SysCulture"
												},
												"quickFilterType": "lookup"
											}
										]
									}
								]
							}
						],
						"from": "QuickFilter_yt46o13_Value"
					},
					"filterType": "lookup",
					"visible": true
				},
				"parentName": "LeftFilterContainerInner",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ButtonToggleGroup_ywwttqy",
				"values": {
					"for": "TabPanelHelp",
					"fitContent": true,
					"toggleViewMode": "button",
					"type": "crt.ButtonToggleGroup"
				},
				"parentName": "RightFilterContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "DataTable_AddTagsBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "Add tag",
					"icon": "tag-icon",
					"clicked": {
						"request": "crt.AddTagsInRecordsRequest",
						"params": {
							"dataSourceName": "PDS",
							"filters": "$Items | crt.ToCollectionFilters : 'Items' : $DataTable_SelectionState | crt.SkipIfSelectionEmpty : $DataTable_SelectionState"
						}
					},
					"items": []
				},
				"parentName": "DataTable",
				"propertyName": "bulkActions",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DataTable_ExportToExcelBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "Export to Excel",
					"icon": "export-button-icon",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "DataTable",
							"filters": "$Items | crt.ToCollectionFilters : 'Items' : $DataTable_SelectionState | crt.SkipIfSelectionEmpty : $DataTable_SelectionState"
						}
					}
				},
				"parentName": "DataTable",
				"propertyName": "bulkActions",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "TabPanelHelp",
				"values": {
					"type": "crt.TabPanel",
					"items": [],
					"mode": "toggle",
					"fitContent": true,
					"styleType": "default",
					"bodyBackgroundColor": "primary-contrast-500",
					"selectedTabTitleColor": "auto",
					"tabTitleColor": "auto",
					"underlineSelectedTabColor": "auto",
					"headerBackgroundColor": "auto",
					"layoutConfig": {
						"width": 368
					},
					"stretch": true,
					"selectedTab": null
				},
				"parentName": "ContentContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "HelpTabPanel",
				"values": {
					"type": "crt.TabContainer",
					"tools": [],
					"items": [],
					"caption": "#ResourceString(HelpTabPanel_caption)#",
					"iconPosition": "left-icon",
					"visible": true,
					"icon": "book-open-icon",
					"layoutConfig": {
						"width": 368
					}
				},
				"parentName": "TabPanelHelp",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "TabTopFlexContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"alignItems": "center",
					"items": []
				},
				"parentName": "HelpTabPanel",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "TabTitleLabel",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(TabTitleLabel_caption)#)#",
					"labelType": "headline-3",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#0D2E4E",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true,
					"headingLevel": "label"
				},
				"parentName": "TabTopFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpContentFlexContainer",
				"values": {
					"type": "crt.FlexContainer",
					"items": [],
					"direction": "column",
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "extra-small",
					"wrap": "nowrap"
				},
				"parentName": "HelpTabPanel",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_Paragraph_1",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_Paragraph_1_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "HelpContentFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_KeyColumnDescription",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_KeyColumnDescription_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "HelpContentFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Label_CultureColumnDescription",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_CultureColumnDescription_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "HelpContentFlexContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Label_ExpectedValueDescription",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_ExpectedValueDescription_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "HelpContentFlexContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "Label_ActualValueDescription",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_ActualValueDescription_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "HelpContentFlexContainer",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "Label_StaticContentValueDescription",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_StaticContentValueDescription_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "HelpContentFlexContainer",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "FlexContainer_Resolutions",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "medium",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "extra-small",
					"wrap": "nowrap"
				},
				"parentName": "HelpContentFlexContainer",
				"propertyName": "items",
				"index": 6
			},
			{
				"operation": "insert",
				"name": "Label_ResolutionsContainerTitle",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_ResolutionsContainerTitle_caption)#)#",
					"labelType": "body-large",
					"labelThickness": "semibold",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "FlexContainer_Resolutions",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_ErrorHintTitle",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_ErrorHintTitle_caption)#)#",
					"labelType": "body",
					"labelThickness": "semibold",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "FlexContainer_Resolutions",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FlexContainer_4ukor13",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "small"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "extra-small",
					"wrap": "nowrap"
				},
				"parentName": "FlexContainer_Resolutions",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Label_rwqe5bc",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_rwqe5bc_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "FlexContainer_4ukor13",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_ErrorsHint",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_ErrorsHint_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "FlexContainer_4ukor13",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Label_ApplyChangesHintTitle",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_ApplyChangesHintTitle_caption)#)#",
					"labelType": "body",
					"labelThickness": "semibold",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "FlexContainer_Resolutions",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "FlexContainer_BusinessProcessHint",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "small"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "extra-small",
					"wrap": "nowrap"
				},
				"parentName": "FlexContainer_Resolutions",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "Label_BusinessProcessBullet",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_BusinessProcessBullet_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "FlexContainer_BusinessProcessHint",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_BusinessProcessHint",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_BusinessProcessHint_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "FlexContainer_BusinessProcessHint",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FlexContainer_StaticContentHint",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "small"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "extra-small",
					"wrap": "nowrap"
				},
				"parentName": "FlexContainer_Resolutions",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "Label_StaticContentBullet",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_StaticContentBullet_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "FlexContainer_StaticContentHint",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_StaticContentHint",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_StaticContentHint_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "FlexContainer_StaticContentHint",
				"propertyName": "items",
				"index": 1
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"attributes"
				],
				"values": {
					"Items_PredefinedFilter": {
						"value": null
					}
				}
			},
			{
				"operation": "merge",
				"path": [
					"attributes",
					"Items",
					"viewModelConfig",
					"attributes"
				],
				"values": {
					"PDS_TranslationKey": {
						"modelConfig": {
							"path": "PDS.TranslationKey"
						}
					},
					"PDS_SysCulture": {
						"modelConfig": {
							"path": "PDS.SysCulture"
						}
					},
					"PDS_ExpectedLocalizationValue": {
						"modelConfig": {
							"path": "PDS.ExpectedLocalizationValue"
						}
					},
					"PDS_ActualLocalizationValue": {
						"modelConfig": {
							"path": "PDS.ActualLocalizationValue"
						}
					},
					"PDS_StaticContentValue": {
						"modelConfig": {
							"path": "PDS.StaticContentValue"
						}
					}
				}
			},
			{
				"operation": "merge",
				"path": [
					"attributes",
					"Items",
					"modelConfig"
				],
				"values": {
					"filterAttributes": [
						{
							"name": "SearchFilter_Items",
							"loadOnChange": true
						},
						{
							"loadOnChange": true,
							"name": "Items_PredefinedFilter"
						},
						{
							"name": "QuickFilter_yt46o13_Items",
							"loadOnChange": true
						}
					]
				}
			},
			{
				"operation": "merge",
				"path": [
					"attributes",
					"Items",
					"modelConfig",
					"sortingConfig"
				],
				"values": {
					"default": [
						{
							"direction": "asc",
							"columnName": "ExpectedLocalizationValue"
						}
					]
				}
			},
			{
				"operation": "merge",
				"path": [
					"attributes",
					"FolderTree_visible"
				],
				"values": {
					"modelConfig": {}
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"dataSources",
					"PDS",
					"config"
				],
				"values": {
					"entitySchemaName": "TranslationStatus",
					"attributes": {
						"TranslationKey": {
							"path": "TranslationKey"
						},
						"SysCulture": {
							"path": "SysCulture"
						},
						"ExpectedLocalizationValue": {
							"path": "ExpectedLocalizationValue"
						},
						"ActualLocalizationValue": {
							"path": "ActualLocalizationValue"
						},
						"StaticContentValue": {
							"path": "StaticContentValue"
						}
					}
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});