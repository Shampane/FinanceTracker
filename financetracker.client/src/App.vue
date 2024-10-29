<template>
  <main class="main">
    <TransactionPage />
  </main>
</template>

<script setup lang="ts">
import TransactionPage from './pages/transaction/TransactionPage.vue';
</script>

<style scoped>
.main {
  max-width: 1200px;
  width: 100%;
  margin: auto;
}
</style>
