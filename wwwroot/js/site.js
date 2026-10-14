(function(){
  function formatNow(){
    const now=new Date();
    const t=document.getElementById('clockTime');
    const d=document.getElementById('clockDate');
    if(t) t.textContent=now.toLocaleTimeString('es-HN',{hour:'2-digit',minute:'2-digit'});
    if(d) d.textContent=now.toLocaleDateString('es-HN',{day:'2-digit',month:'short',year:'numeric'});
    const s=document.getElementById('summaryDate');
    if(s) s.textContent=now.toLocaleString('es-HN',{day:'2-digit',month:'short',year:'numeric',hour:'2-digit',minute:'2-digit'});
  }
  formatNow(); setInterval(formatNow,30000);

  const plate=document.getElementById('plateInput');
  const summaryPlate=document.getElementById('summaryPlate');
  if(plate&&summaryPlate){
    const syncPlate=()=>{plate.value=plate.value.toUpperCase();summaryPlate.textContent=plate.value.trim()||'—';};
    plate.addEventListener('input',syncPlate); syncPlate();
  }

  const typeInput=document.getElementById('vehicleType');
  const sType=document.getElementById('summaryType');
  const sPrice=document.getElementById('summaryPrice');
  document.querySelectorAll('.vehicle-option').forEach(btn=>{
    btn.addEventListener('click',()=>{
      document.querySelectorAll('.vehicle-option').forEach(x=>x.classList.remove('selected'));
      btn.classList.add('selected');
      if(typeInput) typeInput.value=btn.dataset.type;
      if(sType) sType.textContent=btn.dataset.type;
      if(sPrice) sPrice.textContent='L '+Number(btn.dataset.price).toFixed(2);
    });
  });

  const paymentInput=document.getElementById('paymentMethod');
  const cardFields=document.getElementById('cardFields');
  document.querySelectorAll('.payment-option').forEach(btn=>{
    btn.addEventListener('click',()=>{
      document.querySelectorAll('.payment-option').forEach(x=>x.classList.remove('selected'));
      btn.classList.add('selected');
      if(paymentInput) paymentInput.value=btn.dataset.payment;
      if(cardFields) cardFields.style.display=btn.dataset.payment==='Tarjeta de crédito/débito'?'grid':'none';
    });
  });
})();
