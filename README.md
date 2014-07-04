WebRequestor
============

A simple class for sending GET and POST HTTP requests and reading the returned response stream.

Usage
=====

To use the class simply create an instance of type WebRequestor and pass in the necessary parameters to the constructor.

WebRequestor(string Url)
WebRequestor(string Url, string method)
WebRequestor(string Url, string method, string data)

Url – The HTTP endpoint to send data to.

method – The response type. Valid values are GET and POST.

data – the data to send. This should be a string that consists of named key / value pairs e.g. “key1=value1&key2=value2”

To read the response from the request call the method GetResponse()

Example usage

WebRequestor request = new WebRequestor("http://www.myRequestDomain.com", "POST“, "key1=value1&key2=value2”);
Console.WriteLine(request.GetResponse());

An example class is included in the project. This can be found in the class file ExampleClientCode.cs


