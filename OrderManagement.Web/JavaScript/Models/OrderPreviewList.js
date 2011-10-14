var OrderList = Backbone.Collection.extend({
    model: OrderPreview,
    url: '/OrderManagement/orders',

    createOrder: function () {
        var that = this;
        var order = new Order();
        order.bind('change', function () {
            that.fetch();
            order.unbind();
        });
        order.save();
    }
});

