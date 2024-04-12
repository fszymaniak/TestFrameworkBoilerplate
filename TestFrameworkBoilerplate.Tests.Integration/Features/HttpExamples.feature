Feature: HttpExamples
Simple Http Examples

    @HttpExample
    @GetAll
    Scenario: Validate response from getEndpointExample endpoint
        Given the HTTP 'GET' to the endpoint '/getEndpointExample' is being send
        Then the result match expected json 'GetExampleJson.json' and status code '200'
    
    @HttpExample
    @GetSingle
    Scenario: Validate response from getEndpointExample endpoint with single object
        Given the HTTP 'GET' to the endpoint '/getEndpointExample/136acb7d-b90f-4203-b705-7b9ace1aba33' is being send
        Then the result match expected json 'GetSingleExampleJson.json' and status code '200'
        
    @HttpExample
    @Post
    Scenario: Send request and validate response from postEndpointExample endpoint
        Given the HTTP 'POST' to the endpoint '/postEndpointExample' is being send
        Then the result match expected json 'PostExampleResponseJson.json' and status code '201'
        