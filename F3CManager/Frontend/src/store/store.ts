import { configureStore } from '@reduxjs/toolkit'
import { manouversApi } from '../features/manouvers'
import { eventApi } from '../features/events'

const store = configureStore({
    reducer: {
      //RTK Query reducers in alphabetical order:
      [eventApi.reducerPath]: eventApi.reducer,
      [manouversApi.reducerPath]: manouversApi.reducer,

      //RTK Slice reducers in alphabetical order:
    },
        // Adding the api middleware enables caching, invalidation, polling,
        // and other useful features of `rtk-query`.
        middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware({
            immutableCheck: false,
            serializableCheck: false,
        })
        //RTK Query middleware in alphabetical order:
        .concat(eventApi.middleware)
        .concat(manouversApi.middleware)
})

export type AppDispatch = typeof store.dispatch
export type RootState = ReturnType<typeof store.getState>

export default store