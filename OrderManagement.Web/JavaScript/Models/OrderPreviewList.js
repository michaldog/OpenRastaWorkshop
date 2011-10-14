var OrderList = Backbone.Collection.extend({
    model: OrderPreview,
    url: '/OrderManagement/orders'
});

