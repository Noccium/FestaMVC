var lg = {festa:{frontend:{festa:{}}}}

lg.festa.frontend.festa.edit = function($el) {
    if(!$el) {
        throw("Element invalid!")
    }

    this.$el = $el
    this.db = new Store("festas")

    this.init()
}

lg.festa.frontend.festa.edit.prototype = {
    init: function() {
        this.$elCadastrar = this.$el[0].parentElement.querySelector("#botaoCadastrar")

        this.$elId = this.$el[0].parentElement.querySelector("div#campoId>input")
        this.$elNome = this.$el[0].parentElement.querySelector("div#campoNome>input")
        this.$elData = this.$el[0].parentElement.querySelector("div#campoData>input")
        this.$elValorDoIngresso = this.$el[0].parentElement.querySelector("div#campoValorDoIngresso>input")

        var possuiParametrosQueryString = location.search ? true : false

        if(possuiParametrosQueryString) {
            this.carregueCampos()
        }

        this.ligueEventos()
    },
    carregueCampos: function() {
        var props = window.location.search.replace("?", "").split("&")

        var dadoLocal = props.reduce(function(map, x) {
            var keyValuePair = x.split("=")

            map[keyValuePair[0]] = keyValuePair[1]

            return map; 
        }, {});

        this.$elId.value = dadoLocal.id;

        var ehNovo = Number(dadoLocal.id) === 0;

        if(!ehNovo) {
            var item = this.db.getItemById(dadoLocal.id)

            this.$elNome.value = item.nome
            this.$elData.value = item.data
            this.$elValorDoIngresso.value = item.valorDoIngresso
        }

        this.$elId.disabled = true
        this.$elId.readOnly = true

        this.$elNome.focus()
    },
    ligueEventos: function() {
        var _this = this // Pesquisem: bind

        this.$elCadastrar.addEventListener("click", function() {
            _this.salve()
        })
    },
    salve: function() {
        var festa = {
            id: parseInt(this.$elId.value),
            nome: this.$elNome.value,
            data: this.$elData.value,
            valorDoIngresso: this.$elValorDoIngresso.value,
            totalDeConvidados: 0
        }

        this.valide(festa)

        this.db.save(festa, function(item) {
            item.id = festa.id
            item.nome = festa.nome
            item.data = festa.data
            item.valorDoIngresso = festa.valorDoIngresso
            item.totalDeConvidados = festa.totalDeConvidados
        })
    },
    valide: function(festa) {

    }
}