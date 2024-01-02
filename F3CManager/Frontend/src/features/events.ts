import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { EventDTO } from '../types'

export const eventApi = createApi({
    reducerPath: 'events',
    baseQuery: fetchBaseQuery({
        baseUrl: '/api/events',
        prepareHeaders(headers) {
            headers.set(
                'Authorization',
                'Bearer ' + 'accessToken'
            )

            return headers
        },
    }),
    tagTypes: ['EventDTO'],
    endpoints: (builder) => ({
        fetchEvents: builder.query<EventDTO[], void>({
            query: () => '',
            providesTags: ['EventDTO'],
        }),
    }),
})

export const {
    useFetchEventsQuery,
} = eventApi