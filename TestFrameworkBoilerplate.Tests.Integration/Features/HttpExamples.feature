﻿Feature: HttpExamples
Simple Http Examples

    @HttpExample
    Scenario: Validate response from getEndpointExample endpoint
        Given the HTTP 'GET' to the endpoint '/getEndpointExample' is being send
        Then the result should be 'getEndpointExample working fine!'