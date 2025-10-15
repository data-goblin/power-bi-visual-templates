#r "System.Windows.Forms"
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

// ===== VISUAL TEMPLATE: MONTH BUTTON SLICER =====
const string TEMPLATE_PAGE_NAME = "Month Button Slicer";
const string FORMAT_TABLE_NAME = "___K201";

// Page template
const string PAGE_TEMPLATE = @"{
  ""$schema"": ""https://developer.microsoft.com/json-schemas/fabric/item/report/definition/page/2.0.0/schema.json"",
  ""name"": ""PLACEHOLDER_PAGE_ID"",
  ""displayName"": ""Month Button Slicer"",
  ""displayOption"": ""FitToPage"",
  ""height"": 720,
  ""width"": 1280
}";

// Visual template (button slicer with dynamic field replacement)
const string VISUAL_TEMPLATE = @"{
  ""$schema"": ""https://developer.microsoft.com/json-schemas/fabric/item/report/definition/visualContainer/2.2.0/schema.json"",
  ""name"": ""PLACEHOLDER_VISUAL_ID"",
  ""position"": {""x"": 226.75390035228989, ""y"": 266.69350780070459, ""z"": 0, ""height"": 66.995470558631112, ""width"": 806.52239557121288},
  ""visual"": {
    ""visualType"": ""advancedSlicerVisual"",
    ""query"": {""queryState"": {""Values"": {""projections"": [
      {""field"": {""Column"": {""Expression"": {""SourceRef"": {""Entity"": ""PLACEHOLDER_TABLE""}}, ""Property"": ""PLACEHOLDER_COLUMN""}},
       ""queryRef"": ""PLACEHOLDER_TABLE.PLACEHOLDER_COLUMN"", ""nativeQueryRef"": ""PLACEHOLDER_COLUMN""}
    ]}}},
    ""objects"": {
      ""layout"": [{""properties"": {""rowCount"": {""expr"": {""Literal"": {""Value"": ""1L""}}}, ""columnCount"": {""expr"": {""Literal"": {""Value"": ""12L""}}}}}],
      ""shapeCustomRectangle"": [{""properties"": {""tileShape"": {""expr"": {""Literal"": {""Value"": ""'rectangleRoundedByPixel'""}}}, ""rectangleRoundedCurve"": {""expr"": {""Literal"": {""Value"": ""6L""}}}}, ""selector"": {""id"": ""default""}}],
      ""fillCustom"": [
        {""properties"": {""transparency"": {""expr"": {""Literal"": {""Value"": ""50D""}}}}, ""selector"": {""id"": ""default""}},
        {""properties"": {}, ""selector"": {""data"": [{""dataViewWildcard"": {""matchingOption"": 1}}], ""id"": ""default"", ""hierarchyMatching"": 1}},
        {""properties"": {""fillColor"": {""solid"": {""color"": {""expr"": {""Measure"": {""Expression"": {""SourceRef"": {""Entity"": ""___K201""}}, ""Property"": ""Format Color""}}}}}}, ""selector"": {""data"": [{""dataViewWildcard"": {""matchingOption"": 1}}], ""id"": ""selection:selected"", ""hierarchyMatching"": 1}},
        {""properties"": {""transparency"": {""expr"": {""Literal"": {""Value"": ""75D""}}}}, ""selector"": {""id"": ""selection:selected""}}
      ],
      ""outline"": [{""properties"": {""show"": {""expr"": {""Literal"": {""Value"": ""false""}}}}, ""selector"": {""id"": ""default""}}],
      ""value"": [
        {""properties"": {""bold"": {""expr"": {""Literal"": {""Value"": ""true""}}}}, ""selector"": {""id"": ""selection:selected""}},
        {""properties"": {""fontColor"": {""solid"": {""color"": {""expr"": {""Measure"": {""Expression"": {""SourceRef"": {""Entity"": ""___K201""}}, ""Property"": ""Format Color""}}}}}}, ""selector"": {""data"": [{""dataViewWildcard"": {""matchingOption"": 1}}], ""id"": ""default"", ""hierarchyMatching"": 1}},
        {""properties"": {""fontColor"": {""solid"": {""color"": {""expr"": {""Measure"": {""Expression"": {""SourceRef"": {""Entity"": ""___K201""}}, ""Property"": ""Format Color""}}}}}}, ""selector"": {""data"": [{""dataViewWildcard"": {""matchingOption"": 1}}], ""id"": ""selection:selected"", ""hierarchyMatching"": 1}}
      ],
      ""accentBar"": [
        {""properties"": {""show"": {""expr"": {""Literal"": {""Value"": ""true""}}}, ""width"": {""expr"": {""Literal"": {""Value"": ""4D""}}}, ""position"": {""expr"": {""Literal"": {""Value"": ""'Left'""}}}}, ""selector"": {""id"": ""default""}},
        {""properties"": {""width"": {""expr"": {""Literal"": {""Value"": ""6D""}}}}, ""selector"": {""id"": ""interaction:hover""}},
        {""properties"": {""width"": {""expr"": {""Literal"": {""Value"": ""5D""}}}}, ""selector"": {""id"": ""interaction:press""}},
        {""properties"": {""show"": {""expr"": {""Literal"": {""Value"": ""false""}}}}, ""selector"": {""id"": ""selection:selected""}},
        {""properties"": {""color"": {""solid"": {""color"": {""expr"": {""Measure"": {""Expression"": {""SourceRef"": {""Entity"": ""___K201""}}, ""Property"": ""Format Color""}}}}}}, ""selector"": {""data"": [{""dataViewWildcard"": {""matchingOption"": 1}}], ""id"": ""default"", ""hierarchyMatching"": 1}}
      ],
      ""label"": [
        {""properties"": {""show"": {""expr"": {""Literal"": {""Value"": ""false""}}}, ""fontFamily"": {""expr"": {""Literal"": {""Value"": ""'''Segoe UI Semibold'', wf_segoe-ui_semibold, helvetica, arial, sans-serif'""}}}, ""bold"": {""expr"": {""Literal"": {""Value"": ""false""}}}}, ""selector"": {""id"": ""selection:selected""}},
        {""properties"": {""field"": {""expr"": {""Literal"": {""Value"": ""''""}}}, ""fontColor"": {""solid"": {""color"": {""expr"": {""Measure"": {""Expression"": {""SourceRef"": {""Entity"": ""___K201""}}, ""Property"": ""Format Color""}}}}}}, ""selector"": {""data"": [{""dataViewWildcard"": {""matchingOption"": 1}}], ""id"": ""selection:selected"", ""hierarchyMatching"": 1}},
        {""properties"": {""show"": {""expr"": {""Literal"": {""Value"": ""false""}}}, ""fontSize"": {""expr"": {""Literal"": {""Value"": ""8D""}}}, ""fontFamily"": {""expr"": {""Literal"": {""Value"": ""'''Segoe UI'', wf_segoe-ui_normal, helvetica, arial, sans-serif'""}}}}, ""selector"": {""id"": ""default""}},
        {""properties"": {""field"": {""expr"": {""Literal"": {""Value"": ""''""}}}, ""fontColor"": {""solid"": {""color"": {""expr"": {""Measure"": {""Expression"": {""SourceRef"": {""Entity"": ""___K201""}}, ""Property"": ""Format Color""}}}}}}, ""selector"": {""data"": [{""dataViewWildcard"": {""matchingOption"": 1}}], ""id"": ""default"", ""hierarchyMatching"": 1}}
      ]
    },
    ""visualContainerObjects"": {
      ""title"": [{""properties"": {""show"": {""expr"": {""Literal"": {""Value"": ""false""}}}}}],
      ""background"": [{""properties"": {""show"": {""expr"": {""Literal"": {""Value"": ""false""}}}}}],
      ""border"": [{""properties"": {""show"": {""expr"": {""Literal"": {""Value"": ""false""}}}}}],
      ""dropShadow"": [{""properties"": {""angle"": {""expr"": {""Literal"": {""Value"": ""0L""}}}, ""shadowDistance"": {""expr"": {""Literal"": {""Value"": ""0L""}}}, ""shadowBlur"": {""expr"": {""Literal"": {""Value"": ""15L""}}}, ""shadowSpread"": {""expr"": {""Literal"": {""Value"": ""3L""}}}, ""transparency"": {""expr"": {""Literal"": {""Value"": ""70L""}}}, ""show"": {""expr"": {""Literal"": {""Value"": ""false""}}}}}]
    },
    ""drillFilterOtherVisuals"": true
  }
}";

// Format Color measure DAX template (will be replaced with user's measures)
const string FORMAT_COLOR_DAX_TEMPLATE = @"
VAR _Actual = [PLACEHOLDER_ACTUAL_MEASURE]
VAR _Target = [PLACEHOLDER_TARGET_MEASURE]
VAR _GoodColor = ""good""
VAR _BadColor = ""bad""
VAR _NeutralColor = ""midColor""

RETURN
IF ( NOT ISBLANK( _Actual ),
    IF (
        _Actual > _Target,
        _GoodColor,
        _BadColor
    ),
    _NeutralColor
)";

// ===== HELPER FUNCTIONS =====

string GeneratePBIRId()
{
    var random = new Random(Guid.NewGuid().GetHashCode());
    const string chars = "0123456789abcdef";
    return new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());
}

JObject ReadJsonFile(string path)
{
    if (!File.Exists(path)) throw new FileNotFoundException($"File not found: {path}");
    return JObject.Parse(File.ReadAllText(path));
}

void WriteJsonFile(string path, JObject data)
{
    File.WriteAllText(path, data.ToString(Newtonsoft.Json.Formatting.Indented));
}

// ===== MAIN SCRIPT =====

try
{
    // 0. Important setup instructions
    bool hasModel = Model != null;

    if (hasModel)
    {
        // Check if user is connected to PBIP or remote
        var result = MessageBox.Show(
            "IMPORTANT SETUP:\n\n" +
            "For THICK reports (with .SemanticModel folder):\n" +
            "→ Connect Tabular Editor to the PBIP FILES (not Power BI Desktop)\n" +
            "→ This ensures model changes are saved to files directly\n\n" +
            "For THIN reports (no .SemanticModel folder):\n" +
            "→ Connect Tabular Editor to the REMOTE semantic model\n" +
            "→ The script will update the model remotely\n\n" +
            "Are you connected correctly?",
            "Setup Check",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Information
        );

        if (result != DialogResult.Yes)
        {
            Error("Please reconnect Tabular Editor correctly and run again.");
            return;
        }
    }

    // 1. Select target .pbip file first
    OpenFileDialog pbipDialog = new OpenFileDialog();
    pbipDialog.Title = "Select target .pbip file";
    pbipDialog.Filter = "Power BI Project (*.pbip)|*.pbip|All Files (*.*)|*.*";

    if (pbipDialog.ShowDialog() != DialogResult.OK)
    {
        Error("No target file selected. Operation cancelled.");
        return;
    }

    string pbipPath = pbipDialog.FileName;
    FileInfo pbipFile = new FileInfo(pbipPath);
    string pbipDir = pbipFile.Directory.FullName;
    string projectName = Path.GetFileNameWithoutExtension(pbipPath);
    string targetReportDir = Path.Combine(pbipDir, $"{projectName}.Report");
    string targetModelDir = Path.Combine(pbipDir, $"{projectName}.SemanticModel");

    if (!Directory.Exists(targetReportDir))
    {
        Error($"Report folder not found: {targetReportDir}");
        return;
    }

    Info($"Target report: {targetReportDir}");

    bool hasSemanticModel = Directory.Exists(targetModelDir);
    Info($"Semantic model detected: {hasSemanticModel}");

    // 2. Get user inputs for month column and measures
    string tableName = null;
    string columnName = null;
    string actualMeasureName = null;
    string targetMeasureName = null;

    if (hasModel)
    {
        // Get columns and measures from connected model
        var columns = Model.AllColumns.Where(c => !c.IsHidden).OrderBy(c => c.DaxObjectFullName).ToList();
        var measures = Model.AllMeasures.OrderBy(m => m.DaxObjectFullName).ToList();

        if (columns.Count == 0)
        {
            Error("No columns found in model.");
            return;
        }

        if (measures.Count == 0)
        {
            Error("No measures found in model. You need at least 2 measures for conditional formatting.");
            return;
        }

        var columnNames = columns.Select(c => c.DaxObjectFullName).ToArray();
        var measureNames = measures.Select(m => m.DaxObjectFullName).ToArray();

        string selectedColumn = null;
        string selectedActualMeasure = null;
        string selectedTargetMeasure = null;

        using (var form = new Form())
        {
            form.Text = "Configure Month Button Slicer";
            form.Width = 550;
            form.Height = 400;
            form.StartPosition = FormStartPosition.CenterScreen;

            // Month column selection
            var columnLabel = new Label { Text = "Select the month column for the slicer:", Left = 10, Top = 10, Width = 520 };
            var columnListBox = new ListBox { Left = 10, Top = 35, Width = 520, Height = 80 };
            columnListBox.Items.AddRange(columnNames);

            // Actual measure selection
            var actualLabel = new Label { Text = "Select the ACTUAL measure (for 'good' when > target):", Left = 10, Top = 125, Width = 520 };
            var actualListBox = new ListBox { Left = 10, Top = 150, Width = 520, Height = 80 };
            actualListBox.Items.AddRange(measureNames);

            // Target measure selection
            var targetLabel = new Label { Text = "Select the TARGET measure (for comparison):", Left = 10, Top = 240, Width = 520 };
            var targetListBox = new ListBox { Left = 10, Top = 265, Width = 520, Height = 80 };
            targetListBox.Items.AddRange(measureNames);

            var okButton = new Button { Text = "OK", Left = 370, Top = 355, DialogResult = DialogResult.OK };
            var cancelButton = new Button { Text = "Cancel", Left = 460, Top = 355, DialogResult = DialogResult.Cancel };

            okButton.Click += (s, e) => {
                if (columnListBox.SelectedIndex >= 0)
                    selectedColumn = columnNames[columnListBox.SelectedIndex];
                if (actualListBox.SelectedIndex >= 0)
                    selectedActualMeasure = measureNames[actualListBox.SelectedIndex];
                if (targetListBox.SelectedIndex >= 0)
                    selectedTargetMeasure = measureNames[targetListBox.SelectedIndex];
            };

            form.Controls.Add(columnLabel);
            form.Controls.Add(columnListBox);
            form.Controls.Add(actualLabel);
            form.Controls.Add(actualListBox);
            form.Controls.Add(targetLabel);
            form.Controls.Add(targetListBox);
            form.Controls.Add(okButton);
            form.Controls.Add(cancelButton);
            form.AcceptButton = okButton;
            form.CancelButton = cancelButton;

            if (form.ShowDialog() != DialogResult.OK ||
                string.IsNullOrEmpty(selectedColumn) ||
                string.IsNullOrEmpty(selectedActualMeasure) ||
                string.IsNullOrEmpty(selectedTargetMeasure))
            {
                Error("Required selections not made. Operation cancelled.");
                return;
            }
        }

        var selectedCol = columns.First(c => c.DaxObjectFullName == selectedColumn);
        tableName = selectedCol.Table.Name;
        columnName = selectedCol.Name;

        actualMeasureName = selectedActualMeasure.Replace("[", "").Replace("]", "");
        targetMeasureName = selectedTargetMeasure.Replace("[", "").Replace("]", "");

        Info($"Selected Column: {tableName}[{columnName}]");
        Info($"Actual Measure: {actualMeasureName}");
        Info($"Target Measure: {targetMeasureName}");

        // 3. Add Format Color measure to ___K201 table
        var formatTable = Model.Tables.FirstOrDefault(t => t.Name == FORMAT_TABLE_NAME);

        if (formatTable == null)
        {
            Info($"Creating table '{FORMAT_TABLE_NAME}'...");
            formatTable = Model.AddTable(FORMAT_TABLE_NAME);
            var partition = formatTable.AddMPartition("Partition", $"let\n    Source = FILTER( SUMMARIZECOLUMNS( '{tableName}'[{columnName}] ), NOT ISBLANK( '{tableName}'[{columnName}] ) )\nin\n    Source");
        }

        string formatColorDAX = FORMAT_COLOR_DAX_TEMPLATE
            .Replace("PLACEHOLDER_ACTUAL_MEASURE", actualMeasureName)
            .Replace("PLACEHOLDER_TARGET_MEASURE", targetMeasureName)
            .Trim();

        var existingMeasure = formatTable.Measures.FirstOrDefault(m => m.Name == "Format Color");
        if (existingMeasure != null)
        {
            Info("Updating existing 'Format Color' measure...");
            existingMeasure.Expression = formatColorDAX;
            existingMeasure.FormatString = "General Text";
        }
        else
        {
            Info("Adding 'Format Color' measure...");
            var measure = formatTable.AddMeasure("Format Color", formatColorDAX);
            measure.FormatString = "General Text";
        }

        Info("IMPORTANT: Save the model in Tabular Editor to persist the changes!");
    }
    else
    {
        // Prompt user for table, column, and measure names
        using (var form = new Form())
        {
            form.Text = "Configure Month Button Slicer";
            form.Width = 450;
            form.Height = 280;
            form.StartPosition = FormStartPosition.CenterScreen;

            var tableLabel = new Label { Text = "Table Name:", Left = 10, Top = 10, Width = 120 };
            var tableBox = new TextBox { Left = 140, Top = 10, Width = 280, Text = "Date" };

            var columnLabel = new Label { Text = "Column Name:", Left = 10, Top = 50, Width = 120 };
            var columnBox = new TextBox { Left = 140, Top = 50, Width = 280, Text = "Month" };

            var actualLabel = new Label { Text = "ACTUAL Measure:", Left = 10, Top = 90, Width = 120 };
            var actualBox = new TextBox { Left = 140, Top = 90, Width = 280, Text = "Sales" };

            var targetLabel = new Label { Text = "TARGET Measure:", Left = 10, Top = 130, Width = 120 };
            var targetBox = new TextBox { Left = 140, Top = 130, Width = 280, Text = "Sales Target" };

            var helpLabel = new Label {
                Text = "Format Color will show 'good' when ACTUAL > TARGET",
                Left = 10, Top = 170, Width = 410,
                ForeColor = System.Drawing.Color.Gray,
                Font = new System.Drawing.Font("Segoe UI", 8)
            };

            var okButton = new Button { Text = "OK", Left = 260, Top = 205, DialogResult = DialogResult.OK };
            var cancelButton = new Button { Text = "Cancel", Left = 350, Top = 205, DialogResult = DialogResult.Cancel };

            okButton.Click += (s, e) => {
                tableName = tableBox.Text;
                columnName = columnBox.Text;
                actualMeasureName = actualBox.Text;
                targetMeasureName = targetBox.Text;
            };

            form.Controls.Add(tableLabel);
            form.Controls.Add(tableBox);
            form.Controls.Add(columnLabel);
            form.Controls.Add(columnBox);
            form.Controls.Add(actualLabel);
            form.Controls.Add(actualBox);
            form.Controls.Add(targetLabel);
            form.Controls.Add(targetBox);
            form.Controls.Add(helpLabel);
            form.Controls.Add(okButton);
            form.Controls.Add(cancelButton);
            form.AcceptButton = okButton;
            form.CancelButton = cancelButton;

            if (form.ShowDialog() != DialogResult.OK ||
                string.IsNullOrEmpty(tableName) ||
                string.IsNullOrEmpty(columnName) ||
                string.IsNullOrEmpty(actualMeasureName) ||
                string.IsNullOrEmpty(targetMeasureName))
            {
                Error("Required information not provided. Operation cancelled.");
                return;
            }
        }

        Info($"Column: {tableName}[{columnName}]");
        Info($"Actual Measure: {actualMeasureName}");
        Info($"Target Measure: {targetMeasureName}");

        // 3. Add Format Color measure to reportExtensions.json
        string reportExtensionsPath = Path.Combine(targetReportDir, "definition", "reportExtensions.json");

        JObject reportExt;
        if (File.Exists(reportExtensionsPath))
        {
            reportExt = ReadJsonFile(reportExtensionsPath);
        }
        else
        {
            reportExt = JObject.Parse(@"{
                ""$schema"": ""https://developer.microsoft.com/json-schemas/fabric/item/report/definition/reportExtension/1.0.0/schema.json"",
                ""name"": ""extension"",
                ""entities"": []
            }");
        }

        var entities = (JArray)reportExt["entities"];
        var formatEntity = entities.FirstOrDefault(e => e["name"]?.ToString() == FORMAT_TABLE_NAME);

        if (formatEntity == null)
        {
            Info($"Creating entity '{FORMAT_TABLE_NAME}' in reportExtensions...");
            formatEntity = JObject.Parse($@"{{
                ""name"": ""{FORMAT_TABLE_NAME}"",
                ""measures"": []
            }}");
            entities.Add(formatEntity);
        }

        var measures = (JArray)formatEntity["measures"];

        string formatColorDAX = FORMAT_COLOR_DAX_TEMPLATE
            .Replace("PLACEHOLDER_ACTUAL_MEASURE", actualMeasureName)
            .Replace("PLACEHOLDER_TARGET_MEASURE", targetMeasureName)
            .Trim();
        string escapedDAX = formatColorDAX.Replace("\"", "\\\"").Replace("\n", "\\n").Replace("\r", "");

        var existingMeasure = measures.FirstOrDefault(m => m["name"]?.ToString() == "Format Color");
        if (existingMeasure != null)
        {
            Info("Updating existing 'Format Color' measure in reportExtensions...");
            existingMeasure["expression"] = escapedDAX;
        }
        else
        {
            Info("Adding 'Format Color' measure to reportExtensions...");
            var newMeasure = JObject.Parse($@"{{
                ""name"": ""Format Color"",
                ""dataType"": ""Text"",
                ""expression"": ""{escapedDAX}"",
                ""formatString"": ""General Number""
            }}");
            measures.Add(newMeasure);
        }

        WriteJsonFile(reportExtensionsPath, reportExt);
        Info("reportExtensions.json updated.");
    }

    // 4. Generate IDs
    string newPageId = GeneratePBIRId();
    string newVisualId = GeneratePBIRId();

    Info($"Page ID: {newPageId}");
    Info($"Visual ID: {newVisualId}");

    // 5. Create page structure
    string pagesFolder = Path.Combine(targetReportDir, "definition", "pages");
    string pageFolder = Path.Combine(pagesFolder, newPageId);
    string visualsFolder = Path.Combine(pageFolder, "visuals");
    string visualFolder = Path.Combine(visualsFolder, newVisualId);

    Directory.CreateDirectory(visualFolder);

    // 6. Write page.json
    string pageJson = PAGE_TEMPLATE.Replace("PLACEHOLDER_PAGE_ID", newPageId);
    File.WriteAllText(Path.Combine(pageFolder, "page.json"), pageJson);

    // 7. Write visual.json with selected field
    string visualJson = VISUAL_TEMPLATE
        .Replace("PLACEHOLDER_VISUAL_ID", newVisualId)
        .Replace("PLACEHOLDER_TABLE", tableName)
        .Replace("PLACEHOLDER_COLUMN", columnName);

    File.WriteAllText(Path.Combine(visualFolder, "visual.json"), visualJson);

    // 8. Update pages.json
    string pagesJsonPath = Path.Combine(pagesFolder, "pages.json");
    var pagesData = ReadJsonFile(pagesJsonPath);
    var pageOrder = (JArray)pagesData["pageOrder"];
    pageOrder.Add(newPageId);
    WriteJsonFile(pagesJsonPath, pagesData);

    Info($"SUCCESS! Month button slicer applied!\n\nPage: '{TEMPLATE_PAGE_NAME}'\nPage ID: {newPageId}\nField: {tableName}[{columnName}]");
}
catch (Exception ex)
{
    Error($"Error: {ex.Message}\n\nStack Trace:\n{ex.StackTrace}");
}
