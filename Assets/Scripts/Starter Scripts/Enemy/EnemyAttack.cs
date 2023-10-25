using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

	[Header("Enemy Weapon")]
	[Tooltip("This is the current weapon that the enemy is using")]
	public Damager weapon;

	[Header("Parameters")]

	public bool showAttackRadius = false;
	public float attackRadius = 5f;
	[Tooltip("The coolDown before you can attack again")]
	public float coolDown = 0.5f;
	private bool canAttack = true;

	public bool disabled = false;
	private bool disabledColorSet = false;

	private void Update()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRadius);
		foreach (Collider2D other in colliders)
		{
			if (canAttack && other.CompareTag("Player"))
			{
				Attack(other.transform.position - this.transform.position);
			}
		}
		if (disabled && !disabledColorSet) {
			disabledColorSet = true;
			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
			Color originalColor = spriteRenderer.color;
			float tintIntensity = 0.5f;
			Color tintedColor = new Color(
                originalColor.r * tintIntensity,
                originalColor.g * tintIntensity,
                originalColor.b * tintIntensity,
                originalColor.a
            );

            spriteRenderer.color = tintedColor;

		}
	}

	public void Attack(Vector2 attackDir)
	{
		//This is where the weapon is rotated in the right direction that you are facing
		if (weapon && canAttack && !disabled)
		{
			if (weapon is ProjectileWeapon)
				weapon.WeaponStart(this.transform, attackDir, Vector2.zero);
			else
				weapon.WeaponStart(this.transform, attackDir);

			// MouseTraps become disabled
			StartCoroutine(CoolDown());
		}
	}

	public void StopAttack()
	{
		if (weapon)
		{
			weapon.WeaponFinished();
		}
	}

	private IEnumerator CoolDown()
	{
		canAttack = false;
		yield return new WaitForSeconds(coolDown);
		if (this.tag == "MouseTrap") {
			disabled = true;
		}
		canAttack = true;
	}

	private void OnDrawGizmos()
	{
		if (showAttackRadius)
			Gizmos.DrawWireSphere(transform.position, attackRadius);
	}
}
