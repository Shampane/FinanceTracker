<template>
  <div class="cards">
    <GetCard />
    <RemoveCard />
  </div>
</template>

<script setup lang="ts">
import GetCard from './getTransaction/views/TransactionGetCard.vue';
import RemoveCard from './removeTransaction/views/TransactionRemoveCard.vue';
</script>

<style lang="css" scoped>
.cards {
  display: grid;
  grid-template-columns: 1fr;
  row-gap: calc(1vh + 32px);
}
</style>
