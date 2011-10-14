var OrderView = Backbone.View.extend({
    tagName: 'li',
    template: '#orderTemplate',
    events: {
        'click div': 'navigate',
        'click button': 'deleteOrder'
    },

    initialize: function () {
        _.bindAll(this, 'render', 'navigate', 'deleteOrder');
        this.template = _.template($(this.template).html());
    },
    render: function () {
        $(this.el).html(this.template({ title: this.model.getTitle() }));
        return this;
    },

    navigate: function () {
        App.navigate('order/' + this.model.get('id'), true);
    },

    deleteOrder: function () {
        var that = this;
        var orderDetails = new Order({ id: this.model.get('id') });
        orderDetails.destroy({ success: function () {
            that.model.collection.fetch();
        }
        });
        return false;
    }
});