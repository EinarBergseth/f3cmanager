import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { ManouverDTO } from '../types'

export const manouversApi = createApi({
    reducerPath: 'manouvers',
    baseQuery: fetchBaseQuery({
        baseUrl: '/api/manouvers',
        prepareHeaders(headers) {
            headers.set(
                'Authorization',
                'Bearer ' + 'accessToken'
            )

            return headers
        },
    }),
    tagTypes: ['ManouverDTO'],
    endpoints: (builder) => ({
        fetchManouvers: builder.query<ManouverDTO[], void>({
            query: () => '',
            providesTags: ['ManouverDTO'],
        }),
    }),
})

export const {
    useFetchManouversQuery,
} = manouversApi