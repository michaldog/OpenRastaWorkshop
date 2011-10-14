var App = Backbone.Router.extend({
    masterElement: '#orderList',
    detailsElement: '#orderDetails',
    routes: {
        "": 'index',
        "order/:id": 'viewOrder'
    },

    initialize: function (orderList) {
        this.orderList = orderList;
        this.orderListView = new OrderListView({ collection: this.orderList, el: this.masterElement });
        this.orderDetailsView = new OrderDetailsView({ el: this.detailsElement });

    },

    index: function () {
        $(this.detailsElement).html($('<div class="info">').text("Choose an order on the left hand side to view order details"));
    },

    viewOrder: function (orderId) {
        var order = this.orderList.get(orderId);
        if (order) {
            this.orderDetailsView.viewOrder(order);
        } else {
            $(this.detailsElement).html($('<div class="info">').text("The current url refers to an order that does not exist"));
        }

    }
});

$(function () {
    var orderList = new OrderList();
    window.App = new App(orderList);
    orderList.fetch({ success: function () {
        Backbone.history.start();
    }
    });

});
