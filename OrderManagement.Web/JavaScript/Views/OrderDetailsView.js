var OrderDetailsView = Backbone.View.extend({
    template: "#orderDetailsTemplate",
    events: {
        'submit': 'saveOrder'
    },

    initialize: function () {
        _.bindAll(this, 'render', 'saveOrder');
        this.template = _.template($(this.template).html());
    },

    render: function () {
        $(this.el).html(this.template(this.model.toJSON()));
        return this;
    },

    viewOrder: function (orderPreview) {
        if (this.model) {
            this.model.unbind('change', this.render);
        }
        var orderDetails = new Order({ id: orderPreview.get('id') });
        this.model = orderDetails;
        this.model.bind('change', this.render);
        this.model.fetch();
        this.orderPreview = orderPreview;
    },

    saveOrder: function () {
        var that = this,
            reference = this.$('#reference').val(),
            customer = this.$('#customer').val(),
            details = this.$('#details').val();

        this.model.save({
            reference: reference,
            customer: customer,
            details: details
        }, { success: function () {
            that.orderPreview.collection.fetch();
        }
        });
        App.navigate('', true);
        return false;
    }
});