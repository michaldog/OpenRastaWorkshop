$(function () {
    module("OrderPreview");
    test("test new model sets default title", function () {
        var model = new OrderPreview();

        ok(model.get('title'));
    });

    module("OrderView");
    test("test render displays order title ", function () {
        var orderTitle = "title",
            order = new OrderPreview({ title: orderTitle }),
            view = new OrderView({ model: order });

        view.template = _.template('<%= title %>');

        view.render();
        
        equals($(view.el).text(), orderTitle);
    });
});