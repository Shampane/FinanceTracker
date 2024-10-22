<template>
  <main class="main">
    <TransactionCardGet />
  </main>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import TransactionCardGet from './components/TransactionCardGet.vue';

export default defineComponent({
  components: {
    TransactionCardGet,
  },
});
</script>

<style scoped>
.main {
  max-width: 1200px;
  width: 100%;
  margin: auto;
}
</style>
