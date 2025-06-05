<template>
  <div class="background secondary">
    <NuxtPage />
    <ContactSection />
  </div>
</template>
<style lang="scss">
@import "./assets/css/variables.css";
.primary {
  color: var(--color-green-400);
}
.secondary {
  color: var(--color-green-100);
}
.background {
  background-color: var(--color-neutral-900);
}
</style>
