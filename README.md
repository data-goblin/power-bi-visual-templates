# Tabular Editor Report Scripts

![C#](https://img.shields.io/badge/C%23-Script-239120?logo=csharp&logoColor=white)
![Tabular Editor](https://img.shields.io/badge/Tabular%20Editor-3.x-blue)
![Power BI](https://img.shields.io/badge/Power%20BI-PBIR-F2C811?logo=powerbi&logoColor=black)
![License](https://img.shields.io/badge/license-MIT-green)

Collection of Tabular Editor C# scripts for automating Power BI report visual templates. These scripts work with PBIR (Power BI enhanced report format) files and can inject pre-configured visual templates into local Power BI Desktop projects (.PBIP).

## Instructions:

### Script

1. Run the script (.csx) in Tabular Editor 3 when connected to the model that you want to use.
2. Find and select the .pbip for the Power BI report that you want to modify.
3. Choose the fields that you want to use. Note that the script may add necessary supporting fields to your model.
4. Save your changes in Tabular Editor.
5. Close and re-open the .pbip for the report to view the changes.

**NOTE:** For a "thick report" with a local model that you would open in Power BI Desktop, you should apply the changes to the model metadata (model.bim or .tmdl). If you make changes when connected to the model open in Power BI Desktop (i.e. as an external tool) then saving in Power BI Desktop will overwrite the changes you made to the report. Currently, changes to report metadata are not rendered live in Power BI Desktop reports.

### visual.json

1. Copy the visual-template.json into the appropriate page folder of your PBIP in the PBIR definition.
2. In Power BI Desktop or in the JSON itself, replace the placeholder fields and IDs with your actual model field names and. IDs that you want to use.

## Disclaimers:
- **AI tool use:** The files and scripts in this repository were made with the help of claude code.
- *Scripts are provided as-is without warranties or guarantees of any kind. Test thoroughly in non-production environments before use.*