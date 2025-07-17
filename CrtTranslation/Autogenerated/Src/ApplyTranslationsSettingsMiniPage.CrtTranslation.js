define("ApplyTranslationsSettingsMiniPage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "PageTitle",
				"values": {
					"caption": "#MacrosTemplateString(#ResourceString(PageTitle_caption)#)#",
					"visible": true
				}
			},
			{
				"operation": "merge",
				"name": "ContinueInOtherPageButton",
				"values": {
					"clicked": {},
					"color": "default",
					"clickMode": "default"
				}
			},
			{
				"operation": "merge",
				"name": "CloseButton",
				"values": {
					"clicked": {},
					"caption": "#ResourceString(CloseButton_caption)#"
				}
			},
			{
				"operation": "merge",
				"name": "MainContainer",
				"values": {
					"gap": {
						"columnGap": "large",
						"rowGap": "extra-small"
					},
					"alignItems": "stretch"
				}
			},
			{
				"operation": "merge",
				"name": "CancelButton",
				"values": {
					"clicked": {},
					"caption": "#ResourceString(CancelButton_caption)#",
					"color": "default",
					"size": "large",
					"iconPosition": "only-text",
					"clickMode": "default"
				}
			},
			{
				"operation": "merge",
				"name": "SaveButton",
				"values": {
					"clicked": {},
					"caption": "#ResourceString(SaveButton_caption)#"
				}
			},
			{
				"operation": "insert",
				"name": "WindowDescriptionLabel",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(WindowDescriptionLabel_caption)#)#",
					"labelType": "body",
					"labelThickness": "normal",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ApplySpecificLanguageCheckbox",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Checkbox",
					"label": "$Resources.Strings.PageParameters_BooleanParameter1_1a69gvr",
					"labelPosition": "right",
					"control": "$PageParameters_BooleanParameter1_1a69gvr",
					"visible": true,
					"readonly": false,
					"placeholder": "",
					"tooltip": "#ResourceString(ApplySpecificLanguageCheckbox_tooltip)#"
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "LanguageComboBox",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 3,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.PageParameters_LookupParameter1_dojrswl",
					"labelPosition": "above",
					"control": "$PageParameters_LookupParameter1_dojrswl",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": [],
					"visible": false,
					"readonly": false,
					"placeholder": "",
					"tooltip": "",
					"isSimpleLookup": null,
					"valueDetails": null,
					"secondaryDisplayValue": null,
					"mode": "List"
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ListAction_4rngtym",
				"values": {
					"code": "addRecord",
					"type": "crt.ComboboxSearchTextAction",
					"icon": "combobox-add-new",
					"caption": "ComboBox.AddNewRecord",
					"clicked": {
						"request": "crt.CreateRecordFromLookupRequest",
						"params": {}
					}
				},
				"parentName": "LanguageComboBox",
				"propertyName": "listActions",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ApplyAllTranslationsForcedlyCheckbox",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 4,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Checkbox",
					"label": "$Resources.Strings.PageParameters_BooleanParameter1_ydqnq2i",
					"labelPosition": "right",
					"control": "$PageParameters_BooleanParameter1_ydqnq2i",
					"visible": false,
					"readonly": false,
					"placeholder": "",
					"tooltip": "#ResourceString(ApplyAllTranslationsForcedlyCheckbox_tooltip)#"
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 3
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"attributes"
				],
				"values": {
					"PageParameters_BooleanParameter1_1a69gvr": {
						"modelConfig": {
							"path": "PageParameters.UseSpecifiedLanguageOnly"
						}
					},
					"PageParameters_LookupParameter1_dojrswl": {
						"modelConfig": {
							"path": "PageParameters.Language"
						}
					},
					"PageParameters_BooleanParameter1_ydqnq2i": {
						"modelConfig": {
							"path": "PageParameters.ApplyAllTranslationsForcedly"
						}
					}
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [],
				"values": {
					"dataSources": {}
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[{
				request: "crt.LoadDataRequest",
				handler: async (request, next) => {
					var languageDataSourceName = "PageParameters_LookupParameter1_dojrswl_List_DS";
					if(request.dataSourceName !== languageDataSourceName) {
						return await next?.handle(request);
					}
					request.parameters.push({
						type: "filter",
						value: {
							"items": {
								"8533d26b-cedc-4a3f-b701-c58775182a8d": {
									"filterType": 2,
									"comparisonType": 2,
									"isEnabled": true,
									"isNull": false,
									"trimDateTimeParameterToDate": false,
									"leftExpression": {
										"expressionType": 0,
										"columnPath": "[SysCulture:Language].Id"
									},
									"isAggregative": false,
									"dataValueType": 1
								}
							},
							"logicalOperation": 0,
							"isEnabled": true,
							"filterType": 6,
							"rootSchemaName": "SysLanguage"
						}
					});
					return await next?.handle(request);
				}
			},]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});