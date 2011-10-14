var OrderListView = Backbone.View.extend({
    template: '#orderListTemplate',
    initialize: function () {
        _.bindAll(this, 'render');
        this.template = _.template($(this.template).html());
        this.collection.bind('add', this.render);
        this.collection.bind('remove', this.render);
        this.collection.bind('reset', this.render);
    },

    render: function () {
        var orders = [];
        $(this.el).html(this.template({}));
        this.collection.each(function (order) {
            orders.push(new OrderView({ model: order }).render().el);
        });
        this.$('ul').append(orders);
    }
});