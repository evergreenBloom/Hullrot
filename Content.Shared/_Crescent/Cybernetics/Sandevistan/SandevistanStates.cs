// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-FileCopyrightText: 2025 Ted Lukin <66275205+pheenty@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 pheenty <fedorlukin2006@gmail.com>
//

using Robust.Shared.Serialization;

namespace Content.Shared._Crescent.Cybernetics.Sandevistan;

[Serializable, NetSerializable]
public enum SandevistanState : byte
{
    Warning = 0,
    Shaking = 1,
    Damage = 2,
    Knockdown = 3,
    Disable = 4,
    Death = 5,
}
