using FluentAssertions;
using TempoDocGenerator.Tempo;

namespace TempoDocGenerator.Tests.Tempo
{
    public class TempoNodeExtractorShould
    {
        [Fact]
        public void Extract_Nodes_FromValidTrace()
        {
            string validTrace = @"{
  ""batches"": [
    {
      ""resource"": {
        ""attributes"": [
          
          {
            ""key"": ""telemetry.sdk.name"",
            ""value"": { ""stringValue"": ""opentelemetry"" }
          },
          {
            ""key"": ""telemetry.sdk.language"",
            ""value"": { ""stringValue"": ""dotnet"" }
          },
          {
            ""key"": ""telemetry.sdk.version"",
            ""value"": { ""stringValue"": ""1.8.0"" }
          },
          { ""key"": ""app"", ""value"": { ""stringValue"": ""fake_app"" } }
        ],
        ""droppedAttributesCount"": 0
      },
      ""instrumentationLibrarySpans"": [
        {
          ""spans"": [
            {
              ""traceId"": ""527e595a85c3596aea677caa480ae44e"",
              ""spanId"": ""b032c92aaa10c00e"",
              ""parentSpanId"": ""0000000000000000"",
              ""traceState"": """",
              ""name"": ""POST api/test"",
              ""kind"": ""SPAN_KIND_SERVER"",
              ""startTimeUnixNano"": 1716922231269108200,
              ""endTimeUnixNano"": 1716922236708171800,
              ""attributes"": [
                {
                  ""key"": ""server.address"",
                  ""value"": { ""stringValue"": ""myfakeapi.com"" }
                },
                {
                  ""key"": ""http.request.method"",
                  ""value"": { ""stringValue"": ""POST"" }
                },
                { ""key"": ""url.scheme"", ""value"": { ""stringValue"": ""http"" } },
                {
                  ""key"": ""url.path"",
                  ""value"": {
                    ""stringValue"": ""/api/test""
                  }
                },
                {
                  ""key"": ""network.protocol.version"",
                  ""value"": { ""stringValue"": ""1.1"" }
                },
                {
                  ""key"": ""user_agent.original"",
                  ""value"": {
                    ""stringValue"": ""Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/125.0.0.0 Safari/537.36""
                  }
                },
                {
                  ""key"": ""http.route"",
                  ""value"": {
                    ""stringValue"": ""api/test""
                  }
                },
                {
                  ""key"": ""http.response.status_code"",
                  ""value"": { ""intValue"": 200 }
                }
              ],
              ""droppedAttributesCount"": 0,
              ""droppedEventsCount"": 0,
              ""droppedLinksCount"": 0,
              ""status"": { ""code"": 0, ""message"": """" }
            }
          ],
          ""instrumentationLibrary"": {
            ""name"": ""Microsoft.AspNetCore"",
            ""version"": """"
          }
        }
      ]
    },
    {
      ""resource"": {
        ""attributes"": [
          {
            ""key"": ""telemetry.sdk.name"",
            ""value"": { ""stringValue"": ""opentelemetry"" }
          },
          {
            ""key"": ""telemetry.sdk.language"",
            ""value"": { ""stringValue"": ""dotnet"" }
          },
          {
            ""key"": ""telemetry.sdk.version"",
            ""value"": { ""stringValue"": ""1.8.0"" }
          },
          { ""key"": ""app"", ""value"": { ""stringValue"": ""fake_app"" } }
        ],
        ""droppedAttributesCount"": 0
      },
      ""instrumentationLibrarySpans"": [
        {
          ""spans"": [
            {
              ""traceId"": ""527e595a85c3596aea677caa480ae44e"",
              ""spanId"": ""4b58da4ecc49eed3"",
              ""parentSpanId"": ""b032c92aaa10c00e"",
              ""traceState"": """",
              ""name"": ""POST"",
              ""kind"": "" "",
              ""startTimeUnixNano"": 1716922231269729300,
              ""endTimeUnixNano"": 1716922231295020300,
              ""attributes"": [
                {
                  ""key"": ""http.request.method"",
                  ""value"": { ""stringValue"": ""POST"" }
                },
                {
                  ""key"": ""server.address"",
                  ""value"": { ""stringValue"": ""authorization-api"" }
                },
                { ""key"": ""server.port"", ""value"": { ""intValue"": 80 } },
                {
                  ""key"": ""url.full"",
                  ""value"": {
                    ""stringValue"": ""http://authorization-api/connect/introspect""
                  }
                },
                {
                  ""key"": ""network.protocol.version"",
                  ""value"": { ""stringValue"": ""1.1"" }
                },
                {
                  ""key"": ""http.response.status_code"",
                  ""value"": { ""intValue"": 200 }
                },
                {
                  ""key"": ""http.host"",
                  ""value"": { ""stringValue"": ""authorization-api"" }
                },
                { ""key"": ""http.method"", ""value"": { ""stringValue"": ""POST"" } },
                {
                  ""key"": ""http.url"",
                  ""value"": {
                    ""stringValue"": ""http://authorization-api/connect/introspect""
                  }
                },
                { ""key"": ""http.status_code"", ""value"": { ""intValue"": 200 } }
              ],
              ""droppedAttributesCount"": 0,
              ""droppedEventsCount"": 0,
              ""droppedLinksCount"": 0,
              ""status"": { ""code"": 0, ""message"": """" }
            },
            {
              ""traceId"": ""527e595a85c3596aea677caa480ae44e"",
              ""spanId"": ""d0cb3afbd4beec38"",
              ""parentSpanId"": ""b032c92aaa10c00e"",
              ""traceState"": """",
              ""name"": ""FakeCommand"",
              ""kind"": ""SPAN_KIND_INTERNAL"",
              ""startTimeUnixNano"": 1716922231329338000,
              ""endTimeUnixNano"": 1716922236572023600,
              ""attributes"": [
                { ""key"": ""type"", ""value"": { ""stringValue"": ""COMMAND"" } }
              ],
              ""droppedAttributesCount"": 0,
              ""droppedEventsCount"": 0,
              ""droppedLinksCount"": 0,
              ""status"": { ""code"": 0, ""message"": """" }
            },
            {
              ""traceId"": ""527e595a85c3596aea677caa480ae44e"",
              ""spanId"": ""26886780b12a899d"",
              ""parentSpanId"": ""d0cb3afbd4beec38"",
              ""traceState"": """",
              ""name"": ""my-database"",
              ""kind"": ""SPAN_KIND_CLIENT"",
              ""startTimeUnixNano"": 1716922233915074800,
              ""endTimeUnixNano"": 1716922233917071400,
              ""attributes"": [
                { ""key"": ""db.system"", ""value"": { ""stringValue"": ""mssql"" } },
                {
                  ""key"": ""db.name"",
                  ""value"": { ""stringValue"": ""my-database"" }
                },
                {
                  ""key"": ""db.statement_type"",
                  ""value"": { ""stringValue"": ""Text"" }
                },
                {
                  ""key"": ""db.statement"",
                  ""value"": {
                    ""stringValue"": ""SELECT * FROM [dbo].[User] AS [u]\n    WHERE [u].[Id] = @__p_0\n)""
                  }
                }
              ],
              ""droppedAttributesCount"": 0,
              ""droppedEventsCount"": 0,
              ""droppedLinksCount"": 0,
              ""status"": { ""code"": 0, ""message"": """" }
            }
          ]
        }
      ]
    }
  ]
}
";

            Node rootNode = TempoNodeExtractor.Extract(validTrace);

            rootNode.Should().BeEquivalentTo(new Node()
            {
                Id = "b032c92aaa10c00e",
                Name = "POST api/test",
                Type = "server request",
                Nodes = new List<Node>()
                {
                    new Node() { Id = "4b58da4ecc49eed3", Name = "POST", Type = "client request", },
                    new Node()
                    {
                        Id = "d0cb3afbd4beec38",
                        Name = "FakeCommand",
                        Type = "command",
                        Nodes = new List<Node>()
                        {
                            new Node() { Id = "26886780b12a899d", Name = "my-database", Type = "database", },
                        }
                    },
                }

            });

        }
    }
}