Feature: HttpExamples
Simple Http Examples

    @HttpExample
    @Get
    Scenario: Validate response from getEndpointExample endpoint
        Given the HTTP 'GET' to the endpoint '/getEndpointExample' is being send
        Then the result match expected json 'ExampleJsons\\GetExampleJson.json' and status code '200'
        
    @HttpExample
    @Post
    Scenario: Send request and validate response from postEndpointExample endpoint
        Given the HTTP 'POST' to the endpoint '/postEndpointExample' is being send
        Then the result match expected json 'ExampleJsons\\PostExampleResponseJson.json' and status code '201'
        