const Config = () => {
    const { environment } = require(`./${process.env.NODE_ENV || 'development'}`)

    return {
        api: {
            baseUrl: environment.api.baseurl
        }
    }
}

export default Config();