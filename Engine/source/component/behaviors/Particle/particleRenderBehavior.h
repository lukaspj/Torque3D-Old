//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------
#ifndef _PARTICLE_RENDER_BEHAVIOR_H_
#define _PARTICLE_RENDER_BEHAVIOR_H_

#ifndef _BEHAVIORTEMPLATE_H_
	#include "component/behaviors/behaviorTemplate.h"
#endif
#include "particle.h"
#include <component/behaviors/Render/renderInterfaces.h>
#include "renderInstance/renderPassManager.h"

//////////////////////////////////////////////////////////////////////////
/// 
/// 
//////////////////////////////////////////////////////////////////////////
class ParticleRenderBehavior : public BehaviorTemplate
{
   typedef BehaviorTemplate Parent;

public:
   ParticleRenderBehavior();
   virtual ~ParticleRenderBehavior();
   DECLARE_CONOBJECT(ParticleRenderBehavior);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

   virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
   virtual void unpackUpdate(NetConnection *con, BitStream *stream);

   //override to pass back a ExampleBehaviorInstance
   virtual BehaviorInstance *createInstance();
};

class ParticleRenderBehaviorInstance : public BehaviorInstance
{
#if defined(TORQUE_OS_XENON)
   typedef GFXVertexPCTT ParticleVertexType;
   GFX360MemVertexBufferHandle<ParticleVertexType> mVertBuff;
#else
   typedef GFXVertexPCT ParticleVertexType;
   GFXVertexBufferHandle<ParticleVertexType> mVertBuff;
#endif
   enum PDConst
   {
      PDC_NUM_KEYS = 4,
   };

   typedef BehaviorInstance Parent;

   class renderInterface : public PrepRenderImageInterface
	{
		virtual void prepRenderImage( SceneRenderState *state )
		{
			ParticleRenderBehaviorInstance *bI = reinterpret_cast<ParticleRenderBehaviorInstance*>(getOwner());
			if(bI && bI->isEnabled())
				bI->prepRenderImage(state);
		}
	};
   
	renderInterface mRenderInterface;

public:
   ParticleRenderBehaviorInstance(BehaviorTemplate *btemplate = NULL);
   virtual ~ParticleRenderBehaviorInstance();
   DECLARE_CONOBJECT(ParticleRenderBehaviorInstance);

   virtual bool onAdd();
   virtual void onPostAdd();
   virtual void onRemove();
   static void initPersistFields();

   virtual void onBehaviorAdd();
   virtual void onBehaviorRemove();

	virtual void registerInterfaces();
	virtual void unregisterInterfaces();

   virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
   virtual void unpackUpdate(NetConnection *con, BitStream *stream);

   F32 getParticleSize(const Particle* part);
   ColorF getParticleColor(const Particle* part);
   
   virtual void prepRenderImage(SceneRenderState* scene_render_state);

   void allocPrimBuffer();
   void copyToVB( const Point3F &camPos, const ColorF &ambientColor );
   
   inline void setupBillboard( Particle *part,
                              Point3F *basePts,
                              const MatrixF &camView,
                              const ColorF &ambientColor,
                              ParticleVertexType *lVerts );

   inline void setupOriented( Particle *part,
                           const Point3F &camPos,
                           const ColorF &ambientColor,
                           ParticleVertexType *lVerts );

   inline void setupAligned(  const Particle *part, 
                           const ColorF &ambientColor,
                           ParticleVertexType *lVerts );

private:

   GFXPrimitiveBufferHandle   primBuff;
   StringTableEntry  mTextureName;
   GFXTexHandle mTextureHandle;
   MatrixF mBBObjToWorld;
   S32 mCurBuffSize;
   
   F32 mSoftnessDistance;
   Point2F mTexCoords[4];
   bool mRenderReflection;
   bool mHighResOnly;

   bool mSortParticles;
   bool mOrientParticles;
   bool mReverseOrder;
   bool mAlignParticles;
   bool mOrientOnVelocity;
   
   ParticleRenderInst::BlendStyle mBlendStyle;
   Point3F mAlignDirection;
   F32 mAmbientFactor;

   F32       mSizes[ PDC_NUM_KEYS ];
   F32       mTimes[ PDC_NUM_KEYS ];
   ColorF    mColors[ PDC_NUM_KEYS ];
};

#endif // _PARTICLE_RENDER_BEHAVIOR_H_
