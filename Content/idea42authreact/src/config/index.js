const Config = () => {
    const { environment } = require(`./env/${process.env.NODE_ENV || 'development'}`)

    return {
        api: {
            baseUrl: environment.api.baseUrl
        },
        loginRoute: environment.loginRoute
    }
}

export default Config();