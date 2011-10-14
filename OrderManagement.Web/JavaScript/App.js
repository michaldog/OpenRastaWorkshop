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
    },

    index: function () {
    },

    viewOrder: function (orderId) {
    }
});

$(function () {
    // Initialize the order list, and register as global for ease of debugging
    window.Orders = new OrderList();
    
    // Start app
    window.App = new App(window.Orders);
    
    //Initialize routing
    Backbone.history.start();
});
