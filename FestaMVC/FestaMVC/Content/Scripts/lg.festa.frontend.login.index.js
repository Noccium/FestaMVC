var lg = {festa:{frontend:{login:{}}}}

lg.festa.frontend.login.index = function($el) {
    this.$el = $el;
    
    this.init()
}


lg.festa.frontend.login.index.prototype= {
    init: function() {
        this.$elBotao =  this.$el[0].parentElement.querySelector('div>div#botao')

        this.ligaEventos()
    },
    ligaEventos: function() {
        this.$elBotao.addEventListener("click", function() {
            //windows.location.href = ""
           window.location.replace("/home/index.html");
        })
    }
}