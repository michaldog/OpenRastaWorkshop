var OrderListView = Backbone.View.extend({
    events: {
        'click button': 'newOrder'
    },
    template: '#orderListTemplate',
    initialize: function () {
        _.bindAll(this, 'render', 'newOrder');
        this.template = _.template($(this.template).html());
        this.collection.bind('reset', this.render);
    },

    render: function () {
        var orders = [];
        $(this.el).html(this.template({}));
        this.collection.each(function (order) {
            orders.push(new OrderView({ model: order }).render().el);
        });
        this.$('ul').append(orders);
    },

    newOrder: function () {
        this.collection.createOrder();
    }
});