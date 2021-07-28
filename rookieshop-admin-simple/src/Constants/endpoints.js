const Endpoints = {
    authorize: 'api/authorize',
    me: 'api/authorize/me',
    
    brand: '/api/brands',
    brandId: (id) => `api/brands/${id}`,

    category: '/api/Categories',
    categoryId: (id) => `/api/Categories/${id}`,

};

export default Endpoints;
