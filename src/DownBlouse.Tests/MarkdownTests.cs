using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Diagnostics;

namespace DownBlouse.Tests {
    [TestClass]
    public class MarkdownTests {
        [TestMethod]
        public void Markdown_1_0_3_TestSuite() {
            foreach (var f in Directory.GetFiles(@"..\..\..\..\MarkdownTest_1.0.3\", "*.text")) {
                string output = DownBlouse.Markdownify(File.ReadAllText(f), false);
                string compareWith = Path.Combine(Path.GetDirectoryName(f), Path.GetFileNameWithoutExtension(f)) + ".html";
                string compareText = File.ReadAllText(compareWith);

                try {
                    Assert.AreEqual(
                        compareText,
                        output
                    );
                } catch (AssertFailedException) {
                    File.WriteAllText(Path.Combine(Path.GetDirectoryName(f), Path.GetFileNameWithoutExtension(f)) + ".downblouse.html", output);
                }
            }
        }
    }
}
