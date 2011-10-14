$(function () {
    module("Order");
    test("test model without id has baseUri as url", function () {
        var model = new Order({ id: null });
        model.baseUri = 'testUri/';

        equal(model.url(), model.baseUri);
    });
    
    test("test model with id has baseUri/id as url", function () {
        var model = new Order({ id: 4 });
        model.baseUri = 'testUri/';

        equal(model.url(), model.baseUri+4);
    });

});